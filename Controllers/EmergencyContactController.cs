/*[10/07/2021] CN E.Patot*/

using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class EmergencyContactController : ApiController
    {

        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // POST: BasicInformation/Create
        [HttpPost, AllowAnonymous, Route("api/createEmergencyContact")]
        public async Task<IHttpActionResult> Create([FromBody] EncryptedDataModel edm)
        {
            EmergencyContactModel ecm = (EmergencyContactModel)Encryptor.getByModel(typeof(EmergencyContactModel), edm);
            EmergencyContactService ecs = new EmergencyContactService();

            response = ecs.createEmergencyContact(ecm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // POST: BasicInformation/Update
        [HttpPost, AllowAnonymous, Route("api/updateEmergencyContact")]
        public async Task<IHttpActionResult> Update([FromBody] EncryptedDataModel edm)
        {
            EmergencyContactModel ecm = (EmergencyContactModel)Encryptor.getByModel(typeof(EmergencyContactModel), edm);
            EmergencyContactService ecs = new EmergencyContactService();

            response = ecs.updateEmegencyContact(ecm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }


        // GET: All EmergencyContact
        [HttpGet, AllowAnonymous, Route("api/getEmergencyContact/{employeeId}")]
        public async Task<IHttpActionResult> GetByEmployeeId([FromUri] int employeeId)
        {
            EmergencyContactService ecs = new EmergencyContactService();
            response = ecs.getByEmployeeId(employeeId);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        /*// Delete: Employee Basic Information
        [HttpDelete, AllowAnonymous, Route("api/emergencyContact/delete/{id}")]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            EmergencyContactService ecs = new EmergencyContactService();
            response = ecs.deleteEmegencyContact(id);
            
            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }*/
    }
}