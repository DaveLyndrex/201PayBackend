/*[10/09/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class NIDController : ApiController
    {

        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // POST: Create Employee NID
        [HttpPost, AllowAnonymous, Route("api/createEmployeeNID")]
        public async Task<IHttpActionResult> create([FromBody] EncryptedDataModel edm)
        {


            NIDModel nm = (NIDModel)Encryptor.getByModel(typeof(NIDModel), edm);
            NIDService ns = new NIDService();

            response = ns.createEmployeeNID(nm);


            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // POST: Update Employee NID
        [HttpPost, AllowAnonymous, Route("api/updateEmployeeNID")]
        public async Task<IHttpActionResult> Update([FromBody] EncryptedDataModel edm)
        {

            NIDModel nm = (NIDModel)Encryptor.getByModel(typeof(NIDModel), edm);
            NIDService ns = new NIDService();

            response = ns.updateEmployeeNID(nm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // GET: Employee NID by Employee Id
        [HttpGet, AllowAnonymous, Route("api/getEmployeeNIDById/{employeeId}")]
        public async Task<IHttpActionResult> GetEmployeeEthnicityByEmpId([FromUri] int employeeId)
        {
            NIDService ns = new NIDService();
            response = ns.getEmployeeNIDById(employeeId);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        
    }
}


