
/*[10/12/2021] CN E.Patot*/
/*[10/14/2021] CN E.Patot*/
/*[10/20/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Models.Masterfile;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;


namespace BackEnd.Services
{
    public class MasterFileService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        // Get All Suffix
        public ResponseModel getAllSuffixSetup()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_suffix_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<Suffix_SetupModel> list_sfsm = new List<Suffix_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                Suffix_SetupModel sfsm = new Suffix_SetupModel();

                                sfsm.ID = Convert.ToInt32(rdr["ID"]);
                                sfsm.Suffix = rdr["Suffix"].ToString();
                                sfsm.CreatedDate = rdr["CreatedDate"].ToString();
                                sfsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                sfsm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                list_sfsm.Add(sfsm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_sfsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS_RETRIEVE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_suffix_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_suffix_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getAllPrefix()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_prefix_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<Prefix_SetupModel> list_pxsm = new List<Prefix_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                Prefix_SetupModel sfsm = new Prefix_SetupModel();

                                sfsm.ID = Convert.ToInt32(rdr["ID"]);
                                sfsm.Prefix = rdr["Prefix"].ToString();
                                sfsm.CreatedDate = rdr["CreatedDate"].ToString();
                                sfsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                sfsm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                list_pxsm.Add(sfsm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_pxsm;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_prefix_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_prefix_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getCountry()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT* FROM hris.mf_country_setup order by CountryName";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<Country_SetupModel> list_pxsm = new List<Country_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                Country_SetupModel sfsm = new Country_SetupModel();

                                sfsm.ID = Convert.ToInt32(rdr["ID"]);
                                sfsm.CountryName= rdr["CountryName"].ToString();
                                sfsm.CreatedDate = rdr["CreatedDate"].ToString();
                                sfsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                sfsm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                list_pxsm.Add(sfsm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_pxsm;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT* FROM hris.mf_country_setup order by CountryName", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT* FROM hris.mf_country_setup order by CountryName", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }
        
        public ResponseModel getAllBanks()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_bank";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<Bank_SetupModel> list_bsm = new List<Bank_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                Bank_SetupModel bsm = new Bank_SetupModel();

                                bsm.ID = Convert.ToInt32(rdr["ID"]);
                                bsm.BankCode = rdr["BankCode"].ToString();
                                bsm.BankName = rdr["BankName"].ToString();
                                bsm.CreatedDate = rdr["CreatedDate"].ToString();
                                bsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                bsm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                list_bsm.Add(bsm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_bsm;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_bank", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_bank", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getRegularizationPA()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_default_regularization_pa";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<DefaultRegularizationPAModel> list_drpm = new List<DefaultRegularizationPAModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                DefaultRegularizationPAModel drpm = new DefaultRegularizationPAModel();

                                drpm.ID = Convert.ToInt32(rdr["ID"]);
                                drpm.Default = Convert.ToInt32(rdr["Default"]);
                                drpm.Description = rdr["Description"].ToString();
                                drpm.CreatedDate = rdr["CreatedDate"].ToString();
                                drpm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                drpm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                list_drpm.Add(drpm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_drpm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS_RETRIEVE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_default_regularization_pa", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_default_regularization_pa", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getAllBloodTypes()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_blood_type";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<BloodType_SetupModel> list_btsm = new List<BloodType_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                BloodType_SetupModel btsm = new BloodType_SetupModel();

                                btsm.ID = Convert.ToInt32(rdr["ID"]);
                                btsm.BloodType = rdr["BloodType"].ToString();
                                btsm.CreatedDate = rdr["CreatedDate"].ToString();
                                btsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                btsm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                list_btsm.Add(btsm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_btsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS_RETRIEVE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_blood_type", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_blood_type", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getAllGPA()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_gpa_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<GPA_SetupModel> list_gpasm = new List<GPA_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                GPA_SetupModel gpasm = new GPA_SetupModel();

                                gpasm.ID = Convert.ToInt32(rdr["ID"]);
                                gpasm.Level = rdr["Level"].ToString();
                                gpasm.Amount = Convert.ToDouble(rdr["Amount"]);
                                gpasm.CreatedDate = rdr["CreatedDate"].ToString();
                                gpasm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                gpasm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                list_gpasm.Add(gpasm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_gpasm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS_RETRIEVE;

                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_gpa_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_gpa_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getCompanySetup()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_company";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<CompanySetup_Model> list_csm = new List<CompanySetup_Model>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                CompanySetup_Model csm = new CompanySetup_Model();

                                csm.ID = Convert.ToInt32(rdr["ID"]);
                                csm.CompanyCode = rdr["CompanyCode"].ToString();
                                csm.CompanyName = rdr["CompanyName"].ToString();
                                csm.EffectiveStartDate = rdr["EffectiveStartDate"].ToString();
                                csm.EffectiveEndDate = rdr["EffectiveEndDate"].ToString();
                                csm.ClassificationName = rdr["ClassificationName"].ToString();
                                csm.ClassificationEffectiveDate = rdr["ClassificationEffectiveDate"].ToString();
                                csm.ExtraInfoEffectiveStartDate = rdr["ExtraInfoEffectiveStartDate"].ToString();
                                csm.LegislationCode = rdr["LegislationCode"].ToString();
                                csm.LeiInformationCategory = rdr["LeiInformationCategory"].ToString();
                                csm.SetCode = rdr["SetCode"].ToString();
                                csm.CreatedDate = rdr["CreatedDate"].ToString();
                                csm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                csm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                csm.SourceSystemID = rdr["SourceSystemID"].ToString();
                                csm.SourceSystemOwner = rdr["SourceSystemOwner"].ToString();

                                list_csm.Add(csm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_csm;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_company", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_company", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getDepartmentSetup()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_department_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<DepartmentSetup_Model> list_dsm = new List<DepartmentSetup_Model>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                DepartmentSetup_Model dsm = new DepartmentSetup_Model();

                                dsm.ID = Convert.ToInt32(rdr["ID"]);
                                dsm.DepartmentCode = rdr["DepartmentCode"].ToString();
                                dsm.DepartmentName = rdr["DepartmentName"].ToString();
                                dsm.EffectiveStartDate = rdr["EffectiveStartDate"].ToString();
                                dsm.EffectiveEndDate = rdr["EffectiveEndDate"].ToString();
                                dsm.ClassificationName = rdr["ClassificationName"].ToString();
                                dsm.ClassificationEffectiveDate = rdr["ClassificationEffectiveDate"].ToString();
                                dsm.ExtraInfoEffectiveStartDate = rdr["ExtraInfoEffectiveStartDate"].ToString();
                                dsm.LegislationCode = rdr["LegislationCode"].ToString();
                                dsm.LeiInformationCategory = rdr["LeiInformationCategory"].ToString();
                                dsm.SetCode = rdr["SetCode"].ToString();
                                dsm.CreatedDate = rdr["CreatedDate"].ToString();
                                dsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                dsm.SourceSystemID = rdr["SourceSystemID"].ToString();
                                dsm.SourceSystemOwner = rdr["SourceSystemOwner"].ToString();

                                list_dsm.Add(dsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_dsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;

                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_department_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            } 
            catch(Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_department_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getEmployeeStatus()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_employee_status_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<EmployeeStatusSetup_Model> list_essm = new List<EmployeeStatusSetup_Model>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                EmployeeStatusSetup_Model eesm = new EmployeeStatusSetup_Model();

                                eesm.ID = Convert.ToInt32(rdr["ID"]);
                                eesm.EmployeeStatus = rdr["EmployeeStatus"].ToString();
                                eesm.CreatedDate = rdr["CreatedDate"].ToString();
                                eesm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                eesm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_essm.Add(eesm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_essm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;

                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_employee_status_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_employee_status_setup", action: 4, status: response.status, remarks: response.message);
            }

            return response;
        }

        public ResponseModel getJobLevels()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_job_level_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<JobLevelSetup_Model> list_jlsm = new List<JobLevelSetup_Model>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                JobLevelSetup_Model jlsm = new JobLevelSetup_Model();

                                jlsm.ID = Convert.ToInt32(rdr["ID"]);
                                jlsm.JobLevel = rdr["JobLevel"].ToString();
                                jlsm.Level = Convert.ToInt32(rdr["Level"]);
                                jlsm.EffectiveStartDate = rdr["EffectiveStartDate"].ToString();
                                jlsm.EffectiveEndDate = rdr["EffectiveEndDate"].ToString();
                                jlsm.SetCode = rdr["SetCode"].ToString();
                                jlsm.ActiveStatus = rdr["ActiveStatus"].ToString();
                                jlsm.FullPartTime = rdr["FullPartTime"].ToString();
                                jlsm.JobFunctionCode = rdr["JobFunctionCode"].ToString();
                                jlsm.RegularTemporary = rdr["RegularTemporary"].ToString();
                                jlsm.BenchmarkJobCode = rdr["BenchmarkJobCode"].ToString();
                                jlsm.ProgressionJobCode = rdr["ProgressionJobCode"].ToString();
                                jlsm.ApprovalAuthority = (rdr["ApprovalAuthority"]).ToString();
                                jlsm.ActionReasonCode = rdr["ActionReasonCode"].ToString();
                                jlsm.ValidGradeEffectiveStartDate = rdr["ValidGradeEffectiveStartDate"].ToString();
                                jlsm.ValidGradeEffectiveEndDate = rdr["ValidGradeEffectiveEndDate"].ToString();
                                jlsm.GradeCode = rdr["GradeCode"].ToString();
                                jlsm.DateEvaluated = rdr["DateEvaluated"].ToString();
                                jlsm.EvaluationSystem = rdr["EvaluationSystem"].ToString();
                                jlsm.CreatedDate = rdr["CreatedDate"].ToString();
                                jlsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                jlsm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                jlsm.SourceSystemID = rdr["SourceSystemID"].ToString();
                                jlsm.SourceSystemOwner = rdr["SourceSystemOwner"].ToString();

                                list_jlsm.Add(jlsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_jlsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_job_level_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;        

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_job_level_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getJobCategory()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_job_category_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<JobCategorySetup_Model> list_jcsm = new List<JobCategorySetup_Model>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                JobCategorySetup_Model jcsm = new JobCategorySetup_Model();

                                jcsm.ID = Convert.ToInt32(rdr["ID"]);
                                jcsm.JobCategory = rdr["JobCategory"].ToString();
                                jcsm.CreatedDate = rdr["CreatedDate"].ToString();
                                jcsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                jcsm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_jcsm.Add(jcsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_jcsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_job_category_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_job_category_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }
        
        public ResponseModel getDesignation()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_designation_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<Designation_SetupModel> list_dsm = new List<Designation_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                Designation_SetupModel dsm = new Designation_SetupModel();

                                dsm.ID = Convert.ToInt32(rdr["ID"]);
                                dsm.Designation = rdr["Designation"].ToString();
                                dsm.PositionCode = rdr["PositionCode"].ToString();
                                dsm.EffectiveStartDate = rdr["EffectiveStartDate"].ToString();
                                dsm.EffectiveEndDate = rdr["EffectiveEndDate"].ToString();
                                dsm.BusinessUnitName = rdr["BusinessUnitName"].ToString();
                                dsm.JobSetCode = rdr["JobSetCode"].ToString();
                                dsm.LocationSetCode = rdr["LocationSetCode"].ToString();
                                dsm.EntryGradeSetCode = rdr["EntryGradeSetCode"].ToString();
                                dsm.ActiveStatus = rdr["ActiveStatus"].ToString();
                                dsm.SupervisorPersonNumber = rdr["SupervisorPersonNumber"].ToString();
                                dsm.HeadCount = Convert.ToInt32(rdr["HeadCount"]);
                                dsm.WorkingHours = Convert.ToInt32(rdr["WorkingHours"]);
                                dsm.Frequency = rdr["Frequency"].ToString();
                                dsm.OverlapAllowedFlag = rdr["OverlapAllowedFlag"].ToString();
                                dsm.SecurityClearance = rdr["SecurityClearance"].ToString();
                                dsm.ActionReasonCode = rdr["ActionReasonCode"].ToString();
                                dsm.GradeSetCode = rdr["GradeSetCode"].ToString();
                                dsm.GradeCode = rdr["GradeCode"].ToString();
                                dsm.SequenceNumber = Convert.ToInt32(rdr["SequenceNumber"]);
                                dsm.CreatedDate = rdr["CreatedDate"].ToString();
                                dsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                dsm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                dsm.SourceSystemID = rdr["SourceSystemID"].ToString();
                                dsm.SourceSystemOwner = rdr["SourceSystemOwner"].ToString();

                                list_dsm.Add(dsm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_dsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_designation_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_designation_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getLocations()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_location";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<LocationSetup_Model> list_lsm = new List<LocationSetup_Model>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                LocationSetup_Model lsm = new LocationSetup_Model();

                                lsm.ID = Convert.ToInt32(rdr["ID"]);
                                lsm.Location = rdr["Location"].ToString();                     
                                lsm.EffectiveStartDate = rdr["EffectiveStartDate"].ToString();
                                lsm.EffectiveEndDate = rdr["EffectiveEndDate"].ToString();
                                lsm.SetCode = rdr["SetCode"].ToString();
                                lsm.ActiveStatus = rdr["ActiveStatus"].ToString();
                                lsm.MainPhoneAreaCode = rdr["MainPhoneAreaCode"].ToString();
                                lsm.MainPhoneCountryCode = rdr["MainPhoneCountryCode"].ToString();
                                lsm.MainPhoneExtension = rdr["MainPhoneExtension"].ToString();
                                lsm.AddressLine1 = rdr["AddressLine1"].ToString();
                                lsm.AddressLine2 = rdr["AddressLine2"].ToString();
                                lsm.AddressLine3 = rdr["AddressLine3"].ToString();
                                lsm.AddressLine4 = rdr["AddressLine4"].ToString();
                                lsm.City = rdr["City"].ToString();
                                lsm.Province = rdr["Province"].ToString();
                                lsm.Country = rdr["Country"].ToString();
                                lsm.LeiInformationCategory = rdr["LeiInformationCategory"].ToString();
                                lsm.LegislationCode = rdr["LegislationCode"].ToString();
                                lsm.CreatedDate = rdr["CreatedDate"].ToString();
                                lsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                lsm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                lsm.SourceSystemID = rdr["SourceSystemID"].ToString();
                                lsm.SourceSystemOwner = rdr["SourceSystemOwner"].ToString();

                                list_lsm.Add(lsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_lsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_location", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_location", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getRegion()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_region_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<Region_SetupModel> list_rsm = new List<Region_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                Region_SetupModel rsm = new Region_SetupModel();

                                rsm.ID = Convert.ToInt32(rdr["ID"]);
                                rsm.Location = rdr["Location"].ToString();
                                rsm.MinWage = Convert.ToDouble(rdr["MinWage"]);
                                rsm.CreatedDate = rdr["CreatedDate"].ToString();
                                rsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                rsm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_rsm.Add(rsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_rsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_region_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_region_setup", action: 4, status: response.status, remarks: response.message);

            }
            return response;
        }

        public ResponseModel getProjects()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_project_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<ProjectSetup_Model> list_psm = new List<ProjectSetup_Model>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                ProjectSetup_Model psm = new ProjectSetup_Model();

                                psm.ID = Convert.ToInt32(rdr["ID"]);
                                psm.ProjectCode = rdr["ProjectCode"].ToString();
                                psm.ProjectName = rdr["ProjectName"].ToString();
                                psm.CreatedDate = rdr["CreatedDate"].ToString();
                                psm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                psm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_psm.Add(psm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_psm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_project_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_project_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getSites()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_site_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<Site_SetupModel> list_ssm = new List<Site_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                Site_SetupModel ssm = new Site_SetupModel();

                                ssm.ID = Convert.ToInt32(rdr["ID"]);
                                ssm.Site = rdr["Site"].ToString();
                                ssm.CreatedDate = rdr["CreatedDate"].ToString();
                                ssm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                ssm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_ssm.Add(ssm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_ssm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_site_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_site_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getReasons()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_reason_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<Reason_SetupModel> list_rsm = new List<Reason_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                Reason_SetupModel rsm = new Reason_SetupModel();

                                rsm.ID = Convert.ToInt32(rdr["ID"]);
                                rsm.Reason = rdr["Reason"].ToString();
                                rsm.CreatedDate = rdr["CreatedDate"].ToString();
                                rsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                rsm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_rsm.Add(rsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_rsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_reason_setup", action: 4, status: response.status, remarks: response.message);

                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_reason_setup", action: 4, status: response.status, remarks: response.message);

            }
            return response;
        }

        public ResponseModel getBusinessUnits()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_business_unit";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<BusinessUnit_SetupModel> list_busm = new List<BusinessUnit_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                BusinessUnit_SetupModel busm = new BusinessUnit_SetupModel();

                                busm.ID = Convert.ToInt32(rdr["ID"]);
                                busm.BUCode = rdr["BUCode"].ToString();
                                busm.BUName = rdr["BUName"].ToString();
                                busm.CreatedDate = rdr["CreatedDate"].ToString();
                                busm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                busm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_busm.Add(busm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_busm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;

                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_business_unit", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;
                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_business_unit", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getJobFamilyNames()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_job_family_name_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<JobFamilyName_SetupModel> list_jfmsm = new List<JobFamilyName_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                JobFamilyName_SetupModel jfmsm = new JobFamilyName_SetupModel();

                                jfmsm.ID = Convert.ToInt32(rdr["ID"]);
                                jfmsm.JobFamilyName = rdr["JobFamilyName"].ToString();
                                jfmsm.EffectiveStartDate = rdr["EffectiveStartDate"].ToString();
                                jfmsm.EffectiveEndDate = rdr["EffectiveEndDate"].ToString();
                                jfmsm.ActionReasonCode = rdr["ActionReasonCode"].ToString();
                                jfmsm.ActiveStatus = rdr["ActiveStatus"].ToString();
                                jfmsm.CreatedDate = rdr["CreatedDate"].ToString();
                                jfmsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                jfmsm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                jfmsm.SourceSystemID = rdr["SourceSystemID"].ToString();
                                jfmsm.SourceSystemOwner = rdr["SourceSystemOwner"].ToString();

                                list_jfmsm.Add(jfmsm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_jfmsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_business_unit", action: 4, status: response.status, remarks: response.message);

                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_business_unit", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getJobCodes()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_job_code_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<JobCode_SetupModel> list_jcsm = new List<JobCode_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                JobCode_SetupModel jcsm = new JobCode_SetupModel();

                                jcsm.ID = Convert.ToInt32(rdr["ID"]);
                                jcsm.JobCode = rdr["JobCode"].ToString();
                                jcsm.CreatedDate = rdr["CreatedDate"].ToString();
                                jcsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                jcsm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_jcsm.Add(jcsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_jcsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_job_code_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_job_code_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getJobCategories()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_job_category_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<JobCategorySetup_Model> list_jcsm = new List<JobCategorySetup_Model>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                JobCategorySetup_Model jcsm = new JobCategorySetup_Model();

                                jcsm.ID = Convert.ToInt32(rdr["ID"]);
                                jcsm.JobCategory = rdr["JobCategory"].ToString();
                                jcsm.CreatedDate = rdr["CreatedDate"].ToString();
                                jcsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                jcsm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_jcsm.Add(jcsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_jcsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_job_category_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_job_category_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getEmploymentType()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_employment_type_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<EmploymentType_SetupModel> list_etsm = new List<EmploymentType_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                EmploymentType_SetupModel etsm = new EmploymentType_SetupModel();

                                etsm.ID = Convert.ToInt32(rdr["ID"]);
                                etsm.EmploymentType = rdr["EmploymentType"].ToString();
                                etsm.CreatedDate = rdr["CreatedDate"].ToString();
                                etsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                etsm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_etsm.Add(etsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_etsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_employment_type_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;
                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_employment_type_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getCivilStatus()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_default_civilstatus";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<CivilStatus_SetupModel> list_cssm = new List<CivilStatus_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                CivilStatus_SetupModel cssm = new CivilStatus_SetupModel();

                                cssm.ID = Convert.ToInt32(rdr["ID"]);
                                cssm.CivilStatus = rdr["CivilStatus"].ToString();
                                cssm.CreatedDate = rdr["CreatedDate"].ToString();
                                cssm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                cssm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_cssm.Add(cssm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_cssm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_default_civilstatus", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;
                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_default_civilstatus", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }
        public ResponseModel getDivisions()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_division_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<Division_SetupModel> list_dsm = new List<Division_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                Division_SetupModel dsm = new Division_SetupModel();

                                dsm.ID = Convert.ToInt32(rdr["ID"]);
                                dsm.DivisionCode = rdr["DivisionCode"].ToString();
                                dsm.DivisonName = rdr["DivisionName"].ToString();
                                dsm.mf_division_setupcol = rdr["mf_division_setupcol"].ToString();
                                dsm.CreatedDate = rdr["CreatedDate"].ToString();
                                dsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                dsm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_dsm.Add(dsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_dsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS_RETRIEVE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_division_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_division_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getGrades()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_grade_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<Grade_SetupModel> list_gsm = new List<Grade_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                Grade_SetupModel gsm = new Grade_SetupModel();

                                gsm.ID = Convert.ToInt32(rdr["ID"]);          
                                gsm.EffectiveStartDate = rdr["EffectiveStartDate"].ToString();
                                gsm.EffectiveEndDate = rdr["EffectiveEndDate"].ToString();
                                gsm.SetCode = rdr["SetCode"].ToString();
                                gsm.ActiveStatus = rdr["ActiveStatus"].ToString();
                                gsm.GradeStepName = rdr["GradeStepName"].ToString();
                                gsm.GradeStepEffectiveDate = rdr["GradeStepEffectiveDate"].ToString();
                                gsm.GradeStepSequence = Convert.ToInt32(rdr["GradeStepSequence"]);
                                gsm.CeilingStepFlag = Convert.ToInt32(rdr["CeilingStepFlag"]);
                                gsm.CreatedDate = rdr["CreatedDate"].ToString();
                                gsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                gsm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                gsm.SourceSystemID = rdr["SourceSystemID"].ToString();
                                gsm.SourceSystemOwner = rdr["SourceSystemOwner"].ToString();
                                list_gsm.Add(gsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_gsm;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_grade_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_grade_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getGradeRates()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_grade_rate_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<GradeRate_SetupModel> list_grsm = new List<GradeRate_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                GradeRate_SetupModel grsm = new GradeRate_SetupModel();

                                grsm.ID = Convert.ToInt32(rdr["ID"]);
                                grsm.GradeRateName = rdr["GradeRateName"].ToString();
                                grsm.EffectiveStartDate = rdr["EffectiveStartDate"].ToString();
                                grsm.EffectiveEndDate = rdr["EffectiveEndDate"].ToString();
                                grsm.LegislativeDataGroup = rdr["LegislativeDataGroup"].ToString();
                                grsm.RateType = rdr["RateType"].ToString();
                                grsm.CurrencyCode = rdr["CurrencyCode"].ToString();
                                grsm.RateFrequency = rdr["RateFrequency"].ToString();
                                grsm.AnnualizationFactor = Convert.ToInt32(rdr["AnnualizationFactor"]);
                                grsm.ActiveStatus = rdr["ActiveStatus"].ToString();
                                grsm.RateName = Convert.ToInt32(rdr["RateName"]);
                                grsm.MinAmount = Convert.ToInt32(rdr["MinAmount"]);
                                grsm.MaxAmount = Convert.ToInt32(rdr["MaxAmount"]);
                                grsm.MidValueAmount = Convert.ToInt32(rdr["MidValueAmount"]);
                                grsm.SetCode = rdr["SetCode"].ToString();
                                grsm.GradeCode = rdr["GradeCode"].ToString();
                                grsm.CreatedDate = rdr["CreatedDate"].ToString();
                                grsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                grsm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                grsm.SourceSystemID = rdr["SourceSystemID"].ToString();
                                grsm.SourceSystemOwner = rdr["SourceSystemOwner"].ToString();

                                list_grsm.Add(grsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_grsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_grade_rate_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_grade_rate_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getWorkerTypes()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_workertype_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<WorkerType_SetupModel> list_wtsm = new List<WorkerType_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                WorkerType_SetupModel wtsm = new WorkerType_SetupModel();

                                wtsm.ID = Convert.ToInt32(rdr["ID"]);
                                wtsm.WorkerType = rdr["WorkerType"].ToString();
                                wtsm.CreatedDate = rdr["CreatedDate"].ToString();
                                wtsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                wtsm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                wtsm.SourceSystemID = rdr["SourceSystemID"].ToString();
                                wtsm.SourceSystemOwner = rdr["SourceSystemOwner"].ToString();

                                list_wtsm.Add(wtsm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_wtsm;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
            }
            return response;
        }

        public ResponseModel getPayrollGroups()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_payroll_group_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<PayrollGroup_SetupModel> list_pgsm = new List<PayrollGroup_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                PayrollGroup_SetupModel pgsm = new PayrollGroup_SetupModel();

                                pgsm.ID = Convert.ToInt32(rdr["ID"]);
                                pgsm.PayrollGroup = rdr["PayrollGroup"].ToString();
                                pgsm.PayrollDays = Convert.ToInt32(rdr["PayrollDaysOT"]);
                                pgsm.PayrollDaysOT = Convert.ToInt32(rdr["PayrollDaysOT"]);
                                pgsm.DailyHours = Convert.ToDouble(rdr["DailyHours"]);
                                pgsm.WTaxComputation = Convert.ToInt32(rdr["WTaxComputation"]);
                                pgsm.SSSSchedule = Convert.ToInt32(rdr["SSSSchedule"]);
                                pgsm.SSSComputation = Convert.ToInt32(rdr["SSSComputation"]);
                                pgsm.PAGSchedule = Convert.ToInt32(rdr["PAGSchedule"]);
                                pgsm.PHILHEALTHSchedule = Convert.ToInt32(rdr["PHILHEALTHSchedule"]);
                                pgsm.PHILHEALTHComputation = Convert.ToInt32(rdr["PHILHEALTHComputation"]);
                                pgsm.ThirteenthMo = Convert.ToInt32(rdr["ThirteenthMo"]);
                                pgsm.FourteenthMo = Convert.ToInt32(rdr["FourteenthMo"]);
                                pgsm.FifteenthMo = Convert.ToInt32(rdr["FifteenthMo"]);
                                pgsm.PayslipFormat = Convert.ToInt32(rdr["PayslipFormat"]);
                                pgsm.MinTHPCT = Convert.ToDouble(rdr["MinTHPCT"]);
                                pgsm.RiceAllowance = Convert.ToDouble(rdr["RiceAllowance"]);
                                pgsm.RiceAllowSchedule = Convert.ToInt32(rdr["RiceAllowSchedule"]);
                                pgsm.MealAllowance = Convert.ToDouble(rdr["MealAllowance"]);
                                pgsm.TranspoAllowance = Convert.ToDouble(rdr["TranspoAllowance"]);
                                pgsm.NTaxMAMinWP = Convert.ToDouble(rdr["NTaxMAMinWP"]);
                                pgsm.UnionDue = Convert.ToDouble(rdr["UnionDue"]);
                                pgsm.RiceAllowSchedule = Convert.ToInt32(rdr["RiceAllowSchedule"]);
                                pgsm.UnionDueSchedule = Convert.ToInt32(rdr["UnionDueSchedule"]);
                                pgsm.DefaultShift = Convert.ToInt32(rdr["DefaultShift"]);
                                pgsm.CreatedDate = rdr["CreatedDate"].ToString();
                                pgsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                pgsm.ModifiedBy = rdr["ModifiedBy"].ToString();                   

                                list_pgsm.Add(pgsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_pgsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_payroll_group_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                
                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_payroll_group_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getTimekeepings()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_timekeeping_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<TimeKeeping_SetupModel> list_tksm = new List<TimeKeeping_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                TimeKeeping_SetupModel tksm = new TimeKeeping_SetupModel();

                                tksm.ID = Convert.ToInt32(rdr["ID"]);
                                tksm.Timekeeping = rdr["Timekeeping"].ToString();
                                tksm.CreatedDate = rdr["CreatedDate"].ToString();
                                tksm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                tksm.ModifiedBy = rdr["ModifiedBy"].ToString();
                   
                                list_tksm.Add(tksm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_tksm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_timekeeping_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_timekeeping_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getTaxStatus()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_tax_status_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<TaxStatus_SetupModel> list_tssm= new List<TaxStatus_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                TaxStatus_SetupModel tssm = new TaxStatus_SetupModel();

                                tssm.ID = Convert.ToInt32(rdr["ID"]);
                                tssm.TaxStatus = rdr["TaxStatus"].ToString();
                                tssm.CreatedDate = rdr["CreatedDate"].ToString();
                                tssm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                tssm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_tssm.Add(tssm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_tssm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();
                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_tax_status_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_tax_status_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getDefaultPayFrequency()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_default_payfrequency_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<DefaultPayFrequency_SetupModel> list_dpfm = new List<DefaultPayFrequency_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                DefaultPayFrequency_SetupModel dpfm = new DefaultPayFrequency_SetupModel();

                                dpfm.ID = Convert.ToInt32(rdr["ID"]);
                                dpfm.PayFrequency = rdr["PayFrequency"].ToString();
                                dpfm.CreatedDate = rdr["CreatedDate"].ToString();
                                dpfm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                dpfm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_dpfm.Add(dpfm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_dpfm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_default_payfrequency_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_default_payfrequency_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getShiftSets()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_shift_set_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<ShiftSet_SetupModel> list_sssm = new List<ShiftSet_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                ShiftSet_SetupModel sssm = new ShiftSet_SetupModel();

                                sssm.ID = Convert.ToInt32(rdr["ID"]);
                                sssm.ShiftSetName = rdr["ShiftSetName"].ToString();
                                sssm.Mon = Convert.ToInt32(rdr["Mon"]);
                                sssm.Tue = Convert.ToInt32(rdr["Tue"]);
                                sssm.Wed = Convert.ToInt32(rdr["Wed"]);
                                sssm.Thu = Convert.ToInt32(rdr["Thu"]);
                                sssm.Fri = Convert.ToInt32(rdr["Fri"]);
                                sssm.Sat = Convert.ToInt32(rdr["Sat"]);
                                sssm.Sun = Convert.ToInt32(rdr["Sun"]);
                                sssm.CreatedDate = rdr["CreatedDate"].ToString();
                                sssm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                sssm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_sssm.Add(sssm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_sssm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_shift_set_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_shift_set_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getAllDMAccount()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.payroll_DMAccount_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<DMAccount_SetupModel> list_dmam = new List<DMAccount_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                DMAccount_SetupModel dmam = new DMAccount_SetupModel();

                                dmam.ID = Convert.ToInt32(rdr["ID"]);
                                dmam.Description = rdr["Description"].ToString();
                                dmam.CreatedDate = rdr["CreatedDate"].ToString();
                                dmam.ModifiedDate = rdr["ModifiedDate"].ToString();
                                dmam.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_dmam.Add(dmam);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_dmam;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.payroll_DMAccount_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "SELECT * FROM hris.payroll_DMAccount_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel 
            getAllPayDeduction()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.payroll_deduction_code_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<PayrollDeductionCode_SetupModel> list_pdsm = new List<PayrollDeductionCode_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                PayrollDeductionCode_SetupModel pdsm = new PayrollDeductionCode_SetupModel();

                                pdsm.ID = Convert.ToInt32(rdr["ID"]);
                                pdsm.DeductionCode = rdr["DeductionCode"].ToString();
                                pdsm.DeductionName = rdr["DeductionName"].ToString();
                                pdsm.DeductionTypeID = rdr["DeductionTypeID"].ToString();
                                pdsm.Priority = rdr["Priority"].ToString();
                                pdsm.OrderNo = rdr["Priority"].ToString();
                                pdsm.AccountID = rdr["AccountID"].ToString();
                                pdsm.CreatedDate = rdr["CreatedDate"].ToString();
                                pdsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                pdsm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_pdsm.Add(pdsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_pdsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.payroll_deduction_code_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.payroll_deduction_code_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }


        public ResponseModel getAllApproverGroups()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_approver_group";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<ApproverGroup_SetupModel> list_apsm = new List<ApproverGroup_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                ApproverGroup_SetupModel apsm = new ApproverGroup_SetupModel();

                                apsm.ID = Convert.ToInt32(rdr["ID"]);
                                apsm.Description = rdr["Description"].ToString();
                                apsm.Sequence = rdr["Sequence"].ToString();
                                apsm.Type = rdr["Type"].ToString();
                                apsm.Value = rdr["Value"].ToString();
                                apsm.CreatedDate = rdr["CreatedDate"].ToString();
                                apsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                apsm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_apsm.Add(apsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_apsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.payroll_deduction_code_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.payroll_deduction_code_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }


        public ResponseModel getAllApprovalGroups()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT DISTINCT * FROM hris.mf_workflow_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<ApprovalGroup_SetupModel> list_apsm = new List<ApprovalGroup_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                ApprovalGroup_SetupModel apsm = new ApprovalGroup_SetupModel();

                                apsm.ID = Convert.ToInt32(rdr["ID"]);
                                apsm.Description = rdr["Description"].ToString();
                                apsm.Layer = rdr["Layer"].ToString();
                                apsm.Type = rdr["Type"].ToString();
                                apsm.ApproverGroup = rdr["ApproverGroup"].ToString();
                                apsm.CreatedDate = rdr["CreatedDate"].ToString();
                                apsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                apsm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_apsm.Add(apsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_apsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT DISTINCT * FROM hris.mf_workflow_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT DISTINCT * FROM hris.mf_workflow_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getDependentsType()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_dependents_type";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<DependentsType_SetupModel> list_apsm = new List<DependentsType_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                DependentsType_SetupModel apsm = new DependentsType_SetupModel();

                                apsm.ID = Convert.ToInt32(rdr["ID"]);
                                apsm.DepType = rdr["DepType"].ToString();
                               
                                apsm.CreatedDate = rdr["CreatedDate"].ToString();
                                apsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                apsm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_apsm.Add(apsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_apsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_dependents_type", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_dependents_type", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel
            getAllPayRates()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_payrate_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<PayRate_SetupModel> list_prsm = new List<PayRate_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                PayRate_SetupModel prsm = new PayRate_SetupModel();

                                prsm.ID = Convert.ToInt32(rdr["ID"]);
                                prsm.PayRate = rdr["PayRate"].ToString();
                                prsm.CreatedDate = rdr["CreatedDate"].ToString();
                                prsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                prsm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_prsm.Add(prsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_prsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_payrate_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_payrate_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }


        public ResponseModel getAllApproverAndRater()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT EmpID as ID, CONCAT(Firstname, ' ',Middlename,' ',Lastname) AS Fullname FROM CN_EMPLOYEE_MASTER_V";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<ApproverAndRater_SetupModel> list_apsm = new List<ApproverAndRater_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                ApproverAndRater_SetupModel apsm = new ApproverAndRater_SetupModel();

                                apsm.ID = Convert.ToInt32(rdr["ID"]);
                                apsm.FullName = rdr["FullName"].ToString(); 
                                list_apsm.Add(apsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_apsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT CONCAT(FirstName, ' ', Lastname) as Fullname, EmpID FROM hris.employee_master", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.payroll_deduction_code_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getAllPayCodes()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.payroll_paycodes_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<PayrollPaycode_SetupModel> list_ppsm = new List<PayrollPaycode_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                PayrollPaycode_SetupModel ppsm = new PayrollPaycode_SetupModel();

                                ppsm.ID = Convert.ToInt32(rdr["ID"]);
                                ppsm.PayCode = rdr["PayCode"].ToString();
                                ppsm.PayName = rdr["PayName"].ToString();
                                ppsm.PayTypeID = Convert.ToInt32(rdr["PayTypeID"]);
                                ppsm.PayRate = Convert.ToInt32(rdr["PayRate"]);
                                ppsm.OrderNo = Convert.ToInt32(rdr["OrderNo"]);
                                ppsm.PhilHealth = Convert.ToInt32(rdr["PhilHealth"]);
                                ppsm.SSS = Convert.ToInt32(rdr["SSS"]);
                                ppsm.CreatedDate = rdr["CreatedDate"].ToString();
                                ppsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                ppsm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                ppsm.AccountID = Convert.ToInt32(rdr["AccountID"]);

                                list_ppsm.Add(ppsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_ppsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.payroll_paycodes_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.payroll_paycodes_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getPayrollPeriodSetup()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT ID, PeriodID, Year, StartDate, EndDate, PayOutDate, StartDate_MonthID, EndDate_MonthID, " +
                            "CreatedDate, ModifiedDate, ModifiedBy, PayrollGroupId, PayrollGroup, Description," +
                            "CONCAT(DATE_FORMAT(`StartDate`, '%m/%d/%Y'), ' - ', DATE_FORMAT(`EndDate`, '%m/%d/%Y'), ' (',`PeriodID`, ' ',`Year`, ')') as StartProcessPeriod FROM hris.payroll_period_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                         
                        List<PayrollPeriod_SetupModel> list_ppsm = new List<PayrollPeriod_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                PayrollPeriod_SetupModel ppsm = new PayrollPeriod_SetupModel();

                                ppsm.ID = Convert.ToInt32(rdr["ID"]);
                                ppsm.PeriodID = Convert.ToInt32(rdr["PeriodID"]);
                                ppsm.Year = Convert.ToInt32(rdr["Year"]);
                                ppsm.StartDate_MonthID = Convert.ToInt32(rdr["StartDate_MonthID"]);
                                ppsm.EndDate_MonthID = Convert.ToInt32(rdr["EndDate_MonthID"]);
                                ppsm.StartDate = rdr["StartDate"].ToString();
                                ppsm.EndDate = rdr["EndDate"].ToString();
                                ppsm.CreatedDate = rdr["CreatedDate"].ToString();
                                ppsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                ppsm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                ppsm.PayrollGroupID = Convert.ToInt32(rdr["PayrollGroupID"]);
                                ppsm.PayrollGroup = rdr["PayrollGroup"].ToString();
                                ppsm.Description = rdr["Description"].ToString();
                                ppsm.StartProcessPeriod = rdr["StartProcessPeriod"].ToString();
                                list_ppsm.Add(ppsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_ppsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;

                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.payroll_period_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.payroll_period_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getDefaultCurrency()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_default_currency";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<DefaultCurrency_SetupModel> list_dcsm = new List<DefaultCurrency_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                DefaultCurrency_SetupModel dcsm = new DefaultCurrency_SetupModel();

                                dcsm.ID = Convert.ToInt32(rdr["ID"]);
                                dcsm.Code = rdr["Code"].ToString();
                                dcsm.Description = rdr["Description"].ToString();
                                dcsm.CreatedDate = rdr["CreatedDate"].ToString();
                                dcsm.ModifiedDate = rdr["ModifiedDate"].ToString();

                                list_dcsm.Add(dcsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_dcsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;

                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_default_currency", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_default_currency", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getTrainingTypes()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_training_type";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<TrainingType_SetupModel> list_ttsm = new List<TrainingType_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                TrainingType_SetupModel ttsm = new TrainingType_SetupModel();

                                ttsm.ID = Convert.ToInt32(rdr["ID"]);
                                ttsm.Description = rdr["Description"].ToString();
                                ttsm.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                ttsm.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                ttsm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_ttsm.Add(ttsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_ttsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;

                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_training_type", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_training_type", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getLeaveTypes()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_default_leave_type";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<LeaveType_SetupModel> list_ltsm = new List<LeaveType_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                LeaveType_SetupModel ltsm = new LeaveType_SetupModel();

                                ltsm.ID = Convert.ToInt32(rdr["ID"]);
                                ltsm.LeaveType = rdr["LeaveType"].ToString();
                                ltsm.ChargeTo = Convert.ToInt32(rdr["ChargeTo"]);
                                ltsm.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                ltsm.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                ltsm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_ltsm.Add(ltsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_ltsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;

                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_default_leave_type", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_default_leave_type", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getLeaveCreditYears()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_leave_credit_year_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<LeaveCreditYear_SetupModel> list_ltsm = new List<LeaveCreditYear_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                LeaveCreditYear_SetupModel ltsm = new LeaveCreditYear_SetupModel();

                                ltsm.ID = Convert.ToInt32(rdr["ID"]);
                                ltsm.Year = Convert.ToInt32(rdr["Year"]);
                                ltsm.StartDate = Convert.ToDateTime(rdr["StartDate"]).ToString("MMMM dd, yyyy");
                                ltsm.EndDate = Convert.ToDateTime(rdr["EndDate"]).ToString("MMMM dd, yyyy");
                                ltsm.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                ltsm.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                ltsm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_ltsm.Add(ltsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_ltsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;

                        conn.Close();

                        logs.insertActivityLogs(name: "hris.mf_leave_credit_year_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "hris.mf_leave_credit_year_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getVisaPermitType()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_person_visa_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<VisaPermitType_SetupModel> list_vptm = new List<VisaPermitType_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                VisaPermitType_SetupModel vptm = new VisaPermitType_SetupModel();

                                vptm.ID = Convert.ToInt32(rdr["ID"]);
                                vptm.VisaPermitType = Convert.ToString(rdr["VisaPermitType"]);
                                vptm.LegislationCode = Convert.ToString(rdr["LegislationCode"]);
                                vptm.CurrentVisaPermit = Convert.ToString(rdr["CurrentVisaPermit"]);
                                vptm.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                vptm.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                vptm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_vptm.Add(vptm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_vptm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;

                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_person_visa_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_person_visa_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel GetPhoneType()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.phone_type";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<PhoneType_SetupModel> list_ptm = new List<PhoneType_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                PhoneType_SetupModel ptm = new PhoneType_SetupModel();

                                ptm.ID = Convert.ToInt32(rdr["ID"]);
                                ptm.PhoneType = Convert.ToString(rdr["PhoneType"]);
                                ptm.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                ptm.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                ptm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_ptm.Add(ptm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_ptm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;

                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.phone_type", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.phone_type", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }


        public ResponseModel getCitizenshipStatus()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_citizenship_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<CitizenshipStatus_SetupModel> list_csm = new List<CitizenshipStatus_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                CitizenshipStatus_SetupModel csm = new CitizenshipStatus_SetupModel();

                                csm.ID = Convert.ToInt32(rdr["ID"]);
                                csm.LegislationCode = Convert.ToString(rdr["LegislationCode"]);
                                csm.CitizenshipStatus = Convert.ToString(rdr["CitizenshipStatus"]);
                                csm.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                csm.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                csm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_csm.Add(csm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_csm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;

                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_citizenship_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_citizenship_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getAllSex()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_sex_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<Sex_SetupModel> list_sm = new List<Sex_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                Sex_SetupModel sm = new Sex_SetupModel();

                                sm.ID = Convert.ToInt32(rdr["ID"]);
                                sm.Sex = Convert.ToString(rdr["Sex"]);
                                sm.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                sm.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                sm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_sm.Add(sm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_sm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;

                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_sex_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_sex_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }
        public ResponseModel getEthnicity()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_person_ethnicity_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<Ethnicity_SetupModel> list_ltsm = new List<Ethnicity_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                Ethnicity_SetupModel ltsm = new Ethnicity_SetupModel();

                                ltsm.ID = Convert.ToInt32(rdr["ID"]);
                                ltsm.LegislationCode = Convert.ToInt32(rdr["LegislationCode"]);
                                ltsm.DeclarePersonNumber = Convert.ToInt32(rdr["DeclarePersonNumber"]);
                                ltsm.Ethnicity = Convert.ToString(rdr["Ethnicity"]);
                                ltsm.CreatedDate = Convert.ToString(rdr["CreatedDate"]);
                                ltsm.ModifiedDate = Convert.ToString(rdr["ModifiedDate"]);
                                ltsm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_ltsm.Add(ltsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_ltsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;

                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_person_ethnicity_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_person_ethnicity_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }


        public ResponseModel getCostCenter()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_cost_center";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<CostCenter_SetupModel> list_ttsm = new List<CostCenter_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                CostCenter_SetupModel ccsm = new CostCenter_SetupModel();

                                ccsm.ID = Convert.ToInt32(rdr["ID"]);
                                ccsm.CostCenterCode = rdr["CostCenterCode"].ToString();
                                ccsm.CostCenterName = rdr["CostCenterName"].ToString();
                                ccsm.CreatedDate = rdr["CreatedDate"].ToString();
                                ccsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                ccsm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_ttsm.Add(ccsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_ttsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_cost_center", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_cost_center", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }


        public ResponseModel getCostCenterType()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_default_costcenter_type";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<DefaultCostCenter_SetupModel> list_ttsm = new List<DefaultCostCenter_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                DefaultCostCenter_SetupModel ccsm = new DefaultCostCenter_SetupModel();

                                ccsm.ID = Convert.ToInt32(rdr["ID"]);
                                ccsm.Description = rdr["Description"].ToString();
                                ccsm.CreatedDate = rdr["CreatedDate"].ToString();
                                ccsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                ccsm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_ttsm.Add(ccsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_ttsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_default_costcenter_type", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_default_costcenter_type", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getAllDefaultAddressTypes()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_default_address_type";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<DefaultAddressType_SetupModel> list_datsm = new List<DefaultAddressType_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                DefaultAddressType_SetupModel datsm = new DefaultAddressType_SetupModel();

                                datsm.ID = Convert.ToInt32(rdr["ID"]);
                                datsm.Description = rdr["Description"].ToString();
                                datsm.CreatedDate = rdr["CreatedDate"].ToString();
                                datsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                datsm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_datsm.Add(datsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_datsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;

                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_default_address_type", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_default_address_type", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getAllDefaultPayComponentTypes()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_default_paycomponent_type";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<DefaultPayComponentType_SetupModel> list_datsm = new List<DefaultPayComponentType_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                DefaultPayComponentType_SetupModel datsm = new DefaultPayComponentType_SetupModel();

                                datsm.ID = Convert.ToInt32(rdr["ID"]);
                                datsm.PayComponentType = rdr["PayComponentType"].ToString();
                                datsm.CreatedDate = rdr["CreatedDate"].ToString();
                                datsm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                datsm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_datsm.Add(datsm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_datsm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;

                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_default_paycomponent_type", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_default_paycomponent_type", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getCustomFields()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.mf_employee_custom_field_setup";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<CustomField_SetupModel> list_cfm = new List<CustomField_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                CustomField_SetupModel cfm = new CustomField_SetupModel();

                                cfm.ID = Convert.ToInt32(rdr["ID"]);
                                cfm.Description = rdr["Description"].ToString();
                                cfm.CreatedDate = rdr["CreatedDate"].ToString();
                                cfm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                cfm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                list_cfm.Add(cfm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_cfm;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.mf_employee_custom_field_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "SELECT * FROM hris.mf_employee_custom_field_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }
    }
}