/*[10/08/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class DependentsController : ApiController
    {

        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // POST: Employee Dependents/Create
        [HttpPost, AllowAnonymous, Route("api/createEmployeeDependentRecord")]
        public async Task<IHttpActionResult> Create([FromBody] EncryptedDataModel edm)
        {
            DependentsModel dm = (DependentsModel )Encryptor.getByModel(typeof(DependentsModel ), edm);
            DependentsService ds = new DependentsService();

            response = ds.createEmployeeDependentRecord(dm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // POST: Employee Dependents/Update
        [HttpPost, AllowAnonymous, Route("api/updateEmployeeDependentRecord")]
        public async Task<IHttpActionResult> Update([FromBody] EncryptedDataModel edm)
        {
            DependentsModel dm = (DependentsModel )Encryptor.getByModel(typeof(DependentsModel ), edm);
            DependentsService ds = new DependentsService();

            response = ds.updateEmployeeDependentRecord(dm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // GET: All Dependents by Id
        [HttpGet, AllowAnonymous, Route("api/getAllDependentsById/{id}")]
        public async Task<IHttpActionResult> GetAllDependentsByEmplyee([FromUri] int id)
        {
            DependentsService ds = new DependentsService();
            response = ds.getEmployeeDependentsById(id);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        
    }
}