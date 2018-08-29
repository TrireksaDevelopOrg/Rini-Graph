using Penjadwalan.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Penjadwalan.Domains
{
    internal class JadwalDomain
    {
        public JadwalDomain()
        {
        }

        internal List<perawat> GetJadwal(int id)
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var periode = db.Periode.Where(O => O.idperiode == id).FirstOrDefault();
                    if (periode == null)
                        throw new SystemException("Periode Tidak Ditemukan");
                    else
                    {
                        var results = db.Perawat.Select().ToList();
                        foreach (var item in results)
                        {
                            item.Jadwals = db.Jadwal.Where(O => O.IdPeriode == id && O.IdPerawat==item.IdPerawat).ToList();
                        }

                        return results;
                    }
                }
                catch (Exception ex)
                {
                    throw new SystemException(ex.Message);
                }
            }
        }

        internal List<periode> GetPeriode()
        {
            using (var db = new OcphDbContext())
            {
                var result = db.Periode.Select();
                return result.ToList();
            }
        }
    }
}