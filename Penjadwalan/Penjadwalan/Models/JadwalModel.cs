using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Penjadwalan.Models
{
    public class JadwalModel
    {
        public periode Periode { get; set; }
        public List<perawat> Jadwals { get; set; }
    }
}