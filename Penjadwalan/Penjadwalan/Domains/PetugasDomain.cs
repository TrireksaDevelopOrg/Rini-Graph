using Penjadwalan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Penjadwalan.Domains
{
    public class PetugasDomain
    {
        public Task<perawat> SaveChange(perawat item)
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    if(item.IdPerawat<=0)
                    {
                        item.IdPerawat = db.Perawat.InsertAndGetLastID(item);
                        if (item.IdPerawat <= 0)
                        {
                            throw new SystemException("Data Tidak Tersimpan");
                        }
                    }else
                    {
                        if (!db.Perawat.Update(O => new { O.Alamat, O.Gender, O.Golongan, O.Nama, O.NIP }, item, O => O.IdPerawat == item.IdPerawat))
                            throw new SystemException("Data Tidak Tersimpan");
                    }
                    return Task.FromResult(item);
                }
                catch (Exception ex)
                {
                    throw new SystemException(ex.Message);
                }

            }
        }

        public Task<bool> DeletePerawat(int id)
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    if (!db.Perawat.Delete(O => O.IdPerawat == id))
                    {
                        throw new SystemException("Data Tidak Terhapus");
                    }

                    return Task.FromResult(true);
                }
                catch (Exception ex)
                {
                    throw new SystemException(ex.Message);
                }
            }
        }


        public Task<List<perawat>> GetPerawat()
        {
            using (var db = new OcphDbContext())
            {
                var result = from a in db.Perawat.Select()
                             select a;
                return Task.FromResult(result.ToList());
            }
        }


        public Task<perawat> GetPerawatById(int id)
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var result = db.Perawat.Where(O => O.IdPerawat == id).FirstOrDefault();
                    if (result != null)
                        return Task.FromResult(result);
                    throw new SystemException("Data Tidak Ditemukan");
                }
                catch (Exception ex)
                {
                    throw new SystemException(ex.Message);
                }
            }
        }

    }
}