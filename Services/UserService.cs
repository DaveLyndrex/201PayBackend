/*[10/07/2021] CN E.Patot*/
/*[10/11/2021] CN E.Patot*/
using BackEnd.Models;
using System;
using System.Data;
using BackEnd.Global;
using MySqlConnector;

namespace BackEnd.Services
{
    public class UserService
    {

        public Constants consts = new Constants();
        public LoginResponse response = new LoginResponse();
        public LogsService logs = new LogsService();
        public LoginResponse CheckLocalUserCredentials(string username, string password, string email)
        {
            string message = "";
            string role = "";
            string empId = "";
            string pass = "";
            string user = "";

            try
            {
                //Connecting to Database
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_USER_LOGIN";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();

                        command.Parameters.AddWithValue("_username", username);
                        command.Parameters["_username"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_password", password);
                        command.Parameters["_password"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();

                        while (rdr.Read())
                        {
                            pass = rdr["@password"].ToString();
                            user = rdr["@username"].ToString();
                            message = rdr["@message"].ToString();
                            role = rdr["@user_role"].ToString();
                            empId = rdr["@workflow_empId"].ToString();

                        }

                        if (message == "SUCCESS" && role != "" && empId != "")
                        {
                            if (pass == password && user == username)
                            {

                                response.message = message;
                                response.role = role;
                                response.empId = empId;
                            }
                            else if (pass != password && user == username)
                            {
                                message = "Incorrect Password";
                                response.message = message;
                                response.role = "NONE";
                                response.empId = empId;
                            }
                            else if (pass == password && user != username)
                            {
                                message = "Incorrect Username";
                                response.message = message;
                                response.role = "NONE";
                                response.empId = empId;
                            }
                        }
                        else
                        {
                            message = "Incorrect Username and Password";
                            response.message = message;
                            response.role = "NONE";
                            response.empId = empId;
                        }


                    }
                    conn.Close();
                    logs.insertActivityLogs(name: "hris.CN_USER_LOGIN", action: 6, status: consts.SUCCESS, remarks: response.message);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.role = "NONE";

                logs.insertActivityLogs(name: "hris.CN_USER_LOGIN", action: 6, status: consts.ERROR, remarks: response.message);
            }

            return response;
        }

        public LoginResponse CheckUserGmailCredentials(string email)
        {

            string message = "";
            string role = "";
            string empId = "";
            string username = "";
            try
            {
                //Connecting to Database
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_USER_LOGIN_GOOGLE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();

                        command.Parameters.AddWithValue("_email", email);
                        command.Parameters["_email"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();

                        while (rdr.Read())
                        {
                            message = rdr["@message"].ToString();
                            role = rdr["@user_role"].ToString();
                            empId = rdr["@user_empId"].ToString();
                            username = rdr["@username"].ToString();
                        }

                        conn.Close();

                        response.message = message;
                        response.role = role;
                        response.empId = empId;

                        logs.insertActivityLogs(name: "hris.CN_USER_LOGIN_GOOGLE", action: 6, status: consts.SUCCESS, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.role = "NONE";

                logs.insertActivityLogs(name: "hris.CN_USER_LOGIN_GOOGLE", action: 6, status: consts.ERROR, remarks: response.message);
            }

            return response;
        }


        public ResponseModel getUserProfileById(int id)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                //Connecting to Database
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_USER_PROFILE_GET_BY_ID";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();

                        command.Parameters.AddWithValue("_empID", id);
                        command.Parameters["_empID"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();

                        UserProfileModel upm = new UserProfileModel();
                        while (rdr.Read())
                        {
                            upm.DateOfBirth = rdr["DOB"].ToString();
                            upm.FirstName = rdr["FirstName"].ToString();
                            upm.LastName = rdr["LastName"].ToString();
                            upm.MiddleName = rdr["MiddleName"].ToString();
                            upm.Email = rdr["Email"].ToString();
                            upm.EmployeeIDNo = rdr["EmployeeIDNo"].ToString();
                            upm.Username = rdr["Username"].ToString();
                        }
                        responseModel.code = consts.CODE_OK;
                        responseModel.error = consts.ERROR_FALSE;
                        responseModel.status = consts.SUCCESS;
                        responseModel.message = consts.SUCCESS_RETRIEVE;
                        responseModel.data = upm;
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_USER_PROFILE_GET_BY_ID", action: 5, status: responseModel.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.message = ex.Message;
                responseModel.error = consts.ERROR_TRUE;
                responseModel.data = null;
                responseModel.status = consts.ERROR;
                responseModel.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "hris.CN_USER_PROFILE_GET_BY_ID", action: 5, status: responseModel.status, remarks: response.message);
            }

            return responseModel;
        }

        public ResponseModel getDatabaseParameters()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                response.code = consts.CODE_OK;
                response.status = consts.SUCCESS;
                response.error = consts.ERROR_FALSE;
                response.message = "Allowed to Process";
                response.data = ConfigurationManager.getDatabaseParameters();
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = true;
            }

            return response;
        }
    }
}