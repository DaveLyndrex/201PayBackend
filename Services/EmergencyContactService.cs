/*[10/07/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace BackEnd.Services
{
    public class EmergencyContactService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel createEmergencyContact(EmergencyContactModel ecm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_EMERGENCY_CONTACT_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // Emp ID
                        command.Parameters.AddWithValue("_EmpID", ecm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // Name
                        command.Parameters.AddWithValue("_Name", ecm.Name);
                        command.Parameters["_Name"].Direction = ParameterDirection.Input;

                        // Phone Number
                        command.Parameters.AddWithValue("_PhoneNumber", ecm.PhoneNumber);
                        command.Parameters["_PhoneNumber"].Direction = ParameterDirection.Input;

                        // Alternate Number
                        command.Parameters.AddWithValue("_AlternateNumber", ecm.AlternateNumber);
                        command.Parameters["_AlternateNumber"].Direction = ParameterDirection.Input;

                        // Relationship
                        command.Parameters.AddWithValue("_Relationship", ecm.Relationship);
                        command.Parameters["_Relationship"].Direction = ParameterDirection.Input;

                        // Address
                        command.Parameters.AddWithValue("_Address", ecm.Address);
                        command.Parameters["_Address"].Direction = ParameterDirection.Input;

                        // MOTH
                        command.Parameters.AddWithValue("_MOTH", ecm.MOTH);
                        command.Parameters["_MOTH"].Direction = ParameterDirection.Input;

                        // Modified By
                        command.Parameters.AddWithValue("_ModifiedBy", ecm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        int rows_affected = command.ExecuteNonQuery();

                        if (rows_affected > 0)
                        {
                            command.Transaction.Commit();
                            response.message = consts.SUCCESS_INSERT;
                            response.status = consts.SUCCESS;
                            response.code = consts.CODE_OK;
                            response.error = consts.ERROR_FALSE;
                            response.data = null;
                        }
                        else
                        {
                            command.Transaction.Rollback();
                            response.message = consts.ERROR_INSERT;
                            response.status = consts.ERROR;
                            response.code = consts.CODE_ERROR;
                            response.error = consts.ERROR_TRUE;
                            response.data = null;
                        }
                    }
                    conn.Close();

                    logs.insertActivityLogs(name: "hris.CN_EMERGENCY_CONTACT_INSERT", action: 1, status: response.status, remarks: response.message);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.data = null;
                logs.insertActivityLogs(name: "hris.CN_EMERGENCY_CONTACT_INSERT", action: 1, status: response.status, remarks: response.message);
            }
            return response;
        }
        public ResponseModel updateEmegencyContact(EmergencyContactModel ecm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_EMERGENCY_CONTACT_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // ID
                        command.Parameters.AddWithValue("_ID", ecm.ID);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        // Emp ID
                        command.Parameters.AddWithValue("_EmpID", ecm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // Name
                        command.Parameters.AddWithValue("_Name", ecm.Name);
                        command.Parameters["_Name"].Direction = ParameterDirection.Input;

                        // Phone Number
                        command.Parameters.AddWithValue("_PhoneNumber", ecm.PhoneNumber);
                        command.Parameters["_PhoneNumber"].Direction = ParameterDirection.Input;

                        // Alternate Number
                        command.Parameters.AddWithValue("_AlternateNumber", ecm.AlternateNumber);
                        command.Parameters["_AlternateNumber"].Direction = ParameterDirection.Input;

                        // Relationship
                        command.Parameters.AddWithValue("_Relationship", ecm.Relationship);
                        command.Parameters["_Relationship"].Direction = ParameterDirection.Input;

                        // Address
                        command.Parameters.AddWithValue("_Address", ecm.Address);
                        command.Parameters["_Address"].Direction = ParameterDirection.Input;

                        // MOTH
                        command.Parameters.AddWithValue("_MOTH", ecm.MOTH);
                        command.Parameters["_MOTH"].Direction = ParameterDirection.Input;

                        // Modified By
                        command.Parameters.AddWithValue("_ModifiedBy", ecm.ModifiedBy);
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
                    }
                    conn.Close();

                    logs.insertActivityLogs(name: "hris.CN_EMERGENCY_CONTACT_UPDATE", action: 2, status: response.status, remarks: response.message);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.data = null;
                logs.insertActivityLogs(name: "hris.CN_EMERGENCY_CONTACT_UPDATE", action: 2, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel deleteEmegencyContact(int _id)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_EMERGENCY_CONTACT_DELETE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        command.Parameters.AddWithValue("_ID", _id);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        int rows_affected = command.ExecuteNonQuery();

                        if (rows_affected > 0)
                        {
                            command.Transaction.Commit();
                            response.message = consts.SUCCESS_DELETE;
                            response.status = consts.SUCCESS;
                            response.code = consts.CODE_OK;
                            response.error = consts.ERROR_FALSE;
                        }
                        else
                        {
                            command.Transaction.Rollback();
                            response.message = consts.ERROR_DELETE;
                            response.status = consts.ERROR;
                            response.code = consts.CODE_ERROR;
                            response.error = consts.ERROR_TRUE;
                        }
                    }
                    conn.Close();

                    logs.insertActivityLogs(name: "hris.CN_EMERGENCY_CONTACT_DELETE", action: 3, status: response.status, remarks: response.message);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.data = null;
                logs.insertActivityLogs(name: "hris.CN_EMERGENCY_CONTACT_DELETE", action: 3, status: response.status, remarks: response.message);
            }
            return response;
        }
      
        public ResponseModel getByEmployeeId(int employeeId)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_EMERGENCY_CONTACT_GET_BY_EMPLOYEEID";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<EmergencyContactModel> list_ecm = new List<EmergencyContactModel>();

                        command.Parameters.AddWithValue("_EmpID", employeeId);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                EmergencyContactModel ecm = new EmergencyContactModel();

                                ecm.ID = Convert.ToInt32(rdr["ID"]);
                                ecm.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                ecm.Name = rdr["Name"].ToString();
                                ecm.PhoneNumber = rdr["PhoneNumber"].ToString();
                                ecm.AlternateNumber = rdr["AlternateNumber"].ToString();
                                ecm.Relationship = rdr["Relationship"].ToString();
                                ecm.Address = rdr["Address"].ToString();
                                ecm.MOTH = rdr["MOTH"].ToString();
                                ecm.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MM dd, yyyy hh:mm ss");
                                ecm.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MM dd, yyyy hh:mm ss");
                                ecm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_ecm.Add(ecm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_ecm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_EMERGENCY_CONTACT_GET_BY_EMPLOYEEID", action: 5, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;
                response.data = null;

                logs.insertActivityLogs(name: "hris.CN_EMERGENCY_CONTACT_GET_BY_EMPLOYEEID", action: 5, status: response.status, remarks: response.message);
            }
            return response;
        }
    }
}