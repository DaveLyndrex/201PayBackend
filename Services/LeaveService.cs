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
    public class LeaveService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel getAllLeave(string _tablename = "CN_LEAVE_V")
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        EmployeeKioskService serve = new EmployeeKioskService();
                        command.CommandText = "hris.CN_GET_DATA_ALL";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<LeaveModel> list_lv = new List<LeaveModel>();

                        command.Parameters.AddWithValue("_tablename", _tablename);
                        command.Parameters["_tablename"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["EmpID"] != null)
                            {
                                LeaveModel lv = new LeaveModel();
                                lv.ID = Convert.ToInt32(rdr["ID"]);
                                lv.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                lv.RequestID = Convert.ToInt32(rdr["RequestID"]);
                                lv.FormID = Convert.ToInt32(rdr["FormID"]);
                                lv.Form = rdr["Form"].ToString();
                                lv.LeaveType = rdr["LeaveType"].ToString();
                                lv.RequestEmpID = Convert.ToInt32(rdr["RequesterEmpID"]);
                                lv.Date = rdr["Date"].ToString() == "" ? DateTime.Now : Convert.ToDateTime(rdr["Date"]);
                                lv.Requester = rdr["RequesterName"].ToString();
                                lv.CreatedBy = rdr["CreatedBy"].ToString();
                                lv.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]);
                                lv.StartDate = rdr["StartDate"].ToString() == ""? Convert.ToDateTime("1978-12-12") : Convert.ToDateTime(rdr["StartDate"]);
                                lv.EndDate = rdr["EndDate"].ToString() == "" ? Convert.ToDateTime("1978-12-12") : Convert.ToDateTime(rdr["EndDate"]);                  
                                lv.Status = serve.status(Convert.ToInt32(rdr["Status"]));


                                list_lv.Add(lv);
                            }
                        }
                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_lv;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_LEAVE_V", action: 4, status: response.status, remarks: response.message);
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
                logs.insertActivityLogs(name: "hris.CN_LEAVE_V", action: 4, status: response.status, remarks: response.message);
            }


            return response;
        }

        //get SHIFT Details
        public ResponseModel getShiftDetails(int id)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        EmployeeKioskService serve = new EmployeeKioskService();
                        command.CommandText = "select * from hris.mf_shift_setup where ID = (select Mon from hris.mf_shift_set_setup where ID = (select ShiftSetID from hris.payroll_data where EmpID ='"+ id +"' Limit 1 ))";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<ShiftModel> list_sm = new List<ShiftModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {     
                             ShiftModel sm = new ShiftModel();
                            sm.ShiftCode = rdr["ShiftCode"].ToString();
                            sm.ShiftName = rdr["ShiftName"].ToString();
                            sm.In1 = rdr["In1"].ToString();
                            sm.Out1 = rdr["Out1"].ToString();
                            sm.In2 = rdr["In2"].ToString();
                            sm.Out2 = rdr["Out2"].ToString();
                            list_sm.Add(sm);
                            
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_sm;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_LEAVE_V", action: 4, status: response.status, remarks: response.message);
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
                logs.insertActivityLogs(name: "hris.CN_LEAVE_V", action: 4, status: response.status, remarks: response.message);
            }


            return response;
        }

    }
}