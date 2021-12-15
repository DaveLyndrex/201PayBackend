using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BackEnd.Services
{
    public class OvertimeService
    {
        // GET: OvetimeService


        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel getAllOvertime(string _tablename = "CN_OVERTIME_V")
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

                        List<OvertimeModel> list_ot = new List<OvertimeModel>();

                        command.Parameters.AddWithValue("_tablename", _tablename);
                        command.Parameters["_tablename"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["EmpID"] != null)
                            {
                                OvertimeModel ot = new OvertimeModel();
                                ot.ID = Convert.ToInt32(rdr["ID"]);
                                ot.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                ot.RequestID = Convert.ToInt32(rdr["RequestID"]);
                                ot.FormID = Convert.ToInt32(rdr["FormID"]);
                                ot.Form = rdr["Form"].ToString();
                                ot.RequestEmpID = Convert.ToInt32(rdr["RequesterEmpID"]);
                                //ot.Date = Convert.ToDateTime(rdr["Date"]);
                                ot.Requester = rdr["RequesterName"].ToString();
                                ot.CreatedBy = rdr["RequesterName"].ToString();
                                ot.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]);
                                ot.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                                ot.EndDate = Convert.ToDateTime(rdr["EndDate"]);
                                ot.StartTime = rdr["StartTime"].ToString();
                                ot.EndTime = rdr["EndTime"].ToString();
                                ot.Reason = rdr["Reason"].ToString();
                                ot.Status = serve.status(Convert.ToInt32(rdr["Status"]));
                                list_ot.Add(ot);
                            }
                        }
                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_ot;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_OVERTIME_V", action: 4, status: response.status, remarks: response.message);
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
                logs.insertActivityLogs(name: "hris.CN_OVERTIME_V", action: 4, status: response.status, remarks: response.message);
            }


            return response;
        }


    }
}