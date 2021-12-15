/*[10/08/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class DeductionsController : ApiController
    {

        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // POST: BasicInformation/Create
        [HttpPost, AllowAnonymous, Route("api/createEmployeeDeductions")]
        public async Task<IHttpActionResult> Create([FromBody] EncryptedDataModel edm)
        {
            DeductionModel dm = (DeductionModel )Encryptor.getByModel(typeof(DeductionModel ), edm);
            DeductionService ds = new DeductionService();

            response = ds.createEmployeeDeduction(dm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // POST: BasicInformation/Update
        [HttpPost, AllowAnonymous, Route("api/updateEmployeeDeductions")]
        public async Task<IHttpActionResult> Update([FromBody] EncryptedDataModel edm)
        {
            DeductionModel dm = (DeductionModel)Encryptor.getByModel(typeof(DeductionModel ), edm);
            DeductionService ds = new DeductionService();

            response = ds.updateEmployeeDeduction(dm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }



        // GET: Employee Deduction by Id
        [HttpGet, AllowAnonymous, Route("api/getEmployeeDeduction/{id}")]
        public async Task<IHttpActionResult> GetByEmployeeId([FromUri] int id)
        {
            DeductionService ds = new DeductionService();
            response = ds.getEmployeeDeductionById(id);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }
    }
}