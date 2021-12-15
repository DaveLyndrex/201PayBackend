using BackEnd.Global;
using BackEnd.Models.Masterfile;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace BackEnd.Controllers
{
    public class ShiftController : ApiController
    {

        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // GET: api/Shift
        [HttpGet, AllowAnonymous, Route("api/getAllShifts")]
        public async Task<IHttpActionResult> GetAllShifts()
        {
            ShiftService shiftService = new ShiftService();
            response = shiftService.RetrieveShift();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // GET: api/Shift/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Create/Shift
        [HttpPost, AllowAnonymous, Route("api/createShift")]
        public async Task<IHttpActionResult> CreateShift([FromBody] EncryptedDataModel edm)
        {
            Shift_SetupModel shift_SetupModel = (Shift_SetupModel)Encryptor.getByModel(typeof(Shift_SetupModel), edm);
            ShiftService shiftService = new ShiftService();

            response = shiftService.CreateShift(shift_SetupModel);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // POST: api/Update/Shift
        [HttpPost, AllowAnonymous, Route("api/updateShift")]
        public async Task<IHttpActionResult> UpdateShift([FromBody] EncryptedDataModel edm)
        {
            Shift_SetupModel shift_SetupModel = (Shift_SetupModel)Encryptor.getByModel(typeof(Shift_SetupModel), edm);
            ShiftService shiftService = new ShiftService();

            response = shiftService.UpdateShift(shift_SetupModel);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // DELETE: api/Shift/5
        [HttpDelete, AllowAnonymous, Route("api/shift/delete/{id}")]
        public async Task<IHttpActionResult> DeleteShift([FromUri] int id)
        {
            ShiftService shiftService = new ShiftService();
            response = shiftService.DeleteShift(id);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }
    }
}
