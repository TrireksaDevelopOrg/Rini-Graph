using Penjadwalan.Domains;
using Penjadwalan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Penjadwalan.Controllers
{
    public class MatrikController : ApiController
    {
        private GraphDomain domain = new GraphDomain();

      
        public IHttpActionResult Get()
        {

            return Ok(GetData());
        }



        public IHttpActionResult Get(int id)
        {
            var result= domain.GetDataByPeriodeId(id);
            return Ok(result);
        }

        public IHttpActionResult Post(JadwalModel data)
        {
            try
            {
                var result = domain.SaveJadwal(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        private Data GetData()
        {
            Data d = new Data();
            d.Adges = GetEdges();
            d.Nodes = GetNodes();
            return d;
        }

        private List<Adge> GetEdges()
        {
            var edges = new List<Adge>() {
                    new Adge{ Baris=1, Kolom=2, Nilai=1 },
                    new Adge{ Baris=2, Kolom=3, Nilai=1 },
                    new Adge{ Baris=3, Kolom=4, Nilai=1 },
                    new Adge{ Baris=4, Kolom=5 , Nilai=1},
                    new Adge{ Baris=5, Kolom=6, Nilai=1 },
                    new Adge{ Baris=6, Kolom=7, Nilai=1 },
                    new Adge{ Baris=7, Kolom=8 , Nilai=1},
                    new Adge{ Baris=8, Kolom=9, Nilai=1 },
                    new Adge{ Baris=9, Kolom=10 , Nilai=1},
                    new Adge{ Baris=10, Kolom=11 , Nilai=1},
                    new Adge{ Baris=11, Kolom=12 , Nilai=1},
                    new Adge{ Baris=12, Kolom=13 , Nilai=1},
                    new Adge{ Baris=13, Kolom=14 , Nilai=1},
                    new Adge{ Baris=14, Kolom=1 , Nilai=1},
            };

            return edges;
        }

        private List<Node> GetNodes()
        {
            var list = new List<Node>();
            list.Add(new Node() { id = 1, label = "Senin Pagi" , Day=1,IsMoorning=true});
            list.Add(new Node() { id = 2, label = "Senin Malam" , Day = 1, IsMoorning = false});
            list.Add(new Node() { id = 3, label = "Selasa Pagi" , Day = 2, IsMoorning = true});
            list.Add(new Node() { id = 4, label = "Selasa Malam", Day = 2, IsMoorning = false});
            list.Add(new Node() { id = 5, label = "Rabu Pagi" , Day = 3, IsMoorning = true});
            list.Add(new Node() { id = 6, label = "Rabu Malam" , Day = 3, IsMoorning = false});
            list.Add(new Node() { id = 7, label = "Kamis Pagi", Day = 4, IsMoorning = true});
            list.Add(new Node() { id = 8, label = "Kamis Malam" , Day = 4, IsMoorning = false});
            list.Add(new Node() { id = 9, label = "Jumat Pagi" , Day = 5, IsMoorning = true});
            list.Add(new Node() { id = 10, label = "Jumat Malam", Day = 5, IsMoorning = false});
            list.Add(new Node() { id = 11, label = "Sabtu Pagi" , Day = 6, IsMoorning = true});
            list.Add(new Node() { id = 12, label = "Sabtu Malam" , Day = 6, IsMoorning = false});
            list.Add(new Node() { id = 13, label = "Minggu Pagi", Day = 0, IsMoorning = true});
            list.Add(new Node() { id = 14, label = "Minggu Malam" , Day = 0, IsMoorning = false});

            return list;

        }
    }
}
