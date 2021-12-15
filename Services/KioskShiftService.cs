using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace BackEnd.Services
{
    public class KioskShiftService
    {
        // GET: KioskShiftService
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel getAllKioskShift(string _tablename = "CN_SHIFT_V")
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

                        List<KioskShiftModel> list_shift = new List<KioskShiftModel>();

                        command.Parameters.AddWithValue("_tablename", _tablename);
                        command.Parameters["_tablename"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["EmpID"] != null)
                            {
                                KioskShiftModel ks = new KioskShiftModel();
                                ks.ID = Convert.ToInt32(rdr["ID"]);
                                ks.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                ks.RequestID = Convert.ToInt32(rdr["RequestID"]);
                                ks.FormID = Convert.ToInt32(rdr["FormID"]);
                                ks.Form = rdr["Form"].ToString();
                                ks.RequestEmpID = Convert.ToInt32(rdr["RequesterEmpID"]);
                                ks.Date = Convert.ToDateTime(rdr["Date"]);
                                ks.Requester = rdr["RequesterName"].ToString();
                                ks.CreatedBy = rdr["RequesterName"].ToString();
                                ks.Shift = Convert.ToInt32(rdr["FormID"])==1?"Rest Day":"Regular Day";
                                ks.Reason = rdr["Reason"].ToString();
                                ks.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]);
                                ks.Status = serve.status(Convert.ToInt32(rdr["Status"]));


                                list_shift.Add(ks);
                            }
                        }
                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_shift;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_SHIFT_V", action: 4, status: response.status, remarks: response.message);
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
                logs.insertActivityLogs(name: "hris.CN_SHIFT_V", action: 4, status: response.status, remarks: response.message);
            }


            return response;
        }
    }
}