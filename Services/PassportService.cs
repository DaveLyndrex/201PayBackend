/*[10/09/2021] CN E.Patot*/

using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace BackEnd.Services
{
    public class PassportService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel createEmployeePassport(PassportModel pm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "CN_PASSPORT_DATA_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // EMP ID 
                        command.Parameters.AddWithValue("_EmpID", pm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _IssueDate
                        command.Parameters.AddWithValue("_IssueDate", pm.IssueDate);
                        command.Parameters["_IssueDate"].Direction = ParameterDirection.Input;

                        // _ExpirationDate
                        command.Parameters.AddWithValue("_ExpirationDate", pm.ExpirationDate);
                        command.Parameters["_ExpirationDate"].Direction = ParameterDirection.Input;

                        // _LegislationCode
                        command.Parameters.AddWithValue("_LegislationCode", pm.LegislationCode);
                        command.Parameters["_LegislationCode"].Direction = ParameterDirection.Input;

                        // _PassportType
                        command.Parameters.AddWithValue("_PassportType", pm.PassportType);
                        command.Parameters["_PassportType"].Direction = ParameterDirection.Input;

                        // _PassportNumber
                        command.Parameters.AddWithValue("_PassportNumber", pm.PassportNumber);
                        command.Parameters["_PassportNumber"].Direction = ParameterDirection.Input;

                        // _IssuingAuthority
                        command.Parameters.AddWithValue("_IssuingAuthority", pm.IssuingAuthority);
                        command.Parameters["_IssuingAuthority"].Direction = ParameterDirection.Input;

                        // _IssuingCountry
                        command.Parameters.AddWithValue("_IssuingCountry", pm.IssuingCountry);
                        command.Parameters["_IssuingCountry"].Direction = ParameterDirection.Input;

                        // _IssuingLocation
                        command.Parameters.AddWithValue("_IssuingLocation", pm.IssuingLocation);
                        command.Parameters["_IssuingLocation"].Direction = ParameterDirection.Input;

                        // ModifiedBy "
                        command.Parameters.AddWithValue("_ModifiedBy", pm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

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

                        logs.insertActivityLogs(name: "CN_PASSPORT_DATA_INSERT", action: 1, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "CN_PASSPORT_DATA_INSERT", action: 1, status: response.status, remarks: response.message);
            }
            return response;
        }
        public ResponseModel updateEmployeePassport(PassportModel pm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "CN_PASSPORT_DATA_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // ID 
                        command.Parameters.AddWithValue("_ID", pm.ID);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        // EMP ID 
                        command.Parameters.AddWithValue("_EmpID", pm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _IssueDate
                        command.Parameters.AddWithValue("_IssueDate", pm.IssueDate);
                        command.Parameters["_IssueDate"].Direction = ParameterDirection.Input;

                        // _ExpirationDate
                        command.Parameters.AddWithValue("_ExpirationDate", pm.ExpirationDate);
                        command.Parameters["_ExpirationDate"].Direction = ParameterDirection.Input;

                        // _LegislationCode
                        command.Parameters.AddWithValue("_LegislationCode", pm.LegislationCode);
                        command.Parameters["_LegislationCode"].Direction = ParameterDirection.Input;

                        // _PassportType
                        command.Parameters.AddWithValue("_PassportType", pm.PassportType);
                        command.Parameters["_PassportType"].Direction = ParameterDirection.Input;

                        // _PassportNumber
                        command.Parameters.AddWithValue("_PassportNumber", pm.PassportNumber);
                        command.Parameters["_PassportNumber"].Direction = ParameterDirection.Input;

                        // _IssuingAuthority
                        command.Parameters.AddWithValue("_IssuingAuthority", pm.IssuingAuthority);
                        command.Parameters["_IssuingAuthority"].Direction = ParameterDirection.Input;

                        // _IssuingCountry
                        command.Parameters.AddWithValue("_IssuingCountry", pm.IssuingCountry);
                        command.Parameters["_IssuingCountry"].Direction = ParameterDirection.Input;

                        // _IssuingLocation
                        command.Parameters.AddWithValue("_IssuingLocation", pm.IssuingLocation);
                        command.Parameters["_IssuingLocation"].Direction = ParameterDirection.Input;

                        // ModifiedBy "
                        command.Parameters.AddWithValue("_ModifiedBy", pm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;
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

                        logs.insertActivityLogs(name: "CN_NATIONAL_ID_UPDATE", action: 2, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "CN_NATIONAL_ID_UPDATE", action: 2, status: response.status, remarks: response.message);
            }
            return response;
        }


        public ResponseModel getEmployeePassportById(int employeeId)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_GET_PASSPORT_BY_ID";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<PassportModel> list_pm = new List<PassportModel>();

                        command.Parameters.AddWithValue("_empid", employeeId);
                        command.Parameters["_empid"].Direction = ParameterDirection.Input;



                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                PassportModel pm = new PassportModel();

                                pm.ID = Convert.ToInt32(rdr["ID"]);
                                pm.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                pm.IssueDate = Convert.ToDateTime(rdr["IssueDate"]).ToString("MM/dd/yyyy");
                                pm.ExpirationDate = Convert.ToDateTime(rdr["ExpirationDate"]).ToString("MM/dd/yyyy");
                                pm.LegislationCode = Convert.ToString(rdr["LegislationCode"]);
                                pm.PassportType = Convert.ToString(rdr["PassportType"]);
                                pm.PassportNumber = Convert.ToString(rdr["PassportNumber"]);
                                pm.IssuingAuthority = Convert.ToString(rdr["IssuingAuthority"]);
                                pm.IssuingCountry = Convert.ToString(rdr["IssuingCountry"]);
                                pm.IssuingLocation = Convert.ToString(rdr["IssuingLocation"]);
                                pm.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                pm.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                pm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_pm.Add(pm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_pm;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_GET_DATA_BY_ID", action: 5, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "hris.CN_GET_DATA_BY_ID", action: 5, status: response.status, remarks: response.message);
            }

            return response;
        }


    }
}