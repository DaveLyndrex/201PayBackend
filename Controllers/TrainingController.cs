/*[10/08/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class TrainingController : ApiController
    {

        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // POST: Employee Dependents/Create
        [HttpPost, AllowAnonymous, Route("api/createEmployeeTraining")]
        public async Task<IHttpActionResult> Create([FromBody] EncryptedDataModel etm)
        {
            TrainingModel tm = (TrainingModel)Encryptor.getByModel(typeof(TrainingModel), etm);
            TrainingService ts = new TrainingService();

            response = ts.createEmployeeTraining(tm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // POST: Employee Dependents/Update
        [HttpPost, AllowAnonymous, Route("api/updateEmployeeTraining")]
        public async Task<IHttpActionResult> Update([FromBody] EncryptedDataModel etm)
        {
            TrainingModel tm = (TrainingModel)Encryptor.getByModel(typeof(TrainingModel), etm);
            TrainingService ts = new TrainingService();

            response = ts.updateEmployeeTraining(tm);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // GET: All Trainings
        [HttpGet, AllowAnonymous, Route("api/getAllTrainings/{id}")]
        public async Task<IHttpActionResult> Get([FromUri] string id)
        {
            TrainingService ts = new TrainingService();
            response = ts.getAllTraining(id);
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        
    }
}