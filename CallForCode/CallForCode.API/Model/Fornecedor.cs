using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallForCode.Model
{
    public class Fornecedor
    {
        public static Fornecedor Empty;
        public string _id { get; set; }
        public string _rev { get; set; }
        public string nome { get; set; }
        public string contato { get; set; }
        public string tipoproduto { get; set; }
        public string[] equipamentos { get; set; }
        public string[] recursos { get; set; }
        public string status { get; set; }
        public string imagem { get; set; }
        public string url { get; set; }
    }

    public class FindFornecedor
    {
        public Fornecedor[] docs { get; set; }
    }
}
