using BackEnd.Global;
using BackEnd.Models;
using BackEnd.Models.Masterfile;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace BackEnd.Services
{
    public class ShiftService
    {
        public ResponseModel response = new ResponseModel();
        public Constants consts = new Constants();
        public LogsService logs = new LogsService();

        public ResponseModel CreateShift(Shift_SetupModel shift_SetupModel)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_SHIFT_SETUP_INSERT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        command.Parameters.AddWithValue("_ShiftCode", shift_SetupModel.ShiftCode);
                        command.Parameters["_ShiftCode"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_ShiftName", shift_SetupModel.ShiftName);
                        command.Parameters["_ShiftName"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_In1", shift_SetupModel.In1);
                        command.Parameters["_In1"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Out1", shift_SetupModel.Out1);
                        command.Parameters["_Out1"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_NumHrs1", shift_SetupModel.NumHrs1);
                        command.Parameters["_NumHrs1"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_In2", shift_SetupModel.In2);
                        command.Parameters["_In2"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Out2", shift_SetupModel.Out2);
                        command.Parameters["_Out2"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_NumHrs2", shift_SetupModel.NumHrs2);
                        command.Parameters["_NumHrs2"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_OTStart", shift_SetupModel.OTStart);
                        command.Parameters["_OTStart"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_MidRequired", shift_SetupModel.MidRequired);
                        command.Parameters["_MidRequired"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_MaxOT", shift_SetupModel.MaxOT);
                        command.Parameters["_MaxOT"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_MaxUndertime", shift_SetupModel.MaxUndertime);
                        command.Parameters["_MaxUndertime"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_RoundedTo", shift_SetupModel.RoundedTo);
                        command.Parameters["_RoundedTo"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_GracePeriodDaily", shift_SetupModel.GracePeriodDaily);
                        command.Parameters["_GracePeriodDaily"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_GracePeriodWeekly", shift_SetupModel.GracePeriodWeekly);
                        command.Parameters["_GracePeriodWeekly"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_GracePeriodSemiMonthly", shift_SetupModel.GracePeriodSemiMonthly);
                        command.Parameters["_GracePeriodSemiMonthly"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_GracePeriodMonthly", shift_SetupModel.GracePeriodMonthly);
                        command.Parameters["_GracePeriodMonthly"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_ModifiedBy", shift_SetupModel.ModifiedBy);
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
                        logs.insertActivityLogs(name: "hris.CN_SHIFT_SETUP_INSERT", action: 1, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "hris.CN_SHIFT_SETUP_INSERT", action: 1, status: response.status, remarks: response.message);

            }
            return response;
        }

        public ResponseModel RetrieveShift()
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_SHIFT_SETUP_GET";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        List<Shift_SetupModel> list_shift_SetupModels = new List<Shift_SetupModel>();

                        MySqlDataReader rdr = command.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (rdr["ID"] != null)
                            {
                                Shift_SetupModel shift_SetupModel = new Shift_SetupModel();

                                shift_SetupModel.ID = Convert.ToInt32(rdr["ID"]);
                                shift_SetupModel.ShiftCode = rdr["ShiftCode"].ToString();
                                shift_SetupModel.ShiftName = rdr["ShiftName"].ToString();
                                shift_SetupModel.In1 = rdr["In1"].ToString();
                                shift_SetupModel.Out1 = rdr["Out1"].ToString();
                                shift_SetupModel.NumHrs1 = Convert.ToInt32(rdr["NumHrs1"]);
                                shift_SetupModel.In2 = rdr["In2"].ToString();
                                shift_SetupModel.Out2 = rdr["Out2"].ToString();
                                shift_SetupModel.NumHrs2 = Convert.ToInt32(rdr["NumHrs2"]);
                                shift_SetupModel.OTStart = rdr["OTStart"].ToString();
                                shift_SetupModel.MidRequired = Convert.ToInt32(rdr["MidRequired"]);
                                shift_SetupModel.MaxOT = Convert.ToInt32(rdr["MaxOT"]);
                                shift_SetupModel.MaxUndertime = Convert.ToInt32(rdr["MaxUndertime"]);
                                shift_SetupModel.RoundedTo = Convert.ToInt32(rdr["RoundedTo"]);
                                shift_SetupModel.GracePeriodDaily = Convert.ToInt32(rdr["GracePeriodDaily"]);
                                shift_SetupModel.GracePeriodWeekly = Convert.ToInt32(rdr["GracePeriodWeekly"]);
                                shift_SetupModel.GracePeriodSemiMonthly = Convert.ToInt32(rdr["GracePeriodSemiMonthly"]);
                                shift_SetupModel.GracePeriodMonthly = Convert.ToInt32(rdr["GracePeriodMonthly"]);
                                shift_SetupModel.ModifiedBy = rdr["ModifiedBy"].ToString();

                                list_shift_SetupModels.Add(shift_SetupModel);
                            }
                        }

                        response.message = consts.SUCCESS_RETRIEVE;
                        response.code = consts.CODE_OK;
                        response.data = list_shift_SetupModels;
                        response.error = consts.ERROR_FALSE;
                        conn.Close();

                        logs.insertActivityLogs(name: "hris.CN_SHIFT_SETUP_GET", action: 4, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "hris.CN_SHIFT_SETUP_GET", action: 1, status: response.status, remarks: response.message);

            }
            return response;
        }

        public ResponseModel UpdateShift(Shift_SetupModel shift_SetupModel)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_SHIFT_SETUP_UPDATE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        command.Parameters.AddWithValue("_ID", shift_SetupModel.ID);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_ShiftCode", shift_SetupModel.ShiftCode);
                        command.Parameters["_ShiftCode"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_ShiftName", shift_SetupModel.ShiftName);
                        command.Parameters["_ShiftName"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_In1", shift_SetupModel.In1);
                        command.Parameters["_In1"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Out1", shift_SetupModel.Out1);
                        command.Parameters["_Out1"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_NumHrs1", shift_SetupModel.NumHrs1);
                        command.Parameters["_NumHrs1"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_In2", shift_SetupModel.In2);
                        command.Parameters["_In2"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_Out2", shift_SetupModel.Out2);
                        command.Parameters["_Out2"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_NumHrs2", shift_SetupModel.NumHrs2);
                        command.Parameters["_NumHrs2"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_OTStart", shift_SetupModel.OTStart);
                        command.Parameters["_OTStart"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_MidRequired", shift_SetupModel.MidRequired);
                        command.Parameters["_MidRequired"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_MaxOT", shift_SetupModel.MaxOT);
                        command.Parameters["_MaxOT"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_MaxUndertime", shift_SetupModel.MaxUndertime);
                        command.Parameters["_MaxUndertime"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_RoundedTo", shift_SetupModel.RoundedTo);
                        command.Parameters["_RoundedTo"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_GracePeriodDaily", shift_SetupModel.GracePeriodDaily);
                        command.Parameters["_GracePeriodDaily"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_GracePeriodWeekly", shift_SetupModel.GracePeriodWeekly);
                        command.Parameters["_GracePeriodWeekly"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_GracePeriodSemiMonthly", shift_SetupModel.GracePeriodSemiMonthly);
                        command.Parameters["_GracePeriodSemiMonthly"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_GracePeriodMonthly", shift_SetupModel.GracePeriodMonthly);
                        command.Parameters["_GracePeriodMonthly"].Direction = ParameterDirection.Input;

                        command.Parameters.AddWithValue("_ModifiedBy", shift_SetupModel.ModifiedBy);
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
                        logs.insertActivityLogs(name: "hris.CN_SHIFT_SETUP_UPDATE", action: 2, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                logs.insertActivityLogs(name: "hris.CN_SHIFT_SETUP_UPDATE", action: 1, status: response.status, remarks: response.message);

            }
            return response;
        }

        public ResponseModel DeleteShift(int _id)
        {
            try
            {
                using (MySqlConnection conn = ConfigurationManager.DatabaseConnection())
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "hris.CN_SHIFT_SETUP_DELETE";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                        command.Parameters.AddWithValue("_ID", _id);
                        command.Parameters["_ID"].Direction = ParameterDirection.Input;

                        int rows_affected = command.ExecuteNonQuery();

                        if (rows_affected > 0)
                        {
                            command.Transaction.Commit();
                            response.message = consts.SUCCESS_DELETE;
                            response.status = consts.SUCCESS;
                            response.code = consts.CODE_OK;
                            response.error = consts.ERROR_FALSE;
                        }
                        else
                        {
                            command.Transaction.Rollback();
                            response.message = consts.ERROR_DELETE;
                            response.status = consts.ERROR;
                            response.code = consts.CODE_ERROR;
                            response.error = consts.ERROR_TRUE;
                        }
                        logs.insertActivityLogs(name: "hris.CN_SHIFT_SETUP_DELETE", action: 3, status: response.status, remarks: response.message);
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.code = consts.CODE_ERROR;
                response.error = consts.ERROR_TRUE;
                response.status = consts.ERROR;
                response.data = null;
                logs.insertActivityLogs(name: "hris.CN_SHIFT_SETUP_DELETE", action: 3, status: response.status, remarks: response.message);
            }
            return response;
        }

    }
}