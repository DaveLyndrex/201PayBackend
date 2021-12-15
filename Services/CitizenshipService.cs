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
    public class CitizenshipService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        //GETBYID
        public ResponseModel getAllCitizenshipById(int employeeId)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_CITIZENSHIP_GET_BY_ID";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<CitizenshipModel> list_cm = new List<CitizenshipModel>();

                        command.Parameters.AddWithValue("_EmpID", employeeId);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                CitizenshipModel cm = new CitizenshipModel();

                                cm.ID = Convert.ToInt32(rdr["ID"]);
                                cm.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                cm.StartDate = Convert.ToDateTime(rdr["StartDate"]).ToString("MM/dd/yyyy");
                                cm.EndDate = Convert.ToDateTime(rdr["EndDate"]).ToString("MM/dd/yyyy");
                                cm.LegislationCode = rdr["LegislationCode"].ToString();
                                cm.CitizenshipID = rdr["CitizenshipStatus"].ToString();
                                cm.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                cm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                cm.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MM/dd/yyyy hh:mm ss"); ;

                                list_cm.Add(cm);
                            }
                        }
                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_cm;
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


       

        //CREATE OR INSERT
        public ResponseModel createCitizenshipData(CitizenshipModel cm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_CITIZENSHIP_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        #region
                        // Emp ID
                        command.Parameters.AddWithValue("_EmpID", cm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", cm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EndDate", cm.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // _CitizenshipID
                        command.Parameters.AddWithValue("_CitizenshipID", cm.CitizenshipID);
                        command.Parameters["_CitizenshipID"].Direction = ParameterDirection.Input;

                        //Modified By
                        command.Parameters.AddWithValue("_ModifiedBy", cm.ModifiedBy);
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
                    logs.insertActivityLogs(name: "hris.CN_CITIZENSHIP_INSERT", action: 1, status: response.status, remarks: response.message);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.data = null;
                logs.insertActivityLogs(name: "hris.CN_CITIZENSHIP_INSERT", action: 1, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel updateCitizenshipData(CitizenshipModel cm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_CITIZENSHIP_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        #region
                        command.Parameters.AddWithValue("_ID", cm.ID);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        // Emp ID
                        command.Parameters.AddWithValue("_EmpID", cm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", cm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EndDate", cm.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // _CitizenshipID
                        command.Parameters.AddWithValue("_CitizenshipID", cm.CitizenshipID);
                        command.Parameters["_CitizenshipID"].Direction = ParameterDirection.Input;

                        //Modified By
                        command.Parameters.AddWithValue("_ModifiedBy", cm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;
                        #endregion

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
                        logs.insertActivityLogs(name: "hris.CN_CITIZENSHIP_UPDATE", action: 2, status: response.status, remarks: response.message);
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
                logs.insertActivityLogs(name: "hris.CN_CITIZENSHIP_UPDATE", action: 2, status: response.status, remarks: response.message);
            }
            return response;
        }

      
    }
}