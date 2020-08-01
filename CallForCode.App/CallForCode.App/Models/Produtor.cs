using System;
using System.Collections.Generic;
using System.Text;

namespace CallForCode.App.Models
{
    public class Produtor
    {
        public static Produtor Empty;

        public string _id { get; set; }
        public string _rev { get; set; }
        public string nome { get; set; }
        public string contato { get; set; }
        public string tipoproduto { get; set; }
        public string[] materiaprima { get; set; }
        public string status { get; set; }
        public string imagem { get; set; }
        public string url { get; set; }
    }

    public class FindProdutor
    {
        public Produtor[] docs { get; set; }
    }
}
