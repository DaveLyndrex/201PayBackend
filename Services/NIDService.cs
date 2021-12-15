/*[10/09/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace BackEnd.Services
{
    public class NIDService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel createEmployeeNID(NIDModel nm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "CN_NATIONAL_ID_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // EMP ID 
                        command.Parameters.AddWithValue("_EmpID", nm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", nm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EndDate", nm.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // _LegislationCode
                        command.Parameters.AddWithValue("_LegislationCode", nm.LegislationCode);
                        command.Parameters["_LegislationCode"].Direction = ParameterDirection.Input;

                        // _IssueDate
                        command.Parameters.AddWithValue("_IssueDate", nm.IssueDate);
                        command.Parameters["_IssueDate"].Direction = ParameterDirection.Input;

                        // _NationalIdentifierType
                        command.Parameters.AddWithValue("_NationalIdentifierType", nm.NationalIdentifierType);
                        command.Parameters["_NationalIdentifierType"].Direction = ParameterDirection.Input;

                        // _IssueDate
                        command.Parameters.AddWithValue("_NationalIdentifierNo", nm.NationalIdentifierNumber);
                        command.Parameters["_NationalIdentifierNo"].Direction = ParameterDirection.Input;

                        // _PrimaryFlag
                        command.Parameters.AddWithValue("_PrimaryFlag", nm.PrimaryFlag);
                        command.Parameters["_PrimaryFlag"].Direction = ParameterDirection.Input;

                        // ModifiedBy "
                        command.Parameters.AddWithValue("_ModifiedBy", nm.ModifiedBy);
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

                        logs.insertActivityLogs(name: "CN_NATIONAL_ID_INSERT", action: 1, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "CN_NATIONAL_ID_INSERT", action: 1, status: response.status, remarks: response.message);
            }
            return response;
        }
        public ResponseModel updateEmployeeNID(NIDModel nm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "CN_NATIONAL_ID_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // ID 
                        command.Parameters.AddWithValue("_ID", nm.ID);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        // EMP ID 
                        command.Parameters.AddWithValue("_EmpID", nm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", nm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EndDate", nm.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // _LegislationCode
                        command.Parameters.AddWithValue("_LegislationCode", nm.LegislationCode);
                        command.Parameters["_LegislationCode"].Direction = ParameterDirection.Input;

                        // _IssueDate
                        command.Parameters.AddWithValue("_IssueDate", nm.IssueDate);
                        command.Parameters["_IssueDate"].Direction = ParameterDirection.Input;

                        // _NationalIdentifierType
                        command.Parameters.AddWithValue("_NationalIdentifierType", nm.NationalIdentifierType);
                        command.Parameters["_NationalIdentifierType"].Direction = ParameterDirection.Input;

                        // _IssueDate
                        command.Parameters.AddWithValue("_NationalIdentifierNo", nm.NationalIdentifierNumber);
                        command.Parameters["_NationalIdentifierNo"].Direction = ParameterDirection.Input;

                        // _PrimaryFlag
                        command.Parameters.AddWithValue("_PrimaryFlag", nm.PrimaryFlag);
                        command.Parameters["_PrimaryFlag"].Direction = ParameterDirection.Input;

                        // ModifiedBy "
                        command.Parameters.AddWithValue("_ModifiedBy", nm.ModifiedBy);
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

        public ResponseModel getEmployeeNIDById(int employeeId, string tableName="national_id")
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

                        List<NIDModel> list_nm = new List<NIDModel>();

                        command.Parameters.AddWithValue("_empid", employeeId);
                        command.Parameters["_empid"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_tablename", tableName);
                        command.Parameters["_tablename"].Direction = ParameterDirection.Input;



                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                NIDModel nm = new NIDModel();

                                nm.ID = Convert.ToInt32(rdr["ID"]);
                                nm.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                nm.StartDate = Convert.ToDateTime(rdr["StartDate"]).ToString("MM/dd/yyyy");
                                nm.EndDate = Convert.ToDateTime(rdr["EndDate"]).ToString("MM/dd/yyyy");
                                nm.LegislationCode = Convert.ToString(rdr["LegislationCode"]);
                                nm.IssueDate = Convert.ToDateTime(rdr["IssueDate"]).ToString("MM/dd/yyyy");
                                nm.NationalIdentifierType = Convert.ToString(rdr["NationalIdentifierType"]);
                                nm.NationalIdentifierNumber= Convert.ToString(rdr["NationalIdentifierNo"]);
                                nm.PrimaryFlag = Convert.ToString(rdr["PrimaryFlag"]);
                                nm.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                nm.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                nm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_nm.Add(nm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_nm;
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