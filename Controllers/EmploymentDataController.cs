/*[10/05/2021] CN E.Patot*/
/*[10/10/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class EmploymentDataController : ApiController
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // POST: EmploymentData/Create
        [HttpPost, AllowAnonymous, Route("api/createEmploymentData")]
        public async Task<IHttpActionResult> Create([FromBody] EncryptedDataModel edm)
        {
            EmploymentDataModel employment_model = (EmploymentDataModel)Encryptor.getByModel(typeof(EmploymentDataModel), edm);
            EmploymentDataService eds = new EmploymentDataService();

            response = eds.createEmploymentData(employment_model);
            
            return Ok(await Task.Run(() => response));
        }

        [HttpGet, AllowAnonymous, Route("api/getAllEmploymentDataById/{employeeId}")]
        public async Task<IHttpActionResult> GetUsers([FromUri] int employeeId)
        {
            EmploymentDataService eds = new EmploymentDataService();

            response = eds.getAllEmploymentDataById(employeeId);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }



        [HttpPost, AllowAnonymous, Route("api/updateEmploymentData")]
        public async Task<IHttpActionResult> UpdateEmployment([FromBody] EncryptedDataModel edm)
        {
            EmploymentDataModel employment_model = (EmploymentDataModel)Encryptor.getByModel(typeof(EmploymentDataModel), edm);
            EmploymentDataService eds = new EmploymentDataService();

            response = eds.updateEmploymentData(employment_model);
            return Ok(await Task.Run(() => response));
        }
    }
}
