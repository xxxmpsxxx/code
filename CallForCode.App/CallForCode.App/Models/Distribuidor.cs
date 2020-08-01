using System;
using System.Collections.Generic;
using System.Text;

namespace CallForCode.App.Models
{
    public class Distribuidor
    {
        public static Distribuidor Empty;
        public string _id { get; set; }
        public string _rev { get; set; }
        public string nome { get; set; }
        public string contato { get; set; }
        public string tipotransporte { get; set; }
        public string[] equipamentos { get; set; }
        public string[] produto { get; set; }
        public string status { get; set; }
        public string imagem { get; set; }
        public string url { get; set; }
    }

    public class FindDistribuidor
    {
        public Distribuidor[] docs { get; set; }
    }
}
