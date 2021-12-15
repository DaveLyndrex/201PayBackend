/*[10/08/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace BackEnd.Services
{
    public class EthnicityService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel createEmployeeEthnicity(EthnicityModel em)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_ETHNICITY_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // EMP ID 
                        command.Parameters.AddWithValue("_EmpID", em.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", em.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EndDate", em.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // _EthnicityID
                        command.Parameters.AddWithValue("_EthnicityID", em.Ethnicity);
                        command.Parameters["_EthnicityID"].Direction = ParameterDirection.Input;

                        // _PrimaryFlag
                        command.Parameters.AddWithValue("_PrimaryFlag", em.PrimaryFlag);
                        command.Parameters["_PrimaryFlag"].Direction = ParameterDirection.Input;

                        // ModifiedBy "
                        command.Parameters.AddWithValue("_ModifiedBy", em.ModifiedBy);
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

                        logs.insertActivityLogs(name: "hris.CN_ETHNICITY_INSERT", action: 1, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "hris.CN_ETHNICITY_INSERT", action: 1, status: response.status, remarks: response.message);
            }
            return response;
        }
        public ResponseModel updateEmployeeEthnicity(EthnicityModel em)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_ETHNICITY_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // ID 
                        command.Parameters.AddWithValue("_ID", em.ID);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        // EMP ID 
                        command.Parameters.AddWithValue("_EmpID", em.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;


                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", em.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EndDate", em.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // _EthnicityID
                        command.Parameters.AddWithValue("_EthnicityID", em.Ethnicity);
                        command.Parameters["_EthnicityID"].Direction = ParameterDirection.Input;

                        // _PrimaryFlag
                        command.Parameters.AddWithValue("_PrimaryFlag", em.PrimaryFlag);
                        command.Parameters["_PrimaryFlag"].Direction = ParameterDirection.Input;

                        // ModifiedBy "
                        command.Parameters.AddWithValue("_ModifiedBy", em.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        int rows_affected = command.ExecuteNonQuery();

                        if (rows_affected > 0)
                        {
                            command.Transaction.Commit();
                            response.code = consts.CODE_OK;
                            response.status = consts.SUCCESS;
                            response.error = consts.ERROR_FALSE;
                            response.message = consts.SUCCESS_UPDATE;
                          
                            
                        }
                        else
                        {
                            command.Transaction.Rollback();
                            response.code = consts.CODE_ERROR;
                            response.status = consts.ERROR;
                            response.error = consts.ERROR_TRUE;
                            response.message = consts.ERROR_UPDATE;
                            
                            
                        }

                        logs.insertActivityLogs(name: "hris.CN_ETHNICITY_UPDATE", action: 2, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "hris.CN_ETHNICITY_UPDATE", action: 2, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getEmployeeEthnicityById(int employeeId)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_ETHNICITY_GET_BY_ID";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<EthnicityModel> list_em = new List<EthnicityModel>();

                        command.Parameters.AddWithValue("_id", employeeId);
                        command.Parameters["_id"].Direction = ParameterDirection.Input;



                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                EthnicityModel em = new EthnicityModel();

                                em.ID = Convert.ToInt32(rdr["ID"]);
                                em.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                em.StartDate = Convert.ToDateTime(rdr["StartDate"]).ToString("MM/dd/yyyy");
                                em.EndDate = Convert.ToDateTime(rdr["EndDate"]).ToString("MM/dd/yyyy");
                                em.Ethnicity = Convert.ToString(rdr["Ethnicity"]);
                                em.PrimaryFlag = Convert.ToString(rdr["PrimaryFlag"]);
                                em.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                em.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_em.Add(em);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_em;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_ETHNICITY_GET_BY_ID", action: 5, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "hris.CN_ETHNICITY_GET_BY_ID", action: 5, status: response.status, remarks: response.message);
            }

            return response;
        }
       

    }
}