/*[10/07/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;


namespace BackEnd.Controllers
{
    public class PayComponentController : ApiController
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // GET: PayComponent/Get
        [HttpGet, AllowAnonymous, Route("api/getAllPayComponentById/{empid}")]
        public async Task<IHttpActionResult> GetAllPayComponent([FromUri] int empid)
        {
            PayComponentServices pcs = new PayComponentServices();

            response = pcs.getAllPayComponentById(empid);

            var data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => data));
        }

        // POST: PayComponent/Create
        [HttpPost, AllowAnonymous, Route("api/createPayComponent")]
        public async Task<IHttpActionResult> CreatePayComponent([FromBody] EncryptedDataModel edm)
        {
            PayComponentModel payComponentModel = (PayComponentModel)Encryptor.getByModel(typeof(PayComponentModel), edm);
            PayComponentServices pcs = new PayComponentServices();

            response = pcs.createPayComponent(payComponentModel);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // UPDATE: PayComponent/Update
        [HttpPost, AllowAnonymous, Route("api/updatePayComponent")]
        public async Task<IHttpActionResult> updateSalaryRate ([FromBody] EncryptedDataModel edm)
        {
            PayComponentModel payComponentModel = (PayComponentModel)Encryptor.getByModel(typeof(PayComponentModel), edm);
            PayComponentServices pcs = new PayComponentServices();

            response = pcs.updatePayComponent(payComponentModel);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

  /*      // DELETE: PayComponent/Delete
        [HttpDelete, AllowAnonymous, Route("api/deletePayComponent/{id}")]
        public async Task<IHttpActionResult> deletePayComponent([FromUri] int id)
        {
            PayComponentServices pcs = new PayComponentServices();

            response = pcs.deletePayComponent(id);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }*/
    }
}
