/*[10/07/2021] CN E.Patot*/
/*[10/20/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;


namespace BackEnd.Services
{
    public class PayComponentServices
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel getAllPayComponentById(int empid)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using(MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.CN_EMPLOYEE_RATE_V WHERE (NOW() BETWEEN StartDate AND EndDate) AND EmpID = '" + empid +"'";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                      

                        MySqlDataReader dataReader = command.ExecuteReader();
                        List<PayComponentModel> list_pc = new List<PayComponentModel>();

                        while(dataReader.Read())
                        {
                            PayComponentModel pc = new PayComponentModel();

                            if(dataReader["ID"] != null)
                            {
                                pc.ID = Convert.ToInt32(dataReader["ID"]);
                                pc.EmpID = Convert.ToInt32(dataReader["EmpID"]);
                                pc.StartDate = Convert.ToDateTime(dataReader["StartDate"]).ToString("MM/dd/yyyy");
                                pc.EndDate = Convert.ToDateTime(dataReader["EndDate"]).ToString("MM/dd/yyyy");
                                pc.PayCodeID = Convert.ToString(dataReader["PayCode"]);
                                pc.TypeID = Convert.ToString(dataReader["PayComponentType"]);
                                pc.Amount = Convert.ToDecimal(dataReader["Amount"]).ToString();
                                pc.PeriodID = Convert.ToInt32(dataReader["PeriodID"]).ToString();
                                pc.Year = Convert.ToInt32(dataReader["Year"]).ToString();
                                pc.PayRateID = Convert.ToString(dataReader["PayRate"]);
                                pc.Currency = Convert.ToString(dataReader["Code"]);
                                pc.StartProcessPeriod = Convert.ToString(dataReader["StartProcessPeriod"]);
                                pc.Forex = Convert.ToDecimal(dataReader["Forex"]).ToString();
                                pc.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                pc.ModifiedDate = Convert.ToDateTime(dataReader["ModifiedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                pc.ModifiedBy = dataReader["ModifiedBy"].ToString();

                                list_pc.Add(pc);
                            }
                        }
                        response.code = consts.CODE_OK;
                        response.status = consts.SUCCESS;
                        response.error = consts.ERROR_FALSE;
                        response.message = consts.SUCCESS_RETRIEVE;
                        response.data = list_pc;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.CN_EMPLOYEE_RATE_V WHERE (NOW() BETWEEN StartDate AND EndDate) AND EmpID = '" + empid + "'", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "SELECT * FROM hris.CN_EMPLOYEE_RATE_V WHERE (NOW() BETWEEN StartDate AND EndDate) AND EmpID = '" + empid + "'", action: 4, status: response.status, remarks: response.message);
            }

            return response;
        }

        public ResponseModel createPayComponent(PayComponentModel pcm)
        {
            try
            {
                using(MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using(MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_SALARY_RATE_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                        command.Parameters.Clear();

                        command.Parameters.AddWithValue("_EmpID", pcm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_StartDate", pcm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_EndDate", pcm.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_PayCodeID", pcm.PayCodeID);
                        command.Parameters["_PayCodeID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_TypeID", pcm.TypeID);
                        command.Parameters["_TypeID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Amount", pcm.Amount);
                        command.Parameters["_Amount"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_PeriodID", pcm.StartProcessPeriod);
                        command.Parameters["_PeriodID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_PayRateID", pcm.PayRateID);
                        command.Parameters["_PayRateID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Currency", pcm.Currency);
                        command.Parameters["_Currency"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Forex", pcm.Forex);
                        command.Parameters["_Forex"].Direction = ParameterDirection.Input;
                        
                        command.Parameters.AddWithValue("_ModifiedBy", pcm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        int row_count = command.ExecuteNonQuery();

                        if(row_count == 1)
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
                        logs.insertActivityLogs(name: "hris.CN_SALARY_RATE_INSERT", action: 1, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "hris.CN_SALARY_RATE_INSERT", action: 1, status: response.status, remarks: response.message);
            }

            return response;
        }

        public ResponseModel updatePayComponent(PayComponentModel pcm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_SALARY_RATE_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                        command.Parameters.Clear();

                        command.Parameters.AddWithValue("_id", pcm.ID);
                        command.Parameters["_id"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_EmpID", pcm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_StartDate", pcm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_EndDate", pcm.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_PayCodeID", pcm.PayCodeID);
                        command.Parameters["_PayCodeID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_TypeID", pcm.TypeID);
                        command.Parameters["_TypeID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Amount", pcm.Amount);
                        command.Parameters["_Amount"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_PeriodID", pcm.StartProcessPeriod);
                        command.Parameters["_PeriodID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_PayRateID", pcm.PayRateID);
                        command.Parameters["_PayRateID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Currency", pcm.Currency);
                        command.Parameters["_Currency"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Forex", pcm.Forex);
                        command.Parameters["_Forex"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_ModifiedBy", pcm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        int rows_affected = command.ExecuteNonQuery();

                        if (rows_affected > 0)
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
                        logs.insertActivityLogs(name: "hris.CN_SALARY_RATE_UPDATE", action: 2, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "hris.CN_SALARY_RATE_UPDATE", action: 2, status: response.status, remarks: response.message);
            }

            return response;
        }

        /*public ResponseModel deletePayComponent(int id)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_SALARY_RATE_DELETE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                        command.Parameters.Clear();

                        command.Parameters.AddWithValue("_id", id);
                        command.Parameters["_id"].Direction = ParameterDirection.Input;

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
                            response.status = consts.SUCCESS;
                            response.error = consts.ERROR_TRUE;
                            response.message = consts.ERROR_DELETE;
                            response.data = null;
                        }
                        conn.Close();
                        logs.insertActivityLogs(name: "hris.CN_SALARY_RATE_DELETE", action: 3, status: response.status, remarks: response.message);
                    }
                }
            }
            catch(Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.status = consts.ERROR;
                response.error = consts.ERROR_TRUE;

                logs.insertActivityLogs(name: "hris.CN_SALARY_RATE_DELETE", action: 3, status: response.status, remarks: response.message);
            }
            return response;
        }*/
    }
}