using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Diagnostics;

namespace Project1
{
    public class clsDatabase
    {
        //***** AcquireConnection()
        private static SqlConnection AcquireConnection()
        {
            SqlConnection cnSQL = null;
            Boolean blnErrorOccurred = false;

            if (ConfigurationManager.ConnectionStrings["ServiceCenter"] != null)
            {
                cnSQL = new SqlConnection();
                cnSQL.ConnectionString = ConfigurationManager.ConnectionStrings["ServiceCenter"].ToString();

                try
                {
                    cnSQL.Open();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return cnSQL;
            }
        }

        //***** GetProductList()
        public static DataSet GetTechnicianList()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                return null;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspGetTechnicianList";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }

        public static DataSet GetClientList()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                return null;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspGetClientList";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }

        public static DataSet GetTechnicianByID(string strTechID)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            if (strTechID.Trim().Length > 0)
            {
                cnSQL = AcquireConnection();
                if (cnSQL == null)
                {
                    blnErrorOccurred = true;
                }
                else
                {
                    cmdSQL = new SqlCommand();
                    cmdSQL.Connection = cnSQL;
                    cmdSQL.CommandType = CommandType.StoredProcedure;
                    cmdSQL.CommandText = "uspGetTechnicianByID";

                    cmdSQL.Parameters.Add(new SqlParameter("@TechnicianID", SqlDbType.NVarChar, 10));
                    cmdSQL.Parameters["@TechnicianID"].Direction = ParameterDirection.Input;
                    cmdSQL.Parameters["@TechnicianID"].Value = strTechID;

                    cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                    cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                    dsSQL = new DataSet();
                    try
                    {
                        daSQL = new SqlDataAdapter(cmdSQL);
                        intRetCode = daSQL.Fill(dsSQL);
                        daSQL.Dispose();
                    }
                    catch (Exception ex)
                    {
                        blnErrorOccurred = true;
                        dsSQL.Dispose();
                    }
                    finally
                    {
                        cmdSQL.Parameters.Clear();
                        cmdSQL.Dispose();
                        cnSQL.Close();
                        cnSQL.Dispose();
                    }
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }

        public static Int32 DeleteTechnician(String strTechID)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            if (strTechID.Trim().Length > 0)
            {
                cnSQL = AcquireConnection();
                if (cnSQL == null)
                {
                    blnErrorOccurred = true;
                }
                else
                {
                    cmdSQL = new SqlCommand();
                    cmdSQL.Connection = cnSQL;
                    cmdSQL.CommandType = CommandType.StoredProcedure;
                    cmdSQL.CommandText = "uspDeleteTechnician";

                    cmdSQL.Parameters.Add(new SqlParameter("@TechnicianID", SqlDbType.NVarChar, 10));
                    cmdSQL.Parameters["@TechnicianID"].Direction = ParameterDirection.Input;
                    cmdSQL.Parameters["@TechnicianID"].Value = strTechID;

                    cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                    cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        intRetCode = cmdSQL.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        blnErrorOccurred = true;
                    }
                    finally
                    {
                        cmdSQL.Parameters.Clear();
                        cmdSQL.Dispose();
                        cnSQL.Close();
                        cnSQL.Dispose();
                    }
                }
            }
            if (blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return 0;
            }

        }

        public static Int32 InsertTechnician(String strFName, String strLName, String strMI, String strEmail,
                                             String strDep, String strPhone, Decimal strHRate)

        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspInsertTechnician";

