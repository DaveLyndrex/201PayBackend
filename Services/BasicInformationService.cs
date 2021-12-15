/*[10/05/2021] CN E.Patot*/
/*[10/10/2021] CN E.Patot*/
/*[10/20/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;


namespace BackEnd.Services
{
    public class BasicInformationService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel createBasicInformation(BasicInformationModel bim)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_EMPLOYEE_INFORMATION_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                 
                        // Employee Id
                        command.Parameters.AddWithValue("employeeidno", bim.ID);
                        command.Parameters["employeeidno"].Direction = ParameterDirection.Input;

                        // First Name
                        command.Parameters.AddWithValue("firstname", bim.FirstName);
                        command.Parameters["firstname"].Direction = ParameterDirection.Input;

                        // Middle name
                        command.Parameters.AddWithValue("middlename", bim.MiddleName);
                        command.Parameters["middlename"].Direction = ParameterDirection.Input;

                        // Last name
                        command.Parameters.AddWithValue("lastname", bim.LastName);
                        command.Parameters["lastname"].Direction = ParameterDirection.Input;

                        // Suffix Id
                        command.Parameters.AddWithValue("suffixid", bim.SuffixID);
                        command.Parameters["suffixid"].Direction = ParameterDirection.Input;

                        // Prefix Id
                        command.Parameters.AddWithValue("prefixid", bim.PreffixID);
                        command.Parameters["prefixid"].Direction = ParameterDirection.Input;

                        // Date of Birth 
                        command.Parameters.AddWithValue("dateofbirth", bim.DateOfBirth);
                        command.Parameters["dateofbirth"].Direction = ParameterDirection.Input;

                        // Sex Id
                        command.Parameters.AddWithValue("sexID", bim.SexID);
                        command.Parameters["sexID"].Direction = ParameterDirection.Input;

                        // Photo 
                        command.Parameters.AddWithValue("photo", bim.Photo);
                        command.Parameters["photo"].Direction = ParameterDirection.Input;

                        // SSS No
                        command.Parameters.AddWithValue("sssno", bim.SSS);
                        command.Parameters["sssno"].Direction = ParameterDirection.Input;

                        // Phil Health No
                        command.Parameters.AddWithValue("philhealthno", bim.PhilHealth);
                        command.Parameters["philhealthno"].Direction = ParameterDirection.Input;

                        // HDMF No
                        command.Parameters.AddWithValue("hdmfno", bim.HDMFNo);
                        command.Parameters["hdmfno"].Direction = ParameterDirection.Input;

                        // TIN
                        command.Parameters.AddWithValue("tin", bim.TIN);
                        command.Parameters["tin"].Direction = ParameterDirection.Input;

                        // Bank Id
                        command.Parameters.AddWithValue("bankid", bim.BankID);
                        command.Parameters["bankid"].Direction = ParameterDirection.Input;

                        // Payroll Acct
                        command.Parameters.AddWithValue("payrollacct", bim.PayrollAcct);
                        command.Parameters["payrollacct"].Direction = ParameterDirection.Input;

                        // RegularizationPA
                        command.Parameters.AddWithValue("regularizationpa", bim.RegularizationPA);
                        command.Parameters["regularizationpa"].Direction = ParameterDirection.Input;

                        // Blood Type
                        command.Parameters.AddWithValue("bloodtypeid", bim.BloodTypeID);
                        command.Parameters["bloodtypeid"].Direction = ParameterDirection.Input;

                        // CTC No
                        command.Parameters.AddWithValue("ctcno", bim.CommunityTax);
                        command.Parameters["ctcno"].Direction = ParameterDirection.Input;



                        // Service Year
                        command.Parameters.AddWithValue("serviceyearrecognition", bim.ServiceYearRecognition);
                        command.Parameters["serviceyearrecognition"].Direction = ParameterDirection.Input;

                        // Place of Birth
                        command.Parameters.AddWithValue("placeofbirth", bim.PlaceOfBirth);
                        command.Parameters["placeofbirth"].Direction = ParameterDirection.Input;

                        // Business Unit Holiday
                        command.Parameters.AddWithValue("buhiredate", bim.BUHireDate);
                        command.Parameters["buhiredate"].Direction = ParameterDirection.Input;

                        // Rest birthday
                        command.Parameters.AddWithValue("retirementbasedate", bim.RetirementBaseDate);
                        command.Parameters["retirementbasedate"].Direction = ParameterDirection.Input;

                        // Rest day
                        command.Parameters.AddWithValue("regularizationdate", bim.RegularizationDate);
                        command.Parameters["regularizationdate"].Direction = ParameterDirection.Input;

                        // Nickname
                        command.Parameters.AddWithValue("nickname", bim.Nickname);
                        command.Parameters["nickname"].Direction = ParameterDirection.Input;

                        // Initials
                        command.Parameters.AddWithValue("initials", bim.Initials);
                        command.Parameters["initials"].Direction = ParameterDirection.Input;

                        // Religion
                        command.Parameters.AddWithValue("religion", bim.Religion);
                        command.Parameters["religion"].Direction = ParameterDirection.Input;

                        // Unified Id
                        command.Parameters.AddWithValue("unifiedid", bim.UnifiedMembersID);
                        command.Parameters["unifiedid"].Direction = ParameterDirection.Input;

                        // Drivers License
                        command.Parameters.AddWithValue("driverslicense", bim.DriversLicense);
                        command.Parameters["driverslicense"].Direction = ParameterDirection.Input;

                        // Voters Id
                        command.Parameters.AddWithValue("votersid", bim.VotersID);
                        command.Parameters["votersid"].Direction = ParameterDirection.Input;

                        // Passport
                        command.Parameters.AddWithValue("passport", bim.Passport);
                        command.Parameters["passport"].Direction = ParameterDirection.Input;

                        // City Health Card
                        command.Parameters.AddWithValue("cityhealthcard", bim.MaxicareCardNo);
                        command.Parameters["cityhealthcard"].Direction = ParameterDirection.Input;

                        // Country of Birth
                        command.Parameters.AddWithValue("countryofbirth", bim.CountryOfBirth);
                        command.Parameters["countryofbirth"].Direction = ParameterDirection.Input;


                        //Name of Spouse
                        command.Parameters.AddWithValue("nameofspouse", bim.NameOfSpouse);
                        command.Parameters["nameofspouse"].Direction = ParameterDirection.Input;

                        //Date of Marriage
                        command.Parameters.AddWithValue("dateofmarriage", bim.DateOfMarriage);
                        command.Parameters["dateofmarriage"].Direction = ParameterDirection.Input;

                        // Occupation
                        command.Parameters.AddWithValue("occupation", bim.OccupationOfSpouse);
                        command.Parameters["occupation"].Direction = ParameterDirection.Input;

                        //Civil Status
                        command.Parameters.AddWithValue("civilstatus", bim.CivilStatus);
                        command.Parameters["civilstatus"].Direction = ParameterDirection.Input;

                        //Modified By
                        command.Parameters.AddWithValue("modifiedby", bim.ModifiedBy);
                        command.Parameters["modifiedby"].Direction = ParameterDirection.Input;


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

                        logs.insertActivityLogs(name: "hris.CN_EMPLOYEE_INFORMATION_INSERT", action: 1, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.data = null;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "hris.CN_EMPLOYEE_INFORMATION_INSERT", action: 1, status: response.status, remarks: response.message);
            }

            return response;
        }

        public ResponseModel updateBasicInformation(BasicInformationModel bim)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_EMPLOYEE_INFORMATION_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        #region
                        // Emp ID
                        command.Parameters.AddWithValue("_EmpID", bim.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;
                        // Employee Id
                        command.Parameters.AddWithValue("employeeidno", bim.ID);
                        command.Parameters["employeeidno"].Direction = ParameterDirection.Input;

                        // First Name
                        command.Parameters.AddWithValue("firstname", bim.FirstName);
                        command.Parameters["firstname"].Direction = ParameterDirection.Input;

                        // Middle name
                        command.Parameters.AddWithValue("middlename", bim.MiddleName);
                        command.Parameters["middlename"].Direction = ParameterDirection.Input;

                        // Last name
                        command.Parameters.AddWithValue("lastname", bim.LastName);
                        command.Parameters["lastname"].Direction = ParameterDirection.Input;

                        // Suffix Id
                        command.Parameters.AddWithValue("suffixid", bim.SuffixID);
                        command.Parameters["suffixid"].Direction = ParameterDirection.Input;

                        // Prefix Id
                        command.Parameters.AddWithValue("prefixid", bim.PreffixID);
                        command.Parameters["prefixid"].Direction = ParameterDirection.Input;

                        // Date of Birth 
                        command.Parameters.AddWithValue("dateofbirth", bim.DateOfBirth);
                        command.Parameters["dateofbirth"].Direction = ParameterDirection.Input;

                        // Sex Id
                        command.Parameters.AddWithValue("sexID", bim.SexID);
                        command.Parameters["sexID"].Direction = ParameterDirection.Input;

                        // Photo 
                        command.Parameters.AddWithValue("photo", bim.Photo);
                        command.Parameters["photo"].Direction = ParameterDirection.Input;

                        // SSS No
                        command.Parameters.AddWithValue("sssno", bim.SSS);
                        command.Parameters["sssno"].Direction = ParameterDirection.Input;

                        // Phil Health No
                        command.Parameters.AddWithValue("philhealthno", bim.PhilHealth);
                        command.Parameters["philhealthno"].Direction = ParameterDirection.Input;

                        // HDMF No
                        command.Parameters.AddWithValue("hdmfno", bim.HDMFNo);
                        command.Parameters["hdmfno"].Direction = ParameterDirection.Input;

                        // TIN
                        command.Parameters.AddWithValue("tin", bim.TIN);
                        command.Parameters["tin"].Direction = ParameterDirection.Input;

                        // Bank Id
                        command.Parameters.AddWithValue("bankid", bim.BankID);
                        command.Parameters["bankid"].Direction = ParameterDirection.Input;

                        // Payroll Acct
                        command.Parameters.AddWithValue("payrollacct", bim.PayrollAcct);
                        command.Parameters["payrollacct"].Direction = ParameterDirection.Input;

                        // RegularizationPA
                        command.Parameters.AddWithValue("regularizationpa", bim.RegularizationPA);
                        command.Parameters["regularizationpa"].Direction = ParameterDirection.Input;

                        // Blood Type
                        command.Parameters.AddWithValue("bloodtypeid", bim.BloodTypeID);
                        command.Parameters["bloodtypeid"].Direction = ParameterDirection.Input;

                        // CTC No
                        command.Parameters.AddWithValue("ctcno", bim.CommunityTax);
                        command.Parameters["ctcno"].Direction = ParameterDirection.Input;



                        // Service Year
                        command.Parameters.AddWithValue("serviceyearrecognition", bim.ServiceYearRecognition);
                        command.Parameters["serviceyearrecognition"].Direction = ParameterDirection.Input;

                        // Place of Birth
                        command.Parameters.AddWithValue("placeofbirth", bim.PlaceOfBirth);
                        command.Parameters["placeofbirth"].Direction = ParameterDirection.Input;

                        // Business Unit Holiday
                        command.Parameters.AddWithValue("buhiredate", bim.BUHireDate);
                        command.Parameters["buhiredate"].Direction = ParameterDirection.Input;

                        // Rest birthday
                        command.Parameters.AddWithValue("retirementbasedate", bim.RetirementBaseDate);
                        command.Parameters["retirementbasedate"].Direction = ParameterDirection.Input;

                        // Rest day
                        command.Parameters.AddWithValue("regularizationdate", bim.RegularizationDate);
                        command.Parameters["regularizationdate"].Direction = ParameterDirection.Input;

                        // Nickname
                        command.Parameters.AddWithValue("nickname", bim.Nickname);
                        command.Parameters["nickname"].Direction = ParameterDirection.Input;

                        // Initials
                        command.Parameters.AddWithValue("initials", bim.Initials);
                        command.Parameters["initials"].Direction = ParameterDirection.Input;

                        // Religion
                        command.Parameters.AddWithValue("religion", bim.Religion);
                        command.Parameters["religion"].Direction = ParameterDirection.Input;

                        // Unified Id
                        command.Parameters.AddWithValue("unifiedid", bim.UnifiedMembersID);
                        command.Parameters["unifiedid"].Direction = ParameterDirection.Input;

                        // Drivers License
                        command.Parameters.AddWithValue("driverslicense", bim.DriversLicense);
                        command.Parameters["driverslicense"].Direction = ParameterDirection.Input;

                        // Voters Id
                        command.Parameters.AddWithValue("votersid", bim.VotersID);
                        command.Parameters["votersid"].Direction = ParameterDirection.Input;

                        // Passport
                        command.Parameters.AddWithValue("passport", bim.Passport);
                        command.Parameters["passport"].Direction = ParameterDirection.Input;

                        // City Health Card
                        command.Parameters.AddWithValue("cityhealthcard", bim.MaxicareCardNo);
                        command.Parameters["cityhealthcard"].Direction = ParameterDirection.Input;

                        // Country of Birth
                        command.Parameters.AddWithValue("countryofbirth", bim.CountryOfBirth);
                        command.Parameters["countryofbirth"].Direction = ParameterDirection.Input;



                        //Name of Spouse
                        command.Parameters.AddWithValue("nameofspouse", bim.NameOfSpouse);
                        command.Parameters["nameofspouse"].Direction = ParameterDirection.Input;

                        //Date of Marriage
                        command.Parameters.AddWithValue("dateofmarriage", bim.DateOfMarriage);
                        command.Parameters["dateofmarriage"].Direction = ParameterDirection.Input;

                        // Occupation
                        command.Parameters.AddWithValue("occupation", bim.OccupationOfSpouse);
                        command.Parameters["occupation"].Direction = ParameterDirection.Input;

                        //Civil Status
                        command.Parameters.AddWithValue("civilstatus", bim.CivilStatus);
                        command.Parameters["civilstatus"].Direction = ParameterDirection.Input;


                        //Modified By
                        command.Parameters.AddWithValue("modifiedby", bim.ModifiedBy);
                        command.Parameters["modifiedby"].Direction = ParameterDirection.Input;

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
                        logs.insertActivityLogs(name: "hris.CN_EMPLOYEE_INFORMATION_UPDATE", action: 2, status: response.status, remarks: response.message);
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
                logs.insertActivityLogs(name: "hris.CN_EMPLOYEE_INFORMATION_UPDATE", action: 2, status: response.status, remarks: response.message);
            }

            return response;
        }

        public ResponseModel getAllEmployeeBasicInformationById(int id)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.CN_EMPLOYEE_MASTER_V WHERE EmpID = '" + id + "'";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<BasicInformationModel> list_bim = new List<BasicInformationModel>();


                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["EmpID"] != null)
                            {
                                BasicInformationModel bim = new BasicInformationModel();
                                bim.BankID = (rdr["BankName"]).ToString();
                                bim.CountryOfBirth = rdr["CountryOfBirth"].ToString();
                                bim.BloodTypeID = rdr["BloodType"].ToString();
                                bim.BUHireDate = Convert.ToDateTime(rdr["BUHireDate"]).ToString("MM/dd/yyyy");
                                bim.CandidateID = rdr["candidateid"].ToString();
                                bim.MaxicareCardNo = rdr["CityHealthCard"].ToString();
                                bim.CivilStatus = rdr["CivilStatus"].ToString();
                                bim.CommunityTax = Convert.ToInt32(rdr["CTCNo"]).ToString();
                                bim.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]).ToString("MM/dd/yyyy");
                                bim.DateOfDeath = Convert.ToDateTime(rdr["DateOfDeath"]).ToString("MM/dd/yyyy");
                                bim.DateOfMarriage = Convert.ToDateTime(rdr["DateOfMarriage"]).ToString("MM/dd/yyyy");
                                bim.DriversLicense = rdr["DriversLicense"].ToString();
                                bim.ECID = rdr["ecid"].ToString();
                                bim.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                bim.ID = rdr["EmployeeIDNO"].ToString();
                                bim.FirstName = rdr["Firstname"].ToString();
                                bim.GPAID = Convert.ToInt32(rdr["GPAID"]).ToString();
                                bim.HDMFNo = rdr["HDMFNo"].ToString();
                                bim.Initials = rdr["Initials"].ToString();
                                bim.LastName = rdr["Lastname"].ToString();
                                bim.MiddleName = rdr["Middlename"].ToString();
                                bim.Miscellaneous = rdr["Miscellaneous"].ToString();
                                bim.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                bim.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                bim.ModifiedBy = rdr["ModifiedBy"].ToString();
                                bim.NameOfSpouse = rdr["NameOfSpouse"].ToString();
                                bim.Nickname = rdr["Nickname"].ToString();
                                bim.OccupationOfSpouse = rdr["Occupation"].ToString();
                                bim.Passport = rdr["Passport"].ToString();
                                bim.PayrollAcct = rdr["PayrollAcct"].ToString();
                                bim.PhilHealth = rdr["PhilHealthNo"].ToString();
                                bim.Photo = rdr["Photo"].ToString();
                                bim.PlaceOfBirth = rdr["PlaceOfBirth"].ToString();
                                bim.PreffixID = rdr["Prefix"].ToString();
                                bim.RegularizationPA = rdr["Description"].ToString();
                                bim.Religion = rdr["Religion"].ToString();
                                bim.RetirementBaseDate = Convert.ToDateTime(rdr["RetirementBaseDate"]).ToString("MM/dd/yyyy");
                                bim.RegularizationDate = Convert.ToDateTime(rdr["RegularizationDate"]).ToString("MM/dd/yyyy");
                                bim.ServiceYearRecognition = Convert.ToDateTime(rdr["ServiceYearRecognition"]).ToString("MM/dd/yyyy");
                                bim.SexID = rdr["Sex"].ToString();
                                bim.SSS = rdr["SSSNo"].ToString();
                                bim.SuffixID = rdr["Suffix"].ToString();
                                bim.TIN = rdr["TIN"].ToString();
                                bim.UnifiedMembersID = rdr["UnifiedID"].ToString();
                                bim.VotersID = rdr["VotersID"].ToString();

                                list_bim.Add(bim);
                            }
                        }
                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_bim;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.CN_EMPLOYEE_MASTER_V WHERE EmpID = '" + id + "'", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.data = null;
                response.error = consts.ERROR_TRUE;
                logs.insertActivityLogs(name: "SELECT * FROM hris.CN_EMPLOYEE_MASTER_V WHERE EmpID = '" + id + "'", action: 4, status: response.status, remarks: response.message);
            }

            return response;
        }

    }
}