/*[10/10/2021] CN E.Patot*/
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class CostCenterController : ApiController
    {
        public ResponseModel response = new ResponseModel();

        [HttpGet, AllowAnonymous, Route("api/getAllCostCenterById/{empid}")]
        public async Task<IHttpActionResult> getCostCenter([FromUri] int empid)
        {
            CostCenterService ccs = new CostCenterService();

            var result = ccs.getCosts(empid);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        [HttpPost, AllowAnonymous, Route("api/createCostCenter")]
        public async Task<IHttpActionResult> createCostCenter([FromBody] EncryptedDataModel edm)
        {
            CostCenterModel cdm = (CostCenterModel)Encryptor.getByModel(typeof(CostCenterModel), edm);
            CostCenterService ccs = new CostCenterService();
            response = ccs.createCostCenter(cdm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        [HttpPost, AllowAnonymous, Route("api/updateCostCenter")]
        public async Task<IHttpActionResult> updateCostCenter([FromBody] EncryptedDataModel edm)
        {
            CostCenterModel cdm = (CostCenterModel)Encryptor.getByModel(typeof(CostCenterModel), edm);
            CostCenterService ccs = new CostCenterService();
            response = ccs.updateCostCenter(cdm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

    }
}
