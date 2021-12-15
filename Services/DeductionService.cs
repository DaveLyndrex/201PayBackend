/*[10/08/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace BackEnd.Services
{
    public class DeductionService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel createEmployeeDeduction(DeductionModel dm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_DEDUCTIONS_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        #region
                        // EMP ID 
                        command.Parameters.AddWithValue("_EmpID", dm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", dm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;
                        // _DeductionID
                        command.Parameters.AddWithValue("_DeductionID", dm.DeductionID);
                        command.Parameters["_DeductionID"].Direction = ParameterDirection.Input;

                        // _TotalAmount
                        command.Parameters.AddWithValue("_TotalAmount", dm.TotalAmount);
                        command.Parameters["_TotalAmount"].Direction = ParameterDirection.Input;

                        // _DeductionAmount
                        command.Parameters.AddWithValue("_DeductionAmount", dm.DeductionAmount);
                        command.Parameters["_DeductionAmount"].Direction = ParameterDirection.Input;

                        // _FrequencyID
                        command.Parameters.AddWithValue("_FrequencyID", dm.FrequencyID);
                        command.Parameters["_FrequencyID"].Direction = ParameterDirection.Input;

                        // _Status
                        command.Parameters.AddWithValue("_Status", dm.Status);
                        command.Parameters["_Status"].Direction = ParameterDirection.Input;

                        // _Remarks
                        command.Parameters.AddWithValue("_Remarks", dm.Remarks);
                        command.Parameters["_Remarks"].Direction = ParameterDirection.Input;

                        // _ModifiedBy
                        command.Parameters.AddWithValue("_ModifiedBy", dm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;
                        #endregion

                        int rows_affected = command.ExecuteNonQuery();

                        if (rows_affected > 0)
                        {
                            response.message = consts.SUCCESS_INSERT;
                            response.status = consts.SUCCESS;
                            response.code = consts.CODE_OK;
                            response.error = consts.ERROR_FALSE;
                            command.Transaction.Commit();
                        }
                        else
                        {
                            response.message = consts.ERROR_INSERT;
                            response.status = consts.ERROR;
                            response.code = consts.CODE_ERROR;
                            response.error = consts.ERROR_TRUE;
                            command.Transaction.Rollback();
                        }
                    }
                    conn.Close();

                    logs.insertActivityLogs(name: "hris.CN_DEDUCTIONS_INSERT", action: 1, status: response.status, remarks: response.message);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.data = null;

                logs.insertActivityLogs(name: "hris.CN_DEDUCTIONS_INSERT", action: 1, status: response.status, remarks: response.message);
            }
            return response;
        }
        public ResponseModel updateEmployeeDeduction(DeductionModel dm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_DEDUCTIONS_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        #region
                        // id
                        command.Parameters.AddWithValue("_ID", dm.ID);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        // EMP ID 
                        command.Parameters.AddWithValue("_EmpID", dm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", dm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _DeductionID
                        command.Parameters.AddWithValue("_DeductionID", dm.DeductionID);
                        command.Parameters["_DeductionID"].Direction = ParameterDirection.Input;

                        // _TotalAmount
                        command.Parameters.AddWithValue("_TotalAmount", dm.TotalAmount);
                        command.Parameters["_TotalAmount"].Direction = ParameterDirection.Input;

                        // _DeductionAmount
                        command.Parameters.AddWithValue("_DeductionAmount", dm.DeductionAmount);
                        command.Parameters["_DeductionAmount"].Direction = ParameterDirection.Input;

                        // _FrequencyID
                        command.Parameters.AddWithValue("_FrequencyID", dm.FrequencyID);
                        command.Parameters["_FrequencyID"].Direction = ParameterDirection.Input;

                        // _Status
                        command.Parameters.AddWithValue("_Status", dm.Status);
                        command.Parameters["_Status"].Direction = ParameterDirection.Input;

                        // _Remarks
                        command.Parameters.AddWithValue("_Remarks", dm.Remarks);
                        command.Parameters["_Remarks"].Direction = ParameterDirection.Input;

                        // _ModifiedBy
                        command.Parameters.AddWithValue("_ModifiedBy", dm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;
                        #endregion

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
                    }
                    conn.Close();

                    logs.insertActivityLogs(name: "hris.CN_DEDUCTIONS_UPDATE", action: 2, status: response.status, remarks: response.message);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.data = null;

                logs.insertActivityLogs(name: "hris.CN_DEDUCTIONS_UPDATE", action: 2, status: response.status, remarks: response.message);
            }
            return response;
        }

      
        public ResponseModel getEmployeeDeductionById(int id)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.CN_EMPLOYEE_DEDUCTION_V WHERE EmpID ='" + id +"'";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<DeductionModel> list_dm = new List<DeductionModel>();

                        command.Parameters.AddWithValue("_ID", id);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                DeductionModel dm = new DeductionModel();

                                dm.ID = Convert.ToInt32(rdr["ID"]);
                                dm.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                dm.StartDate = Convert.ToDateTime(rdr["StartDate"]).ToString("MM/dd/yyyy");
                                dm.DeductionID = Convert.ToString(rdr["DeductionName"]);
                                dm.TotalAmount = Math.Round(Convert.ToDecimal(rdr["TotalAmount"]),2).ToString();
                                dm.DeductionAmount = Math.Round(Convert.ToDecimal(rdr["DeductionAmount"]),2).ToString();
                                dm.FrequencyID = Convert.ToString(rdr["PayFrequency"]);
                                dm.Status = rdr["Status"].ToString();
                                dm.Remarks = rdr["Remarks"].ToString();
                                dm.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                dm.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                dm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                
                                list_dm.Add(dm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_dm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;

                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.CN_EMPLOYEE_DEDUCTION_V WHERE EmpID = '" + id +"'", action: 5, status: response.status, remarks: response.message);
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
               
                logs.insertActivityLogs(name: "SELECT * FROM hris.CN_EMPLOYEE_DEDUCTION_V WHERE EmpID ='" + id + "'", action: 5, status: response.status, remarks: response.message);
            }
            return response;
        }

      
        
    }
}