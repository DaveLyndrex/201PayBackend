/*[10/14/2021] CN J.Layaog*/

using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;
namespace BackEnd.Controllers
{
    public class TimesheetController : ApiController
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // GET: All Timesheet Information

        [HttpGet, AllowAnonymous, Route("api/getAllTimesheet")]
        public async Task<IHttpActionResult> GetAllTimesheet()
        {
            TimesheetService ts = new TimesheetService();
            response = ts.getAllTimesheet();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        [HttpGet, AllowAnonymous, Route("api/getEmployeeFilter")]
        public async Task<IHttpActionResult> GetEmployee()
        {
            TimesheetService ts = new TimesheetService();
            response = ts.getEmployeeFilter();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }


        [HttpGet, AllowAnonymous, Route("api/filterEmployee/{id}")]
        public async Task<IHttpActionResult> GetFilterEmployee([FromUri] int id)
        {
            TimesheetService kr = new TimesheetService();
            response = kr.filterEmployee(id);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        [HttpGet, AllowAnonymous, Route("api/getPeriod")]
        public async Task<IHttpActionResult> GetPeriod()
        {
            TimesheetService ts = new TimesheetService();
            response = ts.getPeriod();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        [HttpGet, AllowAnonymous, Route("api/getSystemProfile")]
        public async Task<IHttpActionResult> getSystemProfile()
        {
            TimesheetService ts = new TimesheetService();
            response = ts.getSystemProfile();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        [HttpPost, AllowAnonymous, Route("api/validateKioskTimesheet")]
        public async Task<IHttpActionResult> validateTimesheet([FromBody] EncryptedDataModel edm)
        {
            TimesheetModel tm = (TimesheetModel)Encryptor.getByModel(typeof(TimesheetModel), edm);
            TimesheetService process = new TimesheetService();
            response = process.validateKioskTimesheet(tm);
            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));

        }

    }
}
