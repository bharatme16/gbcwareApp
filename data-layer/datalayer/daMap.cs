using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace crossCountryDataAccess
{


    public class daMap
    {


        string csIntServer = ConfigurationManager.ConnectionStrings["IntegrityConnectionString"].ConnectionString;


        #region "Public properties "

        public static bool pTransactionSuccessful;
        public bool TransactionSuccessful()
        {
            return pTransactionSuccessful;
        }

        public static string pErrorMessage;

        public string ErrorMessage()
        {
            return pErrorMessage;
        }

        public static int pErrorNumber;
        public int ErrorNumber()
        {
            return pErrorNumber;
        }

        public static int pErrorClass;
        public int ErrorClass()
        {
            return pErrorClass;
        }

        public static int pErrorState;
        public int ErrorState()
        {
            return pErrorState;
        }

        public static int pErrorLineNumber;
        public int ErrorLineNumber()
        {
            return pErrorLineNumber;
        }

        public static bool pIsFound;
        public bool IsFound()
        {
            return pIsFound;
        }
        public static bool pPolicyFound;
        public bool isPolicyFound()
        {
            return pPolicyFound;
        }

        public static bool IsCompanyNameFound;
        public bool isCompanyFound()
        {
            return IsCompanyNameFound;
        }

        public static bool pIsRoleFound;
        public bool IsRoleFound()
        {
            return pIsRoleFound;
        }

        public static String loggedInUser;
        public String LoggedIn()
        {
            return loggedInUser;
        }

        public static bool pUserFound;
        public bool isUserFound()
        {
            return pUserFound;
        }

        public static bool pisEmailFound;
        public bool isEmailFound()
        {
            return pisEmailFound;
        }
        public static bool pisClaimFound;
        public bool isClaimFound()
        {
            return pisClaimFound;
        }

        #endregion

        #region "Get Methods"

        public DataTable getAssignedClaimByAdjusterEmailId(String EmailId)
        {
            //SqlConnection oc = new SqlConnection(csIntg);

            DataTable dtZip = new DataTable("getAssignedClaimByAdjusterEmailId");
            SqlParameter[] inParams = new SqlParameter[1];

            inParams[0] = new SqlParameter("@email_id", SqlDbType.VarChar);
            inParams[0].Value = EmailId;

            pTransactionSuccessful = true;

            try
            {

                DataSet dsZip = SqlHelper.ExecuteDataset(csIntServer, CommandType.StoredProcedure, "getAssignedClaimByAdjusterEmailId", inParams);
                dtZip = dsZip.Tables[0];

            }
            catch (SqlException ex)
            {
                pErrorMessage = ex.Message.ToString();
                pErrorNumber = ex.Number;
                pErrorClass = ex.Class;
                pErrorState = ex.State;
                pErrorLineNumber = ex.LineNumber;
                pTransactionSuccessful = false;

            }
            return dtZip;

        }


        public DataTable getAssignedClaimbyClaimIdandAdjusterEmailId(String EmailId, String ClaimNumber)
        {
            //SqlConnection oc = new SqlConnection(csIntg);

            DataTable dtZip = new DataTable("getAssignedClaimbyClaimIdandAdjuster'EmailId");
            SqlParameter[] inParams = new SqlParameter[2];

            inParams[0] = new SqlParameter("@email_id", SqlDbType.VarChar);
            inParams[0].Value = EmailId;
            inParams[1] = new SqlParameter("@claim_number", SqlDbType.VarChar);
            inParams[1].Value = ClaimNumber;

            pTransactionSuccessful = true;

            try
            {
                DataSet dsZip = SqlHelper.ExecuteDataset(csIntServer, CommandType.StoredProcedure, "getAssignedClaimbyClaimIdandAdjusterEmailId", inParams);
                dtZip = dsZip.Tables[0];

            }
            catch (SqlException ex)
            {
                pErrorMessage = ex.Message.ToString();
                pErrorNumber = ex.Number;
                pErrorClass = ex.Class;
                pErrorState = ex.State;
                pErrorLineNumber = ex.LineNumber;
                pTransactionSuccessful = false;

            }
            return dtZip;

        }

        #endregion
    }




}