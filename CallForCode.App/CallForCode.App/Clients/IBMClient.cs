using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CallForCode.App.Clients
{
    public class IBMClient : BaseClient
    {
        private const string URL_BASE = @"https://hacka.us-south.cf.appdomain.cloud/";
        private const string URL_FIND_ALL = @"api/IBM/getfindall";

        public async Task<IEnumerable<Models.Produtor>> FindAllProdutor()
        {
            var query = new Dictionary<string, object>()
            {
                { "business", "produtor" },
                { "limit", 100 }
            };

            var response = await GetAsync($"{URL_BASE}{URL_FIND_ALL}", querys: query);

            await EnsureSuccessStatusCodeAsync(response);

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IEnumerable<Models.Produtor>>(json);

            return result;
        }

        public async Task<IEnumerable<Models.Fornecedor>> FindAllFornecedor()
        {
            var query = new Dictionary<string, object>()
            {
                { "business", "fornecedor" },
                { "limit", 100 }
            };

            var response = await GetAsync($"{URL_BASE}{URL_FIND_ALL}", querys: query);

            await EnsureSuccessStatusCodeAsync(response);

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IEnumerable<Models.Fornecedor>>(json);

            return result;
        }

        public async Task<IEnumerable<Models.Distribuidor>> FindAllDistribuidor()
        {
            var query = new Dictionary<string, object>()
            {
                { "business", "distribuidor" },
                { "limit", 100 }
            };

            var response = await GetAsync($"{URL_BASE}{URL_FIND_ALL}", querys: query);

            await EnsureSuccessStatusCodeAsync(response);

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IEnumerable<Models.Distribuidor>>(json);

            return result;
        }

        public async Task<IEnumerable<Models.Beneficiador>> FindAllBeneficiador()
        {
            var query = new Dictionary<string, object>()
            {
                { "business", "beneficiador" },
                { "limit", 100 }
            };

            var response = await GetAsync($"{URL_BASE}{URL_FIND_ALL}", querys: query);

            await EnsureSuccessStatusCodeAsync(response);

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IEnumerable<Models.Beneficiador>>(json);

            return result;
        }       
    }
}
