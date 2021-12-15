/*[10/07/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;


namespace BackEnd.Services
{
    public class OtherDataService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel createEmployeeOtherData(OtherDataModel odm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_OTHER_DATA_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // EMP ID 
                        command.Parameters.AddWithValue("_EmpID", odm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _Description
                        command.Parameters.AddWithValue("_Description", odm.Description);
                        command.Parameters["_Description"].Direction = ParameterDirection.Input;

                        // _Date
                        command.Parameters.AddWithValue("_Date", odm.Date);
                        command.Parameters["_Date"].Direction = ParameterDirection.Input;

                        // _Attachments
                        command.Parameters.AddWithValue("_Attachments", odm.Attachments);
                        command.Parameters["_Attachments"].Direction = ParameterDirection.Input;

                        // Remarks
                        command.Parameters.AddWithValue("_Remarks", odm.Remarks);
                        command.Parameters["_Remarks"].Direction = ParameterDirection.Input;

                        // _ModifiedBy
                        command.Parameters.AddWithValue("_ModifiedBy", odm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        // _FieldName
                        command.Parameters.AddWithValue("_FieldName", odm.FieldName);
                        command.Parameters["_FieldName"].Direction = ParameterDirection.Input;


                        int rows_affected = command.ExecuteNonQuery();

                        if (rows_affected > 0)
                        {
                            command.Transaction.Commit();
                            response.message = consts.SUCCESS_INSERT;
                            response.status = consts.SUCCESS;
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
                    }
                    conn.Close();

                    logs.insertActivityLogs(name: "hris.CN_OTHER_DATA_INSERT", action: 1, status: response.status, remarks: response.message);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "hris.CN_OTHER_DATA_INSERT", action: 1, status: response.status, remarks: response.message);
            }
            return response;
        }
        public ResponseModel updateEmployeeOtherData(OtherDataModel odm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_OTHER_DATA_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // id
                        command.Parameters.AddWithValue("_ID", odm.ID);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        // EMP ID 
                        command.Parameters.AddWithValue("_EmpID", odm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _Description
                        command.Parameters.AddWithValue("_Description", odm.Description);
                        command.Parameters["_Description"].Direction = ParameterDirection.Input;

                        // _Date
                        command.Parameters.AddWithValue("_Date", odm.Date);
                        command.Parameters["_Date"].Direction = ParameterDirection.Input;

                        // _Attachments
                        command.Parameters.AddWithValue("_Attachments", odm.Attachments);
                        command.Parameters["_Attachments"].Direction = ParameterDirection.Input;

                        // Remarks
                        command.Parameters.AddWithValue("_Remarks", odm.Remarks);
                        command.Parameters["_Remarks"].Direction = ParameterDirection.Input;

                        // _ModifiedBy
                        command.Parameters.AddWithValue("_ModifiedBy", odm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        // _FieldName
                        command.Parameters.AddWithValue("_FieldName", odm.FieldName);
                        command.Parameters["_FieldName"].Direction = ParameterDirection.Input;


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

                    logs.insertActivityLogs(name: "hris.CN_OTHER_DATA_UPDATE", action: 2, status: response.status, remarks: response.message);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "hris.CN_OTHER_DATA_UPDATE", action: 2, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getEmployeeOtherDataById(string employeeId)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.CN_EMPLOYEE_OTHER_DATA_V WHERE EmpID = '" + employeeId + "'";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<OtherDataModel> list_odm = new List<OtherDataModel>();

                        command.Parameters.AddWithValue("_EmpID", employeeId);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();
                        
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                OtherDataModel odm = new OtherDataModel();

                                odm.ID = Convert.ToInt32(rdr["ID"]);
                                odm.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                odm.Description = rdr["Description"].ToString();
                                odm.Date = Convert.ToDateTime(rdr["Date"]).ToString("MM/dd/yyyy");
                                odm.Attachments = rdr["Attachments"].ToString();
                                odm.Remarks = rdr["Remarks"].ToString();
                                odm.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                odm.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MM/dd/yyyy hh: mm ss");
                                odm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                odm.FieldName = rdr["CustomField"].ToString();

                                list_odm.Add(odm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_odm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_OTHER_DATA_GET_BY_EMPLOYEEID", action: 5, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "hris.CN_OTHER_DATA_GET_BY_EMPLOYEEID", action: 5, status: response.status, remarks: response.message);
            }
            return response;
        }
/*
        public ResponseModel deleteOtherData(int _id)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_OTHER_DATA_DELETE";
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

                    logs.insertActivityLogs(name: "hris.CN_OTHER_DATA_DELETE", action: 3, status: response.status, remarks: response.message);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "hris.CN_OTHER_DATA_DELETE", action: 3, status: response.status, remarks: response.message);
            }

            return response;
        }
*/
    }
}