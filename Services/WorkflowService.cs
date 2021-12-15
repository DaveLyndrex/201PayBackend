/*[10/05/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;       
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;



namespace BackEnd.Services
{
    public class WorkflowService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel getWorkflowByEmpID(string empID)
        {
            try
            {
                using(MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using(MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM CN_EMPLOYEE_WORKFLOW_V WHERE (NOW() BETWEEN StartDate AND EndDate) AND EmpID = '" + empID + "'";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                        

                        MySqlDataReader dataReader = command.ExecuteReader();
                        List<WorkflowModel> list_wf = new List<WorkflowModel>();

                        while(dataReader.Read())
                        {
                            WorkflowModel workflow = new WorkflowModel();

                            if(dataReader["ID"] != null)
                            {
                                workflow.ID = Convert.ToInt32(dataReader["ID"]);
                                workflow.StartDate = Convert.ToDateTime(dataReader["StartDate"]).ToString("MM/dd/yyyy");
                                workflow.EndDate = Convert.ToDateTime(dataReader["EndDate"]).ToString("MM/dd/yyyy");
                                workflow.CreatedDate= Convert.ToDateTime(dataReader["EndDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                workflow.ModifiedDate = Convert.ToDateTime(dataReader["EndDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                workflow.EmpID = Convert.ToInt32(dataReader["EmpID"]);
                                workflow.Username = dataReader["Username"].ToString();
                                workflow.Email = dataReader["Email"].ToString();
                                workflow.EmailType = dataReader["EmailType"].ToString();
                                workflow.PrimaryFlag = dataReader["PrimaryFlag"].ToString();
                                workflow.SendCredsEmailFlag = dataReader["SendCredsEmailFlag"].ToString();
                                workflow.UserNameMatchingFlag = dataReader["UserNameMatchingFlag"].ToString();
                                workflow.RaterID = Convert.ToString(dataReader["Rater"]);
                                workflow.ApproverID = Convert.ToString(dataReader["Approvers"]);
                                workflow.MaxApprover = Convert.ToString(dataReader["MaxApprover"]);
                                workflow.ApprovalGroupID = Convert.ToString(dataReader["Description"]);
                                workflow.ModifiedBy = dataReader["ModifiedBy"].ToString();

                                list_wf.Add(workflow);
                            }
                        }
                        response.code = consts.CODE_OK;
                        response.status = consts.SUCCESS;
                        response.error = consts.ERROR_FALSE;
                        response.message = consts.SUCCESS_RETRIEVE;
                        response.data = list_wf;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM CN_EMPLOYEE_WORKFLOW_V WHERE (NOW() BETWEEN StartDate AND EndDate) AND EmpID = '" + empID + "'", action: 5, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM CN_EMPLOYEE_WORKFLOW_V WHERE (NOW() BETWEEN StartDate AND EndDate) AND EmpID = '" + empID + "'", action: 5, status: response.status, remarks: response.message);
            }

            return response;
        }

        public ResponseModel createWorkflow(WorkflowModel workflowModel)
        {
            try
            {
                using(MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_EMPLOYEE_WORKFLOW_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                        command.Parameters.Clear();

                        command.Parameters.AddWithValue("_StartDate", workflowModel.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_EndDate", workflowModel.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_EmpID", workflowModel.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Username", workflowModel.Username);
                        command.Parameters["_Username"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Email", workflowModel.Email);
                        command.Parameters["_Email"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_EmailType", workflowModel.Email);
                        command.Parameters["_EmailType"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_PrimaryFlag", workflowModel.PrimaryFlag);
                        command.Parameters["_PrimaryFlag"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_SendCredsEmailFlag", workflowModel.SendCredsEmailFlag);
                        command.Parameters["_SendCredsEmailFlag"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_UserNameMatchingFlag", workflowModel.UserNameMatchingFlag);
                        command.Parameters["_UserNameMatchingFlag"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_RaterID", workflowModel.RaterID);
                        command.Parameters["_RaterID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_ApproverID", workflowModel.ApproverID);
                        command.Parameters["_ApproverID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_MaxApprover", workflowModel.MaxApprover);
                        command.Parameters["_MaxApprover"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_ApprovalGroupID", workflowModel.ApprovalGroupID);
                        command.Parameters["_ApprovalGroupID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_ModifiedBy", workflowModel.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        int row_count = command.ExecuteNonQuery();

                        if (row_count == 1)
                        {
                            response.code = consts.CODE_OK;
                            response.status = consts.SUCCESS;
                            response.error = consts.ERROR_FALSE;
                            response.message = consts.SUCCESS_INSERT;
                            response.data = null;
                            command.Transaction.Commit();
                        }
                        else
                        {
                            response.code = consts.CODE_ERROR;
                            response.status = consts.ERROR;
                            response.error = consts.ERROR_TRUE;
                            response.message = consts.ERROR_INSERT;
                            response.data = null;
                            command.Transaction.Rollback();
                        }

                        conn.Close();
                        logs.insertActivityLogs(name: "hris.CN_EMPLOYEE_WORKFLOW_INSERT", action: 1, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "hris.CN_EMPLOYEE_WORKFLOW_INSERT", action: 1, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel updateWorkflow(WorkflowModel workflowModel)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_EMPLOYEE_WORKFLOW_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                        command.Parameters.Clear();

                        command.Parameters.AddWithValue("_ID", workflowModel.ID);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_StartDate", workflowModel.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_EndDate", workflowModel.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_EmpID", workflowModel.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Username", workflowModel.Username);
                        command.Parameters["_Username"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Email", workflowModel.Email);
                        command.Parameters["_Email"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_EmailType", workflowModel.Email);
                        command.Parameters["_EmailType"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_PrimaryFlag", workflowModel.PrimaryFlag);
                        command.Parameters["_PrimaryFlag"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_SendCredsEmailFlag", workflowModel.SendCredsEmailFlag);
                        command.Parameters["_SendCredsEmailFlag"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_UserNameMatchingFlag", workflowModel.UserNameMatchingFlag);
                        command.Parameters["_UserNameMatchingFlag"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_RaterID", workflowModel.RaterID);
                        command.Parameters["_RaterID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_ApproverID", workflowModel.ApproverID);
                        command.Parameters["_ApproverID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_MaxApprover", workflowModel.MaxApprover);
                        command.Parameters["_MaxApprover"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_ApprovalGroupID", workflowModel.ApprovalGroupID);
                        command.Parameters["_ApprovalGroupID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_ModifiedBy", workflowModel.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        int rows_affected = command.ExecuteNonQuery();

                        if (rows_affected > 0)
                        {
                            response.code = consts.CODE_OK;
                            response.status = consts.SUCCESS;
                            response.error = consts.ERROR_FALSE;
                            response.message = consts.SUCCESS_INSERT;
                            response.data = null;
                            command.Transaction.Commit();
                        }
                        else
                        {
                            response.code = consts.CODE_ERROR;
                            response.status = consts.ERROR;
                            response.error = consts.ERROR_TRUE;
                            response.message = consts.ERROR_INSERT;
                            response.data = null;
                            command.Transaction.Rollback();
                        }

                        conn.Close();
                        logs.insertActivityLogs(name: "hris.CN_EMPLOYEE_WORKFLOW_UPDATE", action: 1, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "hris.CN_EMPLOYEE_WORKFLOW_UPDATE", action: 1, status: response.status, remarks: response.message);
            }

            return response;
        }
/*
        public ResponseModel deleteWorkflow(int id)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_APPROVAL_WORKFLOW_DELETE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                        command.Parameters.Clear();

                        command.Parameters.AddWithValue("_ID", id);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        int rows_affected = command.ExecuteNonQuery();

                        if (rows_affected == 1)
                        {
                            command.Transaction.Commit();

                            response.code = consts.CODE_OK;
                            response.status = consts.SUCCESS;
                            response.error = consts.ERROR_FALSE;
                            response.message = consts.SUCCESS_DELETE;
                            response.data = null;
                        }
                        else
                        {
                            command.Transaction.Rollback();
                            response.code = consts.CODE_OK;
                            response.status = consts.ERROR;
                            response.error = consts.ERROR_TRUE;
                            response.message = consts.ERROR_DELETE;
                            response.data = null;
                        }
                        conn.Close();
                        logs.insertActivityLogs(name: "hris.CN_APPROVAL_WORKFLOW_DELETE", action: 3, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "hris.CN_APPROVAL_WORKFLOW_DELETE", action: 3, status: response.status, remarks: response.message);
            }
            return response;
        }*/
    }
}