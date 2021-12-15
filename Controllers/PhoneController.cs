/* 07/10/2021 CN A.Diez */
/*[10/10/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class PhoneController : ApiController
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        //api/get Employee Phone by EmpID
        [HttpGet, AllowAnonymous, Route("api/getPhoneByEmpId/{employeeId}")]
        public async Task<IHttpActionResult> getPhoneByEmpEmpId([FromUri] string employeeId)
        {
            PhoneService phones = new PhoneService();

            var result = phones.GetPhoneById(employeeId);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }


        // POST: Create Employee Phone 
        [HttpPost, AllowAnonymous, Route("api/createPhone")]
        public async Task<IHttpActionResult> Create([FromBody] EncryptedDataModel edm)
        {
            PhoneModel cm = (PhoneModel)Encryptor.getByModel(typeof(PhoneModel), edm);
            PhoneService cs = new PhoneService();

            response = cs.createPhone(cm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        //UPDATE
        [HttpPost, AllowAnonymous, Route("api/updatePhoneData")]
        public async Task<IHttpActionResult> updatePhone([FromBody] EncryptedDataModel edm)
        {
            PhoneModel phonem = (PhoneModel)Encryptor.getByModel(typeof(PhoneModel), edm);
            PhoneService phones = new PhoneService();
            response = phones.updatePhoneData(phonem);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }
    }
}