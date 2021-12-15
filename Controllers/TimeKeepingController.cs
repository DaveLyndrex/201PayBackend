/*10/07/2021 CN CRUBIO*/
using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;



namespace BackEnd.Controllers
{

    public class TimeKeepingController : ApiController
    {
        public ResponseModel response = new ResponseModel();
        TimeKeepingService timesheet = new TimeKeepingService();


        // GET: get all Period
        [HttpGet, AllowAnonymous, Route("api/getAllPeriod/{payrollgroup}")]
        public async Task<IHttpActionResult> getPeriod([FromUri] string payrollgroup)
        {
            response = timesheet.getPeriod(payrollgroup);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }
        //POST: Get Current Period
        [HttpPost, Route("api/getCurrentPeriod")]
        public async Task<IHttpActionResult> getCurrentPeriod([FromBody] EncryptedDataModel edm)
        {
            PayrollPeriodModel ppm = (PayrollPeriodModel)Encryptor.getByModel(typeof(PayrollPeriodModel), edm);
            TimeKeepingService process = new TimeKeepingService();
            response = process.getCurrentPeriod(ppm.PayrollGroup);
            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        //GET : timesheet current Exception Report
        [HttpGet, AllowAnonymous, Route("api/viewExceptionReport/{payrollgroup}")]

        public async Task<IHttpActionResult> viewExceptionReport([FromUri] string payrollgroup)
        {
            response = timesheet.viewExceptionReport(payrollgroup);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));

        }
        //POST: GET SPECIFIC EMPLOYE REPORT
        [HttpPost, Route("api/getSpecificEmployeeTimesheet")]
        public async Task<IHttpActionResult> getSpecificEmployeeTimesheet([FromBody] EncryptedDataModel edm)
        {
            PayrollPeriodModel ppm = (PayrollPeriodModel)Encryptor.getByModel(typeof(PayrollPeriodModel), edm);
            TimeKeepingService process = new TimeKeepingService();
            response = process.getSpecificEmployeeTimesheet(ppm);
            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        //GET : Payroll Group 
        [HttpGet, AllowAnonymous, Route("api/getPayrollGroup")]

        public async Task<IHttpActionResult> getPayrollGroup()
        {
            response = timesheet.getPayrollGroup();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        //GET : getLocation
        [HttpGet, AllowAnonymous, Route("api/getLocation/{payrollgroup}")]

        public async Task<IHttpActionResult> getLocation([FromUri] string payrollgroup)
        {
            response = timesheet.getLocation(payrollgroup);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // POST: Employee Location
        [HttpPost, AllowAnonymous, Route("api/getSpecificEmployeeLocation")]
        public async Task<IHttpActionResult> getSpecificEmployeeLocation([FromBody] EncryptedDataModel edm)
        {
            PayrollPeriodModel ppm = (PayrollPeriodModel)Encryptor.getByModel(typeof(PayrollPeriodModel), edm);
            TimeKeepingService process = new TimeKeepingService();

            response = process.getSpecificEmployeeLocation(ppm.PayrollGroup, ppm.Location);
            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        //GET : get Employee
        [HttpGet, AllowAnonymous, Route("api/getEmployee/{payrollgroup}")]

        public async Task<IHttpActionResult> getEmployee([FromUri] string payrollgroup)
        {
            response = timesheet.getEmployee(payrollgroup);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        ///POST: Post timesheet

        [HttpPost, AllowAnonymous, Route("api/postTimesheet")]
        public async Task<IHttpActionResult> Update([FromBody] EncryptedDataModel edm)
        {
            PayrollPeriodModel ppm = (PayrollPeriodModel)Encryptor.getByModel(typeof(PayrollPeriodModel), edm);
            TimeKeepingService process = new TimeKeepingService();

            response = process.postTimesheet(ppm.ModifiedBy, ppm.PayrollGroup);
            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        //POST: Export CSV

        [HttpPost, Route("api/exportCSV")]
        public async Task<IHttpActionResult> exportCSV([FromBody] EncryptedDataModel edm)
        {
            PayrollPeriodModel ppm = (PayrollPeriodModel)Encryptor.getByModel(typeof(PayrollPeriodModel), edm);
            TimeKeepingService process = new TimeKeepingService();
            response = process.exportCSV(ppm);
            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }
        //POST: process timesheet

        [HttpPost, Route("api/processTimesheet")]
        public async Task<IHttpActionResult> processTimesheet([FromBody] EncryptedDataModel edm)
        {
            PayrollPeriodModel ppm = (PayrollPeriodModel)Encryptor.getByModel(typeof(PayrollPeriodModel), edm);
            TimeKeepingService process = new TimeKeepingService();
            response = process.processTimesheet(ppm.ModifiedBy, ppm.PayrollGroup);
            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        //POST : Validated/Update
        [HttpPost, AllowAnonymous, Route("api/validateTimesheet")]
        public async Task<IHttpActionResult> validateTimesheet([FromBody] EncryptedDataModel edm)
        {
            TimeKeepingModel tkm = (TimeKeepingModel)Encryptor.getByModel(typeof(TimeKeepingModel), edm);
            TimeKeepingService process = new TimeKeepingService();
            response = process.validateTimesheet(tkm);
            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));

        }
         //POST : Validate All Users Timesheet
         [HttpPost, Route("api/ValidateAllUserTimesheet")]
         public async Task<IHttpActionResult> ValidateAllUserTimesheet([FromBody] EncryptedDataModel edm)
         {
             PayrollPeriodModel ppm = (PayrollPeriodModel)Encryptor.getByModel(typeof(PayrollPeriodModel), edm);
             TimeKeepingService process = new TimeKeepingService();
             response = process.ValidateAllUserTimesheet(ppm);
             return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
         }
     
        // POST : Receive Payroll Group

        [HttpPost, AllowAnonymous, Route("api/payrollGroup/{payrollgroup}")]
        public async Task<IHttpActionResult> payrollGroup([FromUri] string payrollgroup)
        {
            TimeKeepingService bis = new TimeKeepingService();
            int result = bis.payrollGroup(payrollgroup);
            return Ok(await Task.Run(() => JsonConvert.SerializeObject(result)));
        }


    }
}
