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
                var creationResponse = DataAccess.IBMDataAccess.Create(client, instance);

                if (creationResponse.StatusCode == HttpStatusCode.Created)
                    return Created(client.BaseAddress, creationResponse);
                else
                    return BadRequest();
            }
        }
        #endregion

        #region PUTS

        #endregion

        #region DELETES

        #endregion
    }
}
