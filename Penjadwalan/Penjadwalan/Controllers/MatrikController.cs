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
        public Data Get()
        {
            return GetData();
        }

        private Data GetData()
        {
            Data d = new Data();
            d.Nodes = GetNodes();
            return d;
        }

        private List<Node> GetNodes()
        {
            var list = new List<Node>();
            list.Add(new Node() { id = 1, label = "Senin Pagi", shape="Oval" , font=new font { color="white" }, color=new color {  background="red" } });
            list.Add(new Node() { id = 2, label = "Senin Malam", shape = "Oval", font = new font { color = "white" }, color = new color { background = "green" } });
            list.Add(new Node() { id = 3, label = "Selasa Pagi", shape = "Oval", font = new font { color = "white" }, color = new color { background = "#ce6c24" } });
            list.Add(new Node() { id = 4, label = "Selasa Malam", shape = "Oval", font = new font { color = "white" }, color = new color { background = "red" } });
            list.Add(new Node() { id = 5, label = "Rabu Pagi", shape = "Oval", font = new font { color = "white" }, color = new color { background = "green" } });
            list.Add(new Node() { id = 6, label = "Rabu Malam", shape = "Oval", font = new font { color = "white" }, color = new color { background = "#ce6c24" } });
            list.Add(new Node() { id = 7, label = "Kamis Pagi", shape = "Oval", font = new font { color = "white" }, color = new color { background = "red" } });
            list.Add(new Node() { id = 8, label = "Kamis Malam", shape = "Oval", font = new font { color = "white" }, color = new color { background = "green" } });
            list.Add(new Node() { id = 9, label = "Jumat Pagi", shape = "Oval", font = new font { color = "white" }, color = new color { background = "#ce6c24" } });
            list.Add(new Node() { id = 10, label = "Jumat Malam", shape = "Oval", font = new font { color = "white" }, color = new color { background = "red" } });
            list.Add(new Node() { id = 11, label = "Sabtu Pagi", shape = "Oval", font = new font { color = "white" }, color = new color { background = "green" } });
            list.Add(new Node() { id = 12, label = "Sabtu Malam", shape = "Oval", font = new font { color = "white" }, color = new color { background = "#ce6c24" } });
            list.Add(new Node() { id = 13, label = "Minggu Pagi", shape = "Oval", font = new font { color = "white" }, color = new color { background = "red" } });
            list.Add(new Node() { id = 14, label = "Minggu Malam", shape = "Oval", font = new font { color = "white" }, color = new color { background = "green" } });

            return list;

        }
    }
}
