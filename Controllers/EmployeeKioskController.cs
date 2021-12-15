using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using HttpContext = System.Web.HttpContext;

namespace BackEnd.Controllers
{
    public class EmployeeKioskController : ApiController
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();



        [HttpGet, AllowAnonymous, Route("api/getUserInformation/{id}")]
        public async Task<IHttpActionResult> GetInformation([FromUri] int id)
        {
            EmployeeKioskService ks = new EmployeeKioskService();
            response = ks.getUserInformation(id);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }


        [HttpGet, AllowAnonymous, Route("api/getYear/{table}")]
        public async Task<IHttpActionResult> GetYear([FromUri] string table)
        {
            EmployeeKioskService lb = new EmployeeKioskService();
            response = lb.getYear(table);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        [HttpGet, AllowAnonymous, Route("api/getEmployeeExcludeByID/{id}")]
        public async Task<IHttpActionResult> GetEmployeeExclude([FromUri] int id)
        {
            EmployeeKioskService kr = new EmployeeKioskService();
            response = kr.getEmployeeExcludeByID(id);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        [HttpGet, AllowAnonymous, Route("api/getRequestID/{id}")]
        public async Task<IHttpActionResult> GetRequestID([FromUri] int id)
        {
            EmployeeKioskService kr = new EmployeeKioskService();
            response = kr.getRequestID(id);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        [HttpGet, AllowAnonymous, Route("api/getKioskWorkflow/{id}")]
        public async Task<IHttpActionResult> GetKioskWorkflow([FromUri] int id)
        {
            EmployeeKioskService ks = new EmployeeKioskService();
            response = ks.getKioskWorkflow(id);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        [HttpGet, AllowAnonymous, Route("api/getNewRequestID")]
        public async Task<IHttpActionResult> GetNewID()
        {
            EmployeeKioskService kr = new EmployeeKioskService();
            response = kr.getNewRequestID();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }


       
        // Add All Request API'S
        [HttpPost, AllowAnonymous, Route("api/addRequestHeader")]
        public async Task<IHttpActionResult> Create([FromBody] EncryptedDataModel edm)
        {
            RequestHeaderModel bim = (RequestHeaderModel)Encryptor.getByModel(typeof(RequestHeaderModel), edm);
            EmployeeKioskService kr = new EmployeeKioskService();

            response = kr.addRequestHeader(bim);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));

        }


        [HttpPost, AllowAnonymous, Route("api/addRequestRequester")]
        public async Task<IHttpActionResult> AddRequester([FromBody] EncryptedDataModel edm)
        {
            RequestModel rm = (RequestModel)Encryptor.getByModel(typeof(RequestModel), edm);
            EmployeeKioskService kr = new EmployeeKioskService();

            response = kr.addRequestRequester(rm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }


        [HttpPost, AllowAnonymous, Route("api/addRequestAttachment")]
        public async Task<IHttpActionResult> AddAttachment([FromBody] EncryptedDataModel edm)
        {
            RequestModel rm = (RequestModel)Encryptor.getByModel(typeof(RequestModel), edm);
            EmployeeKioskService kr = new EmployeeKioskService();

            response = kr.addRequestAttachment(rm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        [HttpPost, AllowAnonymous, Route("api/addRequestCC")]
        public async Task<IHttpActionResult> AddCC([FromBody] EncryptedDataModel edm)
        {
            RequestModel rm = (RequestModel)Encryptor.getByModel(typeof(RequestModel), edm);
            EmployeeKioskService kr = new EmployeeKioskService();

            response = kr.addRequestCC(rm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        [HttpPost, AllowAnonymous, Route("api/addRequestWorkflow")]
        public async Task<IHttpActionResult> CreateWorkflow([FromBody] EncryptedDataModel edm)
        {
            RequestModel bim = (RequestModel)Encryptor.getByModel(typeof(RequestModel), edm);
            EmployeeKioskService kr = new EmployeeKioskService();

            response = kr.addRequestWorkflow(bim);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // End of Add  All Request API'S

        // Approval

    

        [HttpPost, Route("api/getAwaitingApproval")]
        public async Task<IHttpActionResult> getAwaitingApproval([FromBody] EncryptedDataModel edm)
        {
            Approval a = (Approval)Encryptor.getByModel(typeof(Approval), edm);
            EmployeeKioskService kr = new EmployeeKioskService();
            response = kr.getAwaitingApproval(a);
            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        [HttpPost, AllowAnonymous, Route("api/processApproval")]
        public async Task<IHttpActionResult> ProcessApproval([FromBody] EncryptedDataModel edm)
        {
            Approval rm = (Approval)Encryptor.getByModel(typeof(Approval), edm);
            EmployeeKioskService kr = new EmployeeKioskService();

            response = kr.processApproval(rm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }


        // End of Awaiting Approval Function


        // Add Request DETAILS API'S
        [HttpPost, AllowAnonymous, Route("api/addRequestDetailCOA")]
        public async Task<IHttpActionResult> CreateCoa([FromBody] EncryptedDataModel edm)
        {
            RequestDetails bim = (RequestDetails)Encryptor.getByModel(typeof(RequestDetails), edm);
            EmployeeKioskService kr = new EmployeeKioskService();

            response = kr.addRequestDetailCOA(bim);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }


        [HttpPost, AllowAnonymous, Route("api/addRequestDetailOT")]
        public async Task<IHttpActionResult> CreateOT([FromBody] EncryptedDataModel edm)
        {
            RequestDetails bim = (RequestDetails)Encryptor.getByModel(typeof(RequestDetails), edm);
            EmployeeKioskService kr = new EmployeeKioskService();

            response = kr.addRequestDetailOT(bim);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        [HttpPost, AllowAnonymous, Route("api/addRequestDetailLeave")]
        public async Task<IHttpActionResult> CreateLeave([FromBody] EncryptedDataModel edm)
        {
            RequestDetails bim = (RequestDetails)Encryptor.getByModel(typeof(RequestDetails), edm);
            EmployeeKioskService kr = new EmployeeKioskService();

            response = kr.addRequestDetailLeave(bim);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        [HttpPost, AllowAnonymous, Route("api/addRequestDetailShift")]
        public async Task<IHttpActionResult> CreateShift([FromBody] EncryptedDataModel edm)
        {
            RequestDetails bim = (RequestDetails)Encryptor.getByModel(typeof(RequestDetails), edm);
            EmployeeKioskService kr = new EmployeeKioskService();

            response = kr.addRequestDetailShift(bim);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // End of request details API

        [HttpPost, AllowAnonymous, Route("api/uploadAttachment")]
        public async Task<IHttpActionResult> Upload()
        {
            EmployeeKioskService kr = new EmployeeKioskService();
            string location = HttpContext.Current.Request.Form["path"];
            //create path
            string path = HttpContext.Current.Server.MapPath("~/attachments/" + location);

            //get the file
            HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];

            response = kr.uploadAttachment(path, postedFile);

            //Send OK Response to Client.
            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        [HttpPost, AllowAnonymous, Route("api/employee/uploadAttachment")]
        public async Task<IHttpActionResult> UploadAttachment()
        {
            EmployeeKioskService kr = new EmployeeKioskService();
            string location = HttpContext.Current.Request.Form["path"];
            //create path
            string path = HttpContext.Current.Server.MapPath("~/attachments/" + location);

            //get the file
            HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];

            response = kr.uploadAttachment(path, postedFile);

            //Send OK Response to Client.
            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        [HttpGet, AllowAnonymous, Route("api/employee/downloadAttachment")]
        public HttpResponseMessage DownloadFile(string filename)
        {
            //Create HTTP Response.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            //Set the File Path.
            string filePath = HttpContext.Current.Server.MapPath("~/attachments/employees/") + filename;

            //Check whether File exists.
            if (!File.Exists(filePath))
            {
                //Throw 404 (Not Found) exception if File not found.
                response.StatusCode = HttpStatusCode.NotFound;
                response.ReasonPhrase = string.Format("File not found: {0} .", filename);
                throw new HttpResponseException(response);
            }

            //Read the File into a Byte Array.
            byte[] bytes = File.ReadAllBytes(filePath);

            //Set the Response Content.
            response.Content = new ByteArrayContent(bytes);

            //Set the Response Content Length.
            response.Content.Headers.ContentLength = bytes.LongLength;

            //Set the Content Disposition Header Value and FileName.
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = filename;

            //Set the File Content Type.
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(filename));
            return response;
        }

    }
}