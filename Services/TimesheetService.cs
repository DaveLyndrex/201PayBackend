/*[10/14/2021] CN J.Layaog*/
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace BackEnd.Services
{
    public class TimesheetService
    {

        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel getAllTimesheet(string _tablename = "CN_TIMESHEET_SUMMARY_ALL_V")
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

                        List<TimesheetModel> list_tm = new List<TimesheetModel>();

                        command.Parameters.AddWithValue("_tablename", _tablename);
                        command.Parameters["_tablename"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["EmpID"] != null)
                            {
                                TimesheetModel tm = new TimesheetModel();
                                tm.ID = Convert.ToInt32(rdr["ID"]);
                                tm.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                tm.Date = Convert.ToDateTime(rdr["Date"]);
                                tm.DayTypeCode = rdr["DayTypeCode"].ToString();
                                tm.ShiftCode = rdr["ShiftCode"].ToString();
                                tm.In1 = Convert.ToInt32(rdr["In1"]);
                                tm.In2 = Convert.ToInt32(rdr["In2"]);
                                tm.Out1 = Convert.ToInt32(rdr["Out1"]);
                                tm.Out2 = Convert.ToInt32(rdr["Out2"]);
                                tm.RawDTR = rdr["Raw_DTR"].ToString();
                                tm.COA = rdr["Requested_COA"].ToString();
                                tm.Leave = rdr["Requested_Leave"].ToString();
                                tm.Tardy1 = Convert.ToDecimal(rdr["Tardy_Hrs1"]);
                                tm.Absent1 = Convert.ToDecimal(rdr["Abs_Hrs1"]);
                                tm.Undertime1 = Convert.ToDecimal(rdr["UT_Hrs1"]);
                                tm.Tardy2 = Convert.ToDecimal(rdr["Tardy_Hrs2"]);
                                tm.Absent2 = Convert.ToDecimal(rdr["Abs_Hrs2"]);
                                tm.Undertime2 = Convert.ToDecimal(rdr["UT_Hrs2"]);
                                tm.RequestedOT = rdr["Requested_OT"].ToString();
                                tm.RequestedOTHrs = Convert.ToDecimal(rdr["Requested_OT_Hrs"]);
                                tm.OTHrs = Convert.ToDecimal(rdr["OT_Hrs"]);
                                tm.OTHrsPaid = Convert.ToDecimal(rdr["OT_Hrs_Paid"]);
                                tm.NDHrs = Convert.ToDecimal(rdr["ND_Hrs"]);

                                tm.CreatedDate = rdr["CreatedDate"].ToString();
                                tm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                tm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                tm.Validated = Convert.ToInt32(rdr["Validated"]);


                                list_tm.Add(tm);
                            }
                        }
                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_tm;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_TIMESHEET_SUMMARY_ALL_V", action: 4, status: response.status, remarks: response.message);
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
                logs.insertActivityLogs(name: "hris.CN_TIMESHEET_SUMMARY_ALL_V", action: 4, status: response.status, remarks: response.message);
            }


            return response;
        }


        public ResponseModel getSystemProfile()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "SELECT CONCAT(DATE_FORMAT(StartDate, '%m/%d/%Y'), ' - ', DATE_FORMAT(EndDate, '%m/%d/%Y'), ' (', PeriodID, ' ', Year, ')') FROM hris.period_setup " +
                            "WHERE PeriodID = (SELECT ProfileValue FROM hris.mf_system_profile WHERE ProfileCode ='CURRENT_PERIOD') " +
                            "AND Year = (SELECT ProfileValue FROM hris.mf_system_profile WHERE ProfileCode ='CURRENT_YEAR') LIMIT 1";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);



                        string currentperiod = "";
                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            currentperiod = rdr.GetString(0);


                        }
                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = currentperiod;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT CONCAT(DATE_FORMAT(StartDate, '%m/%d/%Y'), ' - ', DATE_FORMAT(EndDate, '%m/%d/%Y'), ' (', PeriodID, ' ', Year, ')') FROM hris.period_setup " +
                            "WHERE PeriodID = (SELECT ProfileValue FROM hris.mf_system_profile WHERE ProfileCode ='CURRENT_PERIOD') " +
                            "AND Year = (SELECT ProfileValue FROM hris.mf_system_profile WHERE ProfileCode ='CURRENT_YEAR') LIMIT 1", action: 4, status: response.status, remarks: response.message);
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
                logs.insertActivityLogs(name: "SELECT CONCAT(DATE_FORMAT(StartDate, '%m/%d/%Y'), ' - ', DATE_FORMAT(EndDate, '%m/%d/%Y'), ' (', PeriodID, ' ', Year, ')') FROM hris.period_setup " +
                            "WHERE PeriodID = (SELECT ProfileValue FROM hris.mf_system_profile WHERE ProfileCode ='CURRENT_PERIOD') " +
                            "AND Year = (SELECT ProfileValue FROM hris.mf_system_profile WHERE ProfileCode ='CURRENT_YEAR') LIMIT 1", action: 4, status: response.status, remarks: response.message);
            }


            return response;
        }


        public ResponseModel validateKioskTimesheet(TimesheetModel m)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "UPDATE hris.timesheet_summary_current SET Validated = '" + m.Validated + "' WHERE ID = '" + m.ID + "'";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        int row_count = command.ExecuteNonQuery();

                        if (row_count == 1)
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
                        logs.insertActivityLogs(name: "UPDATE hris.timesheet_summary_current SET Validated = '" + m.Validated + "' WHERE ID = '" + m.ID + "'",
                            action: 2, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.data = null;
                response.code = consts.CODE_ERROR;
                logs.insertActivityLogs(name: "UPDATE hris.timesheet_summary_current SET Validated = '" + m.Validated + "' WHERE ID = '" + m.ID + "'",
                    action: 2, status: response.status, remarks: response.message);
            }

            return response;
        }



        public ResponseModel filterEmployee(int _empid)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "SELECT* FROM hris.CN_TIMESHEET_SUMMARY_ALL_V WHERE EmpID=" + _empid + " and PeriodID = (SELECT ProfileValue FROM hris.mf_system_profile WHERE ProfileCode='CURRENT_PERIOD')";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<TimesheetModel> list_tm = new List<TimesheetModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["EmpID"] != null)
                            {
                                TimesheetModel tm = new TimesheetModel();
                                tm.ID = Convert.ToInt32(rdr["ID"]);
                                tm.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                tm.Date = Convert.ToDateTime(rdr["Date"]);
                                tm.DayTypeCode = rdr["DayTypeCode"].ToString();
                                tm.ShiftCode = rdr["ShiftCode"].ToString();
                                tm.In1 = Convert.ToInt32(rdr["In1"]);
                                tm.In2 = Convert.ToInt32(rdr["In2"]);
                                tm.Out1 = Convert.ToInt32(rdr["Out1"]);
                                tm.Out2 = Convert.ToInt32(rdr["Out2"]);
                                tm.RawDTR = rdr["Raw_DTR"].ToString();
                                tm.COA = rdr["Requested_COA"].ToString();
                                tm.Leave = rdr["Requested_Leave"].ToString();
                                tm.Tardy1 = Convert.ToDecimal(rdr["Tardy_Hrs1"]);
                                tm.Absent1 = Convert.ToDecimal(rdr["Abs_Hrs1"]);
                                tm.Undertime1 = Convert.ToDecimal(rdr["UT_Hrs1"]);
                                tm.Tardy2 = Convert.ToDecimal(rdr["Tardy_Hrs2"]);
                                tm.Absent2 = Convert.ToDecimal(rdr["Abs_Hrs2"]);
                                tm.Undertime2 = Convert.ToDecimal(rdr["UT_Hrs2"]);
                                tm.RequestedOT = rdr["Requested_OT"].ToString();
                                tm.RequestedOTHrs = Convert.ToDecimal(rdr["Requested_OT_Hrs"]);
                                tm.OTHrs = Convert.ToDecimal(rdr["OT_Hrs"]);
                                tm.OTHrsPaid = Convert.ToDecimal(rdr["OT_Hrs_Paid"]);
                                tm.NDHrs = Convert.ToDecimal(rdr["ND_Hrs"]);

                                tm.CreatedDate = rdr["CreatedDate"].ToString();
                                tm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                tm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                tm.Validated = Convert.ToInt32(rdr["Validated"]);


                                list_tm.Add(tm);
                            }
                        }
                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_tm;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT* FROM hris.CN_TIMESHEET_SUMMARY_ALL_V WHERE EmpID=" + _empid + " and PeriodID = (SELECT ProfileValue FROM hris.mf_system_profile WHERE ProfileCode='CURRENT_PERIOD')", action: 4, status: response.status, remarks: response.message);
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
                logs.insertActivityLogs(name: "SELECT* FROM hris.CN_TIMESHEET_SUMMARY_ALL_V WHERE EmpID=" + _empid + " and PeriodID = (SELECT ProfileValue FROM hris.mf_system_profile WHERE ProfileCode='CURRENT_PERIOD')", action: 4, status: response.status, remarks: response.message);
            }


            return response;
        }


       

        public ResponseModel getPeriod()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "SELECT CONCAT(DATE_FORMAT(StartDate, '%m/%d/%Y'), ' - ', DATE_FORMAT(EndDate, '%m/%d/%Y'), ' (', PeriodID, ' ', Year, ')') FROM hris.period_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<string> list = new List<string>();
                        MySqlDataReader reader = command.ExecuteReader();
                        string period;

                        while (reader.Read())
                        {
                            period = reader.GetString(0);
                            list.Add(period);
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT CONCAT(DATE_FORMAT(StartDate, '%m/%d/%Y'), ' - ', DATE_FORMAT(EndDate, '%m/%d/%Y'), ' (', PeriodID, ' ', Year, ')') FROM hris.period_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.CODE_ERROR;
                response.data = null;
                logs.insertActivityLogs(name: "SELECT CONCAT(DATE_FORMAT(StartDate, '%m/%d/%Y'), ' - ', DATE_FORMAT(EndDate, '%m/%d/%Y'), ' (', PeriodID, ' ', Year, ')')", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getLocation()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT Location FROM hris.mf_location";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<string> list = new List<string>();
                        MySqlDataReader reader = command.ExecuteReader();
                        string location;

                        while (reader.Read())
                        {
                            location = reader["Location"].ToString();
                            list.Add(location);
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT Location FROM hris.mf_location", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {

                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.CODE_ERROR;
                response.data = null;
                logs.insertActivityLogs(name: "SELECT Location FROM hris.mf_location", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }




        public ResponseModel getEmployeeFilter()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "SELECT EmpID, CONCAT(Lastname,', ', Firstname, ' ', Middlename)as Name FROM hris.employee_master";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<FilterEmployeeModel> list_tm = new List<FilterEmployeeModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["EmpID"] != null)
                            {
                                FilterEmployeeModel tm = new FilterEmployeeModel();
                                tm.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                tm.Fullname = rdr["Name"].ToString();



                                list_tm.Add(tm);
                            }
                        }
                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_tm;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT EmpID, CONCAT(Lastname,', ', Firstname, ' ', Middlename)as Name FROM hris.employee_master", action: 4, status: response.status, remarks: response.message);
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
                logs.insertActivityLogs(name: "SELECT EmpID, CONCAT(Lastname,', ', Firstname, ' ', Middlename)as Name FROM hris.employee_master", action: 4, status: response.status, remarks: response.message);
            }


            return response;
        }




    }
}