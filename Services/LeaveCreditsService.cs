/* 10/08/2021 CN E.Patot */
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace BackEnd.Services
{
    public class LeaveCreditsService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel createEmployeeLeaveCredits(LeaveCreditsModel lcm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_LEAVE_CREDITS_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // EMP ID 
                        command.Parameters.AddWithValue("_EmpID", lcm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                       // _LeaveType
                        command.Parameters.AddWithValue("_LeaveTypeID", lcm.LeaveType);
                        command.Parameters["_LeaveTypeID"].Direction = ParameterDirection.Input;

                        // _StartDate
                         command.Parameters.AddWithValue("_StartDate", lcm.StartDate);
                         command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                         command.Parameters.AddWithValue("_EndDate", lcm.EndDate);
                         command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // _Beginning
                        command.Parameters.AddWithValue("_Beginning", lcm.Beginning);
                         command.Parameters["_Beginning"].Direction = ParameterDirection.Input;

                         // _CarriedOver
                         command.Parameters.AddWithValue("_CarriedOver", lcm.CarriedOver);
                         command.Parameters["_CarriedOver"].Direction = ParameterDirection.Input;

                        // _CarriedOverExpiry
                        command.Parameters.AddWithValue("_CarriedOverExpiry", lcm.CarriedOverExpiry);
                        command.Parameters["_CarriedOverExpiry"].Direction = ParameterDirection.Input;

                        // ModifiedBy "
                        command.Parameters.AddWithValue("_ModifiedBy", lcm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        // _LeaveCreditYear
                        command.Parameters.AddWithValue("_LCYID", lcm.LeaveCreditYear);
                        command.Parameters["_LCYID"].Direction = ParameterDirection.Input;

                        int rows_affected = command.ExecuteNonQuery();

                        if (rows_affected > 0)
                        {
                            command.Transaction.Commit();
                            response.message = consts.SUCCESS_INSERT;   
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

                        logs.insertActivityLogs(name: "hris.CN_LEAVE_CREDITS_INSERT", action: 1, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "hris.CN_LEAVE_CREDITS_INSERT", action: 1, status: response.status, remarks: response.message);
            }
            return response;
        }
        public ResponseModel updateEmployeeLeaveCredits(LeaveCreditsModel lcm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_LEAVE_CREDITS_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // ID 
                        command.Parameters.AddWithValue("_ID", lcm.ID);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        // EMP ID 
                        command.Parameters.AddWithValue("_EmpID", lcm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _LeaveTypeID
                        command.Parameters.AddWithValue("_LeaveTypeID", lcm.LeaveType);
                        command.Parameters["_LeaveTypeID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", lcm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EndDate", lcm.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // _Beginning
                        command.Parameters.AddWithValue("_Beginning", lcm.Beginning);
                        command.Parameters["_Beginning"].Direction = ParameterDirection.Input;

                        // _CarriedOver
                        command.Parameters.AddWithValue("_CarriedOver", lcm.CarriedOver);
                        command.Parameters["_CarriedOver"].Direction = ParameterDirection.Input;

                        // _CarriedOverExpiry
                        command.Parameters.AddWithValue("_CarriedOverExpiry", lcm.CarriedOverExpiry);
                        command.Parameters["_CarriedOverExpiry"].Direction = ParameterDirection.Input;

                        // _ModifiedBy
                        command.Parameters.AddWithValue("_ModifiedBy", lcm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        // _LeaveCreditYear
                        command.Parameters.AddWithValue("_LCYID", lcm.LeaveCreditYear);
                        command.Parameters["_LCYID"].Direction = ParameterDirection.Input;

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

                        logs.insertActivityLogs(name: "hris.CN_LEAVE_CREDITS_UPDATE", action: 2, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "hris.CN_LEAVE_CREDITS_UPDATE", action: 2, status: response.status, remarks: response.message);
            }
            return response;
        }


       
        public ResponseModel getEmployeeLeaveCreditsById(int employeeId, string tableName = "leave_credits")
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = " SELECT * FROM hris.CN_EMPLOYEE_LEAVE_CREDIT_V WHERE (NOW() BETWEEN StartDate AND EndDate) AND EmpID = '" + employeeId + "'";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<LeaveCreditsModel> list_lcm = new List<LeaveCreditsModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                LeaveCreditsModel lcm = new LeaveCreditsModel();

                                lcm.ID = Convert.ToInt32(rdr["ID"]);
                                lcm.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                lcm.LeaveCreditYear = Convert.ToInt32(rdr["Year"]);
                                lcm.StartDate = Convert.ToDateTime(rdr["StartDate"]).ToString("MMMM dd, yyyy");
                                lcm.EndDate = Convert.ToDateTime(rdr["EndDate"]).ToString("MMMM dd, yyyy");
                                lcm.LeaveType = Convert.ToString(rdr["LeaveType"]);
                                lcm.Beginning = Convert.ToString(rdr["Beginning"]);
                                lcm.CarriedOver = Convert.ToString(rdr["CarriedOver"]);
                                lcm.CarriedOverExpiry = Convert.ToDateTime(rdr["CarriedOverExpiry"]).ToString("MMMM dd, yyyy hh:mm ss");
                                lcm.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                lcm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_lcm.Add(lcm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_lcm;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.CN_EMPLOYEE_LEAVE_CREDIT_V WHERE (NOW() BETWEEN StartDate AND EndDate) AND EmpID = '" + employeeId + "'", action: 5, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "SELECT * FROM hris.CN_EMPLOYEE_LEAVE_CREDIT_V WHERE (NOW() BETWEEN StartDate AND EndDate) AND EmpID = '" + employeeId + "'", action: 5, status: response.status, remarks: response.message);
            }

            return response;
        }
        

    }
}