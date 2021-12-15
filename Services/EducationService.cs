/*[10/08/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;


namespace BackEnd.Services
{
    public class EducationService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel createEmployeeEducation(EducationModel em)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_EDUCATIONAL_BACKGROUND_INSERT";
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

                        // _School
                        command.Parameters.AddWithValue("_School", em.School);
                        command.Parameters["_School"].Direction = ParameterDirection.Input;

                        // _Course
                        command.Parameters.AddWithValue("_Course", em.Course);
                        command.Parameters["_Course"].Direction = ParameterDirection.Input;

                        // _Attachment
                        command.Parameters.AddWithValue("_Attachment", em.Attachment);
                        command.Parameters["_Attachment"].Direction = ParameterDirection.Input;

                        // _Remarks
                        command.Parameters.AddWithValue("_Remarks", em.Remarks);
                        command.Parameters["_Remarks"].Direction = ParameterDirection.Input;

                        // _ModifiedBy
                        command.Parameters.AddWithValue("_ModifiedBy", em.ModifiedBy);
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
                        
                        logs.insertActivityLogs(name: "hris.CN_EDUCATIONAL_BACKGROUND_INSERT", action: 1, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "hris.CN_EDUCATIONAL_BACKGROUND_INSERT", action: 1, status: response.status, remarks: response.message);
            }
            return response;
        }
        public ResponseModel updateEmployeeEducation(EducationModel em)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_EDUCATIONAL_BACKGROUND_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // id
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

                        // _School
                        command.Parameters.AddWithValue("_School", em.School);
                        command.Parameters["_School"].Direction = ParameterDirection.Input;

                        // _Course
                        command.Parameters.AddWithValue("_Course", em.Course);
                        command.Parameters["_Course"].Direction = ParameterDirection.Input;

                        // _Attachment
                        command.Parameters.AddWithValue("_Attachment", em.Attachment);
                        command.Parameters["_Attachment"].Direction = ParameterDirection.Input;

                        // _Remarks
                        command.Parameters.AddWithValue("_Remarks", em.Remarks);
                        command.Parameters["_Remarks"].Direction = ParameterDirection.Input;

                        // _ModifiedBy
                        command.Parameters.AddWithValue("_ModifiedBy", em.ModifiedBy);
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

                        logs.insertActivityLogs(name: "hris.CN_EDUCATIONAL_BACKGROUND_UPDATE", action: 2, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "hris.CN_EDUCATIONAL_BACKGROUND_UPDATE", action: 2, status: response.status, remarks: response.message);
            }
            return response;
        }

       

        public ResponseModel getEmployeeEducationById(string employeeId)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_EDUCATIONAL_BACKGROUND_GET_BY_EMPLOYEEID";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<EducationModel> list_em = new List<EducationModel>();

                        command.Parameters.AddWithValue("_EmpID", employeeId);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                EducationModel em = new EducationModel();

                                em.ID = Convert.ToInt32(rdr["ID"]);
                                em.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                em.StartDate = Convert.ToDateTime(rdr["StartDate"]).ToString("MM/dd/yyyy");
                                em.EndDate = Convert.ToDateTime(rdr["EndDate"]).ToString("MM/dd/yyyy");
                                em.School = rdr["School"].ToString();
                                em.Course = rdr["Course"].ToString();
                                em.Attachment = rdr["Attachment"].ToString();
                                em.Remarks = rdr["Remarks"].ToString();
                                em.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MM/dd/yyyy hh:mm ss");
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

                        logs.insertActivityLogs(name: "hris.CN_EDUCATIONAL_BACKGROUND_GET_BY_EMPLOYEEID", action: 5, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "hris.CN_EDUCATIONAL_BACKGROUND_GET_BY_EMPLOYEEID", action: 5, status: response.status, remarks: response.message);
            }

            return response;
        }
    }
}