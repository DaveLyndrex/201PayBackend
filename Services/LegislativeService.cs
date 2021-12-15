/* 07/10/2021 CN A.Diez */
/*[10/09/2021] CN E.Patot*/
/*[10/11/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace BackEnd.Services
{
    public class LegislativeService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        //GET Legislative
        public ResponseModel getLegislative(int empid)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_LEGISLATIVE_GET_BYID";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        command.Parameters.AddWithValue("_id", empid);
                        command.Parameters["_id"].Direction = ParameterDirection.Input;
                        List<LegislativeModel> list_lm = new List<LegislativeModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                LegislativeModel lm = new LegislativeModel();
                                lm.ID = Convert.ToInt32(rdr["ID"]);
                                lm.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                lm.StartDate =Convert.ToDateTime(rdr["StartDate"]).ToString("MM/dd/yyyy");
                                lm.EndDate = Convert.ToDateTime(rdr["EndDate"]).ToString("MM/dd/yyyy");
                                lm.HighestEducationalLevel = rdr["HighestEducationalLevel"].ToString();
                                lm.MaritalStatus = rdr["MaritalStatus"].ToString();
                                lm.MaritalStatusDate = Convert.ToDateTime(rdr["MaritalStatusDate"]).ToString("MM/dd/yyyy");
                                lm.Sex = rdr["Sex"].ToString();
                                lm.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                lm.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                lm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                list_lm.Add(lm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_lm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_LEGISLATIVE_GET", action: 3, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "hris.CN_LEGISLATIVE_GET", action: 3, status: response.status, remarks: response.message);
            }
            return response;
        }

  


        //INSERT Legislative
        public ResponseModel createLegislative(LegislativeModel lm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_LEGISLATIVE_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        command.Parameters.AddWithValue("_ID", lm.ID);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;
                        #region
                        // Emp ID
                        command.Parameters.AddWithValue("_EmpID", lm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", lm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EndDate", lm.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // _HighestEducationalLevel
                        command.Parameters.AddWithValue("_HighestEducationalLevel", lm.HighestEducationalLevel);
                        command.Parameters["_HighestEducationalLevel"].Direction = ParameterDirection.Input;

                        // _MaritalStatus
                        command.Parameters.AddWithValue("_MaritalStatus", lm.MaritalStatus);
                        command.Parameters["_MaritalStatus"].Direction = ParameterDirection.Input;

                        // _MaritalStatusDate
                        command.Parameters.AddWithValue("_MaritalStatusDate", lm.MaritalStatusDate);
                        command.Parameters["_MaritalStatusDate"].Direction = ParameterDirection.Input;

                        // _Sex
                        command.Parameters.AddWithValue("_Sex", lm.Sex);
                        command.Parameters["_Sex"].Direction = ParameterDirection.Input;

                        // _ModifiedBy
                        command.Parameters.AddWithValue("_ModifiedBy", lm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        #endregion

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
                    logs.insertActivityLogs(name: "hris.CN_LEGISLATIVE_INSERT", action: 1, status: response.status, remarks: response.message);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.data = null;
                logs.insertActivityLogs(name: "hris.CN_LEGISLATIVE_INSERT", action: 1, status: response.status, remarks: response.message);
            }

            return response;
        }



        //UPDATE Legislative
        public ResponseModel updateLegislative(LegislativeModel lm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_LEGISLATIVE_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // ID
                        command.Parameters.AddWithValue("_ID", lm.ID);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        // Emp ID
                        command.Parameters.AddWithValue("_EmpID", lm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", lm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EndDate", lm.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // _HighestEducationalLevel
                        command.Parameters.AddWithValue("_HighestEducationalLevel", lm.HighestEducationalLevel);
                        command.Parameters["_HighestEducationalLevel"].Direction = ParameterDirection.Input;

                        // _MaritalStatus
                        command.Parameters.AddWithValue("_MaritalStatus", lm.MaritalStatus);
                        command.Parameters["_MaritalStatus"].Direction = ParameterDirection.Input;

                        // _MaritalStatusDate
                        command.Parameters.AddWithValue("_MaritalStatusDate", lm.MaritalStatusDate);
                        command.Parameters["_MaritalStatusDate"].Direction = ParameterDirection.Input;

                        // _Sex
                        command.Parameters.AddWithValue("_Sex", lm.Sex);
                        command.Parameters["_Sex"].Direction = ParameterDirection.Input;

                        // _ModifiedBy
                        command.Parameters.AddWithValue("_ModifiedBy", lm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

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

                        logs.insertActivityLogs(name: "hris.CN_LEGISLATIVE_UPDATE", action: 2, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "hris.CN_LEGISLATIVE_UPDATE", action: 2, status: response.status, remarks: response.message);
            }
            return response;
        }
    }
}