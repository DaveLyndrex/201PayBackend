/*[10/14/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace BackEnd.Services
{
    public class CostCenterService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel getCosts(int empid)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.CN_EMPLOYEE_COST_CENTER_V WHERE (NOW() BETWEEN StartDate AND EndDate) AND EmpID = '" + empid +"'";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<CostCenterModel> list_ccm = new List<CostCenterModel>();

                        // Emp ID
                        command.Parameters.AddWithValue("_EmpID", empid);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                CostCenterModel ccm = new CostCenterModel();
                                ccm.ID = Convert.ToInt32(rdr["ID"]);
                                ccm.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                ccm.StartDate = Convert.ToDateTime(rdr["StartDate"]).ToString("MM/dd/yyyy");
                                ccm.EndDate = Convert.ToDateTime(rdr["EndDate"]).ToString("MM/dd/yyyy");
                                ccm.CostCenterID = Convert.ToString(rdr["CostCenterName"]);
                                ccm.TypeID = Convert.ToString(rdr["Description"]);
                                ccm.Value = Convert.ToString(rdr["Value"]);
                                ccm.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MM/dd/yyyy hh:mm ss"); ;
                                ccm.ModifiedBy = rdr["ModifiedBy"].ToString();
                                ccm.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MM/dd/yyyy hh:mm ss"); ;
                                ccm.CompanyID = Convert.ToString(rdr["CompanyName"]);
                                ccm.PrimaryID = rdr["PrimaryID"].ToString();
                                list_ccm.Add(ccm);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_ccm;
                        response.error = consts.ERROR_FALSE;
                        response.status = consts.SUCCESS;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.CN_EMPLOYEE_COST_CENTER_V WHERE (NOW() BETWEEN StartDate AND EndDate) AND EmpID = '" + empid + "'", action: 3, status: response.status, remarks: response.message);
                    }
                }
            } 
            catch(Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
                response.code = consts.CODE_ERROR;
                response.status = consts.ERROR;
                response.data = null;

                logs.insertActivityLogs(name: "SELECT * FROM hris.CN_EMPLOYEE_COST_CENTER_V WHERE (NOW() BETWEEN StartDate AND EndDate) AND EmpID = '" + empid + "'", action: 3, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel createCostCenter(CostCenterModel ccm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_COST_CENTER_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        #region
                        // Emp ID
                        command.Parameters.AddWithValue("_EmpID", ccm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", ccm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EndDate", ccm.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // _CostCenterID
                        command.Parameters.AddWithValue("_CostCenterID", ccm.CostCenterID);
                        command.Parameters["_CostCenterID"].Direction = ParameterDirection.Input;

                        // _TypeID
                        command.Parameters.AddWithValue("_TypeID", ccm.TypeID);
                        command.Parameters["_TypeID"].Direction = ParameterDirection.Input;

                        // _Value
                        command.Parameters.AddWithValue("_Value", ccm.Value);
                        command.Parameters["_Value"].Direction = ParameterDirection.Input;

                        // _ModifiedBy
                        command.Parameters.AddWithValue("_ModifiedBy", ccm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        // _CompanyID
                        command.Parameters.AddWithValue("_CompanyID", ccm.CompanyID);
                        command.Parameters["_CompanyID"].Direction = ParameterDirection.Input;

                        // _PrimaryID
                        command.Parameters.AddWithValue("_PrimaryID", ccm.PrimaryID);
                        command.Parameters["_PrimaryID"].Direction = ParameterDirection.Input;

                        #endregion

                        int rows_affected = command.ExecuteNonQuery();

                        if ( rows_affected > 0 )
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
                    logs.insertActivityLogs(name: "hris.CN_COST_CENTER_INSERT", action: 1, status: response.status, remarks: response.message);
                }
            }
            catch(Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.data = null;
                logs.insertActivityLogs(name: "hris.CN_COST_CENTER_INSERT", action: 1, status: response.status, remarks: response.message);
            }

            return response;
        }


        public ResponseModel updateCostCenter(CostCenterModel ccm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_COST_CENTER_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        #region
                        // ID
                        command.Parameters.AddWithValue("_ID", ccm.ID);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        // Emp ID
                        command.Parameters.AddWithValue("_EmpID", ccm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", ccm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EndDate", ccm.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // _CostCenterID
                        command.Parameters.AddWithValue("_CostCenterID", ccm.CostCenterID);
                        command.Parameters["_CostCenterID"].Direction = ParameterDirection.Input;

                        // _TypeID
                        command.Parameters.AddWithValue("_TypeID", ccm.TypeID);
                        command.Parameters["_TypeID"].Direction = ParameterDirection.Input;

                        // _Value
                        command.Parameters.AddWithValue("_Value", ccm.Value);
                        command.Parameters["_Value"].Direction = ParameterDirection.Input;

                        // _ModifiedBy
                        command.Parameters.AddWithValue("_ModifiedBy", ccm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;

                        // _CompanyID
                        command.Parameters.AddWithValue("_CompanyID", ccm.CompanyID);
                        command.Parameters["_CompanyID"].Direction = ParameterDirection.Input;

                        // _PrimaryID
                        command.Parameters.AddWithValue("_PrimaryID", ccm.PrimaryID);
                        command.Parameters["_PrimaryID"].Direction = ParameterDirection.Input;
                        #endregion

                        int rows_affected = command.ExecuteNonQuery();

                        if (rows_affected > 0)
                        {
                            response.message = consts.SUCCESS_UPDATE;
                            response.code = consts.CODE_OK;
                            response.status = consts.SUCCESS;
                            response.error = consts.ERROR_FALSE;
                            response.data = null;
                            command.Transaction.Commit();
                        }
                        else
                        {
                            response.message = consts.ERROR_UPDATE;
                            response.code = consts.CODE_ERROR;
                            response.status = consts.ERROR;
                            response.error = consts.ERROR_TRUE;
                            response.data = null;
                            command.Transaction.Rollback();
                        }
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_COST_CENTER_UPDATE", action: 2, status: response.status, remarks: response.message);
                    }
                }
            } 
            catch(Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.status = consts.ERROR;
                response.error = consts.ERROR_TRUE;
                response.data = null;

                logs.insertActivityLogs(name: "hris.CN_COST_CENTER_UPDATE", action: 2, status: response.status, remarks: response.message);
            }
            return response;
        }
    }
}