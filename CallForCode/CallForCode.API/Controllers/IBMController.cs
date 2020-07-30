using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CallForCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IBMController : ControllerBase
    {
        const string TABELA_TESTE = "teste";
        const string TABELA_PRODUTOR = "produtor";
        const string TABELA_BENEFICIADOR = "beneficiador";
        const string TABELA_FORNECEDOR = "fornecedor";
        const string TABELA_DISTRIBUIDOR = "distribuidor";

        #region GETS

        #endregion

        #region POSTS
        [HttpPost("addteste")]
        public IActionResult AddTeste([FromBody]Model.Teste instance)
        {
            if (instance == null || instance == Model.Teste.Empty)
                return BadRequest();

            var handler = new HttpClientHandler { Credentials = new NetworkCredential(DataAccess.IBMDataAccess.USER, DataAccess.IBMDataAccess.PASSWORD) };
            using (var client = DataAccess.IBMDataAccess.CreateHttpClient(handler, DataAccess.IBMDataAccess.USER, TABELA_TESTE))
            {
                var creationResponse = DataAccess.IBMDataAccess.Create<Model.Teste>(client, instance);

                if (creationResponse.StatusCode == HttpStatusCode.Created)
                {
                    var id = DataAccess.IBMDataAccess.GetString("id", creationResponse);

                    var readResponse = DataAccess.IBMDataAccess.Read(client, id);

                    var dd = DataAccess.IBMDataAccess.GetObjectModel<Model.Teste>(readResponse);

                    return Created(client.BaseAddress, dd);
                }                    
                else
                    return BadRequest();
            }
        }

        [HttpPost("addprodutor")]
        public IActionResult AddProdutor([FromBody] Model.Produtor instance)
        {
            if (instance == null || instance == Model.Produtor.Empty)
                return BadRequest();

            var handler = new HttpClientHandler { Credentials = new NetworkCredential(DataAccess.IBMDataAccess.USER, DataAccess.IBMDataAccess.PASSWORD) };
            using (var client = DataAccess.IBMDataAccess.CreateHttpClient(handler, DataAccess.IBMDataAccess.USER, TABELA_PRODUTOR))
            {
                var creationResponse = DataAccess.IBMDataAccess.Create<Model.Produtor>(client, instance);

                if (creationResponse.StatusCode == HttpStatusCode.Created)
                {
                    var id = DataAccess.IBMDataAccess.GetString("id", creationResponse);

                    var readResponse = DataAccess.IBMDataAccess.Read(client, id);

                    var data = DataAccess.IBMDataAccess.GetObjectModel<Model.Produtor>(readResponse);

                    return Created(client.BaseAddress, data);
                }
                else
                    return BadRequest();
            }
        }

        [HttpPost("addbeneficiador")]
        public IActionResult AddBeneficiador([FromBody]Model.Beneficiador instance)
        {
            if (instance == null || instance == Model.Beneficiador.Empty)
                return BadRequest();

            var handler = new HttpClientHandler { Credentials = new NetworkCredential(DataAccess.IBMDataAccess.USER, DataAccess.IBMDataAccess.PASSWORD) };
            using (var client = DataAccess.IBMDataAccess.CreateHttpClient(handler, DataAccess.IBMDataAccess.USER, TABELA_BENEFICIADOR))
            {
                var creationResponse = DataAccess.IBMDataAccess.Create<Model.Beneficiador>(client, instance);

                if (creationResponse.StatusCode == HttpStatusCode.Created)
                {
                    var id = DataAccess.IBMDataAccess.GetString("id", creationResponse);

                    var readResponse = DataAccess.IBMDataAccess.Read(client, id);

                    var data = DataAccess.IBMDataAccess.GetObjectModel<Model.Beneficiador>(readResponse);

                    return Created(client.BaseAddress, data);
                }
                else
                    return BadRequest();
            }
        }

        [HttpPost("addfornecedor")]
        public IActionResult AddFornecedor([FromBody]Model.Fornecedor instance)
        {
            if (instance == null || instance == Model.Fornecedor.Empty)
                return BadRequest();

            var handler = new HttpClientHandler { Credentials = new NetworkCredential(DataAccess.IBMDataAccess.USER, DataAccess.IBMDataAccess.PASSWORD) };
            using (var client = DataAccess.IBMDataAccess.CreateHttpClient(handler, DataAccess.IBMDataAccess.USER, TABELA_FORNECEDOR))
            {
                var creationResponse = DataAccess.IBMDataAccess.Create<Model.Fornecedor>(client, instance);

                if (creationResponse.StatusCode == HttpStatusCode.Created)
                {
                    var id = DataAccess.IBMDataAccess.GetString("id", creationResponse);

                    var readResponse = DataAccess.IBMDataAccess.Read(client, id);

                    var data = DataAccess.IBMDataAccess.GetObjectModel<Model.Fornecedor>(readResponse);

                    return Created(client.BaseAddress, data);
                }
                else
                    return BadRequest();
            }
        }

        [HttpPost("adddistribuidor")]
        public IActionResult AddDistribuidor([FromBody]Model.Distribuidor instance)
        {
            if (instance == null || instance == Model.Distribuidor.Empty)
                return BadRequest();

            var handler = new HttpClientHandler { Credentials = new NetworkCredential(DataAccess.IBMDataAccess.USER, DataAccess.IBMDataAccess.PASSWORD) };
            using (var client = DataAccess.IBMDataAccess.CreateHttpClient(handler, DataAccess.IBMDataAccess.USER, TABELA_DISTRIBUIDOR))
            {
                var creationResponse = DataAccess.IBMDataAccess.Create<Model.Distribuidor>(client, instance);

                if (creationResponse.StatusCode == HttpStatusCode.Created)
                {
                    var id = DataAccess.IBMDataAccess.GetString("id", creationResponse);

                    var readResponse = DataAccess.IBMDataAccess.Read(client, id);

                    var data = DataAccess.IBMDataAccess.GetObjectModel<Model.Distribuidor>(readResponse);

                    return Created(client.BaseAddress, data);
                }
                else
                    return BadRequest();
            }
        }
        #endregion

        #region PUTS
        [HttpPut("updateprodutor")]
        public IActionResult UpdateProdutor([FromBody]Model.Produtor instance)
        {
            if (instance == null || instance == Model.Produtor.Empty)
                return BadRequest();

            var handler = new HttpClientHandler { Credentials = new NetworkCredential(DataAccess.IBMDataAccess.USER, DataAccess.IBMDataAccess.PASSWORD) };
            using (var client = DataAccess.IBMDataAccess.CreateHttpClient(handler, DataAccess.IBMDataAccess.USER, TABELA_PRODUTOR))
            {
                var updateResponse = DataAccess.IBMDataAccess.Update<Model.Produtor>(client, instance._id, instance);

                if (updateResponse.StatusCode == HttpStatusCode.Created)
                {
                    var revNew = DataAccess.IBMDataAccess.GetString("rev", updateResponse);

                    instance._rev = revNew;
                    
                    return Created(client.BaseAddress, instance);
                }
                else
                    return BadRequest();
            }
        }

        [HttpPut("updatebeneficiador")]
        public IActionResult UpdateBeneficiador([FromBody]Model.Beneficiador instance)
        {
            if (instance == null || instance == Model.Beneficiador.Empty)
                return BadRequest();

            var handler = new HttpClientHandler { Credentials = new NetworkCredential(DataAccess.IBMDataAccess.USER, DataAccess.IBMDataAccess.PASSWORD) };
            using (var client = DataAccess.IBMDataAccess.CreateHttpClient(handler, DataAccess.IBMDataAccess.USER, TABELA_BENEFICIADOR))
            {
                var updateResponse = DataAccess.IBMDataAccess.Update<Model.Beneficiador>(client, instance._id, instance);

                if (updateResponse.StatusCode == HttpStatusCode.Created)
                {
                    var revNew = DataAccess.IBMDataAccess.GetString("rev", updateResponse);

                    instance._rev = revNew;

                    return Created(client.BaseAddress, instance);
                }
                else
                    return BadRequest();
            }
        }

        [HttpPut("updatefornecedor")]
        public IActionResult UpdateFornecedor([FromBody]Model.Fornecedor instance)
        {
            if (instance == null || instance == Model.Fornecedor.Empty)
                return BadRequest();

            var handler = new HttpClientHandler { Credentials = new NetworkCredential(DataAccess.IBMDataAccess.USER, DataAccess.IBMDataAccess.PASSWORD) };
            using (var client = DataAccess.IBMDataAccess.CreateHttpClient(handler, DataAccess.IBMDataAccess.USER, TABELA_FORNECEDOR))
            {
                var updateResponse = DataAccess.IBMDataAccess.Update<Model.Fornecedor>(client, instance._id, instance);

                if (updateResponse.StatusCode == HttpStatusCode.Created)
                {
                    var revNew = DataAccess.IBMDataAccess.GetString("rev", updateResponse);

                    instance._rev = revNew;

                    return Created(client.BaseAddress, instance);
                }
                else
                    return BadRequest();
            }
        }

        [HttpPut("updatedistribuidor")]
        public IActionResult UpdateDistribuidor([FromBody]Model.Distribuidor instance)
        {
            if (instance == null || instance == Model.Distribuidor.Empty)
                return BadRequest();

            var handler = new HttpClientHandler { Credentials = new NetworkCredential(DataAccess.IBMDataAccess.USER, DataAccess.IBMDataAccess.PASSWORD) };
            using (var client = DataAccess.IBMDataAccess.CreateHttpClient(handler, DataAccess.IBMDataAccess.USER, TABELA_DISTRIBUIDOR))
            {
                var updateResponse = DataAccess.IBMDataAccess.Update<Model.Distribuidor>(client, instance._id, instance);

                if (updateResponse.StatusCode == HttpStatusCode.Created)
                {
                    var revNew = DataAccess.IBMDataAccess.GetString("rev", updateResponse);

                    instance._rev = revNew;

                    return Created(client.BaseAddress, instance);
                }
                else
                    return BadRequest();
            }
        }
        #endregion

        #region DELETES
        [HttpDelete("deleteprodutor")]
        public IActionResult DeleteProdutor([FromQuery]string id, string rev)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(rev))
                return BadRequest();

            var handler = new HttpClientHandler { Credentials = new NetworkCredential(DataAccess.IBMDataAccess.USER, DataAccess.IBMDataAccess.PASSWORD) };
            using (var client = DataAccess.IBMDataAccess.CreateHttpClient(handler, DataAccess.IBMDataAccess.USER, TABELA_PRODUTOR))
            {
                var deleteResponse = DataAccess.IBMDataAccess.Delete(client, id, rev);

                if (deleteResponse.StatusCode == HttpStatusCode.Created)
                    return Ok();
                else
                    return BadRequest();
            }
        }

        [HttpDelete("deletebeneficiador")]
        public IActionResult DeleteBeneficiador([FromQuery] string id, string rev)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(rev))
                return BadRequest();

            var handler = new HttpClientHandler { Credentials = new NetworkCredential(DataAccess.IBMDataAccess.USER, DataAccess.IBMDataAccess.PASSWORD) };
            using (var client = DataAccess.IBMDataAccess.CreateHttpClient(handler, DataAccess.IBMDataAccess.USER, TABELA_BENEFICIADOR))
            {
                var deleteResponse = DataAccess.IBMDataAccess.Delete(client, id, rev);

                if (deleteResponse.StatusCode == HttpStatusCode.Created)
                    return Ok();
                else
                    return BadRequest();
            }
        }

        [HttpDelete("deletefornecedor")]
        public IActionResult DeleteFornecedor([FromQuery] string id, string rev)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(rev))
                return BadRequest();

            var handler = new HttpClientHandler { Credentials = new NetworkCredential(DataAccess.IBMDataAccess.USER, DataAccess.IBMDataAccess.PASSWORD) };
            using (var client = DataAccess.IBMDataAccess.CreateHttpClient(handler, DataAccess.IBMDataAccess.USER, TABELA_FORNECEDOR))
            {
                var deleteResponse = DataAccess.IBMDataAccess.Delete(client, id, rev);

                if (deleteResponse.StatusCode == HttpStatusCode.Created)
                    return Ok();
                else
                    return BadRequest();
            }
        }

        [HttpDelete("deletedistribuidor")]
        public IActionResult DeleteDistribuidor([FromQuery] string id, string rev)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(rev))
                return BadRequest();

            var handler = new HttpClientHandler { Credentials = new NetworkCredential(DataAccess.IBMDataAccess.USER, DataAccess.IBMDataAccess.PASSWORD) };
            using (var client = DataAccess.IBMDataAccess.CreateHttpClient(handler, DataAccess.IBMDataAccess.USER, TABELA_DISTRIBUIDOR))
            {
                var deleteResponse = DataAccess.IBMDataAccess.Delete(client, id, rev);

                if (deleteResponse.StatusCode == HttpStatusCode.Created)
                    return Ok();
                else
                    return BadRequest();
            }
        }
        #endregion
    }
}
