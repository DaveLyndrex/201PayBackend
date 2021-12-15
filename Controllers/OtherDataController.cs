/*[10/07/2021] CN E.Patot*/
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class OtherDataController : ApiController
    {
        public ResponseModel response = new ResponseModel();
        //api/getOtherDataByEmpID
        [HttpGet, AllowAnonymous, Route("api/getOtherDataByEmpId/{employeeId}")]
        public async Task<IHttpActionResult> getOtherDataByEmpEmpId([FromUri] string employeeId)
        {
            OtherDataService ods = new OtherDataService();

            var result = ods.getEmployeeOtherDataById(employeeId);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }
       /* //api/getAllOtherData
        [HttpGet, AllowAnonymous, Route("api/getAllOtherData")]
        public async Task<IHttpActionResult> getAllOtherData([FromUri] string employeeId = "all")
        {
            OtherDataService ods = new OtherDataService();

            var result = ods.getEmployeeOtherDataById(employeeId);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }*/
        [HttpPost, AllowAnonymous, Route("api/createOtherData")]
        public async Task<IHttpActionResult> createOtherData([FromBody] EncryptedDataModel edm)
        {
            OtherDataModel odm = (OtherDataModel)Encryptor.getByModel(typeof(OtherDataModel), edm);
            OtherDataService ods = new OtherDataService();
            response = ods.createEmployeeOtherData(odm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        [HttpPost, AllowAnonymous, Route("api/updateOtherData")]
        public async Task<IHttpActionResult> updateOtherData([FromBody] EncryptedDataModel edm)
        {
            OtherDataModel odm = (OtherDataModel)Encryptor.getByModel(typeof(OtherDataModel), edm);
            OtherDataService ods = new OtherDataService();
            response = ods.updateEmployeeOtherData(odm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }
/*
        [HttpDelete, AllowAnonymous, Route("api/deleteOtherData/{id}")]
        public async Task<IHttpActionResult> deleteOtherData ([FromUri] int id)
        {
            OtherDataService ods = new OtherDataService();
            response = ods.deleteOtherData(id);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }*/
    }
}
