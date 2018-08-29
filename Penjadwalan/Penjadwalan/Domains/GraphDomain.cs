using Penjadwalan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Penjadwalan.Domains
{
    public class GraphDomain
    {
        public bool CreateNewPeriode(Data data)
        {

            using (var db = new OcphDbContext())
            {
                var trans = db.BeginTransaction();
                try
                {
                    var id = db.Periode.InsertAndGetLastID(data.Periode);
                    if(id>0)
                    {
                        foreach(var item in data.Adges)
                        {
                            item.IdPeriode = id;
                             item.Id= db.Matrix.InsertAndGetLastID(item);
                            if (item.Id <= 0)
                                throw new SystemException("Data Tidak Tersimpan");
                        }

                        trans.Commit();
                        return true;
                    }

                    throw new SystemException("Data Tidak Tersipan");



                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new SystemException(ex.Message);
                }
            }
        }

        internal bool SaveJadwal(JadwalModel data)
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var periodId = db.Periode.InsertAndGetLastID(data.Periode);
                    if(periodId>0)
                    {
                        foreach(var item in data.Jadwals)
                        {
                            foreach(var date in item.Dates)
                            {
                                var jad = new jadwal { IdPeriode = periodId, Tanggal = date.Date, Shif = date.Value, IdPerawat = item.IdPerawat };
                                if (!db.Jadwal.Insert(jad))
                                    throw new SystemException("Data Gagal Disimpan");
                            }
                           
                        }
                        return true;
                    }else
                        throw new SystemException("Data Gagal Disimpan");
                }
                catch (Exception ex)
                {

                    throw new SystemException(ex.Message);
                }
            }
        }

        internal Data GetLastPeriod()
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var period = db.Periode.GetLastItem();
                    if (period != null)
                    {
                        var mats = from a in db.Matrix.Where(O => O.IdPeriode == period.idperiode)
                                   select new Adge { Baris = a.Baris, Id = a.Id, IdPeriode = a.IdPeriode, Kolom = a.Kolom, Nama = a.Nama, Nilai = a.Nilai };
                        var data = new Data { Periode = period, Adges = mats.ToList() };
                        return data;
                    }
                    else
                    {
                        return new Data();
                    }
                }
                catch (Exception ex)
                {

                    throw new SystemException(ex.Message);
                }
            }
        }

        internal Data GetDataByPeriodeId(int id)
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var period = db.Periode.Where(O => O.idperiode == id).FirstOrDefault();
                    if(period!=null)
                    {
                        var mats = from a in db.Matrix.Where(O => O.IdPeriode == id)
                                   select new Adge {  Baris = a.Baris, Id = a.Id, IdPeriode = a.IdPeriode, Kolom = a.Kolom, Nama = a.Nama, Nilai = a.Nilai };
                        var data = new Data { Periode = period, Adges = mats.ToList() };
                        return data;
                    }
                    else
                    {
                        throw new SystemException("Data Periode Tidak Ditemukan");
                    }
                }
                catch (Exception ex)
                {

                    throw new SystemException(ex.Message);
                }
            }
        }


    }
}