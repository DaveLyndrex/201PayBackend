using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BackEnd.Services;

namespace BackEnd.Controllers
{
    public class EncryptorController : ApiController
    {

        [HttpPost, AllowAnonymous, Route("api/test/decrypt")]
        public async Task<IHttpActionResult> dec([FromBody] EncryptedDataModel test)
        {
            var data = Encryptor.DecryptStringAES(test);
            return Ok(await Task.Run(() => data));
        }

        [HttpPost, AllowAnonymous, Route("api/test/encrypt")]
        public async Task<IHttpActionResult> Enc([FromBody] Object test)
        {
            var data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(test)) };

            return Ok(await Task.Run(() => data));
        }
    }
}
