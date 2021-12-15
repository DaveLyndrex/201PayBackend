using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

/*10/07/2021 CN CRUBIO*/

namespace BackEnd.Services
{
    public class TimeKeepingService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();
        private static int payrollID;

        //get all Period 
        public ResponseModel getPeriod(string payrollgroup)
        {
            int payrollgroupid = payrollGroup(payrollgroup);
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        TimeKeepingModel tkm = new TimeKeepingModel();

                        command.CommandText = "SELECT CONCAT(DATE_FORMAT(StartDate, '%m/%d/%Y'),' - ',DATE_FORMAT(EndDate, '%m/%d/%Y'), ' (', PeriodID, ' ', Year, ')') FROM hris.period_setup " +
                            "WHERE PayrollGroupID = '" + payrollgroupid + "'";

                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<string> list = new List<string>();
                        MySqlDataReader reader = command.ExecuteReader();
                        string datas = "";

                        while (reader.Read())
                        {
                            datas = reader.GetString(0);
                            list.Add(datas);
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: command.CommandText = "SELECT CONCAT(DATE_FORMAT(StartDate, '%m/%d/%Y'),' - ',DATE_FORMAT(EndDate, '%m/%d/%Y'), ' (', PeriodID, ' ', Year, ')') FROM hris.period_setup " +
                            "WHERE PayrollGroupID = '" + payrollgroupid + "'", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.CODE_ERROR;
                response.data = null;
                logs.insertActivityLogs(name: "SELECT CONCAT(DATE_FORMAT(StartDate, '%m/%d/%Y'),' - ',DATE_FORMAT(EndDate, '%m/%d/%Y'), ' (', PeriodID, ' ', Year, ')') FROM hris.period_setup " +
                            "WHERE PayrollGroupID = '" + payrollgroupid + "'", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        //get all location
        public ResponseModel getLocation(string payrollgroup)
     {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "SELECT Location FROM hris.CN_EMPLOYEE_MASTER_CURRENT_V where PayrollGroup = '" + payrollgroup + "'";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<string> list = new List<string>();
                        MySqlDataReader reader = command.ExecuteReader();
                        string location;

                        list.Add("All");

                        while (reader.Read())
                        {
                            //location = reader.GetString(0);
                             if(reader.GetString(0).ToString() != null)
                             {
                                location = reader.GetString(0);
                                list.Add(location);
                             }
                             else
                             {
                                location = "";
                             }

                           // list.Add(location);
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT Location FROM hris.CN_EMPLOYEE_MASTER_CURRENT_V where PayrollGroup = '" + payrollgroup + "'",
                            action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {

                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.CODE_ERROR;
                response.data = null;
                logs.insertActivityLogs(name: "SELECT Location FROM hris.CN_EMPLOYEE_MASTER_CURRENT_V where PayrollGroup = '" + payrollgroup + "'",
                    action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        // get specific employee location
        public ResponseModel getSpecificEmployeeLocation(string payrollgroup, string location)
        {

            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        List<PayrollPeriodModel> list = new List<PayrollPeriodModel>();

                        if (location != "All")
                        {
                            command.CommandText = "SELECT CONCAT(Lastname,', ', Firstname, ' ', Middlename) FROM hris.CN_EMPLOYEE_MASTER_CURRENT_V " +
                                "where Location = '" + location + "' AND PayrollGroup = '" + payrollgroup + "'";
                            command.CommandType = CommandType.Text;
                            command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            MySqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                PayrollPeriodModel ppm = new PayrollPeriodModel();
                                ppm.Employee = reader.GetString(0);
                                list.Add(ppm);
                            }
                            response.code = consts.CODE_OK;
                            response.status = consts.SUCCESS;
                            response.error = consts.ERROR_FALSE;
                            response.message = consts.SUCCESS_RETRIEVE;
                            response.data = list;
                            conn.Close();

                            logs.insertActivityLogs(name: "SELECT CONCAT(Lastname,', ', Firstname, ' ', Middlename) FROM hris.CN_EMPLOYEE_MASTER_CURRENT_V " +
                                "where Location = '" + location + "' AND PayrollGroup = '" + payrollgroup + "'", action: 4, status: response.status, remarks: response.message);

                        }
                        else
                        {

                            int payrollgroupid = payrollGroup(payrollgroup);
                            command.CommandText = "SELECT CONCAT(Lastname,', ', Firstname, ' ', Middlename) FROM hris.CN_EMPLOYEE_MASTER_CURRENT_V WHERE PayrollGroupID ='" + payrollgroupid + "'";
                            command.CommandType = CommandType.Text;
                            command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                            MySqlDataReader reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                PayrollPeriodModel ppm = new PayrollPeriodModel();
                                ppm.Employee = reader.GetString(0);
                                list.Add(ppm);
                            }

                            response.code = consts.CODE_OK;
                            response.status = consts.SUCCESS;
                            response.error = consts.ERROR_FALSE;
                            response.message = consts.SUCCESS_RETRIEVE;
                            response.data = list;
                            conn.Close();

                            logs.insertActivityLogs(name: "SELECT CONCAT(Lastname,', ', Firstname, ' ', Middlename) FROM hris.CN_EMPLOYEE_MASTER_CURRENT_V " +
                                "where Location = '" + location + "' AND PayrollGroup = '" + payrollgroup + "'", action: 4, status: response.status, remarks: response.message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.CODE_ERROR;
                response.data = null;
                logs.insertActivityLogs(name: "SELECT CONCAT(Lastname,', ', Firstname, ' ', Middlename) FROM hris.CN_EMPLOYEE_MASTER_CURRENT_V " +
                                "where Location = '" + location + "' AND PayrollGroup = '" + payrollgroup + "'", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        // get all payroll group
        public ResponseModel getPayrollGroup()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_payroll_group_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<string> payrollList = new List<string>();

                        MySqlDataReader reader = command.ExecuteReader();

                        string payroll;
                        while (reader.Read())
                        {

                            payroll = reader["PayrollGroup"].ToString();
                            payrollList.Add(payroll);
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = payrollList;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT PayrollGroup FROM hris.period_setup", action: 4, status: response.status, remarks: response.message);
                    }


                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.data = null;
                logs.insertActivityLogs(name: "SELECT PayrollGroup FROM hris.period_setup", action: 4, status: response.status, remarks: response.message);

            }
            return response;
        }

        //get all employee base on payroll group
        public ResponseModel getEmployee(string payrollgroup)
        {
            int payrollgroupid = payrollGroup(payrollgroup);
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "SELECT CONCAT(Lastname,', ', Firstname, ' ', Middlename) AS name, EmpID FROM hris.CN_EMPLOYEE_MASTER_CURRENT_V " +
                           "WHERE PayrollGroupID ='" + payrollgroupid + "'";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);


                        List<PayrollPeriodModel> employee = new List<PayrollPeriodModel>();
                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            PayrollPeriodModel ppm = new PayrollPeriodModel();
                            ppm.Employee = reader["name"].ToString();
                            ppm.EmployeeID = Convert.ToInt32(reader["EmpID"]);
                            employee.Add(ppm);
                        }

                        response.code = consts.CODE_OK;
                        response.status = consts.SUCCESS;
                        response.error = consts.ERROR_FALSE;
                        response.message = consts.SUCCESS_RETRIEVE;
                        response.data = employee;

                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT CONCAT(Lastname,', ', Firstname, ' ', Middlename) AS name, EmpID FROM hris.CN_EMPLOYEE_MASTER_CURRENT_V WHERE PayrollGroupID ='" + payrollgroupid + "'",
                            action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {

                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "SELECT CONCAT(Lastname,', ', Firstname, ' ', Middlename) AS name, EmpID FROM hris.CN_EMPLOYEE_MASTER_CURRENT_V WHERE PayrollGroupID ='" + payrollgroupid + "'",
                    action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        // get timesheet current exception 
        public ResponseModel viewExceptionReport(string payrollgroup)
        {
            int payrollgroupid = payrollGroup(payrollgroup);
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "SELECT * FROM CN_TIMESHEET_SUMMARY_CURRENT_EXCEPTION_V WHERE Validated = 0";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<TimeKeepingModel> exceptionReport = new List<TimeKeepingModel>();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["In1"].ToString() == "0" && reader["Out1"].ToString() == "0" && reader["In2"].ToString() == "0" & reader["Out2"].ToString() == "0" ||
                                reader["In1"].ToString() == "0" && reader["Out1"].ToString() == "0" || reader["In2"].ToString() == "0" & reader["Out2"].ToString() == "0")
                            {

                                TimeKeepingModel report = new TimeKeepingModel();
                                report.EmpID = Convert.ToInt32(reader["EmpID"]);
                                report.ID = Convert.ToInt32(reader["Id"]);
                                report.Date = Convert.ToDateTime(reader["Date"]).ToString("MMMM dd, yyyy");
                                report.DayType = reader["DayTypeCode"].ToString();
                                report.Shift = reader["ShiftCode"].ToString();
                                report.In1 = reader["In1"].ToString();
                                report.Out1 = reader["Out1"].ToString();
                                report.In2 = reader["In2"].ToString();
                                report.Out2 = reader["Out2"].ToString();
                                report.RawDTR = reader["Raw_DTR"].ToString();
                                report.COA = reader["Requested_COA"].ToString();
                                report.Leave = reader["Requested_Leave"].ToString();
                                report.Tardy1 = reader["Tardy_Hrs1"].ToString();
                                report.Absent1 = reader["Abs_Hrs1"].ToString();
                                report.Undertime1 = reader["UT_Hrs1"].ToString();
                                report.Tardy2 = reader["Tardy_Hrs2"].ToString();
                                report.Absent2 = reader["Abs_Hrs2"].ToString();
                                report.Undertime2 = reader["UT_Hrs2"].ToString();
                                report.ReqOT = reader["Requested_OT"].ToString();
                                report.OTHrs = reader["OT_Hrs"].ToString();
                                report.OT = reader["OT_Hrs"].ToString();
                                report.ND = reader["ND_Hrs"].ToString();
                                report.Validate = Convert.ToInt32(reader["Validated"]);
                                if (Convert.ToInt32(reader["Validated"]) == 0)
                                {
                                    report.Valid = false;
                                }
                                else
                                {
                                    report.Valid = true;
                                }
                                exceptionReport.Add(report);
                            }
                        }
                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = exceptionReport;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();
                        logs.insertActivityLogs(name: "SELECT * FROM CN_TIMESHEET_SUMMARY_CURRENT_EXCEPTION_V " +
                            "WHERE PayrollGroupID = '" + payrollgroupid + "' AND Validated = 0", action: 4, status: response.status, remarks: response.message);
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
                logs.insertActivityLogs(name: "SELECT * FROM CN_TIMESHEET_SUMMARY_CURRENT_EXCEPTION_V " +
                    "WHERE PayrollGroupID = '" + payrollgroupid + "' AND Validated = 0", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        // get specific employee timesheet current exception
        public ResponseModel getSpecificEmployeeTimesheet(PayrollPeriodModel ppm)
        {
            int payrollgroupid = payrollGroup(ppm.PayrollGroup);
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        List<TimeKeepingModel> timesheet = new List<TimeKeepingModel>();
                        if (ppm.ButtonName == "View Exception Report")
                        {
                            command.CommandText = "SELECT * FROM hris.CN_TIMESHEET_SUMMARY_CURRENT_EXCEPTION_V WHERE PayrollGroupID = '" + payrollgroupid + "'" +
                            " AND CONCAT(Lastname,', ', Firstname,' ', Middlename) LIKE '%" + ppm.Employee + "%' AND Validated=0";
                            command.CommandType = CommandType.Text;
                            command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            MySqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                if (reader["In1"].ToString() == "0" && reader["Out1"].ToString() == "0" && reader["In2"].ToString() == "0" & reader["Out2"].ToString() == "0" ||
                                    reader["In1"].ToString() == "0" && reader["Out1"].ToString() == "0" || reader["In2"].ToString() == "0" & reader["Out2"].ToString() == "0")
                                {

                                    TimeKeepingModel report = new TimeKeepingModel();
                                    report.EmpID = Convert.ToInt32(reader["EmpID"]);
                                    report.ID = Convert.ToInt32(reader["Id"]);
                                    report.Date = Convert.ToDateTime(reader["Date"]).ToString("MMMM dd, yyyy");
                                    report.DayType = reader["DayTypeCode"].ToString();
                                    report.Shift = reader["ShiftCode"].ToString();
                                    report.In1 = reader["In1"].ToString();
                                    report.Out1 = reader["Out1"].ToString();
                                    report.In2 = reader["In2"].ToString();
                                    report.Out2 = reader["Out2"].ToString();
                                    report.RawDTR = reader["Raw_DTR"].ToString();
                                    report.COA = reader["Requested_COA"].ToString();
                                    report.Leave = reader["Requested_Leave"].ToString();
                                    report.Tardy1 = reader["Tardy_Hrs1"].ToString();
                                    report.Absent1 = reader["Abs_Hrs1"].ToString();
                                    report.Undertime1 = reader["UT_Hrs1"].ToString();
                                    report.Tardy2 = reader["Tardy_Hrs2"].ToString();
                                    report.Absent2 = reader["Abs_Hrs2"].ToString();
                                    report.Undertime2 = reader["UT_Hrs2"].ToString();
                                    report.ReqOT = reader["Requested_OT"].ToString();
                                    report.OTHrs = reader["OT_Hrs"].ToString();
                                    report.OT = reader["OT_Hrs"].ToString();
                                    report.ND = reader["ND_Hrs"].ToString();
                                    report.Validate = Convert.ToInt32(reader["Validated"]);
                                    if (Convert.ToInt32(reader["Validated"]) == 0)
                                    {
                                        report.Valid = false;
                                    }
                                    else
                                    {
                                        report.Valid = true;
                                    }

                                    timesheet.Add(report);
                                }
                            }
                        }
                        else
                        {
                            command.CommandText = "SELECT * FROM hris.CN_TIMESHEET_SUMMARY_ALL_V WHERE CONCAT(Lastname,', ', Firstname,' ', Middlename) LIKE '%" + ppm.Employee + "%'";
                            command.CommandType = CommandType.Text;



                            MySqlDataReader reader = command.ExecuteReader();


                            while (reader.Read())
                            {
                                TimeKeepingModel ptimesheet = new TimeKeepingModel();
                                ptimesheet.EmpID = Convert.ToInt32(reader["EmpID"]);
                                ptimesheet.ID = Convert.ToInt32(reader["ID"]);
                                ptimesheet.Date = Convert.ToDateTime(reader["Date"]).ToString("MMMM dd, yyyy");
                                ptimesheet.DayType = reader["DayTypeCode"].ToString();
                                ptimesheet.Shift = reader["ShiftCode"].ToString();
                                ptimesheet.In1 = reader["In1"].ToString();
                                ptimesheet.Out1 = reader["Out1"].ToString();
                                ptimesheet.In2 = reader["In2"].ToString();
                                ptimesheet.Out2 = reader["Out2"].ToString();
                                ptimesheet.RawDTR = reader["Raw_DTR"].ToString();
                                ptimesheet.COA = reader["Requested_COA"].ToString();
                                ptimesheet.Leave = reader["Requested_Leave"].ToString();
                                ptimesheet.Tardy1 = reader["Tardy_Hrs1"].ToString();
                                ptimesheet.Absent1 = reader["Abs_Hrs1"].ToString();
                                ptimesheet.Undertime1 = reader["UT_Hrs1"].ToString();
                                ptimesheet.Tardy2 = reader["Tardy_Hrs2"].ToString();
                                ptimesheet.Absent2 = reader["Abs_Hrs2"].ToString();
                                ptimesheet.Undertime2 = reader["UT_Hrs2"].ToString();
                                ptimesheet.ReqOT = reader["Requested_OT"].ToString();
                                ptimesheet.OTHrs = reader["OT_Hrs"].ToString();
                                ptimesheet.OT = reader["OT_Hrs"].ToString();
                                ptimesheet.ND = reader["ND_Hrs"].ToString();
                                ptimesheet.Validate = Convert.ToInt32(reader["Validated"]);

                                if (Convert.ToInt32(reader["Validated"]) == 0)
                                {
                                    ptimesheet.Valid = false;
                                }
                                else
                                {
                                    ptimesheet.Valid = true;
                                }

                                timesheet.Add(ptimesheet);

                            }

                        }


                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = timesheet;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();
                        logs.insertActivityLogs(name: "SELECT * FROM hris.CN_TIMESHEET_SUMMARY_CURRENT_EXCEPTION_V WHERE PayrollGroupID = '" + payrollgroupid + "'" +
                            " AND CONCAT(Lastname,', ', Firstname,' ', Middlename) LIKE '%" + ppm.Employee + "%' AND Validated=0", action: 4, status: response.status, remarks: response.message);
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
                logs.insertActivityLogs(name: "SELECT * FROM hris.CN_TIMESHEET_SUMMARY_CURRENT_EXCEPTION_V WHERE PayrollGroupID = '" + payrollgroupid + "'" +
                            " AND CONCAT(Lastname,', ', Firstname,' ', Middlename) LIKE '%" + ppm.Employee + "%' AND Validated=0", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        // check if validated
        public Boolean validatedTimesheetChecker(string payrollgroup)
        {
            Boolean checker = false;
            using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
            {
                conn.Open();
                using (MySqlCommand command = conn.CreateCommand())
                {

                    int payrollgroupid = payrollGroup(payrollgroup);

                    if (payrollgroupid != 0)
                    {

                        command.CommandText = "SELECT * FROM hris.CN_TIMESHEET_SUMMARY_CURRENT_EXCEPTION_V WHERE Validated = 0 and PayrollGroupID = '" + payrollgroupid + "'";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                        int count = 0;
                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            count++;
                        }

                        if (count > 0)
                        {
                            checker = false;
                        }
                        else
                        {
                            checker = true;
                        }

                    }
                    else
                    {

                        checker = false;
                    }

                }
            }

            return checker;
        }
        // Post Timesheet
        public ResponseModel postTimesheet(string _modifiedby, string payrollgroup)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        Boolean checker = validatedTimesheetChecker(payrollgroup);

                        if (checker == true)
                        {

                            command.CommandText = "hris.CN_POST_TIMESHEET";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            command.Parameters.AddWithValue("_modifiedby", _modifiedby);
                            command.Parameters["_modifiedby"].Direction = ParameterDirection.Input;

                            response.code = consts.CODE_OK;
                            response.status = consts.SUCCESS;
                            response.error = consts.ERROR_FALSE;
                            response.message = "Timesheet Posted";
                            response.data = null;


                            conn.Close();
                            logs.insertActivityLogs(name: "hris.CN_POST_TIMESHEET", action: 2, status: response.status, remarks: response.message);
                        }
                        else
                        {
                            response.message = "Please Validate All Timesheet";
                            response.error = consts.ERROR_TRUE;
                            response.status = consts.ERROR;
                            response.code = consts.CODE_ERROR;
                        }


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
                logs.insertActivityLogs(name: "hris.CN_POST_TIMESHEET", action: 2, status: response.status, remarks: response.message);
            }
            return response;
        }

        // get Current Period
        public ResponseModel getCurrentPeriod(string payrollgroup)
        {
            PayrollPeriodModel ppm = new PayrollPeriodModel();
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        int payrollgroupid = payrollGroup(payrollgroup);
                        command.CommandText = "SELECT CONCAT(DATE_FORMAT(StartDate, '%m/%d/%Y'), ' - ', DATE_FORMAT(EndDate, '%m/%d/%Y'), ' (', PeriodID, ' ', Year, ')') FROM hris.period_setup " +
                            "WHERE PeriodID = (SELECT ProfileValue FROM hris.mf_system_profile WHERE ProfileCode ='CURRENT_PERIOD') " +
                            "AND Year = (SELECT ProfileValue FROM hris.mf_system_profile WHERE ProfileCode ='CURRENT_YEAR')" +
                            "AND PayrollGroupID = '" + payrollgroupid + "'";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<PayrollPeriodModel> list = new List<PayrollPeriodModel>();
                        MySqlDataReader reader = command.ExecuteReader();


                        while (reader.Read())
                        {
                            ppm.ConcattedPeriod = reader.GetString(0);
                            list.Add(ppm);
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT CONCAT(StartDate,' - ',EndDate, ' (', PeriodID, ' ', Year, ')') as data FROM hris.period_setup " +
                            "WHERE PeriodID = (SELECT ProfileValue FROM hris.mf_system_profile WHERE ProfileCode ='CURRENT_PERIOD') " +
                            "AND Year = (SELECT ProfileValue FROM hris.mf_system_profile WHERE ProfileCode ='CURRENT_YEAR')" +
                            "AND PayrollGroupID = (SELECT ID FROM hris.mf_payroll_group_setup WHERE PayrollGroup = '" + payrollgroup + "')",
                            action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.CODE_ERROR;
                response.data = null;
                logs.insertActivityLogs(name: "SELECT CONCAT(StartDate,' - ',EndDate, ' (', PeriodID, ' ', Year, ')') as data FROM hris.period_setup " +
                            "WHERE PeriodID = (SELECT ProfileValue FROM hris.mf_system_profile WHERE ProfileCode ='CURRENT_PERIOD') " +
                            "AND Year = (SELECT ProfileValue FROM hris.mf_system_profile WHERE ProfileCode ='CURRENT_YEAR')" +
                            "AND PayrollGroupID = (SELECT ID FROM hris.mf_payroll_group_setup WHERE PayrollGroup = '" + payrollgroup + "')",
                            action: 4, status: response.status, remarks: response.message);
            }

            return response;
        }

        //Process Timesheet
        public ResponseModel processTimesheet(string modifiedby, string payrollgroup)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();

                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        int payrollgroupid = payrollGroup(payrollgroup);

                        command.CommandText = "hris.CN_PROCESS_TIMESHEET";
                        command.CommandType = CommandType.StoredProcedure;

                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        command.Parameters.AddWithValue("_modifiedby", modifiedby);
                        command.Parameters["_modifiedby"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_payrollgroupid", payrollgroupid);
                        command.Parameters["_payrollgroupid"].Direction = ParameterDirection.Input;

                        string result = "";
                        DataSet ds = new DataSet();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow row in dt.Rows)
                        {
                            result = row["SUCCESS"].ToString();
                        }

                        if (result == "SUCCESS")
                        {

                            response.message = consts.SUCCESS_RETRIEVE;
                            response.code = consts.CODE_OK;
                            response.data = result;
                            response.error = consts.ERROR_FALSE;
                        }
                        logs.insertActivityLogs(name: "hris.CN_PROCESS_TIMESHEET", action: 4, status: response.status, remarks: response.message);
                        conn.Close();

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
                logs.insertActivityLogs(name: "hris.CN_PROCESS_TIMESHEET", action: 4, status: response.status, remarks: response.message);

            }
            return response;
        }

        //exportCSV 

        public ResponseModel exportCSV(PayrollPeriodModel ppm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();

                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        if (ppm.ButtonName == "Process Timesheet")
                        {

                            command.CommandText = "SELECT * FROM hris.CN_TIMESHEET_SUMMARY_ALL_V WHERE EmpID = '" + ppm.EmployeeID + "'";
                            command.CommandType = CommandType.Text;

                            command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                            MySqlDataReader reader = command.ExecuteReader();
                            List<TimeKeepingModel> list = new List<TimeKeepingModel>();

                            while (reader.Read())
                            {
                                TimeKeepingModel timesheet = new TimeKeepingModel();
                                timesheet.EmpID = Convert.ToInt32(reader["EmpID"]);
                                timesheet.ID = Convert.ToInt32(reader["ID"]);
                                timesheet.Date = Convert.ToDateTime(reader["Date"]).ToString("MMMM dd, yyyy");
                                timesheet.DayType = reader["DayTypeCode"].ToString();
                                timesheet.Shift = reader["ShiftCode"].ToString();
                                timesheet.In1 = reader["In1"].ToString();
                                timesheet.Out1 = reader["Out1"].ToString();
                                timesheet.In2 = reader["In2"].ToString();
                                timesheet.Out2 = reader["Out2"].ToString();
                                timesheet.RawDTR = reader["Raw_DTR"].ToString();
                                timesheet.COA = reader["Requested_COA"].ToString();
                                timesheet.Leave = reader["Requested_Leave"].ToString();
                                timesheet.Tardy1 = reader["Tardy_Hrs1"].ToString();
                                timesheet.Absent1 = reader["Abs_Hrs1"].ToString();
                                timesheet.Undertime1 = reader["UT_Hrs1"].ToString();
                                timesheet.Tardy2 = reader["Tardy_Hrs2"].ToString();
                                timesheet.Absent2 = reader["Abs_Hrs2"].ToString();
                                timesheet.Undertime2 = reader["UT_Hrs2"].ToString();
                                timesheet.ReqOT = reader["Requested_OT"].ToString();
                                timesheet.OTHrs = reader["OT_Hrs"].ToString();
                                timesheet.OT = reader["OT_Hrs"].ToString();
                                timesheet.ND = reader["ND_Hrs"].ToString();
                                timesheet.Validate = Convert.ToInt32(reader["Validated"]);

                                if (Convert.ToInt32(reader["Validated"]) == 0)
                                {
                                    timesheet.Valid = false;
                                }
                                else
                                {
                                    timesheet.Valid = true;
                                }

                                list.Add(timesheet);

                            }
                            response.message = consts.SUCCESS_RETRIEVE;
                            response.code = consts.CODE_OK;
                            response.data = list;
                            response.error = consts.ERROR_FALSE;

                            logs.insertActivityLogs(name: "SELECT * FROM hris.CN_TIMESHEET_SUMMARY_V", action: 4, status: response.status, remarks: response.message);

                        }
                        else if (ppm.ButtonName == "View Exception Report")
                        {

                            command.CommandText = "SELECT * FROM hris.CN_TIMESHEET_SUMMARY_CURRENT_EXCEPTION_V WHERE Validated = 0";
                            command.CommandType = CommandType.Text;

                            MySqlDataReader reader = command.ExecuteReader();
                            List<TimeKeepingModel> list = new List<TimeKeepingModel>();

                            while (reader.Read())
                            {
                                TimeKeepingModel timesheet = new TimeKeepingModel();
                                timesheet.EmpID = Convert.ToInt32(reader["EmpID"]);
                                timesheet.ID = Convert.ToInt32(reader["ID"]);
                                timesheet.Date = Convert.ToDateTime(reader["Date"]).ToString("MMMM dd, yyyy");
                                timesheet.DayType = reader["DayTypeCode"].ToString();
                                timesheet.Shift = reader["ShiftCode"].ToString();
                                timesheet.In1 = reader["In1"].ToString();
                                timesheet.Out1 = reader["Out1"].ToString();
                                timesheet.In2 = reader["In2"].ToString();
                                timesheet.Out2 = reader["Out2"].ToString();
                                timesheet.RawDTR = reader["Raw_DTR"].ToString();
                                timesheet.COA = reader["Requested_COA"].ToString();
                                timesheet.Leave = reader["Requested_Leave"].ToString();
                                timesheet.Tardy1 = reader["Tardy_Hrs1"].ToString();
                                timesheet.Absent1 = reader["Abs_Hrs1"].ToString();
                                timesheet.Undertime1 = reader["UT_Hrs1"].ToString();
                                timesheet.Tardy2 = reader["Tardy_Hrs2"].ToString();
                                timesheet.Absent2 = reader["Abs_Hrs2"].ToString();
                                timesheet.Undertime2 = reader["UT_Hrs2"].ToString();
                                timesheet.ReqOT = reader["Requested_OT"].ToString();
                                timesheet.OTHrs = reader["OT_Hrs"].ToString();
                                timesheet.OT = reader["OT_Hrs"].ToString();
                                timesheet.ND = reader["ND_Hrs"].ToString();
                                timesheet.Validate = Convert.ToInt32(reader["Validated"]);



                                list.Add(timesheet);

                            }
                            response.message = consts.SUCCESS_RETRIEVE;
                            response.code = consts.CODE_OK;
                            response.data = list;
                            response.error = consts.ERROR_FALSE;
                            logs.insertActivityLogs(name: "SELECT * FROM hris.CN_TIMESHEET_SUMMARY_CURRENT_EXCEPTION_V", action: 4, status: response.status, remarks: response.message);
                        }


                        conn.Close();

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
                logs.insertActivityLogs(name: "hris.CN_PROCESS_TIMESHEET", action: 4, status: response.status, remarks: response.message);

            }
            return response;
        }

        // Validate the timesheet
        public ResponseModel validateTimesheet(TimeKeepingModel tkm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "UPDATE hris.timesheet_summary_current SET Validated = '" + tkm.Validate + "' WHERE ID = '" + tkm.ID + "'";
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
                        logs.insertActivityLogs(name: "UPDATE hris.timesheet_summary_current SET Validated = '" + tkm.Validate + "' WHERE ID = '" + tkm.ID + "'",
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
                logs.insertActivityLogs(name: "UPDATE hris.timesheet_summary_current SET Validated = '" + tkm.Validate + "' WHERE ID = '" + tkm.ID + "'",
                    action: 2, status: response.status, remarks: response.message);
            }

            return response;
        }

        public ResponseModel ValidateAllUserTimesheet(PayrollPeriodModel ppm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();

                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "UPDATE hris.timesheet_summary_current SET Validated = 1 WHERE EmpID = '" + ppm.EmployeeID + "'";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        int row_count = command.ExecuteNonQuery();

                        if (row_count > 1)
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
                        logs.insertActivityLogs(name: "UPDATE hris.timesheet_summary_current SET Validated =1", action: 2, status: response.status, remarks: response.message);
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
                logs.insertActivityLogs(name: "UPDATE hris.timesheet_summary_current SET Validated =1", action: 2, status: response.status, remarks: response.message);

            }
            return response;
        }

        //Get specific Payroll Group ID
        public int payrollGroup(string payrollgroup)
        {

            TimeKeepingModel tkm = new TimeKeepingModel();
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT ID FROM hris.mf_payroll_group_setup WHERE PayrollGroup ='" + payrollgroup + "'" +
                            " ";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                        tkm.PayrollGroup = payrollgroup;

                        MySqlDataReader reader = command.ExecuteReader();


                        while (reader.Read())
                        {
                            payrollID = reader.GetInt32(0);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                response.message = ex.Message;
            }

            return payrollID;
        }


    }
}

