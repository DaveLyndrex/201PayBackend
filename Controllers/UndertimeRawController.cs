using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class UndertimeRawController : ApiController
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // GET: api/getAllUndertimeRaw
        [HttpGet, AllowAnonymous, Route("api/getAllUndertimeRaw")]
        public async Task<IHttpActionResult> GetAllUndertimeRaw([FromUri] string EmpID = "all")
        {
            UndertimeRawService undertimeRawService = new UndertimeRawService();

            response = undertimeRawService.getUndertimeRaw(EmpID);

            var data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };

            return Ok(await Task.Run(() => data));
        }

        //GET: api/getUndertimeRawByEmpID
        [HttpGet, AllowAnonymous, Route("api/getUndertimeRawByEmpID/{EmpID}")]
        public async Task<IHttpActionResult> GetUndertimeRawByEmpID([FromUri] string EmpID)
        {
            UndertimeRawService undertimeRawService = new UndertimeRawService();

            response = undertimeRawService.getUndertimeRaw(EmpID);

            var data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };

            return Ok(await Task.Run(() => data));
        }

        //POST: api/createUndertime
        [HttpPost, AllowAnonymous, Route("api/createUndertimeRaw")]
        public async Task<IHttpActionResult> CreateUndertimeRaw([FromBody] EncryptedDataModel edm)
        {
            UndertimeRawModel undertimeRawModel = (UndertimeRawModel)Encryptor.getByModel(typeof(UndertimeRawModel), edm);
            UndertimeRawService undertimeRawService = new UndertimeRawService();

            response = undertimeRawService.createUndertimeRaw(undertimeRawModel);
            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        //POST: api/updateUndertimeRaw
        [HttpPost, AllowAnonymous, Route("api/updateUndertimeRaw")]
        public async Task<IHttpActionResult> UpdateUndertimeRaw([FromBody] EncryptedDataModel encryptedDataModel)
        {
            UndertimeRawModel undertimeRawModel = (UndertimeRawModel)Encryptor.getByModel(typeof(UndertimeRawModel), encryptedDataModel);
            UndertimeRawService undertimeRawService = new UndertimeRawService();

            response = undertimeRawService.updateUndertimeRaw(undertimeRawModel);

            return Ok(await Task.Run(() => response));
        }


        //DELETE: api/deleteUndertimeRaw/id
        [HttpDelete, AllowAnonymous, Route("api/deleteUndertimeRaw/{id}")]
        public async Task<IHttpActionResult> DeleteUndertimeRaw([FromUri] int id)
        {
            UndertimeRawService undertimeRawService = new UndertimeRawService();

            response = undertimeRawService.deleteUndertimeRaw(id);

            return Ok(await Task.Run(() => response));
        }


        // GET: api/UndertimeRaw
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UndertimeRaw/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UndertimeRaw
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UndertimeRaw/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UndertimeRaw/5
        public void Delete(int id)
        {
        }
    }
}
