/*[10/05/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class PayrollDataController : ApiController
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // GET: PayrollData/Get
        [HttpGet, AllowAnonymous, Route("api/getAllPayrollDataById/{empid}")]
        public async Task<IHttpActionResult> GetAllPayroll([FromUri] int empid)
        {
            PayrollDataService pds = new PayrollDataService();

            response = pds.getAllPayrollDataById(empid);

            var data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => data));
        }

        // POST: PayrollData/Create
        [HttpPost, AllowAnonymous, Route("api/createPayrollData")]
        public async Task<IHttpActionResult> CreatePayroll([FromBody] EncryptedDataModel edm)
        {
            PayrollDataModel payrollData_model = (PayrollDataModel)Encryptor.getByModel(typeof(PayrollDataModel), edm);
            PayrollDataService pds = new PayrollDataService();

            response = pds.createPayrollData(payrollData_model);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        /*// DELETE: PayrollData/Delete/5
        [HttpDelete, AllowAnonymous, Route("api/deletePayrollData/{id}")]
        public async Task<IHttpActionResult> DeletePayrollData([FromUri] int id)
        {
            PayrollDataService pds = new PayrollDataService();

            response = pds.deletePayrollData(id);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }*/

        [HttpPost, AllowAnonymous, Route("api/updatePayrollData")]
        public async Task<IHttpActionResult> UpdatePayrollData([FromBody] EncryptedDataModel edm) 
        {
            PayrollDataModel payroll_model = (PayrollDataModel)Encryptor.getByModel(typeof(PayrollDataModel), edm);
            PayrollDataService pds = new PayrollDataService();

            response = pds.updatePayrollData(payroll_model);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }
    }
}
