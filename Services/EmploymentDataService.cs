

/*[10/13/2021] CN E.Patot*/
/*[10/14/2021] CN E.Patot*/
/*[10/20/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;


namespace BackEnd.Services
{
    public class EmploymentDataService
    {
        public ResponseModel response = new ResponseModel();
        public ResponseModel logResponse = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel getAllEmploymentDataById(int id)
        {
            try
            {
                //Connecting to Database
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "SELECT * FROM hris.CN_EMPLOYEE_EMPLOYMENT_DATA_V WHERE (NOW() BETWEEN StartDate AND EndDate) AND EmpID = '" + id + "'";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);



                        List<EmploymentDataModel> list_ed = new List<EmploymentDataModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            EmploymentDataModel ed = new EmploymentDataModel();
                            if (rdr["id"] != null)
                            {
                                ed.id = Convert.ToInt32(rdr["id"]);
                                ed.emp_id = Convert.ToInt32(rdr["EmpID"]);
                                ed.StartDate = Convert.ToDateTime(rdr["StartDate"]).ToString("MM/dd/yyyy");
                                ed.EndDate = Convert.ToDateTime(rdr["EndDate"]).ToString("MM/dd/yyyy");
                                ed.company_id = Convert.ToString(rdr["CompanyName"]);
                                ed.department_id = Convert.ToString(rdr["DepartmentName"]);
                                ed.EmploymentStatusID = Convert.ToString(rdr["EmployeeStatus"]);
                                ed.EmploymentTypeID = Convert.ToString(rdr["EmploymentType"]);
                                ed.JobLevelID = Convert.ToString(rdr["JobLevel"]);
                                ed.JobTypeID = Convert.ToString(rdr["JobCategory"]);
                                ed.JobCodeID = Convert.ToString(rdr["JobCode"]);
                                ed.JobFamilyNameID = Convert.ToString(rdr["JobFamilyName"]);
                                ed.PositionID = Convert.ToString(rdr["Designation"]);
                                ed.GradeID = Convert.ToString(rdr["GradeStepName"]);
                                ed.JobType = Convert.ToString(rdr["JobType"]);
                                ed.LocationID = Convert.ToString(rdr["Location"]);
                                ed.Section = rdr["Section"].ToString();
                                ed.SiteID = Convert.ToString(rdr["Site"]);
                                ed.ReasonID = Convert.ToString(rdr["Reason"]);
                                ed.SubDept = rdr["SubDept"].ToString();
                                ed.BusinessUnitID = Convert.ToString(rdr["BUName"]);
                                ed.DivisionID = Convert.ToString(rdr["DivisionName"]);
                                ed.GradeRateID = Convert.ToString(rdr["GradeRateName"]);
                                ed.WorkerTypeID = Convert.ToString(rdr["WorkerType"]);
                                ed.ModifiedBy = rdr["ModifiedBy"].ToString();
                                ed.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                ed.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                ed.ProjectID = rdr["ProjectName"].ToString();
                                ed.UnionMember = rdr["UnionMember"].ToString();

                                list_ed.Add(ed);
                            }
                        }
                        response.code = consts.CODE_OK;
                        response.status = consts.SUCCESS;
                        response.error = consts.ERROR_FALSE;
                        response.message = consts.SUCCESS_RETRIEVE;
                        response.data = list_ed;
                        conn.Close();

                        logResponse = logs.insertActivityLogs(name: "SELECT * FROM hris.CN_EMPLOYEE_EMPLOYMENT_DATA_V WHERE (NOW() BETWEEN StartDate AND EndDate) AND EmpID = '" + id + "'", action: 4, status: response.status, remarks: response.message);
                    }

                }
            }
            catch (Exception ex)
            {
                logResponse = logs.insertActivityLogs(name: "SELECT * FROM hris.CN_EMPLOYEE_EMPLOYMENT_DATA_V WHERE (NOW() BETWEEN StartDate AND EndDate) AND EmpID = '" + id + "'", action: 4, status: consts.ERROR, remarks: ex.Message);
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
            }

            return response;
        }

        public ResponseModel createEmploymentData(EmploymentDataModel edm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "hris.CN_EMPLOYMENT_DATA_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                        command.Parameters.Clear();


                        // Employee Id
                        command.Parameters.AddWithValue("_EmpID", edm.emp_id);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;
                        // Start date
                        command.Parameters.AddWithValue("_StartDate", edm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;
                        // End date
                        command.Parameters.AddWithValue("_EndDate", edm.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // Company Id
                        command.Parameters.AddWithValue("_CompanyID", edm.company_id);
                        command.Parameters["_CompanyID"].Direction = ParameterDirection.Input;

                        // Department Id
                        command.Parameters.AddWithValue("_DepartmentID", edm.department_id);
                        command.Parameters["_DepartmentID"].Direction = ParameterDirection.Input;

                        // Employment Status Id
                        command.Parameters.AddWithValue("_EmployeeStatusID", edm.EmploymentStatusID);
                        command.Parameters["_EmployeeStatusID"].Direction = ParameterDirection.Input;

                        // Employment Type Id 
                        command.Parameters.AddWithValue("_EmploymentTypeID", edm.EmploymentTypeID);
                        command.Parameters["_EmploymentTypeID"].Direction = ParameterDirection.Input;

                        // Job Level Id
                        command.Parameters.AddWithValue("_JobLevelID", edm.JobLevelID);
                        command.Parameters["_JobLevelID"].Direction = ParameterDirection.Input;

                        // Job Category Id
                        command.Parameters.AddWithValue("_JobCategoryID", edm.JobTypeID);
                        command.Parameters["_JobCategoryID"].Direction = ParameterDirection.Input;

                        // Designation Id
                        command.Parameters.AddWithValue("_DesignationID", edm.PositionID);
                        command.Parameters["_DesignationID"].Direction = ParameterDirection.Input;

                        // Location Id
                        command.Parameters.AddWithValue("_LocationID", edm.LocationID);
                        command.Parameters["_LocationID"].Direction = ParameterDirection.Input;



                        // Project Id
                        command.Parameters.AddWithValue("_ProjectID", edm.ProjectID);
                        command.Parameters["_ProjectID"].Direction = ParameterDirection.Input;

                        // Site Id
                        command.Parameters.AddWithValue("_SiteID", edm.SiteID);
                        command.Parameters["_SiteID"].Direction = ParameterDirection.Input;

                        // Reason Id
                        command.Parameters.AddWithValue("_ReasonID", edm.ReasonID);
                        command.Parameters["_ReasonID"].Direction = ParameterDirection.Input;


                        // Business Unit Id 
                        command.Parameters.AddWithValue("_BusinessUnitID", edm.BusinessUnitID);
                        command.Parameters["_BusinessUnitID"].Direction = ParameterDirection.Input;

                        // Section
                        command.Parameters.AddWithValue("_Section", edm.Section);
                        command.Parameters["_Section"].Direction = ParameterDirection.Input;

                        // Job Family Name Id
                        command.Parameters.AddWithValue("_JobFamilyNameID", edm.JobFamilyNameID);
                        command.Parameters["_JobFamilyNameID"].Direction = ParameterDirection.Input;

                        // Job Code Id
                        command.Parameters.AddWithValue("_JobCodeID", edm.JobCodeID);
                        command.Parameters["_JobCodeID"].Direction = ParameterDirection.Input;


                        // Union Member
                        command.Parameters.AddWithValue("_UnionMember", edm.UnionMember);
                        command.Parameters["_UnionMember"].Direction = ParameterDirection.Input;

                        // Division Id
                        command.Parameters.AddWithValue("_DivisionID", edm.DivisionID);
                        command.Parameters["_DivisionID"].Direction = ParameterDirection.Input;

                        // Grade Id
                        command.Parameters.AddWithValue("_GradeID", edm.GradeID);
                        command.Parameters["_GradeID"].Direction = ParameterDirection.Input;

                        // Grade rate Id
                        command.Parameters.AddWithValue("_GradeRateID", edm.GradeRateID);
                        command.Parameters["_GradeRateID"].Direction = ParameterDirection.Input;

                        // Worker type Id
                        command.Parameters.AddWithValue("_WorkerTypeID", edm.WorkerTypeID);
                        command.Parameters["_WorkerTypeID"].Direction = ParameterDirection.Input;

                        // Modified by
                        command.Parameters.AddWithValue("_ModifiedBy", edm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        // Job Type
                        command.Parameters.AddWithValue("_JobType", edm.JobTypeID);
                        command.Parameters["_JobType"].Direction = ParameterDirection.Input;

                        int row_count = command.ExecuteNonQuery();

                        if (row_count == 1)
                        {
                            response.code = consts.CODE_OK;
                            response.status = consts.SUCCESS;
                            response.error = consts.ERROR_FALSE;
                            response.message = consts.SUCCESS_INSERT;
                            response.data = null;
                            command.Transaction.Commit();
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

                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_EMPLOYMENT_DATA_INSERT", action: 1, status: response.status, remarks: response.message);
                    }
                }

            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "hris.CN_EMPLOYMENT_DATA_INSERT", action: 1, status: response.status, remarks: ex.Message);
            }

            return response;
        }
        public ResponseModel updateEmploymentData(EmploymentDataModel edm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "hris.CN_EMPLOYMENT_DATA_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                        command.Parameters.Clear();

                        // ID
                        command.Parameters.AddWithValue("_ID", edm.id);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        // Employee Id
                        command.Parameters.AddWithValue("_EmpID", edm.emp_id);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;
                        // Start date
                        command.Parameters.AddWithValue("_StartDate", edm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;
                        // End date
                        command.Parameters.AddWithValue("_EndDate", edm.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // Company Id
                        command.Parameters.AddWithValue("_CompanyID", edm.company_id);
                        command.Parameters["_CompanyID"].Direction = ParameterDirection.Input;

                        // Department Id
                        command.Parameters.AddWithValue("_DepartmentID", edm.department_id);
                        command.Parameters["_DepartmentID"].Direction = ParameterDirection.Input;

                        // Employment Status Id
                        command.Parameters.AddWithValue("_EmployeeStatusID", edm.EmploymentStatusID);
                        command.Parameters["_EmployeeStatusID"].Direction = ParameterDirection.Input;

                        // Employment Type Id 
                        command.Parameters.AddWithValue("_EmploymentTypeID", edm.EmploymentTypeID);
                        command.Parameters["_EmploymentTypeID"].Direction = ParameterDirection.Input;

                        // Job Level Id
                        command.Parameters.AddWithValue("_JobLevelID", edm.JobLevelID);
                        command.Parameters["_JobLevelID"].Direction = ParameterDirection.Input;

                        // Job Category Id
                        command.Parameters.AddWithValue("_JobCategoryID", edm.JobTypeID);
                        command.Parameters["_JobCategoryID"].Direction = ParameterDirection.Input;

                        // Designation Id
                        command.Parameters.AddWithValue("_DesignationID", edm.PositionID);
                        command.Parameters["_DesignationID"].Direction = ParameterDirection.Input;

                        // Location Id
                        command.Parameters.AddWithValue("_LocationID", edm.LocationID);
                        command.Parameters["_LocationID"].Direction = ParameterDirection.Input;



                        // Project Id
                        command.Parameters.AddWithValue("_ProjectID", edm.ProjectID);
                        command.Parameters["_ProjectID"].Direction = ParameterDirection.Input;

                        // Site Id
                        command.Parameters.AddWithValue("_SiteID", edm.SiteID);
                        command.Parameters["_SiteID"].Direction = ParameterDirection.Input;

                        // Reason Id
                        command.Parameters.AddWithValue("_ReasonID", edm.ReasonID);
                        command.Parameters["_ReasonID"].Direction = ParameterDirection.Input;


                        // Business Unit Id 
                        command.Parameters.AddWithValue("_BusinessUnitID", edm.BusinessUnitID);
                        command.Parameters["_BusinessUnitID"].Direction = ParameterDirection.Input;

                        // Section
                        command.Parameters.AddWithValue("_Section", edm.Section);
                        command.Parameters["_Section"].Direction = ParameterDirection.Input;

                        // Job Family Name Id
                        command.Parameters.AddWithValue("_JobFamilyNameID", edm.JobFamilyNameID);
                        command.Parameters["_JobFamilyNameID"].Direction = ParameterDirection.Input;

                        // Job Code Id
                        command.Parameters.AddWithValue("_JobCodeID", edm.JobCodeID);
                        command.Parameters["_JobCodeID"].Direction = ParameterDirection.Input;

                      

                        // Union Member
                        command.Parameters.AddWithValue("_UnionMember", edm.UnionMember);
                        command.Parameters["_UnionMember"].Direction = ParameterDirection.Input;

                        // Division Id
                        command.Parameters.AddWithValue("_DivisionID", edm.DivisionID);
                        command.Parameters["_DivisionID"].Direction = ParameterDirection.Input;

                        // Grade Id
                        command.Parameters.AddWithValue("_GradeID", edm.GradeID);
                        command.Parameters["_GradeID"].Direction = ParameterDirection.Input;

                        // Grade rate Id
                        command.Parameters.AddWithValue("_GradeRateID", edm.GradeRateID);
                        command.Parameters["_GradeRateID"].Direction = ParameterDirection.Input;

                        // Worker type Id
                        command.Parameters.AddWithValue("_WorkerTypeID", edm.WorkerTypeID);
                        command.Parameters["_WorkerTypeID"].Direction = ParameterDirection.Input;

                        // Modified by
                        command.Parameters.AddWithValue("_ModifiedBy", edm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;


                        // Job Type
                        command.Parameters.AddWithValue("_JobType", edm.JobTypeID);
                        command.Parameters["_JobType"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("success", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        int row_count = command.ExecuteNonQuery();

                        if (row_count > 0)
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
                        logs.insertActivityLogs(name: "hris.CN_EMPLOYMENT_DATA_UPDATE", action: 2, status: response.status, remarks: response.message);
                    }
                }

            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "hris.CN_EMPLOYMENT_DATA_UPDATE", action: 2, status: response.status, remarks: ex.Message);
            }

            return response;
        }

    }
}   