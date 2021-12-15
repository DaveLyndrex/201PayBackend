/*[10/05/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class WorkflowController : ApiController
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        // GET: api/WorkflowByEmpID
        [HttpGet, AllowAnonymous, Route("api/getEmployeeWorkflow/{empId}")]
        public async Task<IHttpActionResult> GetEmployeeWorkflow([FromUri] string empID)
        {
            WorkflowService workflowService = new WorkflowService();

            response = workflowService.getWorkflowByEmpID(empID);

            var data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };

            return Ok(await Task.Run(() => data));
        }

 /*       // GET: api/AllWorkflow
        [HttpGet, AllowAnonymous, Route("api/getAllApprovalWorkflow")]
        public async Task<IHttpActionResult> GetAllEmployeeWorkflow([FromUri] string empID = "all")
        {
            WorkflowService workflowService = new WorkflowService();

            response = workflowService.getWorkflowByEmpID(empID);

            var data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(response)) };

            return Ok(await Task.Run(() => data));
        }*/

        // POST: api/Workflow
        [HttpPost, AllowAnonymous, Route("api/createWorkflow")]
        public async Task<IHttpActionResult> CreateWorkflow([FromBody] EncryptedDataModel edm)
        {
            WorkflowModel workflowModel = (WorkflowModel)Encryptor.getByModel(typeof(WorkflowModel), edm);
            WorkflowService workflowService = new WorkflowService();

            response = workflowService.createWorkflow(workflowModel);

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }

        // POST: Workflow/Update
        [HttpPost, AllowAnonymous, Route("api/updateWorkflow")]
        public async Task<IHttpActionResult> UpdateWorkflow([FromBody] EncryptedDataModel encryptedDataModel)
        {
            WorkflowModel workflowModel = (WorkflowModel)Encryptor.getByModel(typeof(WorkflowModel), encryptedDataModel);
            WorkflowService workflowService = new WorkflowService();

            response = workflowService.updateWorkflow(workflowModel);

            return Ok(await Task.Run(() => response));
        }

      /*  // DELETE: Workflow/Delete
        [HttpDelete, AllowAnonymous, Route("api/deleteWorkflow/{id}")]
        public async Task<IHttpActionResult> DeleteWorkflow([FromUri] int id)
        {
            WorkflowService workflowService = new WorkflowService();

            response = workflowService.deleteWorkflow(id);

            return Ok(await Task.Run(() => response));
        }*/
    }
}
