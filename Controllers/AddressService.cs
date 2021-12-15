using BackEnd.Global;
using BackEnd.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BackEnd.Services
{
    public class AddressService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();


        public ResponseModel createEmployeeAddress(AddressModel adm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_EMERGENCY_CONTACT_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // EMP ID 
                        command.Parameters.AddWithValue("_EmpID", adm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", adm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EndDate", adm.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // _AddressTypeID
                        command.Parameters.AddWithValue("_AddressTypeID", adm.AddressTypeID);
                        command.Parameters["_AddressTypeID"].Direction = ParameterDirection.Input;

                        // _Address1
                        command.Parameters.AddWithValue("_Address1", adm.Address1);
                        command.Parameters["_Address1"].Direction = ParameterDirection.Input;

                        // _Address2
                        command.Parameters.AddWithValue("_Address2", adm.Address2);
                        command.Parameters["_Address2"].Direction = ParameterDirection.Input;

                        // _Address3
                        command.Parameters.AddWithValue("_Address3", adm.Address3);
                        command.Parameters["_Address3"].Direction = ParameterDirection.Input;

                        // _Address4
                        command.Parameters.AddWithValue("_Address4", adm.Address4);
                        command.Parameters["_Address4"].Direction = ParameterDirection.Input;

                        // _City
                        command.Parameters.AddWithValue("_City", adm.City);
                        command.Parameters["_City"].Direction = ParameterDirection.Input;

                        // _Province
                        command.Parameters.AddWithValue("_Province", adm.Province);
                        command.Parameters["_Province"].Direction = ParameterDirection.Input;

                        // _Region
                        command.Parameters.AddWithValue("_Region", adm.Region);
                        command.Parameters["_Region"].Direction = ParameterDirection.Input;

                        // _PostalCode
                        command.Parameters.AddWithValue("_PostalCode", adm.PostalCode);
                        command.Parameters["_PostalCode"].Direction = ParameterDirection.Input;

                        // _Country
                        command.Parameters.AddWithValue("_Country", adm.Country);
                        command.Parameters["_Country"].Direction = ParameterDirection.Input;

                        // _MobileNumber
                        command.Parameters.AddWithValue("_MobileNumber", adm.MobileNumber);
                        command.Parameters["_MobileNumber"].Direction = ParameterDirection.Input;

                        // _LandlineNumber
                        command.Parameters.AddWithValue("_LandlineNumber", adm.LandlineNumber);
                        command.Parameters["_LandlineNumber"].Direction = ParameterDirection.Input;

                        // _MobileNumber
                        command.Parameters.AddWithValue("_PrimaryFlag", adm.PrimaryFlag);
                        command.Parameters["_PrimaryFlag"].Direction = ParameterDirection.Input;

                        // _MobileNumber
                        command.Parameters.AddWithValue("_ModifiedBy", adm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;
                        int rows_affected = command.ExecuteNonQuery();

                        if (rows_affected > 0)
                        {
                            command.Transaction.Commit();
                            response.message = "Successfully Added";
                            response.status = consts.SUCCESS;
                            response.code = consts.CODE_OK;
                            response.error = consts.ERROR_FALSE;
                        }
                        else
                        {
                            command.Transaction.Rollback();
                            response.message = "Error in adding data";
                            response.status = consts.ERROR;
                            response.code = consts.CODE_ERROR;
                            response.error = consts.ERROR_TRUE;
                        }
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
            }
            return response;
        }
        public ResponseModel updateEmployeeAddress(AddressModel adm)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_ADDRESS_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        // id
                        command.Parameters.AddWithValue("_id", adm.ID);
                        command.Parameters["_id"].Direction = ParameterDirection.Input;

                        // EMP ID 
                        command.Parameters.AddWithValue("_EmpID", adm.EmpID);
                        command.Parameters["_EmpID"].Direction = ParameterDirection.Input;

                        // _StartDate
                        command.Parameters.AddWithValue("_StartDate", adm.StartDate);
                        command.Parameters["_StartDate"].Direction = ParameterDirection.Input;

                        // _EndDate
                        command.Parameters.AddWithValue("_EndDate", adm.EndDate);
                        command.Parameters["_EndDate"].Direction = ParameterDirection.Input;

                        // _AddressTypeID
                        command.Parameters.AddWithValue("_AddressTypeID", adm.AddressTypeID);
                        command.Parameters["_AddressTypeID"].Direction = ParameterDirection.Input;

                        // _Address1
                        command.Parameters.AddWithValue("_Address1", adm.Address1);
                        command.Parameters["_Address1"].Direction = ParameterDirection.Input;

                        // _Address2
                        command.Parameters.AddWithValue("_Address2", adm.Address2);
                        command.Parameters["_Address2"].Direction = ParameterDirection.Input;

                        // _Address3
                        command.Parameters.AddWithValue("_Address3", adm.Address3);
                        command.Parameters["_Address3"].Direction = ParameterDirection.Input;

                        // _Address4
                        command.Parameters.AddWithValue("_Address4", adm.Address4);
                        command.Parameters["_Address4"].Direction = ParameterDirection.Input;

                        // _City
                        command.Parameters.AddWithValue("_City", adm.City);
                        command.Parameters["_City"].Direction = ParameterDirection.Input;

                        // _Province
                        command.Parameters.AddWithValue("_Province", adm.Province);
                        command.Parameters["_Province"].Direction = ParameterDirection.Input;

                        // _Region
                        command.Parameters.AddWithValue("_Region", adm.Region);
                        command.Parameters["_Region"].Direction = ParameterDirection.Input;

                        // _PostalCode
                        command.Parameters.AddWithValue("_PostalCode", adm.PostalCode);
                        command.Parameters["_PostalCode"].Direction = ParameterDirection.Input;

                        // _Country
                        command.Parameters.AddWithValue("_Country", adm.Country);
                        command.Parameters["_Country"].Direction = ParameterDirection.Input;

                        // _MobileNumber
                        command.Parameters.AddWithValue("_MobileNumber", adm.MobileNumber);
                        command.Parameters["_MobileNumber"].Direction = ParameterDirection.Input;

                        // _LandlineNumber
                        command.Parameters.AddWithValue("_LandlineNumber", adm.LandlineNumber);
                        command.Parameters["_LandlineNumber"].Direction = ParameterDirection.Input;

                        // _MobileNumber
                        command.Parameters.AddWithValue("_PrimaryFlag", adm.PrimaryFlag);
                        command.Parameters["_PrimaryFlag"].Direction = ParameterDirection.Input;

                        // _MobileNumber
                        command.Parameters.AddWithValue("_ModifiedBy", adm.ModifiedBy);
                        command.Parameters["_ModifiedBy"].Direction = ParameterDirection.Input;


                        int rows_affected = command.ExecuteNonQuery();

                        if (rows_affected > 0)
                        {
                            command.Transaction.Commit();
                            response.message = "Successfully Updated";
                            response.status = consts.SUCCESS;
                            response.code = consts.CODE_OK;
                            response.error = consts.ERROR_FALSE;
                        }
                        else
                        {
                            command.Transaction.Rollback();
                            response.message = "Error in Updating data";
                            response.status = consts.ERROR;
                            response.code = consts.CODE_ERROR;
                            response.error = consts.ERROR_TRUE;
                        }
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
            }
            return response;
        }

        public ResponseModel deleteEmployeeAddress(int _id)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_ADDRESS_DELETE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        command.Parameters.AddWithValue("_id", _id);
                        command.Parameters["_id"].Direction = ParameterDirection.Input;

                        int rows_affected = command.ExecuteNonQuery();

                        if (rows_affected > 0)
                        {
                            command.Transaction.Commit();
                            response.message = "Successfully Deleted";
                            response.status = consts.SUCCESS;
                            response.code = consts.CODE_OK;
                            response.error = consts.ERROR_FALSE;
                        }
                        else
                        {
                            command.Transaction.Rollback();
                            response.message = "Error in Deleting";
                            response.status = consts.ERROR;
                            response.code = consts.CODE_ERROR;
                            response.error = consts.ERROR_TRUE;
                        }
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
            }
            return response;
        }
        public ResponseModel getAllEmergencyContact()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_EMERGENCY_CONTACT_GET";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<AddressModel> list_adm = new List<AddressModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                AddressModel adm = new AddressModel();

                                adm.ID = Convert.ToInt32(rdr["ID"]);
                                adm.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                adm.StartDate = rdr["StartDate"].ToString();
                                adm.EndDate = rdr["EndDate"].ToString();
                                adm.AddressTypeID = Convert.ToInt32(rdr["AddressTypeID"]);
                                adm.Address1 = rdr["Address1"].ToString();
                                adm.Address2 = rdr["Address2"].ToString();
                                adm.Address3 = rdr["Address3"].ToString();
                                adm.Address4 = rdr["Address4"].ToString();
                                adm.City = rdr["City"].ToString();
                                adm.Province = rdr["Province"].ToString();
                                adm.Region = rdr["Region"].ToString();
                                adm.PostalCode = rdr["PostalCode"].ToString();
                                adm.Country = rdr["Country"].ToString();
                                adm.MobileNumber = rdr["MobileNumber"].ToString();
                                adm.LandlineNumber = rdr["LandlineNumber"].ToString();
                                adm.PrimaryFlag = rdr["PrimaryFlag"].ToString();
                                adm.CreatedDate = rdr["CreatedDate"].ToString();
                                adm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                adm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_adm.Add(adm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_adm;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
            }
            return response;
        }

        public ResponseModel getEmployeeAddressById(int id)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_ADDRESS_GET_BYID";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<AddressModel> list_adm = new List<AddressModel>();

                        command.Parameters.AddWithValue("_id", id);
                        command.Parameters["_id"].Direction = ParameterDirection.Input;

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                AddressModel adm = new AddressModel();

                                adm.ID = Convert.ToInt32(rdr["ID"]);
                                adm.EmpID = Convert.ToInt32(rdr["EmpID"]);
                                adm.StartDate = rdr["StartDate"].ToString();
                                adm.EndDate = rdr["EndDate"].ToString();
                                adm.AddressTypeID = Convert.ToInt32(rdr["AddressTypeID"]);
                                adm.Address1 = rdr["Address1"].ToString();
                                adm.Address2 = rdr["Address2"].ToString();
                                adm.Address3 = rdr["Address3"].ToString();
                                adm.Address4 = rdr["Address4"].ToString();
                                adm.City = rdr["City"].ToString();
                                adm.Province = rdr["Province"].ToString();
                                adm.Region = rdr["Region"].ToString();
                                adm.PostalCode = rdr["PostalCode"].ToString();
                                adm.Country = rdr["Country"].ToString();
                                adm.MobileNumber = rdr["MobileNumber"].ToString();
                                adm.LandlineNumber = rdr["LandlineNumber"].ToString();
                                adm.PrimaryFlag = rdr["PrimaryFlag"].ToString();
                                adm.CreatedDate = rdr["CreatedDate"].ToString();
                                adm.ModifiedDate = rdr["ModifiedDate"].ToString();
                                adm.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_adm.Add(adm);
                            }
                        }

                        response.message = consts.SUCCESS;
                        response.code = consts.CODE_OK;
                        response.data = list_adm;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.error = consts.ERROR_TRUE;
            }
            return response;
        }
    }
}