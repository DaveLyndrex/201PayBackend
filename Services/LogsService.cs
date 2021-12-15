using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BackEnd.Services
{
    public class LogsService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();

        public ResponseModel getLogsByType(int type)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using(MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_LOGS_GET_BY_TYPE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted, isReadOnly:true);

                        command.Parameters.AddWithValue("_type", type);
                        command.Parameters["_type"].Direction = ParameterDirection.Input;

                        List<LogsModel> list_lms = new List<LogsModel>();

                        MySqlDataReader rdr = command.ExecuteReader();

                        while (rdr.Read())
                        {
                            LogsModel lm = new LogsModel();

                            lm.ID = rdr["ID"] != null ? Convert.ToInt32(rdr["ID"]) : 0;

                            if (type == 3)
                            {
                                lm.Action = rdr["Action"] != null ? Convert.ToInt32(rdr["Action"]) : 0;
                                lm.EmpID = rdr["EmpID"] != null ? rdr["EmpID"].ToString() : "";
                                lm.Table = rdr["Table"] != null ? rdr["Table"].ToString() : "";
                                lm.Column = rdr["Column"] != null ? rdr["Column"].ToString() : "";
                                lm.Row = rdr["Row"] != null ? Convert.ToInt32(rdr["Row"]) : 0;
                                lm.OldValue = rdr["OldValue"] != null ? rdr["OldValue"].ToString() : "";
                                lm.NewValue = rdr["NewValue"] != null ? rdr["NewValue"].ToString() : "";
                            }
                            if (type == 2)
                            {
                                lm.StoredProc = rdr["StoredProc"] != null ? rdr["StoredProc"].ToString() : "";
                                //lm.Username = rdr["Username"] != null ? rdr["Username"].ToString() : "";
                                lm.IPAddress = rdr["IPAddress"] != null ? rdr["IPAddress"].ToString() : "";
                                lm.Status = rdr["Status"] != null ? rdr["Status"].ToString() : "";
                                lm.Remarks = rdr["Remarks"] != null ? rdr["Remarks"].ToString() : "";
                                lm.CreatedDate = rdr["CreatedDate"] != null ? rdr["CreatedDate"].ToString() : "";
                            }
                            if (type == 1)
                            {
                                lm.Username = rdr["Username"] != null ? rdr["Username"].ToString() : "";
                                lm.IPAddress = rdr["IPAddress"] != null ? rdr["IPAddress"].ToString() : "";
                                lm.Status = rdr["Status"] != null ? rdr["Status"].ToString() : "";
                                lm.Remarks = rdr["Remarks"] != null ? rdr["Remarks"].ToString() : "";
                                lm.CreatedDate = rdr["CreatedDate"] != null ? rdr["CreatedDate"].ToString() : "";
                            }
                            lm.ModifiedDate = rdr["ModifiedDate"] != null ? rdr["ModifiedDate"].ToString() : "";
                            lm.ModifiedBy = rdr["ModifiedBy"] != null ? rdr["ModifiedBy"].ToString() : "";

                            list_lms.Add(lm);
                        }

                        response.code = consts.CODE_OK;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        response.data = list_lms;
                        response.message = "SUCCESS";
                    }
                }

            } 
            catch(Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.status = consts.ERROR;
                response.error = consts.ERROR_TRUE;
                response.data = null;
            }

            return response;
        }
       
        public ResponseModel insertUserLoggedInLogs(string clientIp, string username = null, string email = null, string status = null , string remarks = null)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_ACCESS_LOGS_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        if (username == null)
                        {
                            command.Parameters.AddWithValue("_Username", email);
                            command.Parameters["_Username"].Direction = ParameterDirection.Input;
                        }
                        else
                        {
                            command.Parameters.AddWithValue("_Username", username);
                            command.Parameters["_Username"].Direction = ParameterDirection.Input;
                        }
                        command.Parameters.AddWithValue("_IPAddress", clientIp);
                        command.Parameters["_IPAddress"].Direction = ParameterDirection.Input;
                        command.Parameters.AddWithValue("_Status", status);
                        command.Parameters["_Status"].Direction = ParameterDirection.Input;
                        command.Parameters.AddWithValue("_Remarks", remarks);
                        command.Parameters["_Remarks"].Direction = ParameterDirection.Input;

                        int row_count = command.ExecuteNonQuery();

                        if(row_count > 0)
                        {
                            command.Transaction.Commit();
                            response.message = consts.SUCCESS_INSERT;
                            response.error = consts.ERROR_FALSE;
                            response.status = consts.SUCCESS;
                            response.code = consts.CODE_OK;
                            response.data = null;
                        }
                        else
                        {
                            command.Transaction.Rollback();
                            response.message = "ERROR IN ADDING ACCESS RECORDS";
                            response.error = consts.ERROR_TRUE;
                            response.status = consts.ERROR;
                            response.code = consts.CODE_ERROR;
                            response.data = null;
                        }
                        conn.Close();
                    }
                }    
            }
            catch(Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;
                response.data = null;
            }
            return response;
        }

        public ResponseModel insertActivityLogs(string name, int action, string status = null, string remarks = null) // action : 1 - Add, 2 - Update, 3 - Delete, 4 - Get, 5 - GetById
        {
            var clientIp = "";

            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_ACTIVITY_LOGS_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        command.Parameters.AddWithValue("_IPAddress", clientIp);
                        command.Parameters["_IPAddress"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Action", action);
                        command.Parameters["_Action"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_StoredProc", name);
                        command.Parameters["_StoredProc"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Status", status);
                        command.Parameters["_Status"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Remarks", remarks);
                        command.Parameters["_Remarks"].Direction = ParameterDirection.Input;

                        int row_count = command.ExecuteNonQuery();

                        if (row_count > 0)
                        {
                            command.Transaction.Commit();
                            response.message = "SUCCESS";
                            response.error = consts.ERROR_FALSE;
                            response.status = consts.SUCCESS;
                            response.code = consts.CODE_OK;
                            response.data = null;
                        }
                        else
                        {
                            command.Transaction.Rollback();
                            response.message = "ERROR IN ADDING ACCESS RECORDS";
                            response.error = consts.ERROR_TRUE;
                            response.status = consts.ERROR;
                            response.code = consts.CODE_ERROR;
                            response.data = null;
                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;
                response.data = null;
            }
            return response;
        }

        public ResponseModel insertLogsToDb(ChangeLogsModel clg)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_CHANGE_LOGS_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        command.Parameters.AddWithValue("_EmpID", clg.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Action", clg.Action);
                        command.Parameters["_Action"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Table", clg.Table);
                        command.Parameters["_Table"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Column", clg.Column);
                        command.Parameters["_Column"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Row", clg.Row);
                        command.Parameters["_Row"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_OldValue", clg.OldValue);
                        command.Parameters["_OldValue"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_NewValue", clg.NewValue);
                        command.Parameters["_NewValue"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_ModifiedBy", clg.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        int row_count = command.ExecuteNonQuery();

                        if (row_count > 0)
                        {
                            command.Transaction.Commit();
                            response.message = consts.SUCCESS;
                            response.error = consts.ERROR_FALSE;
                            response.status = consts.SUCCESS;
                            response.code = consts.CODE_OK;
                            response.data = null;
                        }
                        else
                        {
                            command.Transaction.Rollback();
                            response.message = consts.ERROR;
                            response.error = consts.ERROR_TRUE;
                            response.status = consts.ERROR;
                            response.code = consts.CODE_ERROR;
                            response.data = null;
                        }
                        conn.Close();
                        insertActivityLogs(name: "CN_CHANGE_LOGS_INSERT", action: 1, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;
                response.data = null;

                insertActivityLogs(name: "CN_CHANGE_LOGS_INSERT", action: 1, status: response.status, remarks: response.message);
            }
            return response;
        }
    }
}