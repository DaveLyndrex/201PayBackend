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
    public class LeaveBalancesController : ApiController
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // GET: All Timesheet Information

        [HttpGet, AllowAnonymous, Route("api/getAllLeaveBalances")]
        public async Task<IHttpActionResult> GetAllLeaveBalances()
        {
            LeaveBalancesService lb = new LeaveBalancesService();
            response = lb.getAllLeaveBalances();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        [HttpGet, AllowAnonymous, Route("api/getLeaveCreditYear")]
        public async Task<IHttpActionResult> GetLeaveCreditYear()
        {
            LeaveBalancesService lb = new LeaveBalancesService();
            response = lb.getLeaveCreditYear();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

    }
}
