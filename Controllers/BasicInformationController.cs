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
    public class BasicInformationController : ApiController
    {

        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // POST: BasicInformation/Create
        [HttpPost, AllowAnonymous, Route("api/createBasicInformation")]
        public async Task<IHttpActionResult> Create([FromBody] EncryptedDataModel edm)
        {
            BasicInformationModel bim = (BasicInformationModel)Encryptor.getByModel(typeof(BasicInformationModel), edm);
            BasicInformationService bis = new BasicInformationService();

            response = bis.createBasicInformation(bim);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // POST: BasicInformation/Update
        [HttpPost, AllowAnonymous, Route("api/updateBasicInformation")]
        public async Task<IHttpActionResult> Update([FromBody] EncryptedDataModel edm)
        {
            BasicInformationModel bim = (BasicInformationModel)Encryptor.getByModel(typeof(BasicInformationModel), edm);
            BasicInformationService bis = new BasicInformationService();

            response = bis.updateBasicInformation(bim);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // GET: All Employee Basic Information
        [HttpGet, AllowAnonymous, Route("api/getAllBasicInformationById/{employeeId}")]
        public async Task<IHttpActionResult> Get([FromUri] int employeeId)
        {
            BasicInformationService bis = new BasicInformationService();
            response = bis.getAllEmployeeBasicInformationById(employeeId);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }
    }
}