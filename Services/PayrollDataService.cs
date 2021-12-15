/*[10/05/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;


namespace BackEnd.Services
{
    public class PayrollDataService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel getAllPayrollDataById(int empid)
        {
            try
            {
                //Connecting to Database
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.CN_EMPLOYEE_PAYROLL_DATA_V WHERE (NOW() BETWEEN StartDate AND EndDate) AND EmpID = '" + empid + "'";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
             

                        MySqlDataReader rdr = command.ExecuteReader();
                        List<PayrollDataModel> list_pd = new List<PayrollDataModel>();
                        while (rdr.Read())
                        {
                            PayrollDataModel pd = new PayrollDataModel();
                            if (rdr["ID"] != null)
                            {
                                pd.ID = Convert.ToInt32(rdr["ID"]);
                                pd.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                pd.StartDate = Convert.ToDateTime(rdr["StartDate"]).ToString("MM/dd/yyyy");
                                pd.EndDate = Convert.ToDateTime(rdr["EndDate"]).ToString("MM/dd/yyyy");
                                pd.HDMFContribution = Math.Round(Convert.ToDecimal(rdr["HDMFContribution"]), 2);
                                pd.PayrollGroupID = rdr["PayrollGroup"].ToString();
                                pd.TimekeepingID = Convert.ToString(rdr["Timekeeping"]);
                                pd.TaxStatusID = Convert.ToString(rdr["TaxStatus"]);
                                pd.PayFrequencyID = Convert.ToString(rdr["PayFrequency"]);
                                pd.ShiftSetID = Convert.ToString(rdr["ShiftSetName"]);
                                pd.DMAccountID = Convert.ToString(rdr["Description"]);
                                pd.Remarks = rdr["Remarks"].ToString();
                                pd.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MM/dd/yyyy hh:mm ss"); ;
                                pd.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MM/dd/yyyy hh:mm ss"); ;
                                pd.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_pd.Add(pd);
                            }
                        }
                        response.code = consts.CODE_OK;
                        response.status = consts.SUCCESS;
                        response.error = consts.ERROR_FALSE;
                        response.message = consts.SUCCESS_RETRIEVE;
                        response.data = list_pd;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.CN_EMPLOYEE_PAYROLL_DATA_V WHERE (NOW() BETWEEN StartDate AND EndDate) AND EmpID = '" + empid + "'", action: 4, status: response.status, remarks: response.message);
                    }
                }

            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.CN_EMPLOYEE_PAYROLL_DATA_V WHERE (NOW() BETWEEN StartDate AND EndDate) AND EmpID = '" + empid + "'", action: 4, status: response.status, remarks: response.message);
            }

            return response;
        }

        public ResponseModel createPayrollData(PayrollDataModel pd)
        {
            try
            {
                using(MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_PAYROLL_DATA_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                        

                        command.Parameters.AddWithValue("_EmpID", pd.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_StartDate", pd.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_EndDate", pd.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_HDMFContribution", pd.HDMFContribution);
                        command.Parameters["_HDMFContribution"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_PayrollGroupID", pd.PayrollGroupID);
                        command.Parameters["_PayrollGroupID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_TimekeepingID", pd.TimekeepingID);
                        command.Parameters["_TimekeepingID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_TaxStatusID", pd.TaxStatusID);
                        command.Parameters["_TaxStatusID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_PayFrequencyID", pd.PayFrequencyID);
                        command.Parameters["_PayFrequencyID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_ShiftSetID", pd.ShiftSetID);
                        command.Parameters["_ShiftSetID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_DMAccountID", pd.DMAccountID);
                        command.Parameters["_DMAccountID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Remarks", pd.Remarks);
                        command.Parameters["_Remarks"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_ModifiedBy", pd.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        int row_count = command.ExecuteNonQuery();

                        if (row_count > 0)
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
                        logs.insertActivityLogs(name: "hris.CN_PAYROLL_DATA_INSERT", action: 1, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "hris.CN_PAYROLL_DATA_INSERT", action: 1, status: response.status, remarks: response.message);
            }

            return response;
        }

        public ResponseModel updatePayrollData(PayrollDataModel pd)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_PAYROLL_DATA_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                        command.Parameters.Clear();

                        command.Parameters.AddWithValue("_id", pd.ID);
                        command.Parameters["_id"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_EmpID", pd.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_StartDate", pd.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_EndDate", pd.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_HDMFContribution", pd.HDMFContribution);
                        command.Parameters["_HDMFContribution"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_PayrollGroupID", pd.PayrollGroupID);
                        command.Parameters["_PayrollGroupID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_TimekeepingID", pd.TimekeepingID);
                        command.Parameters["_TimekeepingID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_TaxStatusID", pd.TaxStatusID);
                        command.Parameters["_TaxStatusID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_PayFrequencyID", pd.PayFrequencyID);
                        command.Parameters["_PayFrequencyID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_ShiftSetID", pd.ShiftSetID);
                        command.Parameters["_ShiftSetID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_DMAccountID", pd.DMAccountID);
                        command.Parameters["_DMAccountID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Remarks", pd.Remarks);
                        command.Parameters["_Remarks"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_ModifiedBy", pd.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        int rows_affected = command.ExecuteNonQuery();

                        if(rows_affected > 0)
                        {
                            command.Transaction.Commit();
                            response.code = consts.CODE_OK;
                            response.status = consts.SUCCESS;
                            response.error = consts.ERROR_FALSE;
                            response.message = consts.SUCCESS_UPDATE;
                            response.data = null;
                        }
                        else
                        {
                            command.Transaction.Rollback();
                            response.code = consts.CODE_ERROR;
                            response.status = consts.ERROR;
                            response.error = consts.ERROR_TRUE;
                            response.message = consts.ERROR_UPDATE;
                            response.data = null;
                        }
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_PAYROLL_DATA_UPDATE", action: 2, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "hris.CN_PAYROLL_DATA_UPDATE", action: 2, status: response.status, remarks: response.message);

            }

            return response;
        }

       /* public ResponseModel deletePayrollData(int id)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_PAYROLL_DATA_DELETE";
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
                            response.status = consts.SUCCESS;
                            response.error = consts.ERROR_TRUE;
                            response.message = consts.ERROR_DELETE;
                            response.data = null;
                        }
                        conn.Close();
                        logs.insertActivityLogs(name: "hris.CN_PAYROLL_DATA_DELETE", action: 3, status: response.status, remarks: response.message);

                    }
                }
            } 
            catch(Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.status = consts.ERROR;
                response.error = consts.ERROR_TRUE;

                logs.insertActivityLogs(name: "hris.CN_PAYROLL_DATA_DELETE", action: 3, status: response.status, remarks: response.message);
            }
            return response;
        }*/
    }
}