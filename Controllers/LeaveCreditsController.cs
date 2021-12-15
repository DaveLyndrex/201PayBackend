/* 10/08/2021 CN E.Patot */
using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class LeaveCreditsController : ApiController
    {

        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // POST: Create Employee Leave Credits
        [HttpPost, AllowAnonymous, Route("api/createEmployeeLeaveCredits")]
        public async Task<IHttpActionResult> create([FromBody] EncryptedDataModel edm)
        {


                LeaveCreditsModel lcm = (LeaveCreditsModel)Encryptor.getByModel(typeof(LeaveCreditsModel), edm);
                LeaveCreditsService lcs = new LeaveCreditsService();

                response = lcs.createEmployeeLeaveCredits(lcm);

          
            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // POST: Update Employee Leave Credits
        [HttpPost, AllowAnonymous, Route("api/updateEmployeeLeaveCredits")]
        public async Task<IHttpActionResult> Update([FromBody] EncryptedDataModel edm)
        {
            LeaveCreditsModel lcm = (LeaveCreditsModel)Encryptor.getByModel(typeof(LeaveCreditsModel), edm);
            LeaveCreditsService lcs = new LeaveCreditsService();

            response = lcs.updateEmployeeLeaveCredits(lcm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // GET: Employee Leave Credits by Employee Id
        [HttpGet, AllowAnonymous, Route("api/getEmployeeLeaveCreditsById/{employeeId}")]
        public async Task<IHttpActionResult> GetEmployeeLeaveCreditsByEmpId([FromUri] int employeeId)
        {
            LeaveCreditsService lcs = new LeaveCreditsService();
            response = lcs.getEmployeeLeaveCreditsById(employeeId);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }
       
    }
}

