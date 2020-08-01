using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallForCode.Model
{
    public class Beneficiador
    {
        public static Beneficiador Empty;

        public string _id { get; set; }
        public string _rev { get; set; }
        public string nome { get; set; }
        public string contato { get; set; }
        public string tipoproduto { get; set; }
        public string[] materiaprima { get; set; }
        public string[] produto { get; set; }
        public string status { get; set; }
        public string imagem { get; set; }
        public string url { get; set; }
    }

    public class FindBeneficiador
    {
        public Beneficiador[] docs { get; set; }
    }
}
