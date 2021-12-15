using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace BackEnd.Services
{
    public class UndertimeRawService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel getUndertimeRaw(string EmpID)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_UNDERTIME_RAW_GET";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                        command.Parameters.Clear();

                        command.Parameters.AddWithValue("_EmpID", EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        List<UndertimeRawModel> list_urm = new List<UndertimeRawModel>();

                        MySqlDataReader dataReader = command.ExecuteReader();
                        while (dataReader.Read())
                        {
                            if(dataReader["ID"] != null)
                            {
                                UndertimeRawModel urm = new UndertimeRawModel();
                                urm.ID = Convert.ToInt32(dataReader["ID"]);
                                urm.EmpID = Convert.ToInt32(dataReader["EmpID"]);
                                urm.RequestID = Convert.ToInt32(dataReader["RequestID"]);
                                urm.Paid = Convert.ToInt32(dataReader["Paid"]);
                                urm.Date = dataReader["Date"].ToString();
                                urm.Time1 = dataReader["Time1"].ToString();
                                urm.Time2 = dataReader["Time2"].ToString();
                                urm.PeriodID = Convert.ToInt32(dataReader["PeriodID"]);
                                urm.Year = Convert.ToInt32(dataReader["Year"]);
                                urm.CreatedDate = dataReader["CreatedDate"].ToString();
                                urm.ModifiedBy = dataReader["ModifiedBy"].ToString();
                                urm.ModifiedDate = dataReader["ModifiedDate"].ToString();
                                list_urm.Add(urm);
                            }
                        }
                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_urm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_UNDERTIME_RAW_GET", action: 3, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "hris.CN_UNDERTIME_RAW_GET", action: 3, status: response.status, remarks: response.message);
            }
            return response;
        }

        //create Undertime_Raw
        public ResponseModel createUndertimeRaw(UndertimeRawModel undertimeRawModel)
        {
            try
            {
                using(MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using(MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_UNDERTIME_RAW_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                        command.Parameters.Clear();

                        command.Parameters.AddWithValue("_EmpID", undertimeRawModel.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_RequestID", undertimeRawModel.RequestID);
                        command.Parameters["_RequestID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Paid", undertimeRawModel.Paid);
                        command.Parameters["_Paid"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Date", undertimeRawModel.Date);
                        command.Parameters["_Date"].Direction = ParameterDirection.Input;


                        command.Parameters.AddWithValue("_Time1", undertimeRawModel.Time1);
                        command.Parameters["_Time1"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Time2", undertimeRawModel.Time2);
                        command.Parameters["_Time2"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_PeriodID", undertimeRawModel.PeriodID);
                        command.Parameters["_PeriodID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Year", undertimeRawModel.Year);
                        command.Parameters["_Year"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_ModifiedBy", undertimeRawModel.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        int row_count = command.ExecuteNonQuery();

                        if(row_count == 1)
                        {
                            response.code = consts.CODE_OK;
                            response.status = consts.SUCCESS;
                            response.error = consts.ERROR_FALSE;
                            response.message = consts.SUCCESS_INSERT;
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
                        logs.insertActivityLogs(name: "hris.CN_UNDERTIME_RAW_INSERT", action: 1, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "hris.CN_UNDERTIME_RAW_INSERT", action: 1, status: response.status, remarks: response.message);
            }
            return response;
        }

       
        public ResponseModel updateUndertimeRaw(UndertimeRawModel undertimeRawModel)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_UNDERTIME_RAW_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                        command.Parameters.Clear();

                        command.Parameters.AddWithValue("_ID", undertimeRawModel.ID);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_EmpID", undertimeRawModel.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_RequestID", undertimeRawModel.RequestID);
                        command.Parameters["_RequestID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Paid", undertimeRawModel.Paid);
                        command.Parameters["_Paid"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Date", undertimeRawModel.Date);
                        command.Parameters["_Date"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Time1", undertimeRawModel.Time1);
                        command.Parameters["_Time1"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Time2", undertimeRawModel.Time2);
                        command.Parameters["_Time2"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_PeriodID", undertimeRawModel.PeriodID);
                        command.Parameters["_PeriodID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Year", undertimeRawModel.Year);
                        command.Parameters["_Year"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_ModifiedBy", undertimeRawModel.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        int rows_affected = command.ExecuteNonQuery();

                        if(rows_affected > 0)
                        {
                            response.code = consts.CODE_OK;
                            response.status = consts.SUCCESS;
                            response.error = consts.ERROR_FALSE;
                            response.message = consts.SUCCESS_UPDATE;
                            response.data = null;
                            command.Transaction.Commit();
                        }
                        else
                        {
                            response.code = consts.CODE_ERROR;
                            response.status = consts.ERROR;
                            response.error = consts.ERROR_TRUE;
                            response.message = consts.ERROR_UPDATE;
                            response.data = null;
                            command.Transaction.Rollback();
                        }
                        conn.Close();
                        logs.insertActivityLogs(name: "hris.CN_APPROVAL_WORKFLOW_UPDATE", action: 1, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "hris.CN_UNDERTIME_RAW_UPDATE", action: 1, status: response.status, remarks: response.message);
            }

            return response;
        }

        public ResponseModel deleteUndertimeRaw(int id)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using(MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_UNDERTIME_RAW_DELETE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                        command.Parameters.Clear();

                        command.Parameters.AddWithValue("_ID", id);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        int rows_affected = command.ExecuteNonQuery();

                        if(rows_affected == 1)
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
                        logs.insertActivityLogs(name: "hris.CN_UNDERTIME_RAW_DELETE", action: 3, status: response.status, remarks: response.message);

                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "hris.CN_UNDERTIME_RAW_DELETE", action: 3, status: response.status, remarks: response.message);
            }
            return response;
        }

    }
}