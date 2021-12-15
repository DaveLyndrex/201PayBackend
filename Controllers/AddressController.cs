using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{   
    public class AddressController : ApiController
    {

        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // POST: EmployeeAddress / Create
        [HttpPost, AllowAnonymous, Route("api/createEmployeeAddress")]
        public async Task<IHttpActionResult> Create([FromBody] EncryptedDataModel edm)
        {
            AddressModel ecm = (AddressModel)Encryptor.getByModel(typeof(AddressModel), edm);
            AddressService ads = new AddressService();

            response = ads.createEmployeeAddress(ecm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // POST: EmployeeAddress / Update
        [HttpPost, AllowAnonymous, Route("api/updateEmployeeAddress")]
        public async Task<IHttpActionResult> Update([FromBody] EncryptedDataModel edm)
        {
            AddressModel ecm = (AddressModel)Encryptor.getByModel(typeof(AddressModel), edm);
            AddressService ads = new AddressService();

            response = ads.updateEmployeeAddress(ecm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // GET: All Employees Address By Id
        [HttpGet, AllowAnonymous, Route("api/getAllEmployeeAddressById/{empid}")]
        public async Task<IHttpActionResult> Get([FromUri] int empid)
        {
            AddressService ads = new AddressService();
            response = ads.getAllEmployeeAddressById(empid);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }


       /* // Delete: Employee Address
        [HttpDelete, AllowAnonymous, Route("api/employeAddress/delete/{id}")]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            AddressService ads = new AddressService();
            response = ads.deleteEmployeeAddress(id);
            
            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }*/
    }
}