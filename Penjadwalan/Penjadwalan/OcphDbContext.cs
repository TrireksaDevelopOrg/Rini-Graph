using Ocph.DAL.Repository;
using Penjadwalan.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Penjadwalan
{
    public class OcphDbContext:Ocph.DAL.Provider.MySql.MySqlDbConnection
    {
        public OcphDbContext()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }


        public IRepository<perawat> Perawat { get { return new Repository<perawat>(this); } }
        public IRepository<jadwal> Jadwal { get { return new Repository<jadwal>(this); } }
        public IRepository<matrix> Matrix { get { return new Repository<matrix>(this); } }
        public IRepository<periode> Periode{ get { return new Repository<periode>(this); } }

    }
}