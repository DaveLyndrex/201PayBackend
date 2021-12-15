/*[10/14/2021] CN J.Layaog*/
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace BackEnd.Services
{
    public class EmployeeKioskService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();



        public ResponseModel getEmployeeExcludeByID(int _empid)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "hris.CN_GET_INFORMATION_EXCLUDE_BY_ID";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<KioskUserModel> list_kr = new List<KioskUserModel>();
                        command.Parameters.AddWithValue("_empid", _empid);
                        command.Parameters["_empid"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["EmployeeIDNo"] != null)
                            {
                                KioskUserModel kr = new KioskUserModel();
                                kr.EmpID = Convert.ToInt32(rdr["EmployeeIDNo"]);
                                kr.Firstname = rdr["Firstname"].ToString();
                                kr.Lastname = rdr["Lastname"].ToString();
                                kr.Name = rdr["Firstname"].ToString() + " " + rdr["Lastname"].ToString();
                                kr.Description = rdr["Description"].ToString();
                                kr.Email = rdr["Email"].ToString();



                                list_kr.Add(kr);
                            }
                        }
                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_kr;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_GET_DATA_ALL", action: 4, status: response.status, remarks: response.message);
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
                logs.insertActivityLogs(name: "hris.CN_GET_DATA_ALL", action: 4, status: response.status, remarks: response.message);
            }


            return response;
        }



        public ResponseModel getKioskWorkflow(int _empid)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "hris.CN_GET_APPROVAL_WORKFLOW";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<ApprovalWorkflowModel> list_tm = new List<ApprovalWorkflowModel>();

                        command.Parameters.AddWithValue("_empid", _empid);
                        command.Parameters["_empid"].Direction = ParameterDirection.Input;



                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {

                                ApprovalWorkflowModel tm = new ApprovalWorkflowModel();
                              
                                tm.Fullname = rdr["Fullname"].ToString();
                                tm.Description = rdr["Description"].ToString();
                                tm.Type = rdr["Type"].ToString();
                                tm.Layer = rdr["Layer"].ToString();


                                list_tm.Add(tm);
                            
                        }
                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_tm;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT* FROM hris.CN_TIMESHEET_SUMMARY_ALL_V WHERE EmpID=" + _empid + " and PeriodID = (SELECT ProfileValue FROM hris.mf_system_profile WHERE ProfileCode='CURRENT_PERIOD')", action: 4, status: response.status, remarks: response.message);
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
                logs.insertActivityLogs(name: "SELECT* FROM hris.CN_TIMESHEET_SUMMARY_ALL_V WHERE EmpID=" + _empid + " and PeriodID = (SELECT ProfileValue FROM hris.mf_system_profile WHERE ProfileCode='CURRENT_PERIOD')", action: 4, status: response.status, remarks: response.message);
            }


            return response;
        }



        public ResponseModel getYear(string tablename)
        {

            tablename = requestView(tablename);
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "hris.CN_FILTER_YEAR";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<int> list = new List<int>();

                        command.Parameters.AddWithValue("_tablename", tablename);
                        command.Parameters["_tablename"].Direction = ParameterDirection.Input;

                        MySqlDataReader reader = command.ExecuteReader();

                        int year;

                        while (reader.Read())
                        {
                            year = Convert.ToInt32(reader.GetInt32(0));
                            list.Add(year);
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT Year FROM hris.mf_leave_credit_crear_setup", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.CODE_ERROR;
                response.data = null;
                logs.insertActivityLogs(name: "SELECT Year FROM hris.mf_leave_credit_crear_setup", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }






        public ResponseModel getUserInformation(int _empid)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT *, e.EmpID FROM hris.CN_EMPLOYEE_EMPLOYMENT_DATA_V e INNER JOIN hris.CN_ROLE_MEMBER_V rm ON rm.EmpID=e.EmpID WHERE e.EmpID=" + _empid;
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        //_ID:
                        //  command.Parameters.AddWithValue("_empid", _empid);
                        //.Parameters["_empid"].Direction = ParameterDirection.Input;



                        List<UserInformationModel> user_list = new List<UserInformationModel>();

                        MySqlDataReader rdr = command.ExecuteReader();

                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                UserInformationModel user = new UserInformationModel();


                                user.EmployeeStatus = rdr["EmployeeStatus"].ToString();
                                user.CompanyName = rdr["CompanyName"].ToString();
                                user.DepartmentName = rdr["DepartmentName"].ToString();
                                user.SubDept = rdr["SubDept"].ToString();
                                user.JobCategory = rdr["JobCategory"].ToString();
                                user.GeoLoc = rdr["GeoLoc"].ToString();
                                user.WorkerType = rdr["WorkerType"].ToString();
                                user.GroupMemberName = rdr["GroupMemberName"].ToString();
                                user.Description = rdr["Description"].ToString();


                                user_list.Add(user);
                            }
                        }
                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = user_list;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;

                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_GET_DATA_BY_ID", action: 5, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.data = null;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "hris.CN_DEPENDENTS_GET_BYID", action: 5, status: response.status, remarks: response.message);
            }

            return response;
        }



        public ResponseModel getNewRequestID()
        {

            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "SELECT MAX(ID) FROM hris.request_header";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<int> list = new List<int>();

                        MySqlDataReader reader = command.ExecuteReader();

                        int max;

                        while (reader.Read())
                        {
                            max = Convert.ToInt32(reader.GetInt32(0)) + 1;
                            list.Add(max);
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT MAX(ID) FROM hris.request_header", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.CODE_ERROR;
                response.data = null;
                logs.insertActivityLogs(name: "SELECT MAX(ID) FROM hris.request_header", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getRequestID(int _empid)
        {

            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "SELECT MAX(ID) FROM hris.request_header where EmpID=" + _empid;
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<int> list = new List<int>();

                        MySqlDataReader reader = command.ExecuteReader();

                        int requestid;

                        while (reader.Read())
                        {
                            requestid = Convert.ToInt32(reader.GetInt32(0));
                            list.Add(requestid);
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT MAX(ID) FROM hris.request_header", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.status = consts.CODE_ERROR;
                response.data = null;
                logs.insertActivityLogs(name: "SELECT MAX(ID) FROM hris.request_header", action: 4, status: response.status, remarks: response.message);
            }
            return response;
        }





      




        public ResponseModel addRequestHeader(RequestHeaderModel rh)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_ADD_REQUEST_HEADER";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // Employee Id
                        command.Parameters.AddWithValue("_empid", rh.EmpID);
                        command.Parameters["_empid"].Direction = ParameterDirection.Input;

                        // Form Id
                        command.Parameters.AddWithValue("_formid", formID(rh.FormID));
                        command.Parameters["_formid"].Direction = ParameterDirection.Input;

                        // Leave Type Id
                        command.Parameters.AddWithValue("_leavetypeid", getLeaveTypeID(rh.LeaveType));
                        command.Parameters["_leavetypeid"].Direction = ParameterDirection.Input;

                        // Paid
                        command.Parameters.AddWithValue("_paid", rh.Paid);
                        command.Parameters["_paid"].Direction = ParameterDirection.Input;

                        // Status
                        command.Parameters.AddWithValue("_status", approvalStatus(rh.Status)+1);
                        command.Parameters["_status"].Direction = ParameterDirection.Input;

                        //Modified By
                        command.Parameters.AddWithValue("_modifiedby", rh.ModifiedBy);
                        command.Parameters["_modifiedby"].Direction = ParameterDirection.Input;

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

                        logs.insertActivityLogs(name: "hris.CN_ADD_REQUEST_HEADER", action: 1, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.data = null;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "hris.CN_ADD_REQUEST_HEADER", action: 1, status: response.status, remarks: response.message);
            }

            return response;
        }


     
        public ResponseModel addRequestAttachment(RequestModel ra)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_ADD_REQUEST_ATTACHMENT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // Request Id
                        command.Parameters.AddWithValue("_requestid", ra.RequestID);
                        command.Parameters["_requestid"].Direction = ParameterDirection.Input;


                        // Attachment
                        command.Parameters.AddWithValue("_attachment", ra.Attachment);
                        command.Parameters["_attachment"].Direction = ParameterDirection.Input;

                        //Modified By
                        command.Parameters.AddWithValue("_modifiedby", ra.ModifiedBy);
                        command.Parameters["_modifiedby"].Direction = ParameterDirection.Input;

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

                        logs.insertActivityLogs(name: "hris.CN_ADD_REQUEST_ATTACHMENT", action: 1, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.data = null;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "hris.CN_ADD_REQUEST_HEADER", action: 1, status: response.status, remarks: response.message);
            }

            return response;
        }

        public ResponseModel addRequestCC(RequestModel ra)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_ADD_REQUEST_CC";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // Request Id
                        command.Parameters.AddWithValue("_requestid", ra.RequestID);
                        command.Parameters["_requestid"].Direction = ParameterDirection.Input;

                         // Emp Id
                        command.Parameters.AddWithValue("_empid", ra.EmpID);
                        command.Parameters["_empid"].Direction = ParameterDirection.Input;

                        // Sequence
                        command.Parameters.AddWithValue("_sequence", ra.RequestID);
                        command.Parameters["_sequence"].Direction = ParameterDirection.Input;

                        //Modified By
                        command.Parameters.AddWithValue("_modifiedby", ra.ModifiedBy);
                        command.Parameters["_modifiedby"].Direction = ParameterDirection.Input;

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

                        logs.insertActivityLogs(name: "hris.CN_ADD_REQUEST_CC", action: 1, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.data = null;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "hris.CN_ADD_REQUEST_CC", action: 1, status: response.status, remarks: response.message);
            }

            return response;
        }


        public ResponseModel addRequestRequester(RequestModel ra)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_ADD_REQUEST_REQUESTER";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // Request Id
                        command.Parameters.AddWithValue("_requestid", ra.RequestID);
                        command.Parameters["_requestid"].Direction = ParameterDirection.Input;


                        // Emp Id
                        command.Parameters.AddWithValue("_empid", ra.EmpID);
                        command.Parameters["_empid"].Direction = ParameterDirection.Input;

                        // Sequence
                        command.Parameters.AddWithValue("_sequence", ra.Sequence);
                        command.Parameters["_sequence"].Direction = ParameterDirection.Input;

                        //Modified By
                        command.Parameters.AddWithValue("_modifiedby", ra.ModifiedBy);
                        command.Parameters["_modifiedby"].Direction = ParameterDirection.Input;

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

                        logs.insertActivityLogs(name: "hris.CN_ADD_REQUEST_REQUESTER", action: 1, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.data = null;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "hris.CN_ADD_REQUEST_REQUESTER", action: 1, status: response.status, remarks: response.message);
            }

            return response;
        }

        public ResponseModel addRequestWorkflow(RequestModel ra)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_ADD_REQUEST_WORKFLOW";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // Request Id
                        command.Parameters.AddWithValue("_requestid", ra.RequestID);
                        command.Parameters["_requestid"].Direction = ParameterDirection.Input;
                       

                        //Modified By
                        command.Parameters.AddWithValue("_modifiedby", ra.ModifiedBy);
                        command.Parameters["_modifiedby"].Direction = ParameterDirection.Input;

                        string result = "";
                        DataSet ds = new DataSet();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow row in dt.Rows)
                        {
                            result = row["SUCCESS"].ToString();
                        }

                        if (result == "SUCCESS")
                        {

                            response.code = consts.CODE_OK;
                            response.status = consts.SUCCESS;
                            response.error = consts.ERROR_FALSE;
                            response.message = consts.SUCCESS_INSERT;
                            response.data = result;
                        }

                      
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_ADD_REQUEST_WORKFLOW", action: 1, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.data = null;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "hris.CN_ADD_REQUEST_WORKFLOW", action: 1, status: response.status, remarks: response.message);
            }

            return response;
        }






        // AWAITING APPROVAL

        public ResponseModel processApproval(Approval ra)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_PROCESS_APPROVAL";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);



                        // Status
                        command.Parameters.AddWithValue("_status",ra.Status);
                        command.Parameters["_status"].Direction = ParameterDirection.Input;

                        // Request Id
                        command.Parameters.AddWithValue("_requestid", ra.RequestID);
                        command.Parameters["_requestid"].Direction = ParameterDirection.Input;

                        int row_count = command.ExecuteNonQuery();

                       
                        if (row_count >=1)
                        {

                            response.code = consts.CODE_OK;
                            response.status = consts.SUCCESS;
                            response.error = consts.ERROR_FALSE;
                            response.message = consts.SUCCESS_UPDATE;
                            response.data = null;
                            command.Transaction.Commit();
                        }


                        conn.Close();

                        logs.insertActivityLogs(name: "UPDATE hris.request_header as header,hris.request_workflow as flow SET header.Status=" + ra.Status + ",flow.Status=" + ra.Status + " WHERE header.ID = " + ra.RequestID + " and flow.RequestID = " + ra.RequestID + "", action: 1, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.data = null;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "UPDATE hris.request_header as header,hris.request_workflow as flow SET header.Status=" + ra.Status + ",flow.Status=" + ra.Status + " WHERE header.ID = " + ra.RequestID + " and flow.RequestID = " + ra.RequestID + "", action: 1, status: response.status, remarks: response.message);
            }

            return response;
        }





        // AWAITING APPROVAL
        public ResponseModel getAwaitingApproval(Approval a)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {

                        command.CommandText = "hris.CN_GET_APPROVAL";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<ApprovalWorkflow> list_tm = new List<ApprovalWorkflow>();

                        command.Parameters.AddWithValue("_view", a.View);
                        command.Parameters["_view"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_name", a.Name);
                        command.Parameters["_name"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {

                            ApprovalWorkflow tm = new ApprovalWorkflow();

                            tm.RequestID = Convert.ToInt32(rdr["RequestID"]);
                            tm.EmpID = Convert.ToInt32(rdr["EmpID"]);
                            tm.Request = rdr["Request"].ToString();
                            tm.CreatedBy = rdr["CreatedBy"].ToString();
                            tm.Status = status(Convert.ToInt32(rdr["Status"]));
                            tm.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]);


                            list_tm.Add(tm);

                        }
                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_tm;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_GET_APPROVAL", action: 4, status: response.status, remarks: response.message);
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
                logs.insertActivityLogs(name: "hris.CN_GET_APPROVAL", action: 4, status: response.status, remarks: response.message);
            }


            return response;
        }











        // REQUEST DETAILS FUNCTIONS



        // COA
        public ResponseModel addRequestDetailCOA(RequestDetails rd)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_ADD_REQUEST_DETAIL_COA";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        
                        // Request Id
                        command.Parameters.AddWithValue("_requestid", rd.RequestID);
                        command.Parameters["_requestid"].Direction = ParameterDirection.Input;

                        //Date
                        command.Parameters.AddWithValue("_date", rd.Date);
                        command.Parameters["_date"].Direction = ParameterDirection.Input;

                        // StartTime
                        command.Parameters.AddWithValue("_sttime", rd.StartTime);
                        command.Parameters["_sttime"].Direction = ParameterDirection.Input;

                        // StartTimeDate
                        command.Parameters.AddWithValue("_stdate",rd.StartTimeDate);
                        command.Parameters["_stdate"].Direction = ParameterDirection.Input;

                        //EndTime
                        command.Parameters.AddWithValue("_ettime", rd.EndTime);
                        command.Parameters["_ettime"].Direction = ParameterDirection.Input;

                        //EndTimeDate
                        command.Parameters.AddWithValue("_etdate", rd.EndTimeDate);
                        command.Parameters["_ettime"].Direction = ParameterDirection.Input;


                        // StartTime2
                        command.Parameters.AddWithValue("_sttime2", rd.StartTime2);
                        command.Parameters["_sttime2"].Direction = ParameterDirection.Input;

                        // StartTimeDate2
                        command.Parameters.AddWithValue("_stdate2", rd.StartTimeDate2);
                        command.Parameters["_stdate2"].Direction = ParameterDirection.Input;

                        //EndTime2
                        command.Parameters.AddWithValue("_ettime2", rd.EndTime2);
                        command.Parameters["_ettime2"].Direction = ParameterDirection.Input;

                        //EndTimeDate2
                        command.Parameters.AddWithValue("_etdate2", rd.EndTimeDate2);
                        command.Parameters["_ettime2"].Direction = ParameterDirection.Input;

                        // Reason
                        command.Parameters.AddWithValue("_reason", rd.Reason);
                        command.Parameters["_reason"].Direction = ParameterDirection.Input;

                        //Modified By
                        command.Parameters.AddWithValue("_modifiedby", rd.ModifiedBy);
                        command.Parameters["_modifiedby"].Direction = ParameterDirection.Input;

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

                        logs.insertActivityLogs(name: "hris.CN_ADD_REQUEST_DETAIL_COA", action: 1, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.data = null;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "hris.CN_ADD_REQUEST_DETAIL_COA", action: 1, status: response.status, remarks: response.message);
            }

            return response;
        }




        // OVERTIME 

        public ResponseModel addRequestDetailOT(RequestDetails rd)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_ADD_REQUEST_DETAIL_OT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                      

                        // Request Id
                        command.Parameters.AddWithValue("_requestid", rd.RequestID);
                        command.Parameters["_requestid"].Direction = ParameterDirection.Input;

                       
                    

                        // StartDate
                        command.Parameters.AddWithValue("_startdate", rd.StartDate);
                        command.Parameters["_startdate"].Direction = ParameterDirection.Input;

                        // StartTime
                        command.Parameters.AddWithValue("_starttime", rd.StartTime);
                        command.Parameters["_starttime"].Direction = ParameterDirection.Input;

                        //EndTime
                        command.Parameters.AddWithValue("_endtime", rd.EndTime);
                        command.Parameters["_endtime"].Direction = ParameterDirection.Input;

                        //EndDate
                        command.Parameters.AddWithValue("_enddate",rd.EndDate);
                        command.Parameters["_enddate"].Direction = ParameterDirection.Input;

                        // Reason
                        command.Parameters.AddWithValue("_reason", rd.Reason);
                        command.Parameters["_reason"].Direction = ParameterDirection.Input;


                        //Modified By
                        command.Parameters.AddWithValue("_modifiedby", rd.ModifiedBy);
                        command.Parameters["_modifiedby"].Direction = ParameterDirection.Input;

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

                        logs.insertActivityLogs(name: "hris.CN_ADD_REQUEST_DETAIL_OT", action: 1, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.data = null;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "hris.CN_ADD_REQUEST_DETAIL_OT", action: 1, status: response.status, remarks: response.message);
            }

            return response;
        }



        // LEAVE 

        public ResponseModel addRequestDetailLeave(RequestDetails rd)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_ADD_REQUEST_DETAIL_LEAVE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);





                        // Request Id
                        command.Parameters.AddWithValue("_requestid", rd.RequestID);
                        command.Parameters["_requestid"].Direction = ParameterDirection.Input;




                        // StartDate
                        command.Parameters.AddWithValue("_startdate", rd.StartDate);
                        command.Parameters["_startdate"].Direction = ParameterDirection.Input;

                        // Span
                        command.Parameters.AddWithValue("_span", rd.Span1);
                        command.Parameters["_span"].Direction = ParameterDirection.Input;


                        //EndDate
                        command.Parameters.AddWithValue("_enddate", rd.EndDate);
                        command.Parameters["_enddate"].Direction = ParameterDirection.Input;

                        // Span2
                        command.Parameters.AddWithValue("_span2", rd.Span2);
                        command.Parameters["_span2"].Direction = ParameterDirection.Input;

                        // Date
                        command.Parameters.AddWithValue("_date", rd.Date);
                        command.Parameters["_date"].Direction = ParameterDirection.Input;

                        // StartTime
                        command.Parameters.AddWithValue("_starttime", rd.StartTime);
                        command.Parameters["_starttime"].Direction = ParameterDirection.Input;

                        //EndTime
                        command.Parameters.AddWithValue("_endtime", rd.EndTime);
                        command.Parameters["_endtime"].Direction = ParameterDirection.Input;

                        // Reason
                        command.Parameters.AddWithValue("_reason", rd.Reason);
                        command.Parameters["_reason"].Direction = ParameterDirection.Input;


                        //Modified By
                        command.Parameters.AddWithValue("_modifiedby", rd.ModifiedBy);
                        command.Parameters["_modifiedby"].Direction = ParameterDirection.Input;

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

                        logs.insertActivityLogs(name: "hris.CN_ADD_REQUEST_DETAIL_LEAVE", action: 1, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.data = null;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "hris.CN_ADD_REQUEST_DETAIL_LEAVE", action: 1, status: response.status, remarks: response.message);
            }

            return response;
        }



        // SHIFT 

        public ResponseModel addRequestDetailShift(RequestDetails rd)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_ADD_REQUEST_DETAIL_SHIFT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                   

                        // Request Id
                        command.Parameters.AddWithValue("_requestid", rd.RequestID);
                        command.Parameters["_requestid"].Direction = ParameterDirection.Input;

                        //Date
                        command.Parameters.AddWithValue("_date",rd.Date);
                        command.Parameters["_date"].Direction = ParameterDirection.Input;



                        // Shift
                        command.Parameters.AddWithValue("_shift", rd.Shift=="Rest Day"?1:2);
                        command.Parameters["_shift"].Direction = ParameterDirection.Input;


                        // Reason
                        command.Parameters.AddWithValue("_reason", rd.Reason);
                        command.Parameters["_reason"].Direction = ParameterDirection.Input;


                        //Modified By
                        command.Parameters.AddWithValue("_modifiedby", rd.ModifiedBy);
                        command.Parameters["_modifiedby"].Direction = ParameterDirection.Input;

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

                        logs.insertActivityLogs(name: "hris.CN_ADD_REQUEST_DETAIL_SHIFT", action: 1, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.data = null;
                response.status = consts.ERROR;

                logs.insertActivityLogs(name: "hris.CN_ADD_REQUEST_DETAIL_SHIFT", action: 1, status: response.status, remarks: response.message);
            }

            return response;
        }


        // END OF REQUEST DETAILS FUNCTIONS

        public ResponseModel uploadAttachment(string path, HttpPostedFile postedFile )
        {
            ResponseModel response = new ResponseModel();

            //Check directory, if not exists create one
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Fetch the File Name.
            string fileName = HttpContext.Current.Request.Form["fileName"] + Path.GetExtension(postedFile.FileName);

            //Save the File.
            postedFile.SaveAs(path + fileName);
            response.message = "Successfully uploaded.";
            response.error = false;

            return response;
        }
       






        public String requestView(string type)
        {
            switch (type)
            {
                case "shift":
                    type = "CN_SHIFT_V";
                    break;
                case "coa":
                    type = "CN_COA_V";
                    break;
                case "overtime":
                    type = "CN_OVERTIME_V";
                    break;
                case "leave":
                    type = "CN_LEAVE_V";
                    break;
            }
            return type;
        }




        public String status(int type)
        {
            string approvalStatus = "";
            switch (type)
            {
                case 0:
                    approvalStatus = "Pending";
                    break;
                case 1:
                    approvalStatus = "For Approval";
                    break;
                case 2:
                    approvalStatus = "Approved";
                    break;
                case 3:
                    approvalStatus = "Disapproved";
                    break;
                case 4:
                    approvalStatus = "For Approval to be Withdrawn";
                    break;

                case 6:
                    approvalStatus = "Disapproved Withdraw";
                    break;
            }

            return approvalStatus;
        }
        public int approvalStatus(string type)
        {
            int approvalStatus = 0;
            switch (type)
            {
                case "Pending":
                    approvalStatus = 0;
                    break;
                case "For Approval":
                    approvalStatus = 1;
                    break;
                case "Approved":
                    approvalStatus = 2;
                    break;
                case "Disapproved":
                    approvalStatus = 3;
                    break;
                case "For Approval to be Withdrawn":
                    approvalStatus = 4;
                    break;

                case "Disapproved Withdraw":
                    approvalStatus = 6;
                    break;
            }

            return approvalStatus;
        }

        public int formID(string type)
        {
            int formid = 0;
            switch (type)
            {
                case "COA":
                    formid = 1;
                    break;
                case "OT":
                    formid = 2;
                    break;
                case "Leave":
                    formid = 3;
                    break;
                case "Shift":
                    formid = 4;
                    break;
                case "Dependent":
                    formid = 5;
                    break;
                default:
                    formid = 0;
                    break;

            }

            return formid;
        }


        public int getLeaveTypeID(string type)
        {
            int id = 0;
            switch (type)
            {
                case "Sick":
                    id = 1;
                    break;
                case "Vacation":
                    id = 2;
                    break;
                case "Undertime":
                    id = 3;
                    break;
                case "Birthday":
                    id = 4;
                    break;
                case "Emergency":
                    id = 5;
                    break;
                case "Maternity":
                    id = 6;
                    break;
                case "Paternity":
                    id = 7;
                    break;
                case "Calamity":
                    id = 8;
                    break;
                case "Educational":
                    id = 9;
                    break;
                case "Earned":
                    id = 10;
                    break;
                case "Study":
                    id = 11;
                    break;
                case "Service Incentive":
                    id = 12;
                    break;
                case "Relocation":
                    id = 13;
                    break;
                case "Magna Carta":
                    id = 14;
                    break;
                case "Solo Parent":
                    id = 15;
                    break;
                case "Bereavement":
                    id = 16;
                    break;
                case "Others":
                    id = 17;
                    break;
                default:
                    id = 0;
                    break;

            }

            return id;
        }

    }
}