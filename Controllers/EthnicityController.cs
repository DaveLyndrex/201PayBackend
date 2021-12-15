/*[10/08/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class EthnicityController : ApiController
    {

        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // POST: Create Employee Leave CreditsR
        [HttpPost, AllowAnonymous, Route("api/createEmployeeEthnicity")]
        public async Task<IHttpActionResult> create([FromBody] EncryptedDataModel edm)
        {


            EthnicityModel lcm = (EthnicityModel)Encryptor.getByModel(typeof(EthnicityModel), edm);
            EthnicityService lcs = new EthnicityService();

            response = lcs.createEmployeeEthnicity(lcm);


            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // POST: Update Employee Leave Credits
        [HttpPost, AllowAnonymous, Route("api/updateEmployeeEthnicity")]
        public async Task<IHttpActionResult> Update([FromBody] EncryptedDataModel edm)
        {

            EthnicityModel lcm = (EthnicityModel)Encryptor.getByModel(typeof(EthnicityModel), edm);
            EthnicityService lcs = new EthnicityService();

            response = lcs.updateEmployeeEthnicity(lcm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // GET: Employee Leave Credits by Employee Id
        [HttpGet, AllowAnonymous, Route("api/getEmployeeEthnicityById/{employeeId}")]
        public async Task<IHttpActionResult> GetEmployeeEthnicityByEmpId([FromUri] int employeeId)
        {
            EthnicityService lcs = new EthnicityService();
            response = lcs.getEmployeeEthnicityById(employeeId);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }
        
    }
}


