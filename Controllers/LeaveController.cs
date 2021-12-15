using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class LeaveController : ApiController
    {

        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // GET: Overtime

        [HttpGet, AllowAnonymous, Route("api/getAllLeave")]
        public async Task<IHttpActionResult> GetAllLeave()
        {
            LeaveService lv = new LeaveService();
            response = lv.getAllLeave();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        //get COA Details
 
        [HttpGet, AllowAnonymous, Route("api/getShiftDetails/{id}")]
        public async Task<IHttpActionResult> getPeriod([FromUri] int id)
        {
            LeaveService lv = new LeaveService();
            response = lv.getShiftDetails(id);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }
    }
}