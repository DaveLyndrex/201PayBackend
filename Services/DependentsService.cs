/*[10/08/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace BackEnd.Services
{
    public class DependentsService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel createEmployeeDependentRecord(DependentsModel dm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_DEPENDENTS_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        #region
                        // _EmpID
                        command.Parameters.AddWithValue("_EmpID", dm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _Lastname
                        command.Parameters.AddWithValue("_Lastname", dm.Lastname);
                        command.Parameters["_Lastname"].Direction = ParameterDirection.Input;

                        // _Middlename
                        command.Parameters.AddWithValue("_Middlename", dm.Middlename);
                        command.Parameters["_Middlename"].Direction = ParameterDirection.Input;

                        // _Firstname
                        command.Parameters.AddWithValue("_Firstname", dm.Firstname);
                        command.Parameters["_Firstname"].Direction = ParameterDirection.Input;

                        // Suffix Id
                        command.Parameters.AddWithValue("_SuffixID", dm.SuffixID);
                        command.Parameters["_SuffixID"].Direction = ParameterDirection.Input;

                        // _BirthDate
                        command.Parameters.AddWithValue("_BirthDate", dm.BirthDate);
                        command.Parameters["_BirthDate"].Direction = ParameterDirection.Input;

                        // _Relation
                        command.Parameters.AddWithValue("_Relation", dm.Relation);
                        command.Parameters["_Relation"].Direction = ParameterDirection.Input;

                        // _WTax
                        command.Parameters.AddWithValue("_WTax", dm.WTax);
                        command.Parameters["_WTax"].Direction = ParameterDirection.Input;

                        // _Medical
                        command.Parameters.AddWithValue("_Medical", dm.Medical);
                        command.Parameters["_Medical"].Direction = ParameterDirection.Input;

                        // _GPA
                        command.Parameters.AddWithValue("_GPA", dm.GPA);
                        command.Parameters["_GPA"].Direction = ParameterDirection.Input;

                        // _DepType
                        command.Parameters.AddWithValue("_DepType", dm.DepType);
                        command.Parameters["_DepType"].Direction = ParameterDirection.Input;

                        //Modified By
                        command.Parameters.AddWithValue("_ModifiedBy", dm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;
                        #endregion

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

                        logs.insertActivityLogs(name: "hris.CN_DEPENDENTS_INSERT", action: 1, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.data = null;
                response.status = consts.ERROR;
                response.code = consts.CODE_ERROR;

                logs.insertActivityLogs(name: "hris.CN_DEPENDENTS_INSERT", action: 1, status: response.status, remarks: response.message);
            }

            return response;
        }

        public ResponseModel updateEmployeeDependentRecord(DependentsModel dm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_DEPENDENTS_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                        #region
                        // _id
                        command.Parameters.AddWithValue("_id", dm.ID);
                        command.Parameters["_id"].Direction = ParameterDirection.Input;

                        // _EmpID
                        command.Parameters.AddWithValue("_EmpID", dm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _Lastname
                        command.Parameters.AddWithValue("_Lastname", dm.Lastname);
                        command.Parameters["_Lastname"].Direction = ParameterDirection.Input;

                        // _Middlename
                        command.Parameters.AddWithValue("_Middlename", dm.Middlename);
                        command.Parameters["_Middlename"].Direction = ParameterDirection.Input;

                        // _Firstname
                        command.Parameters.AddWithValue("_Firstname", dm.Firstname);
                        command.Parameters["_Firstname"].Direction = ParameterDirection.Input;

                        // Suffix Id
                        command.Parameters.AddWithValue("_SuffixID", dm.SuffixID);
                        command.Parameters["_SuffixID"].Direction = ParameterDirection.Input;

                        // _BirthDate
                        command.Parameters.AddWithValue("_BirthDate", dm.BirthDate);
                        command.Parameters["_BirthDate"].Direction = ParameterDirection.Input;

                        // _Relation
                        command.Parameters.AddWithValue("_Relation", dm.Relation);
                        command.Parameters["_Relation"].Direction = ParameterDirection.Input;

                        // _WTax
                        command.Parameters.AddWithValue("_WTax", dm.WTax);
                        command.Parameters["_WTax"].Direction = ParameterDirection.Input;

                        // _Medical
                        command.Parameters.AddWithValue("_Medical", dm.Medical);
                        command.Parameters["_Medical"].Direction = ParameterDirection.Input;

                        // _GPA
                        command.Parameters.AddWithValue("_GPA", dm.GPA);
                        command.Parameters["_GPA"].Direction = ParameterDirection.Input;

                        // _DepType
                        command.Parameters.AddWithValue("_DepType", dm.DepType);
                        command.Parameters["_DepType"].Direction = ParameterDirection.Input;

                        //Modified By
                        command.Parameters.AddWithValue("_ModifiedBy", dm.ModifiedBy);
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

                        logs.insertActivityLogs(name: "hris.CN_DEPENDENTS_UPDATE", action: 2, status: response.status, remarks: response.message);

                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = true;
                response.code = consts.CODE_ERROR;
                response.status = consts.ERROR;
                response.data = null;

                logs.insertActivityLogs(name: "hris.CN_DEPENDENTS_UPDATE", action: 2, status: response.status, remarks: response.message);
            }

            return response;


        }

        public ResponseModel getEmployeeDependentsById(int id)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.CN_EMPLOYEE_DEPENDENT_V WHERE EmpID = '" + id + "'";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);


                        List<DependentsModel> list_dm = new List<DependentsModel>();

                        MySqlDataReader rdr = command.ExecuteReader();

                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                DependentsModel dm = new DependentsModel();

                                dm.ID = Convert.ToInt32(rdr["ID"]);
                                dm.EmpID = rdr["EmpID"].ToString();
                                dm.Firstname = rdr["Firstname"].ToString();
                                dm.Lastname = rdr["Lastname"].ToString();
                                dm.Middlename = rdr["Middlename"].ToString();
                                dm.SuffixID = Convert.ToString(rdr["Suffix"]);
                                dm.BirthDate = Convert.ToDateTime(rdr["BirthDate"]).ToString("MM/dd/yyyy");
                                dm.Relation = rdr["Relation"].ToString();
                                dm.WTax = Convert.ToString(rdr["WTax"]);
                                dm.Medical = Convert.ToString(rdr["Medical"]);
                                dm.GPA = Convert.ToString(rdr["GPA"]);
                                dm.DepType = Convert.ToString(rdr["DepType"]);
                                dm.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                dm.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                dm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_dm.Add(dm);
                            }
                        }
                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_dm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;

                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.EMPLOYEE_DEPENDENTS_V WHERE EmpID = '" + id + "'", action: 5, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "SELECT * FROM hris.EMPLOYEE_DEPENDENTS_V WHERE EmpID = '" + id + "'", action: 5, status: response.status, remarks: response.message);
            }

            return response;
        }
    }
}

