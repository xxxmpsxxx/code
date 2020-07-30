using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallForCode.Model
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
    }

    public class FindProdutor
    {
        public Produtor[] docs { get; set; }
    }
}
