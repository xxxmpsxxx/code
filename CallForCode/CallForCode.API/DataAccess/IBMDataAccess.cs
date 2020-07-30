using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CallForCode.DataAccess
{
    public class IBMDataAccess
    {
        public const string USER = "b0317c9e-0a95-4fba-baed-1c1e4a1a864b-bluemix";
        public const string PASSWORD = "a89c5e79ac58e166287a69dde14a8346b16d54ad0a8802798d5cbc00bfb21a8e";        

        public static HttpResponseMessage Create<T>(HttpClient client, object doc)
        {
            var jsonResolver = new Helpers.PropertyRenameAndIgnoreSerializerContractResolver();
            jsonResolver.IgnoreProperty(typeof(T), "_id");
            jsonResolver.IgnoreProperty(typeof(T), "_rev");

            var jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.ContractResolver = jsonResolver;

            var json = JsonConvert.SerializeObject(doc, jsonSerializerSettings);
            return client.PostAsync("", new StringContent(json, Encoding.UTF8, "application/json")).Result;
        }

        public static HttpResponseMessage Read(HttpClient client, string id)
        {
            return client.GetAsync(id).Result;
        }

        public static HttpResponseMessage Update<T>(HttpClient client, string id, object doc)
        {
            var jsonResolver = new Helpers.PropertyRenameAndIgnoreSerializerContractResolver();
            jsonResolver.IgnoreProperty(typeof(T), "_id");

            var jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.ContractResolver = jsonResolver;

            var json = JsonConvert.SerializeObject(doc, jsonSerializerSettings);
            return client.PutAsync(id, new StringContent(json, Encoding.UTF8, "application/json")).Result;
        }

        public static HttpResponseMessage Delete(HttpClient client, string id, string rev)
        {
            return client.DeleteAsync($"{id}?rev={rev}").Result;
        }

        public static HttpClient CreateHttpClient(HttpClientHandler handler, string user, string database)
        {
            return new HttpClient(handler)
            {
                BaseAddress = new Uri($"https://{user}.cloudant.com/{database}/")
            };
        }

        public static void PrintResponse(HttpResponseMessage response)
        {
            Console.WriteLine($"Status code: {response.StatusCode}");
            Console.WriteLine(Convert.ToString(response));
        }

        public static string GetString(string propertyName, HttpResponseMessage creationResponse)
        {
            using (var streamReader = new StreamReader(creationResponse.Content.ReadAsStreamAsync().Result))
            {
                var responseContent = (JObject)JToken.ReadFrom(new JsonTextReader(streamReader));
                return responseContent[propertyName].Value<string>();
            }
        }

        public static T GetObjectModel<T>(HttpResponseMessage readResponse)
        {
            using (var streamReader = new StreamReader(readResponse.Content.ReadAsStreamAsync().Result))
            {
                var resultContent = (JObject)JToken.ReadFrom(new JsonTextReader(streamReader));
                return JsonConvert.DeserializeObject<T>(resultContent.ToString());
            }
        }
    }
}