                cmdSQL.Parameters.Add(new SqlParameter("@LName", SqlDbType.NVarChar, 30));
                cmdSQL.Parameters["@LName"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@LName"].Value = strLName;

                cmdSQL.Parameters.Add(new SqlParameter("@FName", SqlDbType.NChar, 30));
                cmdSQL.Parameters["@FName"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@FName"].Value = strFName;

                cmdSQL.Parameters.Add(new SqlParameter("@MInit", SqlDbType.NVarChar, 1));
                cmdSQL.Parameters["@MInit"].Direction = ParameterDirection.Input;
                if (strMI == null)
                {
                    cmdSQL.Parameters["@MInit"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@MInit"].Value = strMI;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@EMail", SqlDbType.NVarChar, 50));
                cmdSQL.Parameters["@Email"].Direction = ParameterDirection.Input;
                if (strEmail == null)
                {
                    cmdSQL.Parameters["@EMail"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@EMail"].Value = strEmail;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Dept", SqlDbType.NVarChar, 25));
                cmdSQL.Parameters["@Dept"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Dept"].Value = strDep;
                if (strDep == null)
                {
                    cmdSQL.Parameters["@Dept"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Dept"].Value = strDep;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@Phone"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Phone"].Value = strPhone;

                cmdSQL.Parameters.Add(new SqlParameter("@HRate", SqlDbType.Money));
                cmdSQL.Parameters["@HRate"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@HRate"].Value = strHRate;

                cmdSQL.Parameters.Add(new SqlParameter("@NewTechnicianID", SqlDbType.Int));
                cmdSQL.Parameters["@NewTechnicianID"].Direction = ParameterDirection.Output;
                //cmdSQL.Parameters["@HNewTechnicianID"].Value;

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static Int32 UpdateTechnician(String strTechId, String strFName, String strLName, String strMI, String strEmail,
                                             String strDep, String strPhone, Decimal strHRate)
        {

            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspUpdateTechnician";

                cmdSQL.Parameters.Add(new SqlParameter("@TechnicianID", SqlDbType.Int));
                cmdSQL.Parameters["@TechnicianID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TechnicianID"].Value = strTechId;

                cmdSQL.Parameters.Add(new SqlParameter("@LName", SqlDbType.NVarChar, 30));
                cmdSQL.Parameters["@LName"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@LName"].Value = strLName;

                cmdSQL.Parameters.Add(new SqlParameter("@FName", SqlDbType.NChar, 30));
                cmdSQL.Parameters["@FName"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@FName"].Value = strFName;

                cmdSQL.Parameters.Add(new SqlParameter("@MInit", SqlDbType.NVarChar, 1));
                cmdSQL.Parameters["@MInit"].Direction = ParameterDirection.Input;
                if (strMI == null)
                {
                    cmdSQL.Parameters["@MInit"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@MInit"].Value = strMI;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@EMail", SqlDbType.NVarChar, 50));
                cmdSQL.Parameters["@Email"].Direction = ParameterDirection.Input;
                if (strEmail == null)
                {
                    cmdSQL.Parameters["@EMail"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@EMail"].Value = strEmail;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Dept", SqlDbType.NVarChar, 25));
                cmdSQL.Parameters["@Dept"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Dept"].Value = strDep;
                if (strDep == null)
                {
                    cmdSQL.Parameters["@Dept"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Dept"].Value = strDep;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@Phone"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Phone"].Value = strPhone;

                cmdSQL.Parameters.Add(new SqlParameter("@HRate", SqlDbType.Money));
                cmdSQL.Parameters["@HRate"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@HRate"].Value = strHRate;

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static DataSet ProblemsProduct(string sqlCommand)//
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                return null;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = sqlCommand; //

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }

        public static DataSet GetOpenProblems()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                return null;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspGetOpenProblems";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }

        public static DataSet GetProductList()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                return null;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspGetProductList";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }


        public static Int32 InsertResolution(String strTechID, String strResDesc, String strIncNum, String strResNo, String strNoCharge,
                                             String strTicketId, Decimal decHours, String strDateFix, String strDateOnSite,
                                             String strMilage, String strMisc, String strSupplies, String strCostMiles)
        {

            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspInsertResolution";

                cmdSQL.Parameters.Add(new SqlParameter("@TicketID", SqlDbType.Int));
                cmdSQL.Parameters["@TicketID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TicketID"].Value = Convert.ToInt32(strTicketId);

                cmdSQL.Parameters.Add(new SqlParameter("@IncidentNo", SqlDbType.Int));
                cmdSQL.Parameters["@IncidentNo"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@IncidentNo"].Value = Convert.ToInt32(strIncNum);

                cmdSQL.Parameters.Add(new SqlParameter("@ResNo", SqlDbType.Int));
                cmdSQL.Parameters["@ResNo"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ResNo"].Value = Convert.ToInt32(strResNo);

                cmdSQL.Parameters.Add(new SqlParameter("@ResDesc", SqlDbType.NVarChar, 500));
                cmdSQL.Parameters["@ResDesc"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ResDesc"].Value = strResDesc;

                cmdSQL.Parameters.Add(new SqlParameter("@DateFix", SqlDbType.DateTime));
                cmdSQL.Parameters["@DateFix"].Direction = ParameterDirection.Input;
                if (String.IsNullOrWhiteSpace(strDateFix))
                {
                    cmdSQL.Parameters["@DateFix"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@DateFix"].Value = Convert.ToDateTime(strDateFix);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@DateOnSite", SqlDbType.DateTime));
                cmdSQL.Parameters["@DateOnSite"].Direction = ParameterDirection.Input;
                if (strDateOnSite == null)
                {
                    cmdSQL.Parameters["@DateOnSite"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@DateOnSite"].Value = Convert.ToDateTime(strDateOnSite);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@TechID", SqlDbType.Int));
                cmdSQL.Parameters["@TechID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TechID"].Value = Convert.ToInt32(strTechID);

                cmdSQL.Parameters.Add(new SqlParameter("@Hours", SqlDbType.Decimal, 10));
                cmdSQL.Parameters["@Hours"].Precision = 10;
                cmdSQL.Parameters["@Hours"].Scale = 2;
                cmdSQL.Parameters["@Hours"].Direction = ParameterDirection.Input;
                if (decHours == 0)
                {
                    cmdSQL.Parameters["@Hours"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Hours"].Value = Convert.ToDecimal(decHours);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Mileage", SqlDbType.Decimal));
                cmdSQL.Parameters["@Mileage"].Precision = 10;
                cmdSQL.Parameters["@Mileage"].Scale = 1;
                cmdSQL.Parameters["@Mileage"].Direction = ParameterDirection.Input;
                if (String.IsNullOrWhiteSpace(strMilage) )
                {
                    cmdSQL.Parameters["@Mileage"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Mileage"].Value = Convert.ToDecimal(strMilage);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@CostMiles", SqlDbType.Money));
                cmdSQL.Parameters["@CostMiles"].Direction = ParameterDirection.Input;
                if (String.IsNullOrWhiteSpace(strCostMiles))
                {
                    cmdSQL.Parameters["@CostMiles"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@CostMiles"].Value = Convert.ToDecimal(strCostMiles);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Supplies", SqlDbType.Money));
                cmdSQL.Parameters["@Supplies"].Direction = ParameterDirection.Input;
                if (String.IsNullOrWhiteSpace(strSupplies))
                {
                    cmdSQL.Parameters["@Supplies"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Supplies"].Value = Convert.ToDecimal(strSupplies);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Misc", SqlDbType.Money));
                cmdSQL.Parameters["@Misc"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Misc"].Value = strMisc;
                if (String.IsNullOrWhiteSpace(strMisc))
                {
                    cmdSQL.Parameters["@Misc"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Misc"].Value = Convert.ToDecimal(strMisc);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@NoCharge", SqlDbType.Int));
                cmdSQL.Parameters["@NoCharge"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@NoCharge"].Value = Convert.ToInt32(strNoCharge);


                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static Int32 InsertProblem(String strTicketID, String strIncNo, String strProbDesc, String strTechID,
                                            String strProdID)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspInsertProblem";

                cmdSQL.Parameters.Add(new SqlParameter("@TicketID", SqlDbType.Int));
                cmdSQL.Parameters["@TicketID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TicketID"].Value = Convert.ToInt32(strTicketID);

                cmdSQL.Parameters.Add(new SqlParameter("@IncidentNo", SqlDbType.Int));
                cmdSQL.Parameters["@IncidentNo"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@IncidentNo"].Value = Convert.ToInt32(strIncNo);

                cmdSQL.Parameters.Add(new SqlParameter("@ProbDesc", SqlDbType.NVarChar, 1));
                cmdSQL.Parameters["@ProbDesc"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ProbDesc"].Value = strProbDesc;

                cmdSQL.Parameters.Add(new SqlParameter("@TechID", SqlDbType.NVarChar, 50));
                cmdSQL.Parameters["@TechID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TechID"].Value = strTechID;

                cmdSQL.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@ProductID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ProductID"].Value = strProdID;

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public static Int32 InsertServiceEvent(String strClientID, String strContact, String strPhone, String strServiceDate)

        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode = 0;
            Int32 intNewTicket = 0;
            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspInsertServiceEvent";

                cmdSQL.Parameters.Add(new SqlParameter("@ClientID", SqlDbType.Int));
                cmdSQL.Parameters["@ClientID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ClientID"].Value = strClientID;

                cmdSQL.Parameters.Add(new SqlParameter("@Contact", SqlDbType.NVarChar, 30));
                cmdSQL.Parameters["@Contact"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Contact"].Value = strContact;

                cmdSQL.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NChar, 10));
                cmdSQL.Parameters["@Phone"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Phone"].Value = strPhone;

                cmdSQL.Parameters.Add(new SqlParameter("@EventDate", SqlDbType.DateTime));
                cmdSQL.Parameters["@EventDate"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@EventDate"].Value = strServiceDate;

                cmdSQL.Parameters.Add(new SqlParameter("@NewTicketID", SqlDbType.Int));
                cmdSQL.Parameters["@NewTicketID"].Direction = ParameterDirection.Output;

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery();
                    if (cmdSQL.Parameters["@NewTicketID"] != null)
                    {
                        intNewTicket = Convert.ToInt32(cmdSQL.Parameters["@NewTicketID"].Value);
                    }
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

          
                return intNewTicket;
            
        }
    }
}