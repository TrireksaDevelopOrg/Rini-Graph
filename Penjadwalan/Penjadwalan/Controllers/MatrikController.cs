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

        [HttpGet]
        [Route("api/matrik/Last")]
        public IHttpActionResult GetLast()
        {
            var result = domain.GetLastPeriod();
            result.Nodes = GetNodes();
            return Ok(result);
        }


        public IHttpActionResult Post(Data data)
        {
            var result=domain.CreateNewPeriode(data);
            return Ok(result);
        }

        private Data GetData()
        {
            Data d = new Data();
            d.Periode = new periode { idperiode = 1, TanggalAkhir = DateTime.Now, TanggalMulai = DateTime.Now };
            d.Adges = GetEdges(d.Periode.idperiode);
            d.Nodes = GetNodes();
            return d;
        }

        private List<Adge> GetEdges(int idperiode)
        {
            var edges = new List<Adge>() {
   


            };

            return edges;
        }

        private List<Node> GetNodes()
        {
            var list = new List<Node>();
            list.Add(new Node() { id = 1, label = "Senin Pagi" });
            list.Add(new Node() { id = 2, label = "Senin Malam" });
            list.Add(new Node() { id = 3, label = "Selasa Pagi" });
            list.Add(new Node() { id = 4, label = "Selasa Malam"});
            list.Add(new Node() { id = 5, label = "Rabu Pagi" });
            list.Add(new Node() { id = 6, label = "Rabu Malam" });
            list.Add(new Node() { id = 7, label = "Kamis Pagi"});
            list.Add(new Node() { id = 8, label = "Kamis Malam" });
            list.Add(new Node() { id = 9, label = "Jumat Pagi" });
            list.Add(new Node() { id = 10, label = "Jumat Malam"});
            list.Add(new Node() { id = 11, label = "Sabtu Pagi" });
            list.Add(new Node() { id = 12, label = "Sabtu Malam" });
            list.Add(new Node() { id = 13, label = "Minggu Pagi"});
            list.Add(new Node() { id = 14, label = "Minggu Malam" });

            return list;

        }
    }
}
