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
    public class LicenseController : ApiController
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        //api/get Employee License by EmpID
        [HttpGet, AllowAnonymous, Route("api/getLicenseByEmpId/{employeeId}")]
        public async Task<IHttpActionResult> getLiceneseByEmpEmpId([FromUri] string employeeId)
        {
            LicenseService licenses = new LicenseService();

            var result = licenses.GetLicenseById(employeeId);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }
        

        // POST: Create Employee License 
        [HttpPost, AllowAnonymous, Route("api/createLicense")]
        public async Task<IHttpActionResult> createLicense([FromBody] EncryptedDataModel edm)
        {
            LicenseModel license = (LicenseModel)Encryptor.getByModel(typeof(LicenseModel), edm);
            LicenseService licenses = new LicenseService();
            response = licenses.createLicense(license);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        //UPDATE License
        [HttpPost, AllowAnonymous, Route("api/updateLicense")]
        public async Task<IHttpActionResult> updateLicense([FromBody] EncryptedDataModel edm)
        {
            LicenseModel license = (LicenseModel)Encryptor.getByModel(typeof(LicenseModel), edm);
            LicenseService ls = new LicenseService();
            response = ls.updateLicense(license);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

    }
}