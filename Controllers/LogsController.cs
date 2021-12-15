using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class LogsController : ApiController
    {
        public ResponseModel response = new ResponseModel();

        [HttpGet, Authorize, Route("api/getLogsByType/{type}")]
        public async Task<IHttpActionResult> getLogs([FromUri] int type)
        {
            LogsService ls = new LogsService();

            response = ls.getLogsByType(type);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }
        [HttpPost, Authorize, Route("api/insertChangeLogs")]
        public async Task<IHttpActionResult> insertLogs([FromBody] EncryptedDataModel edm)
        {
            ChangeLogsModel clm = (ChangeLogsModel)Encryptor.getByModel(typeof(ChangeLogsModel), edm);
            LogsService ls = new LogsService();
            response = ls.insertLogsToDb(clm);

            return Ok(await Task.Run(() => response));
        }
    }
}