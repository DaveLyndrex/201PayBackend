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
    public class KioskShiftController : ApiController
    {

        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // GET: getAllKioskShift

        [HttpGet, AllowAnonymous, Route("api/getAllKioskShift")]
        public async Task<IHttpActionResult> GetAllKioskShift()
        {
            KioskShiftService ot = new KioskShiftService();
            response = ot.getAllKioskShift();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }
    }
}