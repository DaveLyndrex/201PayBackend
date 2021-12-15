/*[10/08/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace BackEnd.Services
{
    public class TrainingService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel createEmployeeTraining(TrainingModel tm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_TRAINING_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // EMP ID 
                        command.Parameters.AddWithValue("_EmpID", tm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", tm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EndDate", tm.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // _Title
                        command.Parameters.AddWithValue("_Title", tm.Title);
                        command.Parameters["_Title"].Direction = ParameterDirection.Input;

                        // _Description
                        command.Parameters.AddWithValue("_Description", tm.Description);
                        command.Parameters["_Description"].Direction = ParameterDirection.Input;

                        // _ActualDuration
                        command.Parameters.AddWithValue("_ActualDuration", tm.ActualDuration);
                        command.Parameters["_ActualDuration"].Direction = ParameterDirection.Input;

                        // _TypeID
                        command.Parameters.AddWithValue("_TypeID", tm.TypeID);
                        command.Parameters["_TypeID"].Direction = ParameterDirection.Input;

                        // _Location
                        command.Parameters.AddWithValue("_Location", tm.Location);
                        command.Parameters["_Location"].Direction = ParameterDirection.Input;

                        // _ConductedBy
                        command.Parameters.AddWithValue("_ConductedBy", tm.ConductedBy);
                        command.Parameters["_ConductedBy"].Direction = ParameterDirection.Input;

                        // _Attachments
                        command.Parameters.AddWithValue("_Attachments", tm.Attachments);
                        command.Parameters["_Attachments"].Direction = ParameterDirection.Input;

                        // _Remarks
                        command.Parameters.AddWithValue("_Remarks", tm.Remarks);
                        command.Parameters["_Remarks"].Direction = ParameterDirection.Input;

                        // _ProgramFee
                        command.Parameters.AddWithValue("_ProgramFee", tm.ProgramFee);
                        command.Parameters["_ProgramFee"].Direction = ParameterDirection.Input;

                        // _WithCertification
                        command.Parameters.AddWithValue("_WithCertification", tm.WithCertification);
                        command.Parameters["_WithCertification"].Direction = ParameterDirection.Input;

                        // _IncidentialCost
                        command.Parameters.AddWithValue("_IncidentialCost", tm.IncidentialCost);
                        command.Parameters["_IncidentialCost"].Direction = ParameterDirection.Input;

                        // _ModifiedBy
                        command.Parameters.AddWithValue("_ModifiedBy", tm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

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
                    logs.insertActivityLogs(name: "hris.CN_TRAINING_INSERT", action: 1, status: response.status, remarks: response.message);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "hris.CN_TRAINING_INSERT", action: 1, status: response.status, remarks: response.message);
            }
            return response;
        }
        public ResponseModel updateEmployeeTraining(TrainingModel tm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_TRAINING_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // ID 
                        command.Parameters.AddWithValue("_id", tm.ID);
                        command.Parameters["_id"].Direction = ParameterDirection.Input;
                            
                        // EMP ID 
                        command.Parameters.AddWithValue("_EmpID", tm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", tm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EndDate", tm.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // _Title
                        command.Parameters.AddWithValue("_Title", tm.Title);
                        command.Parameters["_Title"].Direction = ParameterDirection.Input;

                        // _Description
                        command.Parameters.AddWithValue("_Description", tm.Description);
                        command.Parameters["_Description"].Direction = ParameterDirection.Input;

                        // _ActualDuration
                        command.Parameters.AddWithValue("_ActualDuration", tm.ActualDuration);
                        command.Parameters["_ActualDuration"].Direction = ParameterDirection.Input;

                        // _TypeID
                        command.Parameters.AddWithValue("_TypeID", tm.TypeID);
                        command.Parameters["_TypeID"].Direction = ParameterDirection.Input;

                        // _Location
                        command.Parameters.AddWithValue("_Location", tm.Location);
                        command.Parameters["_Location"].Direction = ParameterDirection.Input;

                        // _ConductedBy
                        command.Parameters.AddWithValue("_ConductedBy", tm.ConductedBy);
                        command.Parameters["_ConductedBy"].Direction = ParameterDirection.Input;

                        // _Attachments
                        command.Parameters.AddWithValue("_Attachments", tm.Attachments);
                        command.Parameters["_Attachments"].Direction = ParameterDirection.Input;

                        // _Remarks
                        command.Parameters.AddWithValue("_Remarks", tm.Remarks);
                        command.Parameters["_Remarks"].Direction = ParameterDirection.Input;

                        // _ProgramFee
                        command.Parameters.AddWithValue("_ProgramFee", tm.ProgramFee);
                        command.Parameters["_ProgramFee"].Direction = ParameterDirection.Input;

                        // _WithCertification
                        command.Parameters.AddWithValue("_WithCertification", tm.WithCertification);
                        command.Parameters["_WithCertification"].Direction = ParameterDirection.Input;

                        // _IncidentialCost
                        command.Parameters.AddWithValue("_IncidentialCost", tm.IncidentialCost);
                        command.Parameters["_IncidentialCost"].Direction = ParameterDirection.Input;

                        // _ModifiedBy
                        command.Parameters.AddWithValue("_ModifiedBy", tm.ModifiedBy);
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
                    logs.insertActivityLogs(name: "hris.CN_TRAINING_UPDATE", action: 2, status: response.status, remarks: response.message);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "hris.CN_TRAINING_UPDATE", action: 2, status: response.status, remarks: response.message);
            }
            return response;
        }

      
        public ResponseModel getAllTraining(string id)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.CN_EMPLOYEE_TRAINING_V WHERE EmpID ='" + id + "'";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // ID 
                        command.Parameters.AddWithValue("_id", id);
                        command.Parameters["_id"].Direction = ParameterDirection.Input;

                        List<TrainingModel> list_tm = new List<TrainingModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                TrainingModel tm = new TrainingModel();

                                tm.ID = Convert.ToInt32(rdr["ID"]);
                                tm.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                tm.StartDate = Convert.ToDateTime(rdr["StartDate"]).ToString("MM/dd/yyyy");
                                tm.EndDate = Convert.ToDateTime(rdr["EndDate"]).ToString("MM/dd/yyyy");
                                tm.Title = rdr["Title"].ToString();
                                tm.Description = rdr["Description"].ToString();
                                tm.IncidentialCost = Math.Round(Convert.ToDecimal(rdr["IncidentialCost"]), 2).ToString();
                                tm.ActualDuration = rdr["ActualDuration"].ToString();
                                tm.TypeID = Convert.ToString(rdr["TrainingType"]);
                                tm.ConductedBy = rdr["ConductedBy"].ToString();
                                tm.Attachments = rdr["Attachments"].ToString();
                                tm.Remarks = rdr["Remarks"].ToString();
                                tm.Location = rdr["Location"].ToString();
                                tm.WithCertification = rdr["WithCertification"].ToString();
                                tm.ProgramFee = Math.Round(Convert.ToDecimal(rdr["ProgramFee"]), 2).ToString();
                                tm.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                tm.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                tm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_tm.Add(tm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_tm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;

                        conn.Close();
                        logs.insertActivityLogs(name: "SELECT * FROM hris.CN_EMPLOYEE_TRAINING_V WHERE EmpID ='" + id + "'", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.CN_EMPLOYEE_TRAINING_V WHERE EmpID ='" + id + "'", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }
    }
}