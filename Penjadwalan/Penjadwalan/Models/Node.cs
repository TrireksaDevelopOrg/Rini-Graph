using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Penjadwalan.Models
{
    public class Node
    {
        public int id { get; set; }

        public string label { get; set; }
        public string shape { get; set; }
        public color color { get; set; }
        public font font { get; set; }

    }


    public class Data
    {
        public List<Node> Nodes { get; set; }
        public List<Adge> Adges { get; set; }
        public periode Periode { get; set; }
    }


    public class Adge:matrix
    {
        public string label { get; set; }
        public string arrows { get; set; }
    }

    public class color
    {
        public string background { get; set; }
        public string border { get; set; }
    }


    public class font
    {
        public string color { get; set; }
    }
}