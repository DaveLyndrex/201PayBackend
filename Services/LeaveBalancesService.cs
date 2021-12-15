using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
// [10 / 12 / 2021 CN CRUBIO]

namespace BackEnd.Services
{
    public class LeaveBalancesService
    {

        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        // GET: LeaveBalanceService
        public ResponseModel getAllLeaveBalances(string _tablename = "CN_LEAVE_CREDIT_BALANCES_V")
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "hris.CN_GET_DATA_ALL";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<LeaveBalancesModel> list_lb = new List<LeaveBalancesModel>();

                        command.Parameters.AddWithValue("_tablename", _tablename);
                        command.Parameters["_tablename"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["EmployeeIDNo"] != null)
                            {
                                LeaveBalancesModel lb = new LeaveBalancesModel();
                                lb.EmployeeIDNo = Convert.ToInt32(rdr["EmployeeIDNo"]);
                                lb.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                lb.LeaveType = rdr["LeaveType"].ToString();
                                lb.StartDate = rdr["LCY_StartDate"].ToString();
                                lb.EndDate = rdr["LCY_EndDate"].ToString();
                                lb.CarriedOverExpiry =rdr["CarriedOverExpiry"].ToString();
                                lb.ExpiredCarriedOver = Convert.ToDecimal(rdr["ExpiredCarriedOver"]);
                                lb.Beginning = Convert.ToDecimal(rdr["Beginning"]);
                                lb.CarriedOver = Convert.ToDecimal(rdr["CarriedOver"]);
                                lb.TotalBegCredits = Convert.ToDecimal(rdr["TotalBeginningCredits"]);
                                lb.Approved = Convert.ToDecimal(rdr["Approved"]);
                                lb.Balance = Convert.ToDecimal(rdr["Balance"]);


                                list_lb.Add(lb);
                            }
                        }
                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_lb;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_LEAVE_CREDIT_BALANCES_V", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.data = null;
                response.error = consts.ERROR_TRUE;
                logs.insertActivityLogs(name: "hris.CN_LEAVE_CREDIT_BALANCES_V", action: 4, status: response.status, remarks: response.message);
            }


            return response;
        }


        public ResponseModel getLeaveCreditYear()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "SELECT Year FROM hris.mf_leave_credit_year_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<int> list = new List<int>();
                        MySqlDataReader reader = command.ExecuteReader();
                        int year;

                        while (reader.Read())
                        {
                            year = Convert.ToInt32(reader["Year"]);
                            list.Add(year);
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT Year FROM hris.mf_leave_credit_crear_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.CODE_ERROR;
                response.data = null;
                logs.insertActivityLogs(name: "SELECT Year FROM hris.mf_leave_credit_crear_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }
    }
}