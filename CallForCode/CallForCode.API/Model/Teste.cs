using Microsoft.Extensions.WebEncoders.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallForCode.Model
{
    public class Teste
    {
        public static Teste Empty;
                
        public string _id { get; set; }                
        public string _rev { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }
    }
}
