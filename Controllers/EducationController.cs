/*[10/08/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class EducationController : ApiController
    {

        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // POST: Create Employee Education 
        [HttpPost, AllowAnonymous, Route("api/createEmployeeEducation")]
        public async Task<IHttpActionResult> Create([FromBody] EncryptedDataModel edm)
        {
            EducationModel ecm = (EducationModel)Encryptor.getByModel(typeof(EducationModel), edm);
            EducationService es = new EducationService();

            response = es.createEmployeeEducation(ecm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // POST: Update Employee Education
        [HttpPost, AllowAnonymous, Route("api/updateEmployeeEducation")]
        public async Task<IHttpActionResult> Update([FromBody] EncryptedDataModel edm)
        {
            EducationModel ecm = (EducationModel)Encryptor.getByModel(typeof(EducationModel), edm);
            EducationService es = new EducationService();

            response = es.updateEmployeeEducation(ecm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // GET: Employee Education by Employee Id
        [HttpGet, AllowAnonymous, Route("api/getEmployeeEducationById/{employeeId}")]
        public async Task<IHttpActionResult> GetEducationByEmpId([FromUri] string employeeId)
        {
            EducationService es = new EducationService();
            response = es.getEmployeeEducationById(employeeId);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }
      
    }
}