/* 07/10/2021 CN A.Diez */
/* 10/08/2021 CN E.Patot */
using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class CitizenshipController : ApiController
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // POST: Citizenship/Create
        [HttpPost, AllowAnonymous, Route("api/createCitizenshipData")]
        public async Task<IHttpActionResult> Create([FromBody] EncryptedDataModel edm)
        {
            CitizenshipModel cm = (CitizenshipModel)Encryptor.getByModel(typeof(CitizenshipModel), edm);
            CitizenshipService cs = new CitizenshipService();

            response = cs.createCitizenshipData(cm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // POST: Citizenship/Update
        [HttpPost, AllowAnonymous, Route("api/updateCitizenshipData")]
        public async Task<IHttpActionResult> Update([FromBody] EncryptedDataModel edm)
        {
            CitizenshipModel cm = (CitizenshipModel)Encryptor.getByModel(typeof(CitizenshipModel), edm);
            CitizenshipService cs = new CitizenshipService();

            response = cs.updateCitizenshipData(cm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }



        // GET: All Citizenship by Id
        [HttpGet, AllowAnonymous, Route("api/getCitizenshipByID/{empid}")]
        public async Task<IHttpActionResult> GetByID(int empId)
        {
            CitizenshipService cs = new CitizenshipService();
            response = cs.getAllCitizenshipById(empId);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }
    }
}