/* 07/10/2021 CN A.Diez */
/* 10/08/2021 CN E.Patot */
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace BackEnd.Services
{
    public class LicenseService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        //GET BY ID
        public ResponseModel GetLicenseById(string employeeId, string tableName = "license")
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_GET_DATA_BY_ID";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<LicenseModel> list_licensem = new List<LicenseModel>();

                        command.Parameters.AddWithValue("_tablename", tableName);
                        command.Parameters["_tablename"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_EmpID", employeeId);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                LicenseModel license = new LicenseModel();

                                license.ID = Convert.ToInt32(rdr["ID"]);
                                license.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                license.StartDate = Convert.ToDateTime(rdr["StartDate"]).ToString("MM/dd/yyyy");
                                license.EndDate = Convert.ToDateTime(rdr["EndDate"]).ToString("MM/dd/yyyy");
                                license.LicenseType = rdr["LicenseType"].ToString();
                                license.Description = rdr["Description"].ToString();
                                license.Attachment = rdr["Attachment"].ToString();
                                license.Remarks = rdr["Remarks"].ToString();
                                license.LegislationCode = rdr["LegislationCode"].ToString();
                                license.IssuingAuthority = rdr["IssuingAuthority"].ToString();
                                license.IssuingCountry = rdr["IssuingCountry"].ToString();
                                license.IssuingLocation = rdr["IssuingLocation"].ToString();
                                license.LicenseSuspended = rdr["LicenseSuspended"].ToString();
                                license.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                license.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                license.LicenseNo = (rdr["LicenseNo"]).ToString();
                                license.RenewalDate = Convert.ToDateTime(rdr["RenewalDate"]).ToString("MM/dd/yyyy");
                                license.Renewed = rdr["Renewed"].ToString();
                                license.ModifiedBy = rdr["ModifiedBy"].ToString();
                                list_licensem.Add(license);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_licensem;
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

      
        //CREATE OR INSERT LICENSE
        public ResponseModel createLicense(LicenseModel license)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_LICENSE_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        #region
                        // Emp ID
                        command.Parameters.AddWithValue("_EmpID", license.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", license.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EndDate", license.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // _Description
                        command.Parameters.AddWithValue("_Description", license.Description);
                        command.Parameters["_Description"].Direction = ParameterDirection.Input;

                        // _Attachment
                        command.Parameters.AddWithValue("_Attachment", license.Attachment);
                        command.Parameters["_Attachment"].Direction = ParameterDirection.Input;

                        // _Remarks
                        command.Parameters.AddWithValue("_Remarks", license.Remarks);
                        command.Parameters["_Remarks"].Direction = ParameterDirection.Input;

                        // _ModifiedBy
                        command.Parameters.AddWithValue("_ModifiedBy", license.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        // _LicenseNo
                        command.Parameters.AddWithValue("_LicenseNo", license.LicenseNo);
                        command.Parameters["_LicenseNo"].Direction = ParameterDirection.Input;

                        // _RenewalDate
                        command.Parameters.AddWithValue("_RenewalDate", license.RenewalDate);
                        command.Parameters["_RenewalDate"].Direction = ParameterDirection.Input;
                        #endregion
                        // _Renewed
                        command.Parameters.AddWithValue("_Renewed", license.Renewed);
                        command.Parameters["_Renewed"].Direction = ParameterDirection.Input;

                        // _LegislationCode
                        command.Parameters.AddWithValue("_LegislationCode", license.LegislationCode);
                        command.Parameters["_LegislationCode"].Direction = ParameterDirection.Input;

                        // _LicenseType
                        command.Parameters.AddWithValue("_LicenseType", license.LicenseType);
                        command.Parameters["_LicenseType"].Direction = ParameterDirection.Input;

                        // _IssuingAuthority
                        command.Parameters.AddWithValue("_IssuingAuthority", license.IssuingAuthority);
                        command.Parameters["_IssuingAuthority"].Direction = ParameterDirection.Input;

                        // _IssuingCountry
                        command.Parameters.AddWithValue("_IssuingCountry", license.IssuingCountry);
                        command.Parameters["_IssuingCountry"].Direction = ParameterDirection.Input;

                        // _IssuingLocation
                        command.Parameters.AddWithValue("_IssuingLocation", license.IssuingLocation);
                        command.Parameters["_IssuingLocation"].Direction = ParameterDirection.Input;

                        // _LicenseSuspended
                        command.Parameters.AddWithValue("_LicenseSuspended", license.LicenseSuspended);
                        command.Parameters["_LicenseSuspended"].Direction = ParameterDirection.Input;

                        int rows_affected = command.ExecuteNonQuery();

                        if (rows_affected > 0)
                        {
                            command.Transaction.Commit();
                            response.message = consts.SUCCESS_INSERT;
                            response.code = consts.CODE_OK;
                            response.status = consts.SUCCESS;
                            response.error = consts.ERROR_FALSE;
                            response.data = null;
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
                    }
                    conn.Close();
                    logs.insertActivityLogs(name: "hris.CN_LICENSE_INSERT", action: 1, status: response.status, remarks: response.message);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.data = null;
                logs.insertActivityLogs(name: "hris.CN_LICENSE_INSERT", action: 1, status: response.status, remarks: response.message);
            }

            return response;
        }

        //UPDATE LICENSE
        public ResponseModel updateLicense(LicenseModel license)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_LICENSE_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        //ID
                        command.Parameters.AddWithValue("_ID", license.ID);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        // Emp ID
                        command.Parameters.AddWithValue("_EmpID", license.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", license.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EndDate", license.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // _Description
                        command.Parameters.AddWithValue("_Description", license.Description);
                        command.Parameters["_Description"].Direction = ParameterDirection.Input;

                        // _Attachment
                        command.Parameters.AddWithValue("_Attachment", license.Attachment);
                        command.Parameters["_Attachment"].Direction = ParameterDirection.Input;

                        // _Remarks
                        command.Parameters.AddWithValue("_Remarks", license.Remarks);
                        command.Parameters["_Remarks"].Direction = ParameterDirection.Input;

                        // _ModifiedBy
                        command.Parameters.AddWithValue("_ModifiedBy", license.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        // _LicenseNo
                        command.Parameters.AddWithValue("_LicenseNo", license.LicenseNo);
                        command.Parameters["_LicenseNo"].Direction = ParameterDirection.Input;

                        // _RenewalDate
                        command.Parameters.AddWithValue("_RenewalDate", license.RenewalDate);
                        command.Parameters["_RenewalDate"].Direction = ParameterDirection.Input;

                        // _Renewed
                        command.Parameters.AddWithValue("_Renewed", license.Renewed);
                        command.Parameters["_Renewed"].Direction = ParameterDirection.Input;

                        // _LegislationCode
                        command.Parameters.AddWithValue("_LegislationCode", license.LegislationCode);
                        command.Parameters["_LegislationCode"].Direction = ParameterDirection.Input;

                        // _LicenseType
                        command.Parameters.AddWithValue("_LicenseType", license.LicenseType);
                        command.Parameters["_LicenseType"].Direction = ParameterDirection.Input;

                        // _IssuingAuthority
                        command.Parameters.AddWithValue("_IssuingAuthority", license.IssuingAuthority);
                        command.Parameters["_IssuingAuthority"].Direction = ParameterDirection.Input;

                        // _IssuingCountry
                        command.Parameters.AddWithValue("_IssuingCountry", license.IssuingCountry);
                        command.Parameters["_IssuingCountry"].Direction = ParameterDirection.Input;

                        // _IssuingLocation
                        command.Parameters.AddWithValue("_IssuingLocation", license.IssuingLocation);
                        command.Parameters["_IssuingLocation"].Direction = ParameterDirection.Input;

                        // _LicenseSuspended
                        command.Parameters.AddWithValue("_LicenseSuspended", license.LicenseSuspended);
                        command.Parameters["_LicenseSuspended"].Direction = ParameterDirection.Input;

                        int rows_affected = command.ExecuteNonQuery();

                        if (rows_affected > 0)
                        {
                            response.message = consts.SUCCESS_UPDATE;
                            response.code = consts.CODE_OK;
                            response.status = consts.SUCCESS;
                            response.error = consts.ERROR_FALSE;
                            response.data = null;
                            command.Transaction.Commit();
                        }
                        else
                        {
                            response.message = consts.ERROR_UPDATE;
                            response.code = consts.CODE_ERROR;
                            response.status = consts.ERROR;
                            response.error = consts.ERROR_TRUE;
                            response.data = null;
                            command.Transaction.Rollback();
                        }
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_LICENSE_UPDATE", action: 2, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.status = consts.ERROR;
                response.error = consts.ERROR_TRUE;
                response.data = null;

                logs.insertActivityLogs(name: "hris.CN_LICENSE_UPDATE", action: 2, status: response.status, remarks: response.message);
            }
            return response;
        }

       

    }
}
