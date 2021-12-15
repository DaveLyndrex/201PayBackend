/* 07/10/2021 CN A.Diez */
/*[10/10/2021] CN E.Patot*/

using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace BackEnd.Services
{
    public class PhoneService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        //GET BY ID
        public ResponseModel GetPhoneById(string employeeId)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_PHONE_GET_DATA_BY_ID";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<PhoneModel> list_phonem = new List<PhoneModel>();


                        command.Parameters.AddWithValue("_EmpID", employeeId);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                PhoneModel phonem = new PhoneModel();

                                phonem.ID = Convert.ToInt32(rdr["ID"]);
                                phonem.EmpID = Convert.ToString(rdr["EmpID"]);
                                phonem.PhoneNumber = rdr["PhoneNumber"].ToString();
                                phonem.CountryCode = rdr["CountryCode"].ToString();
                                phonem.AreaCode = rdr["AreaCode"].ToString();
                                phonem.PhoneType = rdr["PhoneType"].ToString();
                                phonem.Extension = rdr["Extension"].ToString();
                                phonem.DateFrom = Convert.ToDateTime(rdr["DateFrom"]).ToString("MMMM dd, yyyy");
                                phonem.DateTo = Convert.ToDateTime(rdr["DateTo"]).ToString("MMMM dd, yyyy");
                                phonem.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                phonem.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                phonem.ModifiedBy = rdr["ModifiedBy"].ToString();


                                list_phonem.Add(phonem);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_phonem;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_GET_DATA_BY_ID", action: 5, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "hris.CN_GET_DATA_BY_ID", action: 5, status: response.status, remarks: response.message);
            }

            return response;
        }


        //GET ALL
        public ResponseModel getAllEmployeePhone()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_PHONE_GET_ALL";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<PhoneModel> list_phonem = new List<PhoneModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                PhoneModel phonem = new PhoneModel();

                                phonem.ID = Convert.ToInt32(rdr["ID"]);
                                phonem.EmpID = Convert.ToString(rdr["EmpID"]);
                                phonem.PhoneNumber = rdr["PhoneNumber"].ToString();
                                phonem.CountryCode = rdr["CountryCode"].ToString();
                                phonem.AreaCode = rdr["AreaCode"].ToString();
                                phonem.PhoneType = rdr["PhoneType"].ToString();
                                phonem.Extension = rdr["Extension"].ToString();
                                phonem.DateFrom = Convert.ToDateTime(rdr["DateFrom"]).ToString("MMMM dd, yyyy");
                                phonem.DateTo = Convert.ToDateTime(rdr["DateTo"]).ToString("MMMM dd, yyyy");
                                phonem.CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                phonem.ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"]).ToString("MMMM dd, yyyy hh:mm ss");
                                phonem.ModifiedBy = rdr["ModifiedBy"].ToString();


                                list_phonem.Add(phonem);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_phonem;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_PHONE_GET_ALL", action: 5, status: response.status, remarks: response.message);
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

                logs.insertActivityLogs(name: "hris.CN_PHONE_GET_ALL", action: 5, status: response.status, remarks: response.message);
            }

            return response;
        }

        //CREATE OR INSERT
        public ResponseModel createPhone(PhoneModel phone)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_PHONE_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        //ID
                        //command.Parameters.AddWithValue("_ID", phone.ID);
                        // command.Parameters["_ID"].Direction = ParameterDirection.Input;
                        #region
                        // Emp ID
                        command.Parameters.AddWithValue("_EmpID", phone.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _PhoneNumber
                        command.Parameters.AddWithValue("_PhoneNumber", phone.PhoneNumber);
                        command.Parameters["_PhoneNumber"].Direction = ParameterDirection.Input;

                        // _CountryCode
                        command.Parameters.AddWithValue("_CountryCode", phone.CountryCode);
                        command.Parameters["_CountryCode"].Direction = ParameterDirection.Input;

                        // _AreaCode
                        command.Parameters.AddWithValue("_AreaCode", phone.AreaCode);
                        command.Parameters["_AreaCode"].Direction = ParameterDirection.Input;

                        // _PhoneType
                        command.Parameters.AddWithValue("_PhoneType", phone.PhoneType);
                        command.Parameters["_PhoneType"].Direction = ParameterDirection.Input;

                        // _Extension
                        command.Parameters.AddWithValue("_Extension", phone.Extension);
                        command.Parameters["_Extension"].Direction = ParameterDirection.Input;

                        // _DateFrom
                        command.Parameters.AddWithValue("_DateFrom", phone.DateFrom);
                        command.Parameters["_DateFrom"].Direction = ParameterDirection.Input;

                        // _DateTo
                        command.Parameters.AddWithValue("_DateTo", phone.DateTo);
                        command.Parameters["_DateTo"].Direction = ParameterDirection.Input;
                        // _ModifiedBy
                        command.Parameters.AddWithValue("_ModifiedBy", phone.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;
                        #endregion

                        int rows_affected = command.ExecuteNonQuery();

                        if (rows_affected > 0)
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
                    logs.insertActivityLogs(name: "hris.CN_PHONE_INSERT", action: 1, status: response.status, remarks: response.message);

                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.data = null;
                logs.insertActivityLogs(name: "hris.CN_PHONE_INSERT", action: 1, status: response.status, remarks: response.message);
            }

            return response;
        }

        //UPDATE
        public ResponseModel updatePhoneData(PhoneModel phone)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_PHONE_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        #region
                        //ID
                        command.Parameters.AddWithValue("_ID", phone.ID);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        // Emp ID
                        command.Parameters.AddWithValue("_EmpID", phone.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _PhoneNumber
                        command.Parameters.AddWithValue("_PhoneNumber", phone.PhoneNumber);
                        command.Parameters["_PhoneNumber"].Direction = ParameterDirection.Input;

                        // _CountryCode
                        command.Parameters.AddWithValue("_CountryCode", phone.CountryCode);
                        command.Parameters["_CountryCode"].Direction = ParameterDirection.Input;

                        // _AreaCode
                        command.Parameters.AddWithValue("_AreaCode", phone.AreaCode);
                        command.Parameters["_AreaCode"].Direction = ParameterDirection.Input;

                        // _PhoneType
                        command.Parameters.AddWithValue("_PhoneType", phone.PhoneType);
                        command.Parameters["_PhoneType"].Direction = ParameterDirection.Input;

                        // _Extension
                        command.Parameters.AddWithValue("_Extension", phone.Extension);
                        command.Parameters["_Extension"].Direction = ParameterDirection.Input;

                        // _DateFrom
                        command.Parameters.AddWithValue("_DateFrom", phone.DateFrom);
                        command.Parameters["_DateFrom"].Direction = ParameterDirection.Input;

                        // _DateTo
                        command.Parameters.AddWithValue("_DateTo", phone.DateTo);
                        command.Parameters["_DateTo"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_ModifiedBy", phone.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;
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

                        logs.insertActivityLogs(name: "hris.CN_PHONE_UPDATE", action: 2, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.status = consts.ERROR;
                response.error = consts.ERROR_TRUE;
                response.data = null;

                logs.insertActivityLogs(name: "hris.CN_PHONE_UPDATE", action: 2, status: response.status, remarks: response.message);
            }
            return response;
        }

    }
}