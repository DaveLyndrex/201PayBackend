    /*[10/08/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace BackEnd.Services
{
    public class JobHistoryService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel createEmployeeJobHistory(JobHistoryModel jhm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_JOB_HISTORY_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // EMP ID 
                        command.Parameters.AddWithValue("_EmpID", jhm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", jhm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EndDate", jhm.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // _Company
                        command.Parameters.AddWithValue("_Company", jhm.Company);
                        command.Parameters["_Company"].Direction = ParameterDirection.Input;

                        // _Designation
                        command.Parameters.AddWithValue("_Designation", jhm.Designation);
                        command.Parameters["_Designation"].Direction = ParameterDirection.Input;

                        // _Responsibilities
                        command.Parameters.AddWithValue("_Responsibilities", jhm.Responsibilities);
                        command.Parameters["_Responsibilities"].Direction = ParameterDirection.Input;

                        // _Reason for Leaving
                        command.Parameters.AddWithValue("_ReasonForLeaving", jhm.ReasonForLeaving);
                        command.Parameters["_ReasonForLeaving"].Direction = ParameterDirection.Input;

                        // _Attachment
                        command.Parameters.AddWithValue("_Attachment", jhm.Attachment);
                        command.Parameters["_Attachment"].Direction = ParameterDirection.Input;

                        // _Remarks
                        command.Parameters.AddWithValue("_Remarks", jhm.Remarks);
                        command.Parameters["_Remarks"].Direction = ParameterDirection.Input;

                        // _ModifiedBy
                        command.Parameters.AddWithValue("_ModifiedBy", jhm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        int rows_affected = command.ExecuteNonQuery();

                        if (rows_affected > 0)
                        {
                            command.Transaction.Commit();
                            response.message = consts.SUCCESS_INSERT;
                            response.status = consts.SUCCESS;
                            response.code = consts.CODE_OK;
                            response.error = consts.ERROR_FALSE;
                        }
                        else
                        {
                            command.Transaction.Rollback();
                            response.message = consts.ERROR_INSERT;
                            response.status = consts.ERROR;
                            response.code = consts.CODE_ERROR;
                            response.error = consts.ERROR_TRUE;
                        }

                        logs.insertActivityLogs(name: "hris.CN_JOB_HISTORY_INSERT", action: 1, status: response.status, remarks: response.message);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.data = null;

                logs.insertActivityLogs(name: "hris.CN_JOB_HISTORY_INSERT", action: 1, status: response.status, remarks: response.message);
            }
            return response;
        }
        public ResponseModel updateEmployeeJobHistory(JobHistoryModel jhm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_JOB_HISTORY_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // EMP ID 
                        command.Parameters.AddWithValue("_ID", jhm.ID);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;
                        // EMP ID 
                        command.Parameters.AddWithValue("_EmpID", jhm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", jhm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EndDate", jhm.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // _Company
                        command.Parameters.AddWithValue("_Company", jhm.Company);
                        command.Parameters["_Company"].Direction = ParameterDirection.Input;

                        // _Designation
                        command.Parameters.AddWithValue("_Designation", jhm.Designation);
                        command.Parameters["_Designation"].Direction = ParameterDirection.Input;

                        // _Responsibilities
                        command.Parameters.AddWithValue("_Responsibilities", jhm.Responsibilities);
                        command.Parameters["_Responsibilities"].Direction = ParameterDirection.Input;

                        // _Reason for Leaving
                        command.Parameters.AddWithValue("_ReasonForLeaving", jhm.ReasonForLeaving);
                        command.Parameters["_ReasonForLeaving"].Direction = ParameterDirection.Input;

                        // _Attachment
                        command.Parameters.AddWithValue("_Attachment", jhm.Attachment);
                        command.Parameters["_Attachment"].Direction = ParameterDirection.Input;

                        // _Remarks
                        command.Parameters.AddWithValue("_Remarks", jhm.Remarks);
                        command.Parameters["_Remarks"].Direction = ParameterDirection.Input;

                        // _ModifiedBy
                        command.Parameters.AddWithValue("_ModifiedBy", jhm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        int rows_affected = command.ExecuteNonQuery();

                        if (rows_affected > 0)
                        {
                            command.Transaction.Commit();
                            response.message = consts.SUCCESS_UPDATE;
                            response.status = consts.SUCCESS;
                            response.code = consts.CODE_OK;
                            response.error = consts.ERROR_FALSE;
                        }
                        else
                        {
                            command.Transaction.Rollback();
                            response.message = consts.ERROR_UPDATE;
                            response.status = consts.ERROR;
                            response.code = consts.CODE_ERROR;
                            response.error = consts.ERROR_TRUE;
                        }

                        logs.insertActivityLogs(name: "hris.CN_JOB_HISTORY_UPDATE", action: 2, status: response.status, remarks: response.message);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.data = null;

                logs.insertActivityLogs(name: "hris.CN_JOB_HISTORY_UPDATE", action: 2, status: response.status, remarks: response.message);
            }
            return response;
        }

 

        public ResponseModel getEmployeeJobHistoryById( int employeeId, string tableName = "job_history")
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_GET_DATA_BY_ID";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<JobHistoryModel> list_jhm = new List<JobHistoryModel>();

                        command.Parameters.AddWithValue("_tablename", tableName);
                        command.Parameters["_tablename"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_EmpID", employeeId);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                JobHistoryModel jhm = new JobHistoryModel();

                                jhm.ID = Convert.ToInt32(rdr["ID"]);
                                jhm.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                jhm.StartDate = Convert.ToDateTime(rdr["StartDate"]).ToString("MMMM dd, yyyy");
                                jhm.EndDate = Convert.ToDateTime(rdr["EndDate"]).ToString("MMMM dd, yyyy");
                                jhm.Company = rdr["Company"].ToString();
                                jhm.Designation = rdr["Designation"].ToString();
                                jhm.Responsibilities = rdr["Responsibilities"].ToString();
                                jhm.ReasonForLeaving = rdr["ReasonForLeaving"].ToString();
                                jhm.Attachment = rdr["Attachment"].ToString();
                                jhm.Remarks = rdr["Remarks"].ToString();
                                jhm.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                jhm.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                jhm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_jhm.Add(jhm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_jhm;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_GET_DATA_BY_ID", action: 5, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.code = consts.CODE_ERROR;
                response.status = consts.ERROR;
                response.data = null;

                logs.insertActivityLogs(name: "hris.CN_GET_DATA_BY_ID", action: 5, status: response.status, remarks: response.message);
            }

            return response;
        }

     
    }

}