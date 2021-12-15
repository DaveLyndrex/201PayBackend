/*[10/10/2021] CN E.Patot*/
using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace BackEnd.Services
{
    public class VisaService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel createEmployeeVisa(VisaModel vm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_VISA_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // EMP ID 
                        command.Parameters.AddWithValue("_EmpID", vm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_EffectiveStartDate", vm.EffectiveStartDate);
                        command.Parameters["_EffectiveStartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EffectiveEndDate", vm.EffectiveEndDate);
                        command.Parameters["_EffectiveEndDate"].Direction = ParameterDirection.Input;

                        // _VisaPermitType
                        command.Parameters.AddWithValue("_VisaPermitType", vm.VisaPermitType);
                        command.Parameters["_VisaPermitType"].Direction = ParameterDirection.Input;


                        // _EntryDate
                        command.Parameters.AddWithValue("_EntryDate", vm.EntryDate);
                        command.Parameters["_EntryDate"].Direction = ParameterDirection.Input;

                        // _CurrentVisaPermit
                        command.Parameters.AddWithValue("_CurrentVisaPermit", vm.CurrentVisaPermit);
                        command.Parameters["_CurrentVisaPermit"].Direction = ParameterDirection.Input;

                        // _ModifiedBy
                        command.Parameters.AddWithValue("_ModifiedBy", vm.ModifiedBy);
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

                        logs.insertActivityLogs(name: "hris.CN_VISA_INSERT", action: 1, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "hris.CN_VISA_INSERT", action: 1, status: response.status, remarks: response.message);
            }
            return response;
        }
        public ResponseModel updateEmployeeVisa(VisaModel vm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_VISA_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // _ID
                        command.Parameters.AddWithValue("_ID", vm.ID);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        // _EmpID
                        command.Parameters.AddWithValue("_EmpID", vm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_EffectiveStartDate", vm.EffectiveStartDate);
                        command.Parameters["_EffectiveStartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EffectiveEndDate", vm.EffectiveEndDate);
                        command.Parameters["_EffectiveEndDate"].Direction = ParameterDirection.Input;

                        // _VisaPermitType
                        command.Parameters.AddWithValue("_VisaPermitType", vm.VisaPermitType);
                        command.Parameters["_VisaPermitType"].Direction = ParameterDirection.Input;

                        

                        // _EntryDate
                        command.Parameters.AddWithValue("_EntryDate", vm.EntryDate);
                        command.Parameters["_EntryDate"].Direction = ParameterDirection.Input;

                        // _CurrentVisaPermit
                        command.Parameters.AddWithValue("_CurrentVisaPermit", vm.CurrentVisaPermit);
                        command.Parameters["_CurrentVisaPermit"].Direction = ParameterDirection.Input;

                        // _ModifiedBy
                        command.Parameters.AddWithValue("_ModifiedBy", vm.ModifiedBy);
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

                        logs.insertActivityLogs(name: "hris.CN_VISA_UPDATE", action: 2, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "hris.CN_VISA_UPDATE", action: 2, status: response.status, remarks: response.message);
            }
            return response;
        }

        public ResponseModel getEmployeeVisaById(int employeeId)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM hris.CN_EMPLOYEE_VISA_V WHERE (NOW() BETWEEN EffectiveStartDate AND EffectiveEndDate)  AND EmpID = '" + employeeId + "'";
                        command.CommandType = CommandType.Text;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<VisaModel> list_vm = new List<VisaModel>();

                       
                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                VisaModel vm = new VisaModel();

                                vm.ID = Convert.ToInt32(rdr["ID"]);
                                vm.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                vm.EffectiveStartDate = Convert.ToDateTime(rdr["EffectiveStartDate"]).ToString("MM/dd/yyyy");
                                vm.EffectiveEndDate = Convert.ToDateTime(rdr["EffectiveEndDate"]).ToString("MM/dd/yyyy");
                                vm.VisaPermitType = rdr["VisaPermitType"].ToString();
                                vm.CurrentVisaPermit= rdr["CurrentVisaPermit"].ToString();
                                vm.EntryDate = Convert.ToDateTime(rdr["EntryDate"]).ToString("MM/dd/yyyy");
                                vm.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                vm.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MM/dd/yyyy hh:mm ss");
                                vm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_vm.Add(vm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_vm;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "SELECT * FROM hris.CN_EMPLOYEE_VISA_V WHERE (NOW() BETWEEN EffectiveStartDate AND EffectiveEndDate)  AND EmpID = '" + employeeId + "'", action: 5, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "SELECT * FROM hris.CN_EMPLOYEE_VISA_V WHERE (NOW() BETWEEN EffectiveStartDate AND EffectiveEndDate)  AND EmpID = '" + employeeId + "'", action: 5, status: response.status, remarks: response.message);
            }

            return response;
        }

    
    }
}