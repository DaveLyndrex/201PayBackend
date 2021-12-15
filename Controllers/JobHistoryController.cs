/*[10/08/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class JobHistoryController : ApiController
    {

        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // POST: Create Employee Job History
        [HttpPost, AllowAnonymous, Route("api/createEmployeeJobHistory")]
        public async Task<IHttpActionResult> Create([FromBody] EncryptedDataModel edm)
        {
            JobHistoryModel jhm = (JobHistoryModel)Encryptor.getByModel(typeof(JobHistoryModel), edm);
            JobHistoryService jhs = new JobHistoryService();

            response = jhs.createEmployeeJobHistory(jhm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // POST: Update Employee Job History
        [HttpPost, AllowAnonymous, Route("api/updateEmployeeJobHistory")]
        public async Task<IHttpActionResult> Update([FromBody] EncryptedDataModel edm)
        {
            JobHistoryModel jhm = (JobHistoryModel)Encryptor.getByModel(typeof(JobHistoryModel), edm);
            JobHistoryService jhs = new JobHistoryService();

            response = jhs.updateEmployeeJobHistory(jhm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // GET: Employee Job History by Employee Id
        [HttpGet, AllowAnonymous, Route("api/getEmployeeJobHistoryById/{employeeId}")]
        public async Task<IHttpActionResult> GetJobHistoryByEmpId([FromUri] int employeeId)
        {
            JobHistoryService jhs = new JobHistoryService();
            response = jhs.getEmployeeJobHistoryById(employeeId);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }
       
    }
}
