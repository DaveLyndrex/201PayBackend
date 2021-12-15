/*[10/10/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class VisaController : ApiController
    {

        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // POST: Create Employee Visa
        [HttpPost, AllowAnonymous, Route("api/createEmployeeVisa")]
        public async Task<IHttpActionResult> Create([FromBody] EncryptedDataModel edm)
        {
            VisaModel vm = (VisaModel)Encryptor.getByModel(typeof(VisaModel), edm);
            VisaService vs = new VisaService();

            response = vs.createEmployeeVisa(vm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // POST: Update Employee Visa
        [HttpPost, AllowAnonymous, Route("api/updateEmployeeVisa")]
        public async Task<IHttpActionResult> Update([FromBody] EncryptedDataModel edm)
        {
            VisaModel vm = (VisaModel)Encryptor.getByModel(typeof(VisaModel), edm);
            VisaService vs = new VisaService();

            response = vs.updateEmployeeVisa(vm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // GET: Employee Visa by Employee Id
        [HttpGet, AllowAnonymous, Route("api/getEmployeeVisaById/{employeeId}")]
        public async Task<IHttpActionResult> GetVisaByEmpId([FromUri] int employeeId)
        {
            VisaService vs = new VisaService();
            response = vs.getEmployeeVisaById(employeeId);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }
        
    }
}

