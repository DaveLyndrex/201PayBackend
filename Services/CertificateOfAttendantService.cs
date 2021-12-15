/*[10/14/2021] CN J.Layaog*/
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace BackEnd.Services
{
    public class CertificateOfAttendantService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel getAllCertificateOfAttendant(string _tablename = "CN_COA_V")
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

                        List<CertificateOfAttendantModel> lis_coa = new List<CertificateOfAttendantModel>();
                        EmployeeKioskService ek = new EmployeeKioskService();

                        command.Parameters.AddWithValue("_tablename", _tablename);
                        command.Parameters["_tablename"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["EmpID"] != null)
                            {
                                CertificateOfAttendantModel coa = new CertificateOfAttendantModel();
                                coa.ID = Convert.ToInt32(rdr["ID"]);
                                coa.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                coa.RequestID = Convert.ToInt32(rdr["RequestID"]);
                                coa.FormID = Convert.ToInt32(rdr["FormID"]);
                                coa.Form = rdr["Form"].ToString();
                                coa.RequestEmpID = Convert.ToInt32(rdr["RequesterEmpID"]);
                                coa.Date = Convert.ToDateTime(rdr["Date"]);

                                coa.StartTime= rdr["StartTime"].ToString();
                                coa.StartTimeDate = Convert.ToDateTime(rdr["StartTimeDate"]);
                                coa.EndTime = rdr["EndTime"].ToString();
                                coa.EndTimeDate = Convert.ToDateTime(rdr["EndTimeDate"]);

                                coa.StartTime2 = rdr["StartTime2"].ToString();
                                coa.StartTimeDate2 = Convert.ToDateTime(rdr["StartTimeDate2"]);
                                coa.EndTime2 = rdr["EndTime2"].ToString();
                                coa.EndTimeDate2 = Convert.ToDateTime(rdr["EndTimeDate2"]);


                                coa.Requester = rdr["RequesterName"].ToString();
                                coa.Reason = rdr["Reason"].ToString();
                                // coa.CreatedBy = rdr["RequesterName"].ToString();
                                coa.CreatedBy = rdr["CreatedBy"].ToString();
                                coa.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]);
                                coa.Status =  ek.status(Convert.ToInt32(rdr["Status"]));


                                lis_coa.Add(coa);
                            }
                        }
                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = lis_coa;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_COA_V", action: 4, status: response.status, remarks: response.message);
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
                logs.insertActivityLogs(name: "hris.CN_COA_V", action: 4, status: response.status, remarks: response.message);
            }


            return response;
        }

        public String requestType(int type)
        {
            string request = "";
            switch (type)
            {
                case 1:
                    request = "COA";
                    break;
                case 2:
                    request = "OT";
                    break;
                case 3:
                    request = "Leave";
                    break;
                case 4:
                    request = "Shift";
                    break;
                case 5:
                    request = "Dependent";
                    break;
                default:
                    request = "";
                    break;
            }

            return request;
        }
    }
}