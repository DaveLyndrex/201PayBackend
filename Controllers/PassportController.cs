/*[10/09/2021] CN E.Patot*/

using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class PassportController : ApiController
    {

        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // POST: Create Employee Passport
        [HttpPost, AllowAnonymous, Route("api/createEmployeePassport")]
        public async Task<IHttpActionResult> create([FromBody] EncryptedDataModel edm)
        {


            PassportModel pm = (PassportModel)Encryptor.getByModel(typeof(PassportModel), edm);
            PassportService ps = new PassportService();

            response = ps.createEmployeePassport(pm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // POST: Update Employee Passport
        [HttpPost, AllowAnonymous, Route("api/updateEmployeePassport")]
        public async Task<IHttpActionResult> Update([FromBody] EncryptedDataModel edm)
        {

            PassportModel pm = (PassportModel)Encryptor.getByModel(typeof(PassportModel), edm);
            PassportService ps = new PassportService();

            response = ps.updateEmployeePassport(pm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // GET: Employee Passport by Employee Id
        [HttpGet, AllowAnonymous, Route("api/getEmployeePassportById/{employeeId}")]
        public async Task<IHttpActionResult> GetEmployeeEthnicityByEmpId([FromUri] int employeeId)
        {
            PassportService ps = new PassportService();
            response = ps.getEmployeePassportById(employeeId);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }
        
    }
}


