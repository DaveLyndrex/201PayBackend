/* 07/10/2021 CN A.Diez */
/*[10/09/2021] CN E.Patot*/
/*[10/11/2021] CN E.Patot*/
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class LegislativeController : ApiController
    {
        public ResponseModel response = new ResponseModel();

        //GET Legislative
        [HttpGet, AllowAnonymous, Route("api/getLegislativeById/{empid}")]
        public async Task<IHttpActionResult> Get([FromUri] int empid)
        {
            LegislativeService ls = new LegislativeService();

            var result = ls.getLegislative(empid);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        //CREATE Legislative
        [HttpPost, AllowAnonymous, Route("api/createLegislative")]
        public async Task<IHttpActionResult> createLegislative([FromBody] EncryptedDataModel edm)
        {
            LegislativeModel lm = (LegislativeModel)Encryptor.getByModel(typeof(LegislativeModel), edm);
            LegislativeService ls = new LegislativeService();
            response = ls.createLegislative(lm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        //UPDATE Legislative
        [HttpPost, AllowAnonymous, Route("api/updateLegislative")]
        public async Task<IHttpActionResult> updateLegislative([FromBody] EncryptedDataModel edm)
        {
            LegislativeModel lm = (LegislativeModel)Encryptor.getByModel(typeof(LegislativeModel), edm);
            LegislativeService ls = new LegislativeService();
            response = ls.updateLegislative(lm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

    }
}