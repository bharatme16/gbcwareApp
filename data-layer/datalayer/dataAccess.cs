using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Web.Configuration;
using System.Configuration;

namespace CrossCountryDataAccess
{
    public class dataAccess
    {

#region "Public properties "

        string connectionString = ConfigurationManager.ConnectionStrings["IntegrityConnectionString"].ConnectionString;
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
        public static bool pIsClaimClosed;
        public bool isClaimClosed()
        {
            return pIsClaimClosed;
        }
        public static bool pIsClaimCanceled;
        public bool isClaimCanceled()
        {
            return pIsClaimCanceled;
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

        public static bool pisDuplicateRoleFound;
        public bool isDuplicateRoleFound()
        {
            return pisDuplicateRoleFound;
        }

        public static bool pisLossTypeFound;
        public bool isLossTypeFound()
        {
            return pisLossTypeFound;
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
        public static bool pisUserDeleted;
        public bool isUserDeleted()
        {
            return pisUserDeleted;
        }
        public static bool pisCompanyDeleted;
        public bool isCompanyDeleted()
        {
            return pisCompanyDeleted;
        }

        public static bool pisRepDeleted;
        public bool isRepDeleted()
        {
            return pisRepDeleted;
        }

        public static bool pisBillingDeleted;
        public bool isBillingDeleted()
        {
            return pisBillingDeleted;
        }

        #endregion

#region "Insert Methods"

//insert reopen date
public bool insertReopenDate(string claimId)
        {
            //returns false if operation failed

            SqlParameter[] inParams = new SqlParameter[1];

            inParams[0] = new SqlParameter("@claimId", SqlDbType.NVarChar);
            inParams[0].Value = claimId;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "insertReopenDate", inParams);
            }
            catch (SqlException InsertError)
            {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;
                pTransactionSuccessful = false;

            }
            return pTransactionSuccessful;
        }

//insert close date
public bool insertCloseDate(string claimId, string openedDate)
        {
            //returns false if operation failed

            SqlParameter[] inParams = new SqlParameter[2];

            inParams[0] = new SqlParameter("@openedDate", SqlDbType.NVarChar);
            inParams[0].Value = openedDate;
            inParams[1] = new SqlParameter("@claimId", SqlDbType.NVarChar);
            inParams[1].Value = claimId;



            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "insertCloseDate", inParams);

            }
            catch (SqlException InsertError)
            {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;
                pTransactionSuccessful = false;

            }
            return pTransactionSuccessful;
        }

//insert Delete Log
public bool insertDeleteLog(string userName, string claimNumber, DateTime dateDeleted, string deletedFile)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[4];

    inParams[0] = new SqlParameter("@userName", SqlDbType.NVarChar);
    inParams[0].Value = userName;
    inParams[1] = new SqlParameter("@claimNumber", SqlDbType.NVarChar);
    inParams[1].Value = claimNumber;
    inParams[2] = new SqlParameter("@dateDeleted", SqlDbType.DateTime);
    inParams[2].Value = dateDeleted;
    inParams[3] = new SqlParameter("@deletedFile", SqlDbType.NVarChar);
    inParams[3].Value = deletedFile;



    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "insertDeleteLog", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//insert new claim contact
public bool insertClaimContact(string repEmail, string repFirstName, string repLastName, string companyName)
        {
            //returns false if operation failed

            SqlParameter[] inParams = new SqlParameter[4];

            inParams[0] = new SqlParameter("@rep_email", SqlDbType.NVarChar);
            inParams[0].Value = repEmail;
            inParams[1] = new SqlParameter("@rep_firstName", SqlDbType.NVarChar);
            inParams[1].Value = repFirstName;
            inParams[2] = new SqlParameter("@rep_lastName", SqlDbType.NVarChar);
            inParams[2].Value = repLastName;
            inParams[3] = new SqlParameter("@company_name", SqlDbType.NVarChar);
            inParams[3].Value = companyName;


            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "addNewRep", inParams);

            }
            catch (SqlException InsertError)
            {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;
                pTransactionSuccessful = false;

            }
            return pTransactionSuccessful;
        }

//Insert new filepath
public bool insertFilepath(string claimNumber, string filetype, string filepath, string description, string fileName,string documentType)
        {
            //returns false if operation failed

            SqlParameter[] inParams = new SqlParameter[6];

            inParams[0] = new SqlParameter("@claim_number", SqlDbType.NVarChar);
            inParams[0].Value = claimNumber;
            inParams[1] = new SqlParameter("@filetype", SqlDbType.NVarChar);
            inParams[1].Value = filetype;
            inParams[2] = new SqlParameter("@filepath", SqlDbType.NVarChar);
            inParams[2].Value = filepath;
            inParams[3] = new SqlParameter("@description", SqlDbType.NVarChar);
            inParams[3].Value = description;
            inParams[4] = new SqlParameter("@file_name", SqlDbType.NVarChar);
            inParams[4].Value = fileName;
            inParams[5] = new SqlParameter("@documentType", SqlDbType.NVarChar);
            inParams[5].Value = documentType;
            //inParams[6] = new SqlParameter("@fileSize", SqlDbType.NVarChar);
            //inParams[6].Value = filesize;
            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "addNewFilepath", inParams);

            }
            catch (SqlException InsertError)
            {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;
                pTransactionSuccessful = false;

            }
            return pTransactionSuccessful;
        }
//insert file type
public bool insertFileType(string fileType)
        {
            //returns false if operation failed

            SqlParameter[] inParams = new SqlParameter[1];

            inParams[0] = new SqlParameter("@file_type", SqlDbType.NVarChar);
            inParams[0].Value = fileType;
          

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "addNewFileType", inParams);

            }
            catch (SqlException InsertError)
            {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;
                pTransactionSuccessful = false;

            }
            return pTransactionSuccessful;
        }
//insert company and invoice relationship
public bool insertCompanyInvoiceRelationship(string companyName, string invoiceType)
        {
            //returns false if operation failed

            SqlParameter[] inParams = new SqlParameter[2];

            inParams[0] = new SqlParameter("@company_name", SqlDbType.NVarChar);
            inParams[0].Value = companyName;
            inParams[1] = new SqlParameter("@invoice_type_name", SqlDbType.NVarChar);
            inParams[1].Value = invoiceType;
            

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "insertCompanyInvoiceRelationship", inParams);

            }
            catch (SqlException InsertError)
            {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;
                pTransactionSuccessful = false;

            }
            return pTransactionSuccessful;
        }

//Insert Invoice Details
public bool insertInvoiceDetails(string invoiceNumber, string filePath, bool inovicePaid, string createDate, string claimNumber)
{
    //returns false if operation failed
 
    SqlParameter[] inParams = new SqlParameter[5];

    inParams[0] = new SqlParameter("@invoice_number", SqlDbType.NVarChar);
    inParams[0].Value = invoiceNumber;
    inParams[1] = new SqlParameter("@invoice_filepath", SqlDbType.NVarChar);
    inParams[1].Value = filePath;
    inParams[2] = new SqlParameter("@invoice_paid", SqlDbType.Bit);
    inParams[2].Value = inovicePaid;
    inParams[3] = new SqlParameter("@create_date", SqlDbType.NVarChar);
    inParams[3].Value = createDate;
    inParams[4] = new SqlParameter("@claim_number", SqlDbType.NVarChar);
    inParams[4].Value = claimNumber;

    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "insertInvoiceDetails", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//Insert Invoice Expense list
public bool insertInvoiceExpenseList(string invoiceNumber, string expense_type, double expense_amount)
        {
            //returns false if operation failed

            SqlParameter[] inParams = new SqlParameter[3];

            inParams[0] = new SqlParameter("@invoice_number", SqlDbType.NVarChar);
            inParams[0].Value = invoiceNumber;
            inParams[1] = new SqlParameter("@expense_type", SqlDbType.NVarChar);
            inParams[1].Value = expense_type;
            inParams[2] = new SqlParameter("@expense_amount", SqlDbType.Float);
            inParams[2].Value = expense_amount;

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "insertInvoiceExpenseList", inParams);

            }
            catch (SqlException InsertError)
            {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;
                pTransactionSuccessful = false;

            }
            return pTransactionSuccessful;
        }

//Insert Invoice Type
 public bool insertInvoiceType(string claim_description, string price)
        {
            //returns false if operation failed

            SqlParameter[] inParams = new SqlParameter[2];

            inParams[0] = new SqlParameter("@claim_description", SqlDbType.NVarChar);
            inParams[0].Value = claim_description;
            inParams[1] = new SqlParameter("@_price", SqlDbType.NVarChar);
            inParams[1].Value = price;
            

            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "insertInvoiceType", inParams);

            }
            catch (SqlException InsertError)
            {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;
                pTransactionSuccessful = false;

            }
            return pTransactionSuccessful;
        }

//insert new claim  
 public bool insertNewClaim(string claimNumber, string insuredFirstName, string insuredLastName, string insuredStreet, string insuredCity, string insuredState, string insuredZip, string insurCarrier, string repFirstName, string repLastName, string repemail, string policyNumber, string policyType, DateTime dateLoss, string typeOfLoss, DateTime dateReceived, string insur_altPhone, string insur_primaryPhone, string latitude, string longitude)
 {
     //returns false if operation failed
     SqlParameter[] inParams = new SqlParameter[20];

     inParams[0] = new SqlParameter("@claim_number", SqlDbType.NVarChar);
     inParams[0].Value = claimNumber;
     inParams[1] = new SqlParameter("@insured_firstName", SqlDbType.NVarChar);
     inParams[1].Value = insuredFirstName;
     inParams[2] = new SqlParameter("@insured_lastName", SqlDbType.NVarChar);
     inParams[2].Value = insuredLastName;
     inParams[3] = new SqlParameter("@insured_street", SqlDbType.NVarChar);
     inParams[3].Value = insuredStreet;
     inParams[4] = new SqlParameter("@insured_city", SqlDbType.NVarChar);
     inParams[4].Value = insuredCity;
     inParams[5] = new SqlParameter("@insured_state", SqlDbType.NVarChar);
     inParams[5].Value = insuredState;
     inParams[6] = new SqlParameter("@insured_zip", SqlDbType.NVarChar);
     inParams[6].Value = insuredZip;
     inParams[7] = new SqlParameter("@insur_carrier", SqlDbType.NVarChar);
     inParams[7].Value = insurCarrier;
     inParams[8] = new SqlParameter("@rep_firstName", SqlDbType.NVarChar);
     inParams[8].Value = repFirstName;
     inParams[9] = new SqlParameter("@rep_lastName", SqlDbType.NVarChar);
     inParams[9].Value = repLastName;
     inParams[10] = new SqlParameter("@rep_email", SqlDbType.NVarChar);
     inParams[10].Value = repemail;
     inParams[11] = new SqlParameter("@policy_number", SqlDbType.NVarChar);
     inParams[11].Value = policyNumber;
     inParams[12] = new SqlParameter("@policy_type", SqlDbType.NVarChar);
     inParams[12].Value = policyType;
     inParams[13] = new SqlParameter("@date_loss", SqlDbType.Date);
     inParams[13].Value = dateLoss;
     inParams[14] = new SqlParameter("@type_of_loss", SqlDbType.NVarChar);
     inParams[14].Value = typeOfLoss;
     inParams[15] = new SqlParameter("@date_received", SqlDbType.Date);
     inParams[15].Value = dateReceived;
     inParams[16] = new SqlParameter("@insur_altPhone", SqlDbType.NVarChar);
     inParams[16].Value = insur_altPhone;
     inParams[17] = new SqlParameter("@insur_primaryPhone", SqlDbType.NVarChar);
     inParams[17].Value = insur_primaryPhone;
     inParams[18] = new SqlParameter("@latitude", SqlDbType.NVarChar);
     inParams[18].Value = latitude;
     inParams[19] = new SqlParameter("@longitude", SqlDbType.NVarChar);
     inParams[19].Value = longitude;


     pTransactionSuccessful = true;

     try
     {
         SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "insertNewClaim", inParams);

     }
     catch (SqlException InsertError)
     {

         pErrorMessage = InsertError.Message.ToString();
         pErrorNumber = InsertError.Number;
         pErrorClass = InsertError.Class;
         pErrorState = InsertError.State;
         pErrorLineNumber = InsertError.LineNumber;
         pTransactionSuccessful = false;

     }
     return pTransactionSuccessful;
 }
//insert user role
public bool insertRole(string title, string description)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@title", SqlDbType.NVarChar);
    inParams[0].Value = title;
    inParams[1] = new SqlParameter("@description", SqlDbType.NVarChar);
    inParams[1].Value = description;

    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "insertRole", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//insert Role Child Menu list
public bool insertRoleChildMenuList(string roletitle, int MenuId)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@roleTitle", SqlDbType.NVarChar);
    inParams[0].Value = roletitle;
    inParams[1] = new SqlParameter("@childMenuId", SqlDbType.Int);
    inParams[1].Value = MenuId;

    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "insertRolechildMenuList", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//insert Role Main Menu list
public bool insertRoleMainMenuList(string roletitle, int MenuId)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@roleTitle", SqlDbType.NVarChar);
    inParams[0].Value = roletitle;
    inParams[1] = new SqlParameter("@mainMenuId", SqlDbType.Int);
    inParams[1].Value = MenuId;

    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "insertRoleMainMenuList", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}


//Insert new user
public bool insertUsers(string firstName, string lastName, string Street, string City, string State, string zipCode, string Telephone, string altPhone, string Email, string Password, string Title, string symbilityId)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[12];

    inParams[0] = new SqlParameter("@f_name", SqlDbType.NVarChar);
    inParams[0].Value = firstName;
    inParams[1] = new SqlParameter("@l_name", SqlDbType.NVarChar);
    inParams[1].Value = lastName;
    inParams[2] = new SqlParameter("@_street", SqlDbType.NVarChar);
    inParams[2].Value = Street;
    inParams[3] = new SqlParameter("@_city", SqlDbType.NVarChar);
    inParams[3].Value = City;
    inParams[4] = new SqlParameter("@_state", SqlDbType.NVarChar);
    inParams[4].Value = State;
    inParams[5] = new SqlParameter("@z_code", SqlDbType.NVarChar);
    inParams[5].Value = zipCode;
    inParams[6] = new SqlParameter("@t_phone", SqlDbType.NVarChar);
    inParams[6].Value = Telephone;
    inParams[7] = new SqlParameter("@alt_phone", SqlDbType.NVarChar);
    inParams[7].Value = altPhone;
    inParams[8] = new SqlParameter("@e_mail", SqlDbType.NVarChar);
    inParams[8].Value = Email;
    inParams[9] = new SqlParameter("@p_word", SqlDbType.NVarChar);
    inParams[9].Value = Password;
    inParams[10] = new SqlParameter("@_title", SqlDbType.NVarChar);
    inParams[10].Value = Title;
    inParams[11] = new SqlParameter("@symbilityId", SqlDbType.NVarChar);
    inParams[11].Value = symbilityId;

    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "insertUsers", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//Insert new Company
public bool addNewCompany(string companyName, string companyAddress, string city, string state, string zip, string telephone, string primaryEmail)
{
    // Set up parameters in parameter array 
    SqlParameter[] arParms = new SqlParameter[7];


    arParms[0] = new SqlParameter("@company_name", SqlDbType.NVarChar);
    arParms[0].Value = companyName;
    arParms[1] = new SqlParameter("@company_address", SqlDbType.NVarChar);
    arParms[1].Value = companyAddress;
    arParms[2] = new SqlParameter("@company_city", SqlDbType.NVarChar);
    arParms[2].Value = city;
    arParms[3] = new SqlParameter("@company_state", SqlDbType.NVarChar);
    arParms[3].Value = state;
    arParms[4] = new SqlParameter("@company_zip ", SqlDbType.NVarChar);
    arParms[4].Value = zip;
    arParms[5] = new SqlParameter("@company_phone", SqlDbType.NVarChar);
    arParms[5].Value = telephone;
    arParms[6] = new SqlParameter("@company_email", SqlDbType.NVarChar);
    arParms[6].Value = primaryEmail;


    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "addNewCompany", arParms);
    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;

        pTransactionSuccessful = false;
    }
    return pTransactionSuccessful;
}

//Insert Claim Notes
public bool insertClaimNotes(string claim_number, string notes, string user_name, bool isVisibleByClaimRep)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[4];

    inParams[0] = new SqlParameter("@claim_number", SqlDbType.NVarChar);
    inParams[0].Value = claim_number;
    inParams[1] = new SqlParameter("@notes", SqlDbType.NVarChar);
    inParams[1].Value = notes;
    inParams[2] = new SqlParameter("@user_name", SqlDbType.NVarChar);
    inParams[2].Value = user_name;
    inParams[3] = new SqlParameter("@isVisibleByClaimRep", SqlDbType.Bit);
    inParams[3].Value = isVisibleByClaimRep;

    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "insertClaimNotes", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}
#endregion

#region "Get Method"
//search claims by criteria
public DataTable searchAllClaimsByCriteria(string policyNumber, string claimNumber, string insuredName)
{
    DataTable dtClaims = new DataTable("closedClaims");
    pTransactionSuccessful = true;
    SqlParameter[] inParams = new SqlParameter[3];

    inParams[0] = new SqlParameter("@policyNumber", SqlDbType.NVarChar);
    inParams[0].Value = policyNumber;
    inParams[1] = new SqlParameter("@claimNumber", SqlDbType.NVarChar);
    inParams[1].Value = claimNumber;
    inParams[2] = new SqlParameter("@insuredName", SqlDbType.NVarChar);
    inParams[2].Value = insuredName;
   

    try
    {
        DataSet dsClaims = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "searchAllClaimsByCriteria", inParams);
        dtClaims = dsClaims.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtClaims;
}



//get Claims For Report
public DataTable getOpenClaimsForReport(string carrier, int adjuster, string contact, string dateFrom, string dateTo, string state)
{
    DataTable dtClaimNumber = new DataTable("closedClaims");
    pTransactionSuccessful = true;
    SqlParameter[] inParams = new SqlParameter[7];

    inParams[0] = new SqlParameter("@dateFrom", SqlDbType.NVarChar);
    inParams[0].Value = dateFrom;
    inParams[1] = new SqlParameter("@dateTo", SqlDbType.NVarChar);
    inParams[1].Value = dateTo;
    inParams[2] = new SqlParameter("@carrier", SqlDbType.NVarChar);
    inParams[2].Value = carrier;
    inParams[3] = new SqlParameter("@adjuster", SqlDbType.Int);
    inParams[3].Value = adjuster;
    inParams[4] = new SqlParameter("@claimContact", SqlDbType.NVarChar);
    inParams[4].Value = contact;
    inParams[5] = new SqlParameter("@state", SqlDbType.NVarChar);
    inParams[5].Value = state;

    try
    {
        DataSet dsClaimNumber = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getOpenClaimsForReport", inParams);
        dtClaimNumber = dsClaimNumber.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtClaimNumber;
}

 //get admin users
public DataTable getAdminUsers()
{
    DataTable dtAdminUsers = new DataTable("adminUsers");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsAdminUsers = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAdminUsers");
        dtAdminUsers = dsAdminUsers.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtAdminUsers;
}


//get All Notification
public DataTable getAllFilePaths()
{
    DataTable dtAuthenticationInfo = new DataTable("filePath");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsAuthenticationInfo = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getALLFilepaths");
        dtAuthenticationInfo = dsAuthenticationInfo.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtAuthenticationInfo;
}


//get All Notification
public DataTable getAllNotification()
{
    DataTable dtAuthenticationInfo = new DataTable("AuthenticationInfo");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsAuthenticationInfo = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllNotification");
        dtAuthenticationInfo = dsAuthenticationInfo.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtAuthenticationInfo;
}

//get symbility company Id code
public DataTable getSymbilityCompanyId(string userEmail)
{
    DataTable dtSymbilityId = new DataTable("SymbilityId");
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@userEmail", SqlDbType.NVarChar);
    inParams[0].Value = userEmail;

    pTransactionSuccessful = true;

    try
    {
        DataSet dsSymbilityId = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getSymbilityCompanyId", inParams);
        dtSymbilityId = dsSymbilityId.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtSymbilityId;
}

//get Symbility Authentication Info
public DataTable getSymbilityAuthenticationInfo()
{
    DataTable dtAuthenticationInfo = new DataTable("AuthenticationInfo");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsAuthenticationInfo = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getSymbilityInfo");
        dtAuthenticationInfo = dsAuthenticationInfo.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtAuthenticationInfo;
}


//get reopened dates
public DataTable getReopenedDateByClaimId(int ClaimId)
{
    DataTable dtAllClaims = new DataTable("AllClaims");
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@claimId", SqlDbType.Int);
    inParams[0].Value = ClaimId;

    pTransactionSuccessful = true;

    try
    {
        DataSet dsAllClaims = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getReopenedDate", inParams);
        dtAllClaims = dsAllClaims.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtAllClaims;
}

//get all Adjsuster claims
public DataTable getAllClaimsByAdjusterEmail(string email)
{
    DataTable dtAllClaims = new DataTable("AllClaims");
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@email_id", SqlDbType.NVarChar);
    inParams[0].Value = email;
    
    pTransactionSuccessful = true;

    try
    {
        DataSet dsAllClaims = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllClaimsByAdjusterEmail", inParams);
        dtAllClaims = dsAllClaims.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtAllClaims;
}

//get update message
public DataTable getUpdateMessage()
{
    DataTable dtInvoices = new DataTable("invoices");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsCity = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getUpdateMessage");
        dtInvoices = dsCity.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtInvoices;
}

//get all overdue invoices list
public DataTable getOverdueInvoiceList()
{
    DataTable dtInvoices = new DataTable("invoices");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsCity = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getOverdueInvoicesList");
        dtInvoices = dsCity.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtInvoices;
}
//get all overdue invoices
public DataTable getOverdueInvoiceQuantity()
{
    DataTable dtInvoices = new DataTable("invoices");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsCity = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getOverdueInvoicesQuantity");
        dtInvoices = dsCity.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtInvoices;
}
//get count of all claims by date
public DataTable getAllClaimListForReportCount(string carrier, int adjuster, string contact, string dateFrom, string dateTo, string state)
{
    DataTable dtClaimNumber = new DataTable("allClaims");
    pTransactionSuccessful = true;
    SqlParameter[] inParams = new SqlParameter[6];

    inParams[0] = new SqlParameter("@dateFrom", SqlDbType.NVarChar);
    inParams[0].Value = dateFrom;
    inParams[1] = new SqlParameter("@dateTo", SqlDbType.NVarChar);
    inParams[1].Value = dateTo;
    inParams[2] = new SqlParameter("@carrier", SqlDbType.NVarChar);
    inParams[2].Value = carrier;
    inParams[3] = new SqlParameter("@adjuster", SqlDbType.Int);
    inParams[3].Value = adjuster;
    inParams[4] = new SqlParameter("@claimContact", SqlDbType.NVarChar);
    inParams[4].Value = contact;
    inParams[5] = new SqlParameter("@state", SqlDbType.NVarChar);
    inParams[5].Value = state;

    try
    {
        DataSet dsClaimNumber = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllClaimsListForReportCount", inParams);
        dtClaimNumber = dsClaimNumber.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtClaimNumber;
}
//get all claims by date
public DataTable getAllClaimListForReport(string carrier, int adjuster, string contact, string dateFrom, string dateTo, string state)
{
    DataTable dtClaimNumber = new DataTable("allClaims");
    pTransactionSuccessful = true;
    SqlParameter[] inParams = new SqlParameter[6];

    inParams[0] = new SqlParameter("@dateFrom", SqlDbType.NVarChar);
    inParams[0].Value = dateFrom;
    inParams[1] = new SqlParameter("@dateTo", SqlDbType.NVarChar);
    inParams[1].Value = dateTo;
    inParams[2] = new SqlParameter("@carrier", SqlDbType.NVarChar);
    inParams[2].Value = carrier;
    inParams[3] = new SqlParameter("@adjuster", SqlDbType.Int);
    inParams[3].Value = adjuster;
    inParams[4] = new SqlParameter("@claimContact", SqlDbType.NVarChar);
    inParams[4].Value = contact;
    inParams[5] = new SqlParameter("@state", SqlDbType.NVarChar);
    inParams[5].Value = state;
    try
    {
        DataSet dsClaimNumber = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllClaimsListForReport", inParams);
        dtClaimNumber = dsClaimNumber.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtClaimNumber;
}
//get open claims by date
public DataTable getAllOpenClaimListForReport(string carrier, int adjuster, string contact, string dateFrom, string dateTo, string state)
{
    DataTable dtClaimNumber = new DataTable("closedClaims");
    pTransactionSuccessful = true;
    SqlParameter[] inParams = new SqlParameter[6];

    inParams[0] = new SqlParameter("@dateFrom", SqlDbType.NVarChar);
    inParams[0].Value = dateFrom;
    inParams[1] = new SqlParameter("@dateTo", SqlDbType.NVarChar);
    inParams[1].Value = dateTo;
    inParams[2] = new SqlParameter("@carrier", SqlDbType.NVarChar);
    inParams[2].Value = carrier;
    inParams[3] = new SqlParameter("@adjuster", SqlDbType.Int);
    inParams[3].Value = adjuster;
    inParams[4] = new SqlParameter("@claimContact", SqlDbType.NVarChar);
    inParams[4].Value = contact;
    inParams[5] = new SqlParameter("@state", SqlDbType.NVarChar);
    inParams[5].Value = state;
    try
    {
        DataSet dsClaimNumber = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllOpenClaimsListForReport", inParams);
        dtClaimNumber = dsClaimNumber.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtClaimNumber;
}
//get count of open claims by date
public DataTable getAllOpenClaimListForReportCount(string carrier, int adjuster, string contact, string dateFrom, string dateTo, string state)
{
    DataTable dtClaimNumber = new DataTable("closedClaims");
    pTransactionSuccessful = true;
    SqlParameter[] inParams = new SqlParameter[6];

    inParams[0] = new SqlParameter("@dateFrom", SqlDbType.NVarChar);
    inParams[0].Value = dateFrom;
    inParams[1] = new SqlParameter("@dateTo", SqlDbType.NVarChar);
    inParams[1].Value = dateTo;
    inParams[2] = new SqlParameter("@carrier", SqlDbType.NVarChar);
    inParams[2].Value = carrier;
    inParams[3] = new SqlParameter("@adjuster", SqlDbType.Int);
    inParams[3].Value = adjuster;
    inParams[4] = new SqlParameter("@claimContact", SqlDbType.NVarChar);
    inParams[4].Value = contact;
    inParams[5] = new SqlParameter("@state", SqlDbType.NVarChar);
    inParams[5].Value = state;
    try
    {
        DataSet dsClaimNumber = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllOpenClaimsListForReportCount", inParams);
        dtClaimNumber = dsClaimNumber.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtClaimNumber;
}
//get count of closed claims by date
public DataTable getClosedClaimListForReportCount(string carrier, int adjuster, string contact, string dateFrom, string dateTo,string state)
{
    DataTable dtClaimNumber = new DataTable("closedClaims");
    pTransactionSuccessful = true;
    SqlParameter[] inParams = new SqlParameter[6];

    inParams[0] = new SqlParameter("@dateFrom", SqlDbType.NVarChar);
    inParams[0].Value = dateFrom;
    inParams[1] = new SqlParameter("@dateTo", SqlDbType.NVarChar);
    inParams[1].Value = dateTo;
    inParams[2] = new SqlParameter("@carrier", SqlDbType.NVarChar);
    inParams[2].Value = carrier;
    inParams[3] = new SqlParameter("@adjuster", SqlDbType.Int);
    inParams[3].Value = adjuster;
    inParams[4] = new SqlParameter("@claimContact", SqlDbType.NVarChar);
    inParams[4].Value = contact;
    inParams[5] = new SqlParameter("@state", SqlDbType.NVarChar);
    inParams[5].Value = state;
    try
    {
        DataSet dsClaimNumber = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllClosedClaimsListForReportCount", inParams);
        dtClaimNumber = dsClaimNumber.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtClaimNumber;
}
//get closed claims by date
public DataTable getClosedClaimListForReport(string carrier, int adjuster, string contact, string dateFrom, string dateTo, string state, int userId)
{
    DataTable dtClaimNumber = new DataTable("closedClaims");
    pTransactionSuccessful = true;
    SqlParameter[] inParams = new SqlParameter[7];

    inParams[0] = new SqlParameter("@dateFrom", SqlDbType.NVarChar);
    inParams[0].Value = dateFrom;
    inParams[1] = new SqlParameter("@dateTo", SqlDbType.NVarChar);
    inParams[1].Value = dateTo;
    inParams[2] = new SqlParameter("@carrier", SqlDbType.NVarChar);
    inParams[2].Value = carrier;
    inParams[3] = new SqlParameter("@adjuster", SqlDbType.Int);
    inParams[3].Value = adjuster;
    inParams[4] = new SqlParameter("@claimContact", SqlDbType.NVarChar);
    inParams[4].Value = contact;
    inParams[5] = new SqlParameter("@state", SqlDbType.NVarChar);
    inParams[5].Value = state;
    inParams[6] = new SqlParameter("@closingUserId", SqlDbType.Int);
    inParams[6].Value = userId;
    try
    {
        DataSet dsClaimNumber = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllClosedClaimsListForReport", inParams);
        dtClaimNumber = dsClaimNumber.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtClaimNumber;
}

//get all insured cities
public DataTable getAllInsuredCity()
{
    DataTable dtCity = new DataTable("City");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsCity = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllInsuredCity");
        dtCity = dsCity.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtCity;
}

public DataTable getUnassignedClaimCountbyState(string state)
{
    DataTable dtUnassignedClaimCount = new DataTable("getCountedUnassignedClaimByState");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@insstate", SqlDbType.VarChar);
    inParams[0].Value = state;
    pTransactionSuccessful = true;

    try
    {
        DataSet dsUnassignedClaimCount = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getCountedUnassignedClaimByState", inParams);
        dtUnassignedClaimCount = dsUnassignedClaimCount.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtUnassignedClaimCount;
}


//get all the unassigned claims
public DataTable getUnAssignedClaimByStateAndCity(string state, string city)
{
    DataTable dtUnassignedClaims = new DataTable("unassignedClaims");

    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@insstate", SqlDbType.VarChar);
    inParams[0].Value = state;
    inParams[1] = new SqlParameter("@city", SqlDbType.VarChar);
    inParams[1].Value = city;

    pTransactionSuccessful = true;
    try
    {
        DataSet dsUnassignedClaims = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getUnassignedClaimByStateAndCity", inParams);
        dtUnassignedClaims = dsUnassignedClaims.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = true;
    }
    return dtUnassignedClaims;
}

//get all the unassigned claims
public DataTable getAllOpenClaimsByState(String state)
{
    DataTable dtUnassignedClaims = new DataTable("openClaims");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@state", SqlDbType.NVarChar);
    inParams[0].Value = state;

    pTransactionSuccessful = true;
    try
    {
        DataSet dsUnassignedClaims = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllOpenClaimsListByState", inParams);
        dtUnassignedClaims = dsUnassignedClaims.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = true;
    }
    return dtUnassignedClaims;
}



//get all the unassigned claims
public DataTable getUnAssignedClaimByState(String state)
{
    DataTable dtUnassignedClaims = new DataTable("unassignedClaims");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@insstate", SqlDbType.VarChar);
    inParams[0].Value = state;

    pTransactionSuccessful = true;
    try
    {
        DataSet dsUnassignedClaims = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getUnassignedClaimByState", inParams);
        dtUnassignedClaims = dsUnassignedClaims.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = true;
    }
    return dtUnassignedClaims;
}


//get child Menu by main menu Id
public DataTable getChildMenuByMainMenuIdRole(int mainMenuId, string roleTitle)
{
    DataTable dtInvoiceNumber = new DataTable("childMenu");
    pTransactionSuccessful = true;
    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@mainMenuId", SqlDbType.Int);
    inParams[0].Value = mainMenuId;
    inParams[1] = new SqlParameter("@roleTitle", SqlDbType.NVarChar);
    inParams[1].Value = roleTitle;

    try
    {
        DataSet dsInvoiceNumber = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getChildMenuByMainMenuIdRole", inParams);
        dtInvoiceNumber = dsInvoiceNumber.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtInvoiceNumber;
}

//get Next Invoice Number
public DataTable getMainMenuListByRole(string roleTitle)
{
    DataTable dtInvoiceNumber = new DataTable("menu");
    pTransactionSuccessful = true;
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@roleTitle", SqlDbType.NVarChar);
    inParams[0].Value = roleTitle;

    try
    {
        DataSet dsInvoiceNumber = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getMainMenuListByRole", inParams);
        dtInvoiceNumber = dsInvoiceNumber.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtInvoiceNumber;
}

//get All Main Menu List
public DataTable getAllChildMenuList()
{
    DataTable dtMainMenuList = new DataTable("ChildMenuList");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsMainMenuList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllChildMenuList");
        dtMainMenuList = dsMainMenuList.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtMainMenuList;
}

//get All Main Menu List
public DataTable getAllMainMenuList()
{
    DataTable dtMainMenuList = new DataTable("MainMenuList");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsMainMenuList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllMainMenuList");
        dtMainMenuList = dsMainMenuList.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtMainMenuList;
}

//get claims with final reports
public DataTable getClaimsToReview()
{
    DataTable dtClaimsToReview = new DataTable("claimsToReview");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsClaimsToReview = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getReportstoReviewList");
        dtClaimsToReview = dsClaimsToReview.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtClaimsToReview;
}

//get Next Invoice Number
public DataTable getNextInvoiceNumber(string claimNumber)
{
    DataTable dtInvoiceNumber = new DataTable("invoiceNumber");
    pTransactionSuccessful = true;
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@claimNumber", SqlDbType.NVarChar);
    inParams[0].Value = claimNumber;

    try
    {
        DataSet dsInvoiceNumber = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getInvoiceNumber", inParams);
        dtInvoiceNumber = dsInvoiceNumber.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtInvoiceNumber;
}

//get company Detail by company name
public DataTable getCompanyDetailByCompanyName(string companyName)
{
    DataTable dtCompanyEmail = new DataTable("companyEmail");
    pTransactionSuccessful = true;
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@companyName", SqlDbType.NVarChar);
    inParams[0].Value = companyName;

    try
    {
        DataSet dsCompanyEmail = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getCompanyDetailByCompanyName", inParams);
        dtCompanyEmail = dsCompanyEmail.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtCompanyEmail;
}

 //get company email by company name
public DataTable getCompanyEmailByCompanyName(string companyName)
{
    DataTable dtCompanyEmail = new DataTable("companyEmail");
    pTransactionSuccessful = true;
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@company_name", SqlDbType.NVarChar);
    inParams[0].Value = companyName;

    try
    {
        DataSet dsCompanyEmail = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getCompanyEmailByCompanyName", inParams);
        dtCompanyEmail = dsCompanyEmail.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtCompanyEmail;
}

//Get Invoice type list
public DataTable getInvoiceTypeForClaim(string carrier, string invoiceType)
{
    DataTable dtInvoiceType = new DataTable("invoiceType");
    pTransactionSuccessful = true;
    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@carrier", SqlDbType.NVarChar);
    inParams[0].Value = carrier;
    inParams[1] = new SqlParameter("@InvoiceType", SqlDbType.NVarChar);
    inParams[1].Value = invoiceType;
    try
    {
        DataSet dsInvoiceType = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getInvoiceAssignedToClaim", inParams);
        dtInvoiceType = dsInvoiceType.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtInvoiceType;
}
//search generated invoices by company 
public DataTable searchGeneratedInvocies(string search)
{
    DataTable dtGeneratedInvoices = new DataTable("generatedInvoices");
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@searchString", SqlDbType.NVarChar);
    inParams[0].Value = search;
     
    pTransactionSuccessful = true;

    try
    {
        DataSet dsGeneratedInvoices = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "searchGeneratedInvoices", inParams);
        dtGeneratedInvoices = dsGeneratedInvoices.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtGeneratedInvoices;
}
//search generated invoices by company and contact
public DataTable searchGeneratedInvociesByCompanyAndContact(string search, string company, string contactEmail)
{
    DataTable dtGeneratedInvoices = new DataTable("generatedInvoices");
    SqlParameter[] inParams = new SqlParameter[3];

    inParams[0] = new SqlParameter("@searchString", SqlDbType.NVarChar);
    inParams[0].Value = search;
    inParams[1] = new SqlParameter("@carrier", SqlDbType.NVarChar);
    inParams[1].Value = company;
    inParams[2] = new SqlParameter("@contactEmail", SqlDbType.NVarChar);
    inParams[2].Value = contactEmail;
    pTransactionSuccessful = true;

    try
    {
        DataSet dsGeneratedInvoices = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "searchGeneratedInvoicesByCompanyAndContact", inParams);
        dtGeneratedInvoices = dsGeneratedInvoices.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtGeneratedInvoices;
}
//get rep by company
public DataTable getContactListByCompany(string company)
{
    DataTable dtContactInfo = new DataTable("InvoiceList");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@company", SqlDbType.NVarChar);
    inParams[0].Value =company;

    pTransactionSuccessful = true;

    try
    {
        DataSet dsContactInfo = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getRepListByCompany", inParams);
        dtContactInfo = dsContactInfo.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtContactInfo;
}
//get overdue invoices by carrier 
public DataTable getOverdueInvoicesListByCompany(string carrier)
{
    DataTable dtGeneratedInvoicesList = new DataTable("getGeneratedInvoicesList");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@carrier", SqlDbType.NVarChar);
    inParams[0].Value = carrier;
    

    pTransactionSuccessful = true;


    try
    {
        DataSet dsGeneratedInvoicesList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getOverdueInvoicesListByCompany", inParams);
        dtGeneratedInvoicesList = dsGeneratedInvoicesList.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtGeneratedInvoicesList;
}
//get overdue invoices by carrier and contact
public DataTable getOverdueInvoicesListByCompanyAndContact(string carrier, string contactEmail)
{
    DataTable dtGeneratedInvoicesList = new DataTable("getGeneratedInvoicesList");

    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@carrier", SqlDbType.NVarChar);
    inParams[0].Value = carrier;
    inParams[1] = new SqlParameter("@claimContactEmail", SqlDbType.NVarChar);
    inParams[1].Value = contactEmail;

    pTransactionSuccessful = true;


    try
    {
        DataSet dsGeneratedInvoicesList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getOverdueInvoicesListByCompanyAndRep", inParams);
        dtGeneratedInvoicesList = dsGeneratedInvoicesList.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtGeneratedInvoicesList;
}

//get generated invoices by carrier and contact
public DataTable getGeneratedInvoicesListByCompanyAndContact(string carrier, string contactEmail)
{
    DataTable dtGeneratedInvoicesList = new DataTable("getGeneratedInvoicesList");

    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@carrier", SqlDbType.NVarChar);
    inParams[0].Value = carrier;
    inParams[1] = new SqlParameter("@claimContactEmail", SqlDbType.NVarChar);
    inParams[1].Value = contactEmail;

    pTransactionSuccessful = true;


    try
    {
        DataSet dsGeneratedInvoicesList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getGeneratedInvoicesListByCompanyAndRep", inParams);
        dtGeneratedInvoicesList = dsGeneratedInvoicesList.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtGeneratedInvoicesList;
}

//get rep name by email
public DataTable getContactInfoByEmail(string email)
{
    DataTable dtContactInfo = new DataTable("InvoiceList");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@rep_email", SqlDbType.NVarChar);
    inParams[0].Value = email;

    pTransactionSuccessful = true;

    try
    {
        DataSet dsContactInfo = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getRepByEmail", inParams);
        dtContactInfo = dsContactInfo.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtContactInfo;
}
//get rep list
public DataTable getClaimContactList()
{
    DataTable dtContactList = new DataTable("contactList");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsContactList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getRepList");
        dtContactList = dsContactList.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtContactList;
}

//get rep list
public DataTable getAllState()
{
    DataTable dtState = new DataTable("State");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsState = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllState");
        dtState = dsState.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtState;
}
   
  
//Get generated invoices list based on date comparison
public DataTable getGeneratedInvoicesListByDateCarrierContact(string dateFrom, string dateTo, string carrier,string claimRep)
{
    DataTable dtGeneratedInvoices = new DataTable("InvoiceList");

    SqlParameter[] inParams = new SqlParameter[4];

    inParams[0] = new SqlParameter("@dateFrom", SqlDbType.NVarChar);
    inParams[0].Value = dateFrom;
    inParams[1] = new SqlParameter("@dateTo", SqlDbType.NVarChar);
    inParams[1].Value = dateTo;
    inParams[2] = new SqlParameter("@carrier", SqlDbType.NVarChar);
    inParams[2].Value = carrier;
    inParams[3] = new SqlParameter("@claimContact", SqlDbType.NVarChar);
    inParams[3].Value = claimRep;
    pTransactionSuccessful = true;

    try
    {
        DataSet dsGeneratedInvoices = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getGeneratedInvoicesListByDatesCarrierContact", inParams);
        dtGeneratedInvoices = dsGeneratedInvoices.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtGeneratedInvoices;
}

//Get overdue invoices list based on date comparison, carrier and contact
public DataTable getOverdueInvoicesListByDateContactCarrier(string dateFrom, string dateTo, string carrier, string contact)
{
    DataTable dtGeneratedInvoices = new DataTable("InvoiceList");

    SqlParameter[] inParams = new SqlParameter[4];

    inParams[0] = new SqlParameter("@dateFrom", SqlDbType.NVarChar);
    inParams[0].Value = dateFrom;
    inParams[1] = new SqlParameter("@dateTo", SqlDbType.NVarChar);
    inParams[1].Value = dateTo;
    inParams[2] = new SqlParameter("@carrier", SqlDbType.NVarChar);
    inParams[2].Value = carrier;
    inParams[3] = new SqlParameter("@claimContact", SqlDbType.NVarChar);
    inParams[3].Value = contact;

    pTransactionSuccessful = true;

    try
    {
        DataSet dsGeneratedInvoices = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getOverdueInvoicesListByDatesCarrierContact", inParams);
        dtGeneratedInvoices = dsGeneratedInvoices.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtGeneratedInvoices;
}
//Get overdue invoices list by carrier

//Get overdue invoices list based on date comparison
public DataTable getOverdueInvoicesListByDate(string dateFrom, string dateTo, string carrier)
{
    DataTable dtGeneratedInvoices = new DataTable("InvoiceList");

    SqlParameter[] inParams = new SqlParameter[3];

    inParams[0] = new SqlParameter("@dateFrom", SqlDbType.NVarChar);
    inParams[0].Value = dateFrom;
    inParams[1] = new SqlParameter("@dateTo", SqlDbType.NVarChar);
    inParams[1].Value = dateTo;
    inParams[2] = new SqlParameter("@carrier", SqlDbType.NVarChar);
    inParams[2].Value = carrier;
    pTransactionSuccessful = true;

    try
    {
        DataSet dsGeneratedInvoices = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getOverdueInvoicesListByDates", inParams);
        dtGeneratedInvoices = dsGeneratedInvoices.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtGeneratedInvoices;
}


//Get generated invoices list based on date comparison
public DataTable getGeneratedInvoicesListByDate(string dateFrom, string dateTo, string carrier)
{
    DataTable dtGeneratedInvoices = new DataTable("InvoiceList");

    SqlParameter[] inParams = new SqlParameter[3];

    inParams[0] = new SqlParameter("@dateFrom", SqlDbType.NVarChar);
    inParams[0].Value = dateFrom;
    inParams[1] = new SqlParameter("@dateTo", SqlDbType.NVarChar);
    inParams[1].Value = dateTo;
    inParams[2] = new SqlParameter("@carrier", SqlDbType.NVarChar);
    inParams[2].Value = carrier;
    pTransactionSuccessful = true;

    try
    {
        DataSet dsGeneratedInvoices = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getGeneratedInvoicesListByDates", inParams);
        dtGeneratedInvoices = dsGeneratedInvoices.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtGeneratedInvoices;
}

        
        //gets assigned claims by adjuster username (email)
public DataTable getAssignedClaimByAdjusterId(int adjusterId)
{
    DataTable dtAdjusterAssignedClaims = new DataTable("adjusterAssignedClaims");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@adjuster_id", SqlDbType.Int);
    inParams[0].Value = adjusterId;

    pTransactionSuccessful = true;
    try
    {
        DataSet dsAdjusterAssignedClaims = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAssignedClaimByAdjusterId", inParams);
        dtAdjusterAssignedClaims = dsAdjusterAssignedClaims.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = true;
    }
    return dtAdjusterAssignedClaims;
}

//Get assignded Claim quantity by adjuster
public DataTable getClaimAverageDaysOpenByAdjusterId(int AdjusterId)
{
    DataTable dtAssignedClaim = new DataTable("AssignedAdjuster");
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@adjusterId", SqlDbType.Int);
    inParams[0].Value = AdjusterId;
    pTransactionSuccessful = true;

    try
    {
        DataSet dsAssignedAdjuster = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAdjusterAverageDaysOpen", inParams);
        dtAssignedClaim = dsAssignedAdjuster.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtAssignedClaim;
}

//Get assignded Claim quantity by adjuster
public DataTable getAssignedClaimQuantityByAdjusterId(int AdjusterId)
{
    DataTable dtAssignedClaim = new DataTable("AssignedAdjuster");
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@adjuster_id", SqlDbType.Int);
    inParams[0].Value = AdjusterId;
    pTransactionSuccessful = true;

    try
    {
        DataSet dsAssignedAdjuster = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAssignedClaimQuantityByAdjusterId", inParams);
        dtAssignedClaim = dsAssignedAdjuster.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtAssignedClaim;
}

//Get overdue Claim quantity by adjuster
public DataTable getOverDueClaimQuantityByAdjusterId(int AdjusterId)
{
    DataTable dtAssignedClaim = new DataTable("AssignedAdjuster");
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@adjuster_id", SqlDbType.Int);
    inParams[0].Value = AdjusterId;
    pTransactionSuccessful = true;

    try
    {
        DataSet dsAssignedAdjuster = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getOverdueClaimQuantityAdjuster", inParams);
        dtAssignedClaim = dsAssignedAdjuster.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtAssignedClaim;
}


//gets opened claims by adjuster Id
public DataTable getOverDueClaimByAdjusterId(int adjusterId)
{
    DataTable dtAdjusterAssignedClaims = new DataTable("overDueClaims");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@adjuster_id", SqlDbType.Int);
    inParams[0].Value = adjusterId;

    pTransactionSuccessful = true;
    try
    {
        DataSet dsAdjusterAssignedClaims = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getOverdueClaimByAdjusterId", inParams);
        dtAdjusterAssignedClaims = dsAdjusterAssignedClaims.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = true;
    }
    return dtAdjusterAssignedClaims;
}

//Get critical Claim quantity by adjuster
public DataTable getCriticalClaimQuantityByAdjusterId(int AdjusterId)
{
    DataTable dtCriticalClaim = new DataTable("CriticalAdjuster");
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@adjuster_id", SqlDbType.Int);
    inParams[0].Value = AdjusterId;
    pTransactionSuccessful = true;

    try
    {
        DataSet dsCriticalAdjuster = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getCriticalClaimQuantityByAdjusterId", inParams);
        dtCriticalClaim = dsCriticalAdjuster.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtCriticalClaim;
}

//gets critical claims by adjuster Id
public DataTable getCriticalClaimByAdjusterId(int adjusterId)
{
    DataTable dtAdjusterCriticalClaims = new DataTable("criticalClaims");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@adjuster_id", SqlDbType.Int);
    inParams[0].Value = adjusterId;

    pTransactionSuccessful = true;
    try
    {
        DataSet dsAdjusterCriticalClaims = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getCriticalClaimByAdjusterId", inParams);
        dtAdjusterCriticalClaims = dsAdjusterCriticalClaims.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = true;
    }
    return dtAdjusterCriticalClaims;
}

//get critical claims list
public DataTable getCriticalClaimsList()
{
    DataTable dtGetCriticalClaimsList = new DataTable("getCriticalClaimsList");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsGetCriticalClaimsList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getCriticalClaimList");
        dtGetCriticalClaimsList = dsGetCriticalClaimsList.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtGetCriticalClaimsList;
}

//get critical claim quantity
public DataTable getCriticalClaimQty()
{
    DataTable dtCriticalClaimQty = new DataTable("CriticalClaimQty");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsCriticalClaimQty = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getCriticalClaimQuantity");
        dtCriticalClaimQty = dsCriticalClaimQty.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtCriticalClaimQty;
}

//Get contacts for notes
public DataTable getAdjusterByClaimId(int claimId)
{
    DataTable dtAssignedAdjuster = new DataTable("AssignedAdjuster");
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@claim_id", SqlDbType.Int);
    inParams[0].Value = claimId;
    pTransactionSuccessful = true;

    try
    {
        DataSet dsAssignedAdjuster = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAdjusterByClaimId", inParams);
        dtAssignedAdjuster = dsAssignedAdjuster.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtAssignedAdjuster;
}


//Get invoice details by id
public DataTable getInvoiceTypeById(int invoiceId)
{
    DataTable dtInvoiceType = new DataTable("AssignedAdjuster");
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@invoice_type_id", SqlDbType.Int);
    inParams[0].Value = invoiceId;
    pTransactionSuccessful = true;

    try
    {
        DataSet dsInvoiceType = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getInvoiceTypebyId", inParams);
        dtInvoiceType = dsInvoiceType.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtInvoiceType;
}

//Get contacts for notes
public DataTable getContactsForNotesForAdjuster(int claimId)
{
    DataTable dtContactsForNotes = new DataTable("contactsForNotes");
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@claim_id", SqlDbType.Int);
    inParams[0].Value = claimId;
    pTransactionSuccessful = true;

    try
    {
        DataSet dsContactsForNotes = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getContactsForNotesForAdjuster", inParams);
        dtContactsForNotes = dsContactsForNotes.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtContactsForNotes;
}



//Get contacts for notes
public DataTable getContactsForNotes(int claimId)
{
    DataTable dtContactsForNotes = new DataTable("contactsForNotes");
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@claim_id", SqlDbType.Int);
    inParams[0].Value = claimId;
    pTransactionSuccessful = true;

    try
    {
        DataSet dsContactsForNotes = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getContactsForNotes", inParams);
        dtContactsForNotes = dsContactsForNotes.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtContactsForNotes;
}

//Gets filepaths associated with claim ID
public DataTable getLostNoticeByClaimId(int claimId)
{
    DataTable dtFilepathsForClaim = new DataTable("Filepaths");
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@claim_id", SqlDbType.Int);
    inParams[0].Value = claimId;
    pTransactionSuccessful = true;

    try
    {
        DataSet dsFilepathsForClaim = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getLostNoticeFilepathByClaimId", inParams);
        dtFilepathsForClaim = dsFilepathsForClaim.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtFilepathsForClaim;
}

//Gets filepaths associated with claim ID
public DataTable getFilepathByClaimId(int claimId,string userRole)
{
    DataTable dtFilepathsForClaim = new DataTable("Filepaths");
    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@claim_id", SqlDbType.Int);
    inParams[0].Value = claimId;
    inParams[1] = new SqlParameter("@userRole", SqlDbType.NVarChar);
    inParams[1].Value = userRole;
    pTransactionSuccessful = true;

    try
    {
        DataSet dsFilepathsForClaim = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getFilepathByClaimId", inParams);
        dtFilepathsForClaim = dsFilepathsForClaim.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtFilepathsForClaim;
}
        //get password
public DataTable getPassword(int userId)
{

    DataTable dtPassword = new DataTable("password");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@users_id", SqlDbType.Int);
    inParams[0].Value = userId;

    pTransactionSuccessful = true;
    try
    {
        DataSet dsUserDetail = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getPassword", inParams);
        dtPassword = dsUserDetail.Tables[0];
    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;

        pTransactionSuccessful = false;
    }
    return dtPassword;
}

//get role list
public DataTable getAllRoleListDetail()
{
    DataTable dtRoleList = new DataTable("RoleList");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsRoleList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllRoleListDetail");
        dtRoleList = dsRoleList.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtRoleList;
}

//get role list
public DataTable getRoleList()
{
    DataTable dtRoleList = new DataTable("RoleList");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsRoleList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getRoleList");
        dtRoleList = dsRoleList.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtRoleList;
}

//get all claims
public DataTable getAllClaims()
{
    DataTable dtClaimList = new DataTable("ClaimList");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsClaimList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllClaims");
        dtClaimList = dsClaimList.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtClaimList;
}

//get SMTP info
public DataTable getSmtpInfo()
{
    DataTable dtSmtpInfo = new DataTable("SmtpInfo");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsSmtpInfo = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getSmtpInfo");
        dtSmtpInfo = dsSmtpInfo.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtSmtpInfo;
}
//get user info by email
public DataTable getUsersDetailByEmail(string email)
{

    DataTable dtUserDetail = new DataTable("Users");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@email", SqlDbType.NVarChar);
    inParams[0].Value = email;

    pTransactionSuccessful = true;
    try
    {
        DataSet dsUserDetail = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getUserDetailByEmail", inParams);
        dtUserDetail = dsUserDetail.Tables[0];
    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;

        pTransactionSuccessful = false;
    }
    return dtUserDetail;
}

public DataTable getAll10DayOldClaims()
{
    DataTable dtGetAllOpeneClaimsList = new DataTable("10DayOldClaims");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsGetAllOpeneClaimsList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "get10DayOldClaimList");
        dtGetAllOpeneClaimsList = dsGetAllOpeneClaimsList.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtGetAllOpeneClaimsList;
}

public DataTable getAllOpenClaimsList()
{
    DataTable dtGetAllOpeneClaimsList = new DataTable("getAllOpeneClaimsList");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsGetAllOpeneClaimsList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllOpenClaimsList");
        dtGetAllOpeneClaimsList = dsGetAllOpeneClaimsList.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtGetAllOpeneClaimsList;
}
//get overdue claims list
public DataTable getOverdueClaimsList()
{
    DataTable dtGetOverdueClaimsList = new DataTable("getOverdueClaimsList");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsGetOverdueClaimsList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getOverdueClaimList");
        dtGetOverdueClaimsList = dsGetOverdueClaimsList.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtGetOverdueClaimsList;
}
//get file type
public DataTable getFileType()
{
    DataTable dtGetFileType = new DataTable("getFileType");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsGetFileType = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getFileType");
        dtGetFileType = dsGetFileType.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtGetFileType;
}
//get overdue dates
public DataTable getOverdueDates(int overdueDateID)
{
    DataTable dtOverdueDate = new DataTable("overdueDate");
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@overdue_date_id", SqlDbType.Int);
    inParams[0].Value = overdueDateID;
    pTransactionSuccessful = true;

    try
    {
        DataSet dsOverdueDate = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getOverdueDateById", inParams);
        dtOverdueDate = dsOverdueDate.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtOverdueDate;
}
//search unassigned claims
public DataTable searchUnassignedClaim(string search)
{
    DataTable dtUnassignedClaim = new DataTable("UnassignedClaim");
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@searchString", SqlDbType.NVarChar);
    inParams[0].Value = search;
    pTransactionSuccessful = true;

    try
    {
        DataSet dsUnassignedClaim = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "searchUnassignedClaims", inParams);
        dtUnassignedClaim = dsUnassignedClaim.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtUnassignedClaim;
}
//search All Adjsuster claims
public DataTable searchAllAdjusterClaims(string search, string email)
{
    DataTable dtAllClaims = new DataTable("AllClaims");
    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@searchString", SqlDbType.NVarChar);
    inParams[0].Value = search;
    inParams[1] = new SqlParameter("@adjuster_email", SqlDbType.NVarChar);
    inParams[1].Value = email;
    pTransactionSuccessful = true;

    try
    {
        DataSet dsAllClaims = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "searchAllAdjusterClaims", inParams);
        dtAllClaims = dsAllClaims.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtAllClaims;
}
//search All claims
public DataTable searchAllClaims(string search)
{
    DataTable dtAllClaims = new DataTable("AllClaims");
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@searchString", SqlDbType.NVarChar);
    inParams[0].Value = search;
    pTransactionSuccessful = true;

    try
    {
        DataSet dsAllClaims = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "searchAllClaims", inParams);
        dtAllClaims = dsAllClaims.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtAllClaims;
}

//get adjuster workload
public DataTable getAdjusterWorkload()
{
    DataTable dtAdjusterWorkLoad = new DataTable("getAdjusterWorkload");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsAdjusterWorkLoad = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAdjusterWorkLoad");
        dtAdjusterWorkLoad = dsAdjusterWorkLoad.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtAdjusterWorkLoad;
}

//get 10 old claim claims
public DataTable get10DayOldClaimqty()
{
    DataTable dtAllOpenClaimsQuantity = new DataTable("10DayOldClaim");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsAllOpenClaimsQuantity = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "get10DayOldClaimQuantity");
        dtAllOpenClaimsQuantity = dsAllOpenClaimsQuantity.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtAllOpenClaimsQuantity;
}

//get all open claims
public DataTable getAllOpenClaimsQuantity()
{
    DataTable dtAllOpenClaimsQuantity = new DataTable("getAllOpenClaimsQuantity");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsAllOpenClaimsQuantity = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllOpenClaimsQuantity");
        dtAllOpenClaimsQuantity = dsAllOpenClaimsQuantity.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtAllOpenClaimsQuantity;
}

//get unassigned claim quantity
public DataTable getUnassignedClaimQty()
{
    DataTable dtUnassignedClaimQty = new DataTable("UnassignedClaimQty");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsUnassignedClaimQty = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getUnassignedClaimQuantity");
        dtUnassignedClaimQty = dsUnassignedClaimQty.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtUnassignedClaimQty;
}

//get reports to review quantity
public DataTable getReportsToReview()
{
    DataTable dtReportsToReview = new DataTable("ReportsToReview");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsReportsToReview = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getReportstoReviewQuantity");
        dtReportsToReview = dsReportsToReview.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtReportsToReview;
}

//get over due claim quantity
public DataTable getOverDueClaimQty()
{
    DataTable dtOverDueClaimQty = new DataTable("OverDueClaimQty");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsOverDueClaimQty = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getOverDueClaimQuantity");
        dtOverDueClaimQty = dsOverDueClaimQty.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtOverDueClaimQty;
}

//get role ID by role title
public DataTable getRoleIDByRoleTitle(string title)
{
    DataTable dtRoleId = new DataTable("roleId");
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@title", SqlDbType.NVarChar);
    inParams[0].Value = title;

    pTransactionSuccessful = true;

    try
    {
        DataSet dsRoleId = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getRoleIdByRoleTitle", inParams);
        dtRoleId = dsRoleId.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtRoleId;
}

//Get Company name list
public DataTable getCompanyList()
{
    DataTable dtCompanyList = new DataTable("companyList");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsCompanyList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getCompanyList");
        dtCompanyList = dsCompanyList.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtCompanyList;
}

//Get claim by policy number
public DataTable getClaimByPolicyNumber(string policyNumber, int claimId)
{
    DataTable dtClaimFromPolicy = new DataTable("claimFromPolicy");
    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@policy_number", SqlDbType.NVarChar);
    inParams[0].Value = policyNumber;
    inParams[1] = new SqlParameter("@claim_id", SqlDbType.Int);
    inParams[1].Value = claimId;

    pTransactionSuccessful = true;

    try
    {
        DataSet dsClaimFromPolicy = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getClaimByPolicyNumber", inParams);
        dtClaimFromPolicy = dsClaimFromPolicy.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtClaimFromPolicy;
}

//Get contacts for notes
public DataTable getContactsForNotes()
{
    DataTable dtContactsForNotes = new DataTable("contactsForNotes");
    pTransactionSuccessful = true;

    try
    {
        DataSet dsContactsForNotes = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getContactsForNotes");
        dtContactsForNotes = dsContactsForNotes.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtContactsForNotes;
}

//Get invoice type by invoice type Id description
public DataTable getInvoiceTypeIdByDescription(string claim_description)
{
    DataTable dtInvoiceTypeId = new DataTable("invoiceTypeId");
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@claim_description", SqlDbType.NVarChar);
    inParams[0].Value = claim_description;

    pTransactionSuccessful = true;

    try
    {
        DataSet dsInvoiceTypeId = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getInvoiceTypeIdByDescription", inParams);
        dtInvoiceTypeId = dsInvoiceTypeId.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtInvoiceTypeId;
}

//Get company Id by company name
public DataTable getCompanyIdByCompanyName(string carrier)
{
    DataTable dtCompanyName = new DataTable("companyName");
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@company_name", SqlDbType.NVarChar);
    inParams[0].Value = carrier;
  
    pTransactionSuccessful = true;

    try
    {
        DataSet dsCompanyName = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getCompanyIdByCompanyName", inParams);
        dtCompanyName = dsCompanyName.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtCompanyName;
}
//Get Invoice type list
public DataTable getInvoiceTypeListByCarrier(string carrier)
{
    DataTable dtInvoiceType = new DataTable("invoiceType");
    SqlParameter[] inparams = new SqlParameter[1];

    inparams[0] = new SqlParameter("@carrier", SqlDbType.NVarChar);
    inparams[0].Value = carrier;
    pTransactionSuccessful = true;

    try
    {
        DataSet dsInvoiceType = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getInvoiceTypeListByCarrier",inparams);
        dtInvoiceType = dsInvoiceType.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtInvoiceType;
}



//Get Invoice type list
public DataTable getInvoiceTypeList()
{
    DataTable dtInvoiceType = new DataTable("invoiceType");
    pTransactionSuccessful = true;

    try
    {
        DataSet dsInvoiceType = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getInvoiceTypeList");
        dtInvoiceType = dsInvoiceType.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtInvoiceType;
}

//Get claim ID for status
public DataTable getClaimID(string claimNumber)
{
    DataTable dtClaimID = new DataTable("claimID");
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@claim_number", SqlDbType.NVarChar);
    inParams[0].Value = claimNumber;

    pTransactionSuccessful = true;

    try
    {
        DataSet dsclaimID = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getClaimID",inParams);
        dtClaimID = dsclaimID.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtClaimID;
}
//getAssignedUserlist
public DataTable getAssignedAdjusterList()
{
    DataTable dtAdjusters = new DataTable("adjusterList");


    pTransactionSuccessful = true;

    try
    {
        DataSet dsAdjusters = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAssignedAdjusterlist");
        dtAdjusters = dsAdjusters.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtAdjusters;
}



//Get List of adjuster
public DataTable getAdjusterList()
{
    DataTable dtAdjusters = new DataTable("adjusterList");
      

    pTransactionSuccessful = true;

    try
    {
        DataSet dsAdjusters = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAdjusterList");
        dtAdjusters = dsAdjusters.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtAdjusters;
}

//get all user list 
public DataTable getUserList()
{
    DataTable dtUserList = new DataTable("userList");


    

    pTransactionSuccessful = true;

    try
    {
        DataSet dsUserList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getUserList");
        dtUserList = dsUserList.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtUserList;
}


//is date a string? also should array in try have a value?
public DataTable getAssignedClaim()
{
    DataTable dtAssignedClaims = new DataTable("assignedClaims");

   

    pTransactionSuccessful = true;
    try
    {
        DataSet dsAssignedClaims = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAssignedClaim");
        dtAssignedClaims = dsAssignedClaims.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = true;
    }
    return dtAssignedClaims;
}

public DataTable getClosedClaim()
{
    DataTable dtClosedClaims = new DataTable("closedClaims");


    pTransactionSuccessful = true;
    try
    {
        DataSet dsClosedClaims = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getClosedClaim");
        dtClosedClaims = dsClosedClaims.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;
    }
    return dtClosedClaims;
}

public DataTable getReopenedClaim()
{
    DataTable dtReopenedClaims = new DataTable("reopenedClaims");

   
    pTransactionSuccessful = true;

    try
    {
        DataSet dsReopenedClaims = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getReopenClaim");
        dtReopenedClaims = dsReopenedClaims.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;
    }
    return dtReopenedClaims;
}

//Get user Id by Email
public DataTable getUserIdByEmail(string email)
{
    
    DataTable dtUserId = new DataTable("userId");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@email", SqlDbType.NVarChar);
    inParams[0].Value = email;

    pTransactionSuccessful = true;
    try
    {
        DataSet dsUserId = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getUserIdByEmail", inParams);
        dtUserId = dsUserId.Tables[0];
    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;

        pTransactionSuccessful = false;
    }
    return dtUserId;
}

//get company detail by company id
public DataTable getCompanyDetailByCompanyId(int companyId)
{

    DataTable dtCompanyDetail = new DataTable("Company");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@companyId", SqlDbType.Int);
    inParams[0].Value = companyId;

    pTransactionSuccessful = true;
    try
    {
        DataSet dsCompanyDetail = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getCompanyDetailByCompanyId", inParams);
        dtCompanyDetail = dsCompanyDetail.Tables[0];
    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;

        pTransactionSuccessful = false;
    }
    return dtCompanyDetail;
}
//Get users detail info: All info by User Id
public DataTable getUsersDetailByUserId(int userId)
{
    
    DataTable dtUserDetail = new DataTable("Users");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@userid", SqlDbType.Int);
    inParams[0].Value = userId;

    pTransactionSuccessful = true;
    try
    {
        DataSet dsUserDetail = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getuserDetailByUserId", inParams);
        dtUserDetail= dsUserDetail.Tables[0];
    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;

        pTransactionSuccessful = false;
    }
    return dtUserDetail;
}

//get role of user by user Id
public DataTable getUserRoleByUserid(int userId)
{
    DataTable dtRole = new DataTable("role");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@userId", SqlDbType.Int);
    inParams[0].Value = userId;
    

    try
    {
        DataSet dsRole = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getRoleByUserId", inParams);
        dtRole = dsRole.Tables[0];

    }
    catch (SqlException)
    {

    }
    return dtRole;
}

//get role of user by Email and password
public DataTable getRoleByUserName(string email, string password)
{
    DataTable dtRole = new DataTable("role");

    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@email", SqlDbType.NVarChar);
    inParams[0].Value = email;
    inParams[1] = new SqlParameter("@password", SqlDbType.NVarChar);
    inParams[1].Value = password;

    try
    {
        DataSet dsRole = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getRole", inParams);
        dtRole = dsRole.Tables[0];

    }
    catch (SqlException)
    {

    }
    return dtRole;
}


//get list of unassigned claims
public DataTable getUnassignedClaim()
{

    DataTable dtUnassignedClaims = new DataTable("unassignedClaims");


    pTransactionSuccessful = true;

    try
    {
        DataSet dsUnassignedClaims = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getUnassignedClaim");
        dtUnassignedClaims = dsUnassignedClaims.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;
    }
    return dtUnassignedClaims;
}

//get Claim Contact info
public DataTable getRepById(int repId)
{
    DataTable dtRep = new DataTable("Rep");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@rep_id", SqlDbType.Int);
    inParams[0].Value = repId;


    try
    {
        DataSet dsRep = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getRepById", inParams);
        dtRep = dsRep.Tables[0];

    }
    catch (SqlException)
    {

    }
    return dtRep;
}


//get user list
//get Claim Rep Drop Down
public DataTable getClaimRepDropDownMap()
{
    DataTable dtAdjusters = new DataTable("ClaimRep");


    pTransactionSuccessful = true;

    try
    {
        DataSet dsAdjusters = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getClaimRepDropDownMap");
        dtAdjusters = dsAdjusters.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtAdjusters;
}

//get adjuster drop down
public DataTable getAdjusterDropDownMap()
{
    DataTable dtAdjusters = new DataTable("adjusterList");


    pTransactionSuccessful = true;

    try
    {
        DataSet dsAdjusters = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAdjusterListDropDownMap");
        dtAdjusters = dsAdjusters.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtAdjusters;
}
//get adjuster drop down
public DataTable getAdjusterDropDown()
{
    DataTable dtAdjusters = new DataTable("adjusterList");


    pTransactionSuccessful = true;

    try
    {
        DataSet dsAdjusters = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAdjusterDropDown");
        dtAdjusters = dsAdjusters.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtAdjusters;
}


//gets Claim List by Carrier
public DataTable getAllClaimsByCarrier(string carrier)
{
    DataTable dtAdjusterAssignedClaims = new DataTable("ClaimRepClaims");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@carrier", SqlDbType.NVarChar);
    inParams[0].Value = carrier;

    pTransactionSuccessful = true;
    try
    {
        DataSet dsAdjusterAssignedClaims = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllOpenClaimsListByCarrier", inParams);
        dtAdjusterAssignedClaims = dsAdjusterAssignedClaims.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = true;
    }
    return dtAdjusterAssignedClaims;
}

//gets Claim List by Loss Type
public DataTable getAllClaimsByLossType(string LossType)
{
    DataTable dtAdjusterAssignedClaims = new DataTable("ClaimsLossType");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@lossType", SqlDbType.NVarChar);
    inParams[0].Value =LossType;

    pTransactionSuccessful = true;
    try
    {
        DataSet dsAdjusterAssignedClaims = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllOpenClaimsListByLossType", inParams);
        dtAdjusterAssignedClaims = dsAdjusterAssignedClaims.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = true;
    }
    return dtAdjusterAssignedClaims;
}

//gets Claim List by Claim Rep
public DataTable getAllClaimsByClaimRep(string Email)
{
    DataTable dtAdjusterAssignedClaims = new DataTable("ClaimRepClaims");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@ClaimRepEmail", SqlDbType.NVarChar);
    inParams[0].Value = Email;

    pTransactionSuccessful = true;
    try
    {
        DataSet dsAdjusterAssignedClaims = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllOpenClaimsListByClaimRep", inParams);
        dtAdjusterAssignedClaims = dsAdjusterAssignedClaims.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = true;
    }
    return dtAdjusterAssignedClaims;
}



//gets assigned claims by adjuster username (email)
public DataTable getAssignedClaimByAdjusterEmailId(string Email)
{
    DataTable dtAdjusterAssignedClaims = new DataTable("adjusterAssignedClaims");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@email_id", SqlDbType.NVarChar);
    inParams[0].Value = Email;

    pTransactionSuccessful = true;
    try
    {
        DataSet dsAdjusterAssignedClaims = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAssignedClaimByAdjusterEmailId", inParams);
        dtAdjusterAssignedClaims = dsAdjusterAssignedClaims.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = true;
    }
    return dtAdjusterAssignedClaims;
}


//gets claim by claim id
public DataTable getClaimByClaimId(int claim_id)
{
    DataTable dtClaim = new DataTable("Claim");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@claim_id", SqlDbType.Int);
    inParams[0].Value = claim_id;

    pTransactionSuccessful = true;
    try
    {
        DataSet dsclaim = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getClaimByClaimId", inParams);
        dtClaim = dsclaim.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = true;
    }
    return dtClaim;
}

//gets notes by claim id
public DataTable getNotes(int claim_id)
{
    DataTable dtNotes = new DataTable("Notes");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@claim_id", SqlDbType.Int);
    inParams[0].Value = claim_id;

    pTransactionSuccessful = true;
    try
    {
        DataSet dsNotes = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getClaimNotesByClaimId", inParams);
        dtNotes = dsNotes.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = true;
    }
    return dtNotes;
}
        //gets all claims for month
public DataTable getAllClaimsForMonth()
{
    DataTable dtMonthlyClaimList = new DataTable("Monthly Claim List");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsMonthlyClaimList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllClaimsForMonth");
        dtMonthlyClaimList = dsMonthlyClaimList.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtMonthlyClaimList;
}


//gets all claims for Today
public DataTable getAllClaimsForToday()
{
    DataTable dtMonthlyClaimList = new DataTable("Today Claim List");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsMonthlyClaimList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllClaimsForToday");
        dtMonthlyClaimList = dsMonthlyClaimList.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtMonthlyClaimList;
}

//get monthly claim quantity
public DataTable getAllClaimsForMonthQty()
{
    DataTable dtMonthlyClaimsQty = new DataTable("MonthlyClaimsQty");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsMonthlyClaimsQty = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllClaimsForMonthQuantity");
        dtMonthlyClaimsQty = dsMonthlyClaimsQty.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtMonthlyClaimsQty;
}


//get Today claim quantity
public DataTable getAllClaimsForTodayQty()
{
    DataTable dtMonthlyClaimsQty = new DataTable("TodayClaimsQty");

    pTransactionSuccessful = true;

    try
    {
        DataSet dsMonthlyClaimsQty = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getAllClaimsForTodayQuantity");
        dtMonthlyClaimsQty = dsMonthlyClaimsQty.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtMonthlyClaimsQty;
}

        
        
        
        //gets list of generated invoices
public DataTable getGeneratedInvoicesList(string carrier)
{
    DataTable dtGeneratedInvoicesList = new DataTable("getGeneratedInvoicesList");

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@carrier", SqlDbType.NVarChar);
    inParams[0].Value = carrier;

    pTransactionSuccessful = true;
   

    try
    {
        DataSet dsGeneratedInvoicesList = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getGeneratedInvoicesList", inParams);
        dtGeneratedInvoicesList = dsGeneratedInvoicesList.Tables[0];

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return dtGeneratedInvoicesList;
}


#endregion

#region "Remove and delete methods"

//Remove Claim File Type
public void removeClaimFileType(int claimFileTypeId)
{
    //returns false if operation failed
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@claim_filetype_id", SqlDbType.Int);
    inParams[0].Value = claimFileTypeId;

    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "removeClaimFileType", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;
    }

}


//Remove Loss Type
public void removeLossType(int LossType)
{
    //returns false if operation failed
    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@loss_type_id", SqlDbType.Int);
    inParams[0].Value = LossType;
  
    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "removeLossType", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;
    }
    
}


//remove user
public void removeUser(int userID)
{
    //returns false if operation failed
     SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@users_id", SqlDbType.Int);
    inParams[0].Value = userID;
    inParams[1] = new SqlParameter("@removeSuccessful", SqlDbType.Bit);
    inParams[1].Direction = ParameterDirection.Output;

    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "removeUser", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;
    }
    pisUserDeleted = (bool)inParams[1].Value;
}

//Delete claim
public bool deleteClaim(int claimId)
{
    // Set up parameters in parameter array 
    SqlParameter[] arParms = new SqlParameter[1];


    arParms[0] = new SqlParameter("@claim_id", SqlDbType.Int);
    arParms[0].Value = claimId;


    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "deleteClaim", arParms);
    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;

        pTransactionSuccessful = false;
    }
    return pTransactionSuccessful;
}

//Delete Company
public void deleteCompany(int companyId)
{
    // Set up parameters in parameter array 
    SqlParameter[] inParams = new SqlParameter[2];


    inParams[0] = new SqlParameter("@company_id", SqlDbType.Int);
    inParams[0].Value = companyId;
    inParams[1] = new SqlParameter("@removeSuccessful", SqlDbType.Bit);
    inParams[1].Direction = ParameterDirection.Output;

    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "deleteCompany", inParams);
    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;

        pTransactionSuccessful = false;
    }
    pisCompanyDeleted=(bool)inParams[1].Value;
}

//Delete Rep
public void deleteRep(int repId)
{
    // Set up parameters in parameter array 
    SqlParameter[] inParams = new SqlParameter[2];


    inParams[0] = new SqlParameter("@rep_id", SqlDbType.Int);
    inParams[0].Value = repId;
    inParams[1] = new SqlParameter("@removeSuccessful", SqlDbType.Bit);
    inParams[1].Direction = ParameterDirection.Output;

    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "deleteRep", inParams);
    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;

        pTransactionSuccessful = false;
    }
    
}

//Delete Billing
public void deleteBilling(int billingId)
{
    // Set up parameters in parameter array 
    SqlParameter[] inParams = new SqlParameter[2];


    inParams[0] = new SqlParameter("@invoice_type_id", SqlDbType.Int);
    inParams[0].Value = billingId;
    inParams[1] = new SqlParameter("@removeSuccessful", SqlDbType.Bit);
    inParams[1].Direction = ParameterDirection.Output;

    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "deleteInvoiceType", inParams);
    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;

        pTransactionSuccessful = false;
    }
    pisBillingDeleted = (bool)inParams[1].Value;
}


//Delete File
public void deleteFile(int claimfileTypeId)
{
    // Set up parameters in parameter array 
    SqlParameter[] inParams = new SqlParameter[1];


    inParams[0] = new SqlParameter("@claim_filepath_id", SqlDbType.Int);
    inParams[0].Value = claimfileTypeId;
  
    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "deleteFile", inParams);
    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;

        pTransactionSuccessful = false;
    }
   
}
#endregion

#region "Check and Valid Methods"
//Check if claim is canceled
public void checkClaimCanceled(int claimId)
{
    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@claim_id", SqlDbType.Int);
    inParams[0].Value = claimId;
    inParams[1] = new SqlParameter("@isFound", SqlDbType.Bit);
    inParams[1].Direction = ParameterDirection.Output;

    pTransactionSuccessful = true;
    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "checkClaimCanceled", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;
    }
    pIsClaimCanceled = (bool)inParams[1].Value;

}
//Check if rep email address is valid
public void checkContactEmail(string email)
{
    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@rep_email", SqlDbType.NVarChar);
    inParams[0].Value = email;
    inParams[1] = new SqlParameter("@isFound", SqlDbType.Bit);
    inParams[1].Direction = ParameterDirection.Output;

    pTransactionSuccessful = true;
    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "checkRepEmail", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;
    }
    pisEmailFound = (bool)inParams[1].Value;

}
//Check if claim is closed
public void checkClaimClosed(int claimId)
{
    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@claim_id", SqlDbType.Int);
    inParams[0].Value = claimId;
    inParams[1] = new SqlParameter("@isFound", SqlDbType.Bit);
    inParams[1].Direction = ParameterDirection.Output;

    pTransactionSuccessful = true;
    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "checkClaimClosed", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;
    }
    pIsClaimClosed = (bool)inParams[1].Value;

}

//Check company exists
public void checkCompany(string companyName)
{
    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@company_name", SqlDbType.NVarChar);
    inParams[0].Value = companyName;
    inParams[1] = new SqlParameter("@isFound", SqlDbType.Bit);
    inParams[1].Direction = ParameterDirection.Output;

    pTransactionSuccessful = true;
    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "checkCompany", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;
    }
    IsCompanyNameFound = (bool)inParams[1].Value;

}

//Check if Duplicate role already exists.
public void checkDuplicateRole(string roleTitle)
{
    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@roleTitle", SqlDbType.NVarChar);
    inParams[0].Value = roleTitle;
    inParams[1] = new SqlParameter("@isFound", SqlDbType.Bit);
    inParams[1].Direction = ParameterDirection.Output;

    pTransactionSuccessful = true;
    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "checkDuplicateRole", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;
    }
    pisDuplicateRoleFound = (bool)inParams[1].Value;
    }

//Check if email address is valid
public void checkEmail(string email)
{
    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@email", SqlDbType.NVarChar);
    inParams[0].Value = email;
    inParams[1] = new SqlParameter("@isFound", SqlDbType.Bit);
    inParams[1].Direction = ParameterDirection.Output;

    pTransactionSuccessful = true;
    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "checkEmail", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;
    }
    pisEmailFound = (bool)inParams[1].Value;

}

//Checks for duplicate claim numbers
public void checkClaim(string claimNumber)
{
    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@claimNumber", SqlDbType.NVarChar);
    inParams[0].Value = claimNumber;
    inParams[1] = new SqlParameter("@isFound", SqlDbType.Bit);
    inParams[1].Direction = ParameterDirection.Output;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "checkClaim", inParams);

    }
    catch (SqlException)
    {

    }
    pisClaimFound = (bool)inParams[1].Value;

}
//check if user's email and password is valid
public void checkUser(string email, string password)
{
    SqlParameter[] inParams = new SqlParameter[3];

    inParams[0] = new SqlParameter("@email", SqlDbType.NVarChar);
    inParams[0].Value = email;
    inParams[1] = new SqlParameter("@password", SqlDbType.NVarChar);
    inParams[1].Value = password;
    inParams[2] = new SqlParameter("@isFound", SqlDbType.Bit);
    inParams[2].Direction = ParameterDirection.Output;

    pTransactionSuccessful = true;
    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "checkuser", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;

        pTransactionSuccessful = false;
    }
    pUserFound = (bool)inParams[2].Value;
}
//check method for poilcy number
public void checkDuplicatePolicyNumber(string policyNumber)
{
    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@policyNumber", SqlDbType.NVarChar);
    inParams[0].Value = policyNumber;
    inParams[1] = new SqlParameter("@isFound", SqlDbType.Bit);
    inParams[1].Direction = ParameterDirection.Output;

    pTransactionSuccessful = true;
    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "checkPolicyNumber", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;
    }
    pPolicyFound = (bool)inParams[1].Value;

}






#endregion
        
#region "Change/Assign/Unassign methods"

//Change Claim Rep Info by claim Id
public bool changeClaimRepInfoByClaimId(string repEmail, string repFirstName, string repLastName, int claimId)
{
    // Set up parameters in parameter array 
    SqlParameter[] arParms = new SqlParameter[4];


    arParms[0] = new SqlParameter("@repEmail", SqlDbType.NVarChar);
    arParms[0].Value = repEmail;
    arParms[1] = new SqlParameter("@repFirstName", SqlDbType.NVarChar);
    arParms[1].Value = repFirstName;
    arParms[2] = new SqlParameter("@repLastName", SqlDbType.NVarChar);
    arParms[2].Value = repLastName;
    arParms[3] = new SqlParameter("@claimId", SqlDbType.Int);
    arParms[3].Value = claimId;
 


    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "changeClaimRepInfoByClaimId", arParms);
    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;

        pTransactionSuccessful = false;
    }
    return pTransactionSuccessful;
}


//modify File Size
public bool modifyFileSize(string fileSize, int filePathId)
{
    // Set up parameters in parameter array 
    SqlParameter[] arParms = new SqlParameter[2];


    arParms[0] = new SqlParameter("@fileSize", SqlDbType.NVarChar);
    arParms[0].Value = fileSize;
    arParms[1] = new SqlParameter("@filePathId", SqlDbType.Int);
    arParms[1].Value = filePathId;


    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "modifyFileSize", arParms);
    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;

        pTransactionSuccessful = false;
    }
    return pTransactionSuccessful;
}
//Change Status of the file
public bool changeFileCheckedStatus(bool isChecked, int filePathId)
{
    // Set up parameters in parameter array 
    SqlParameter[] arParms = new SqlParameter[2];


    arParms[0] = new SqlParameter("@isChecked", SqlDbType.Bit);
    arParms[0].Value = isChecked;
    arParms[1] = new SqlParameter("@filePathId", SqlDbType.Int);
    arParms[1].Value = filePathId;
   

    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "changeFileCheckedStatus", arParms);
    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;

        pTransactionSuccessful = false;
    }
    return pTransactionSuccessful;
}
//Change overdue claim date
public bool modifyInvoice(int invoiceTypeId, string price, string description)
        {
            // Set up parameters in parameter array 
            SqlParameter[] arParms = new SqlParameter[3];


            arParms[0] = new SqlParameter("@invoice_type_id", SqlDbType.Int);
            arParms[0].Value = invoiceTypeId;
            arParms[1] = new SqlParameter("@price", SqlDbType.NVarChar);
            arParms[1].Value = price;
            arParms[2] = new SqlParameter("@description", SqlDbType.NVarChar);
            arParms[2].Value = description;


            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "modifyInvoiceType", arParms);
            }
            catch (SqlException InsertError)
            {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;

                pTransactionSuccessful = false;
            }
            return pTransactionSuccessful;
        }
public bool changeOverdueDate(int overdueDateID, int overdueDate)
{
    // Set up parameters in parameter array 
    SqlParameter[] arParms = new SqlParameter[2];


    arParms[0] = new SqlParameter("@overdue_date_id", SqlDbType.Int);
    arParms[0].Value = overdueDateID;
    arParms[1] = new SqlParameter("@_date", SqlDbType.Int);
    arParms[1].Value = overdueDate;


    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "changeOverdueDate", arParms);
    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;

        pTransactionSuccessful = false;
    }
    return pTransactionSuccessful;
}

//Assign adjuster to claim
public bool assignAdjusterToClaim(string claimNumber,string AdjusterEmail)
{
    // Set up parameters in parameter array 
    SqlParameter[] arParms = new SqlParameter[2];


    arParms[0] = new SqlParameter("@claim_number", SqlDbType.NVarChar);
    arParms[0].Value = claimNumber;
    arParms[1] = new SqlParameter("@Adjuster_email", SqlDbType.NVarChar);
    arParms[1].Value = AdjusterEmail;


    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "assignAdjuster", arParms);
    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;

        pTransactionSuccessful = false;
    }
    return pTransactionSuccessful;
}

//Assign role to the user/Adjuster
public bool assignUserRole(string userEmail, string roleTitle)
{
    // Set up parameters in parameter array 
    SqlParameter[] arParms = new SqlParameter[2];


    arParms[0] = new SqlParameter("@users_email", SqlDbType.NVarChar);
    arParms[0].Value = userEmail;
    arParms[1] = new SqlParameter("@role_title", SqlDbType.NVarChar);
    arParms[1].Value = roleTitle;


    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "assignRole", arParms);
    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;

        pTransactionSuccessful = false;
    }
    return pTransactionSuccessful;
}

//Change Status of the claim
public bool changeClaimStatus(string claimStatusId, bool isClaimOpen, bool isClaimClosed, bool isClaimReopened, bool isClaimCanceled)
{
    // Set up parameters in parameter array 
    SqlParameter[] arParms = new SqlParameter[5];


    arParms[0] = new SqlParameter("@claim_number", SqlDbType.NVarChar);
    arParms[0].Value = claimStatusId;
    arParms[1] = new SqlParameter("@claim_open", SqlDbType.Bit);
    arParms[1].Value = isClaimOpen;
    arParms[2] = new SqlParameter("@claim_closed", SqlDbType.Bit);
    arParms[2].Value = isClaimClosed;
    arParms[3] = new SqlParameter("@claim_reopened", SqlDbType.Bit);
    arParms[3].Value = isClaimReopened;
    arParms[4] = new SqlParameter("@claim_canceled", SqlDbType.Bit);
    arParms[4].Value = isClaimCanceled;


    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "changeClaimStatus", arParms);
    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;

        pTransactionSuccessful = false;
    }
    return pTransactionSuccessful;
}

//set the claim status
public bool setClaimStatus(string claimNumber, bool claimOpen, bool claimClosed, bool claimReopened, bool claimCanceled)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[5];

    inParams[0] = new SqlParameter("@claim_number", SqlDbType.NVarChar);
    inParams[0].Value = claimNumber;
    inParams[1] = new SqlParameter("@claim_open", SqlDbType.Bit);
    inParams[1].Value = claimOpen;
    inParams[2] = new SqlParameter("@claim_closed", SqlDbType.Bit);
    inParams[2].Value = claimClosed;
    inParams[3] = new SqlParameter("@claim_reopened", SqlDbType.Bit);
    inParams[3].Value = claimReopened;
    inParams[4] = new SqlParameter("@claim_canceled", SqlDbType.Bit);
    inParams[4].Value = claimCanceled;

    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "setClaimStatus", inParams);

    }
    catch (SqlException InsertError)
    {

        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//unassign adjuster from the claim
public bool unassignAdjuster(string claimNumber)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@claim_number", SqlDbType.NVarChar);
    inParams[0].Value = claimNumber;


    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "unassignAdjuster", inParams);

    }
    catch (SqlException InsertError)
    {

        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//set the claim status
public bool setInvoiceStatus(int invoiceId, bool paid)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@invoice_id", SqlDbType.Int);
    inParams[0].Value = invoiceId;
    inParams[1] = new SqlParameter("@paid", SqlDbType.Bit);
    inParams[1].Value = paid;


    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "setInvoiceStatus", inParams);

    }
    catch (SqlException InsertError)
    {

        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

#endregion

#region "Email"
//email close claim with files
public bool sendEmailCloseClaim(int claimid, string recipients, string fromName, string fromAddress, string replyTo, string filePath)
{
    pTransactionSuccessful = true;
    SqlParameter[] inParams = new SqlParameter[6];

    inParams[0] = new SqlParameter("@claimId", SqlDbType.Int);
    inParams[0].Value = claimid;
    inParams[1] = new SqlParameter("@recipients", SqlDbType.NVarChar);
    inParams[1].Value = recipients;
    inParams[2] = new SqlParameter("@fromName", SqlDbType.NVarChar);
    inParams[2].Value = fromName;
    inParams[3] = new SqlParameter("@from_address", SqlDbType.NVarChar);
    inParams[3].Value = fromAddress;
    inParams[4] = new SqlParameter("@reply_to", SqlDbType.NVarChar);
    inParams[4].Value = replyTo;
    inParams[5] = new SqlParameter("@file_attachments", SqlDbType.NVarChar);
    inParams[5].Value = filePath;
    try
    {
        DataSet dsEmailClaim = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sendEmailCloseClaim", inParams);
       
    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//email with no files
public bool sendEmailNoAttachment(string recipients, string fromName, string fromAddress, string replyTo, string subject, string body, string ccList, string bccList)
{
    pTransactionSuccessful = true;
    SqlParameter[] inParams = new SqlParameter[8];


    inParams[0] = new SqlParameter("@recipients", SqlDbType.NVarChar);
    inParams[0].Value = recipients;
    inParams[1] = new SqlParameter("@fromName", SqlDbType.NVarChar);
    inParams[1].Value = fromName;
    inParams[2] = new SqlParameter("@from_address", SqlDbType.NVarChar);
    inParams[2].Value = fromAddress;
    inParams[3] = new SqlParameter("@reply_to", SqlDbType.NVarChar);
    inParams[3].Value = replyTo;
    inParams[4] = new SqlParameter("@subject", SqlDbType.NVarChar);
    inParams[4].Value = subject;
    inParams[5] = new SqlParameter("@body", SqlDbType.NVarChar);
    inParams[5].Value = body;
    inParams[6] = new SqlParameter("@ccList", SqlDbType.NVarChar);
    inParams[6].Value = ccList;
    inParams[7] = new SqlParameter("@bccList", SqlDbType.NVarChar);
    inParams[7].Value = bccList;


    try
    {
        DataSet dsEmailClaim = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sendEmailNoAttachment", inParams);
       

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//email with files
public bool sendEmailWithAttachment(string recipients, string fromName, string fromAddress, string replyTo, string subject, string body, string filePath, string ccList, string bccList)
{
    pTransactionSuccessful = true;
    SqlParameter[] inParams = new SqlParameter[9];


    inParams[0] = new SqlParameter("@recipients", SqlDbType.NVarChar);
    inParams[0].Value = recipients;
    inParams[1] = new SqlParameter("@fromName", SqlDbType.NVarChar);
    inParams[1].Value = fromName;
    inParams[2] = new SqlParameter("@from_address", SqlDbType.NVarChar);
    inParams[2].Value = fromAddress;
    inParams[3] = new SqlParameter("@reply_to", SqlDbType.NVarChar);
    inParams[3].Value = replyTo;
    inParams[4] = new SqlParameter("@subject", SqlDbType.NVarChar);
    inParams[4].Value = subject;
    inParams[5] = new SqlParameter("@body", SqlDbType.NVarChar);
    inParams[5].Value = body;
    inParams[6] = new SqlParameter("@file_attachments", SqlDbType.NVarChar);
    inParams[6].Value = filePath;
    inParams[7] = new SqlParameter("@ccList", SqlDbType.NVarChar);
    inParams[7].Value = ccList;
    inParams[8] = new SqlParameter("@bccList", SqlDbType.NVarChar);
    inParams[8].Value = bccList;

    try
    {
        DataSet dsEmailClaim = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sendEmailWithAttachment", inParams);
       

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}


//Email new password
public bool emailPassword(string recipients, string fromName, string from_address, string reply_to)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[4];

    inParams[0] = new SqlParameter("@recipients", SqlDbType.NVarChar);
    inParams[0].Value = recipients;
    inParams[1] = new SqlParameter("@fromName", SqlDbType.NVarChar);
    inParams[1].Value = fromName;
    inParams[2] = new SqlParameter("@from_address", SqlDbType.NVarChar);
    inParams[2].Value = from_address;
    inParams[3] = new SqlParameter("@reply_to", SqlDbType.NVarChar);
    inParams[3].Value = reply_to;

    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "sendEmailNewPassword", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}


//Email support ticket
public bool emailSupportTicket(string userEmail, string Request)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@userEmail", SqlDbType.NVarChar);
    inParams[0].Value = userEmail;
    inParams[1] = new SqlParameter("@Request", SqlDbType.NVarChar);
    inParams[1].Value = Request;


    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "sendEmailSupportRequest", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//Email support ticket confirmation
public bool emailSupportTicketConfirmation(string userEmail, string Request)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@userEmail", SqlDbType.NVarChar);
    inParams[0].Value = userEmail;
    inParams[1] = new SqlParameter("@Request", SqlDbType.NVarChar);
    inParams[1].Value = Request;


    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "sendEmailSupportConfirmation", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//Email New Note
public bool emailNewNote(string recipients, string userEmail, string insured, string claimNumber, string note, string blindCopy, bool repChecked)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[7];

    inParams[0] = new SqlParameter("@recipients", SqlDbType.NVarChar);
    inParams[0].Value = recipients;
    inParams[1] = new SqlParameter("@userEmail", SqlDbType.NVarChar);
    inParams[1].Value = userEmail;
    inParams[2] = new SqlParameter("@insured", SqlDbType.NVarChar);
    inParams[2].Value = insured;
    inParams[3] = new SqlParameter("@claimNumber", SqlDbType.NVarChar);
    inParams[3].Value = claimNumber;
    inParams[4] = new SqlParameter("@Notes", SqlDbType.NVarChar);
    inParams[4].Value = note;
    inParams[5] = new SqlParameter("@blindCopy", SqlDbType.NVarChar);
    inParams[5].Value = blindCopy;
    inParams[6] = new SqlParameter("@repChecked", SqlDbType.Bit);
    inParams[6].Value = repChecked;
    
    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "sendEmailNewNote", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}


#endregion


#region "Update"
//modify claim info 
public bool modifyClaim(int claimId, string claimNumber, string insuredFirstName, string insuredLastName, string insuredStreet, string insuredCity, string insuredState, string insuredZip, string insurCarrier, string repFirstName, string repLastName, string repemail, string policyNumber, string policyType, DateTime dateLoss, string typeOfLoss, DateTime dateReceived, string insur_altPhone, string insur_primaryPhone, string latitude, string longitude)
{
    //returns false if operation failed
    SqlParameter[] inParams = new SqlParameter[21];

    inParams[0] = new SqlParameter("@claim_number", SqlDbType.NVarChar);
    inParams[0].Value = claimNumber;
    inParams[1] = new SqlParameter("@insured_firstName", SqlDbType.NVarChar);
    inParams[1].Value = insuredFirstName;
    inParams[2] = new SqlParameter("@insured_lastName", SqlDbType.NVarChar);
    inParams[2].Value = insuredLastName;
    inParams[3] = new SqlParameter("@insured_street", SqlDbType.NVarChar);
    inParams[3].Value = insuredStreet;
    inParams[4] = new SqlParameter("@insured_city", SqlDbType.NVarChar);
    inParams[4].Value = insuredCity;
    inParams[5] = new SqlParameter("@insured_state", SqlDbType.NVarChar);
    inParams[5].Value = insuredState;
    inParams[6] = new SqlParameter("@insured_zip", SqlDbType.NVarChar);
    inParams[6].Value = insuredZip;
    inParams[7] = new SqlParameter("@insur_carrier", SqlDbType.NVarChar);
    inParams[7].Value = insurCarrier;
    inParams[8] = new SqlParameter("@rep_firstName", SqlDbType.NVarChar);
    inParams[8].Value = repFirstName;
    inParams[9] = new SqlParameter("@rep_lastName", SqlDbType.NVarChar);
    inParams[9].Value = repLastName;
    inParams[10] = new SqlParameter("@rep_email", SqlDbType.NVarChar);
    inParams[10].Value = repemail;
    inParams[11] = new SqlParameter("@policy_number", SqlDbType.NVarChar);
    inParams[11].Value = policyNumber;
    inParams[12] = new SqlParameter("@policy_type", SqlDbType.NVarChar);
    inParams[12].Value = policyType;
    inParams[13] = new SqlParameter("@date_loss", SqlDbType.Date);
    inParams[13].Value = dateLoss;
    inParams[14] = new SqlParameter("@type_of_loss", SqlDbType.NVarChar);
    inParams[14].Value = typeOfLoss;
    inParams[15] = new SqlParameter("@date_received", SqlDbType.Date);
    inParams[15].Value = dateReceived;
    inParams[16] = new SqlParameter("@insur_altPhone", SqlDbType.NVarChar);
    inParams[16].Value = insur_altPhone;
    inParams[17] = new SqlParameter("@insur_primaryPhone", SqlDbType.NVarChar);
    inParams[17].Value = insur_primaryPhone;
    inParams[18] = new SqlParameter("@claims_id", SqlDbType.Int);
    inParams[18].Value = claimId;
    inParams[19] = new SqlParameter("@latitude", SqlDbType.VarChar);
    inParams[19].Value = latitude;
    inParams[20] = new SqlParameter("@longitude", SqlDbType.VarChar);
    inParams[20].Value = longitude;


    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "modifyClaim", inParams);

    }
    catch (SqlException InsertError)
    {

        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//modify user password
public bool modifyPassword(string password, string email)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@p_word", SqlDbType.NVarChar);
    inParams[0].Value = password;
    inParams[1] = new SqlParameter("@email", SqlDbType.NVarChar);
    inParams[1].Value = email;




    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "modifyPassword", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//Modify Loss Type
public bool modifyLossType(int claimId, string lossType)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@claims_id", SqlDbType.Int);
    inParams[0].Value = claimId;
    inParams[1] = new SqlParameter("@lossType", SqlDbType.NVarChar);
    inParams[1].Value = lossType;

    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "modifyLossType", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}


//Mark Invoice as paid
public bool markInvoicePaid(int invoiceId, int modifiedBy)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@invoice_id", SqlDbType.Int);
    inParams[0].Value = invoiceId;
    inParams[1] = new SqlParameter("@modifiedBy", SqlDbType.Int);
    inParams[1].Value = modifiedBy;
  
    
    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "markInvoicePaid", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//Mark Invoice as paid
public bool updateInvoiceSubmitDate(int claimId)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@claimId", SqlDbType.Int);
    inParams[0].Value = claimId;


    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "updateInvoiceSubmitDate", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//Mark Invoice as Unpaid
public bool markInvoiceUnPaid(int invoiceId, int modifiedBy)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[2];

    inParams[0] = new SqlParameter("@invoice_id", SqlDbType.Int);
    inParams[0].Value = invoiceId;
    inParams[1] = new SqlParameter("@modifiedBy", SqlDbType.Int);
    inParams[1].Value = modifiedBy;
  


    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "markInvoiceUnPaid", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//modify company info
public bool modifyCompany(int companyId, string companyName, string companyAddress, string companyCity, string companyState, string companyZip, string companyPhone,string companyEmail)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[8];
    inParams[0] = new SqlParameter("@companyId", SqlDbType.Int);
    inParams[0].Value = companyId;
    inParams[1] = new SqlParameter("@company_name", SqlDbType.NVarChar);
    inParams[1].Value = companyName;
    inParams[2] = new SqlParameter("@company_address", SqlDbType.NVarChar);
    inParams[2].Value = companyAddress;
    inParams[3] = new SqlParameter("@company_city", SqlDbType.NVarChar);
    inParams[3].Value = companyCity;
    inParams[4] = new SqlParameter("@company_state", SqlDbType.NVarChar);
    inParams[4].Value = companyState;
    inParams[5] = new SqlParameter("@company_zip", SqlDbType.NVarChar);
    inParams[5].Value = companyZip;
    inParams[6] = new SqlParameter("@company_phone", SqlDbType.NVarChar);
    inParams[6].Value = companyPhone;
    inParams[7] = new SqlParameter("@company_email", SqlDbType.NVarChar);
    inParams[7].Value = companyEmail;
    



    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "modifyCompany", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//update Attempted Login by user
public bool updateUsersAttemptedLogin(string email)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@e_mail", SqlDbType.NVarChar);
    inParams[0].Value = email;
   


    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "updateUsersAttemptLogin", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//disable Adjuster Status
public bool disableAdjusterStatus(int userId)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@userId", SqlDbType.Int);
    inParams[0].Value = userId;



    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "disableAdjusterStatus", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}


//enable Adjuster Status
public bool enableAdjusterStatus(int userId)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@userId", SqlDbType.Int);
    inParams[0].Value = userId;



    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "enableAdjusterStatus", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//Lock the user
public bool lockUser(string email)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@e_mail", SqlDbType.NVarChar);
    inParams[0].Value = email;
    


    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "lockUser", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//Un Lock the user
public bool unLockUser(string email)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[1];

    inParams[0] = new SqlParameter("@e_mail", SqlDbType.NVarChar);
    inParams[0].Value = email;



    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "UnlockUser", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

 //update role
public bool updateRole(string role_title, int userId)
        {
            //returns false if operation failed

            SqlParameter[] inParams = new SqlParameter[2];

            inParams[0] = new SqlParameter("@role_title", SqlDbType.NVarChar);
            inParams[0].Value = role_title;
            inParams[1] = new SqlParameter("@users_id", SqlDbType.Int);
            inParams[1].Value = userId;
           


            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "modifyRole", inParams);

            }
            catch (SqlException InsertError)
            {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;
                pTransactionSuccessful = false;

            }
            return pTransactionSuccessful;
        }


//modify user info
public bool modifyUsers(string firstName, string lastName, string Street, string City, string State, string zipCode, string Telephone, string altPhone, string EmailOld, string Email, string Title, string symbilityId)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[12];

    inParams[0] = new SqlParameter("@f_name", SqlDbType.NVarChar);
    inParams[0].Value = firstName;
    inParams[1] = new SqlParameter("@l_name", SqlDbType.NVarChar);
    inParams[1].Value = lastName;
    inParams[2] = new SqlParameter("@_street", SqlDbType.NVarChar);
    inParams[2].Value = Street;
    inParams[3] = new SqlParameter("@_city", SqlDbType.NVarChar);
    inParams[3].Value = City;
    inParams[4] = new SqlParameter("@_state", SqlDbType.NVarChar);
    inParams[4].Value = State;
    inParams[5] = new SqlParameter("@z_code", SqlDbType.NVarChar);
    inParams[5].Value = zipCode;
    inParams[6] = new SqlParameter("@t_phone", SqlDbType.NVarChar);
    inParams[6].Value = Telephone;
    inParams[7] = new SqlParameter("@alt_phone", SqlDbType.NVarChar);
    inParams[7].Value = altPhone;
    inParams[8] = new SqlParameter("@e_mailold", SqlDbType.NVarChar);
    inParams[8].Value = EmailOld;
    inParams[9] = new SqlParameter("@e_mail", SqlDbType.NVarChar);
    inParams[9].Value = Email;
    inParams[10] = new SqlParameter("@_title", SqlDbType.NVarChar);
    inParams[10].Value = Title;
    inParams[11] = new SqlParameter("@symbilityId", SqlDbType.NVarChar);
    inParams[11].Value = symbilityId;



    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "modifyUsers", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}

//update users
public bool updateUsers(string firstName, string lastName, string Street, string City, string State, string zipCode, string Telephone, string altPhone, string emailOld, string Email, string Password)
{
    //returns false if operation failed

    SqlParameter[] inParams = new SqlParameter[11];

    inParams[0] = new SqlParameter("@f_name", SqlDbType.NVarChar);
    inParams[0].Value = firstName;
    inParams[1] = new SqlParameter("@l_name", SqlDbType.NVarChar);
    inParams[1].Value = lastName;
    inParams[2] = new SqlParameter("@_street", SqlDbType.NVarChar);
    inParams[2].Value = Street;
    inParams[3] = new SqlParameter("@_city", SqlDbType.NVarChar);
    inParams[3].Value = City;
    inParams[4] = new SqlParameter("@_state", SqlDbType.NVarChar);
    inParams[4].Value = State;
    inParams[5] = new SqlParameter("@z_code", SqlDbType.NVarChar);
    inParams[5].Value = zipCode;
    inParams[6] = new SqlParameter("@t_phone", SqlDbType.NVarChar);
    inParams[6].Value = Telephone;
    inParams[7] = new SqlParameter("@alt_phone", SqlDbType.NVarChar);
    inParams[7].Value = altPhone;
    inParams[8] = new SqlParameter("@e_mailold", SqlDbType.NVarChar);
    inParams[8].Value = emailOld;
    inParams[9] = new SqlParameter("@e_mail", SqlDbType.NVarChar);
    inParams[9].Value = Email;
    inParams[10] = new SqlParameter("@p_word", SqlDbType.NVarChar);
    inParams[10].Value = Password;



    pTransactionSuccessful = true;

    try
    {
        SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "updateUsers", inParams);

    }
    catch (SqlException InsertError)
    {
        pErrorMessage = InsertError.Message.ToString();
        pErrorNumber = InsertError.Number;
        pErrorClass = InsertError.Class;
        pErrorState = InsertError.State;
        pErrorLineNumber = InsertError.LineNumber;
        pTransactionSuccessful = false;

    }
    return pTransactionSuccessful;
}


 //update Claim Rep
 public bool updateRep(int Id, string firstName, string lastName, string Company, string Email)
        {
            //returns false if operation failed

            SqlParameter[] inParams = new SqlParameter[5];

            inParams[0] = new SqlParameter("@rep_id", SqlDbType.Int);
            inParams[0].Value = Id;
            inParams[1] = new SqlParameter("@rep_firstName", SqlDbType.NVarChar);
            inParams[1].Value = firstName;
            inParams[2] = new SqlParameter("@rep_lastName", SqlDbType.NVarChar);
            inParams[2].Value = lastName;
            inParams[3] = new SqlParameter("@company_name", SqlDbType.NVarChar);
            inParams[3].Value = Company;
            inParams[4] = new SqlParameter("@rep_email", SqlDbType.NVarChar);
            inParams[4].Value = Email;

            


            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "modifyRep", inParams);

            }
            catch (SqlException InsertError)
            {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;
                pTransactionSuccessful = false;

            }
            return pTransactionSuccessful;
        }


        //update SMTP info
        public bool updateSmtp(string smtpHost, string smtpEmail, string smtpPassword, string smtpPort)
        {
            //returns false if operation failed

            SqlParameter[] inParams = new SqlParameter[4];

            inParams[0] = new SqlParameter("@smtpHost", SqlDbType.NVarChar);
            inParams[0].Value = smtpHost;
            inParams[1] = new SqlParameter("@smtpEmail", SqlDbType.NVarChar);
            inParams[1].Value = smtpEmail;
            inParams[2] = new SqlParameter("@smtpPassword", SqlDbType.NVarChar);
            inParams[2].Value = smtpPassword;
            inParams[3] = new SqlParameter("@smtpPort", SqlDbType.NVarChar);
            inParams[3].Value = smtpPort;
            


            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "updateSmtp", inParams);

            }
            catch (SqlException InsertError)
            {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;
                pTransactionSuccessful = false;

            }
            return pTransactionSuccessful;
        }


        //Change Claim Invoice Type
        public bool changeClaimInvoiceType(string claimNumber, string invoiceType)
        {
            
            SqlParameter[] inParams = new SqlParameter[2];

            inParams[0] = new SqlParameter("@claim_number", SqlDbType.NVarChar);
            inParams[0].Value = claimNumber;
            inParams[1] = new SqlParameter("@insur_carrier", SqlDbType.NVarChar);
            inParams[1].Value = invoiceType;
            



            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "changeClaimInvoiceType", inParams);

            }
            catch (SqlException InsertError)
            {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;
                pTransactionSuccessful = false;

            }
            return pTransactionSuccessful;
        }

        //inserts latitude and longitude into previous claims
        public bool insertLatLong(int claimId, string latitude, string longitude)
        {
            //returns false if operation failed
            SqlParameter[] inParams = new SqlParameter[3];


            inParams[0] = new SqlParameter("@claim_id", SqlDbType.Int);
            inParams[0].Value = claimId;
            inParams[1] = new SqlParameter("@latitude", SqlDbType.VarChar);
            inParams[1].Value = latitude;
            inParams[2] = new SqlParameter("@longitude", SqlDbType.VarChar);
            inParams[2].Value = longitude;


            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "insertLatitudeLongitude", inParams);

            }
            catch (SqlException InsertError)
            {

                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;
                pTransactionSuccessful = false;

            }
            return pTransactionSuccessful;
        }


        #endregion

 #region "Loss Type"
        //get all loss types
        public DataTable getLossType()
        {
            DataTable dtLossType = new DataTable("lossType");

            pTransactionSuccessful = true;

            try
            {
                DataSet dsLossType = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getLossType");
                dtLossType = dsLossType.Tables[0];

            }
            catch (SqlException InsertError)
            {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;
                pTransactionSuccessful = false;

            }
            return dtLossType;
        }
        //insert loss type
        public bool insertLossType(string lossType)
        {
            //returns false if operation failed

            SqlParameter[] inParams = new SqlParameter[1];

            inParams[0] = new SqlParameter("@loss_type", SqlDbType.NVarChar);
            inParams[0].Value = lossType;


            pTransactionSuccessful = true;

            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "addNewLossType", inParams);

            }
            catch (SqlException InsertError)
            {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;
                pTransactionSuccessful = false;

            }
            return pTransactionSuccessful;
        }
        //checks if loss type exists
        public void checkLossType(string lossType)
        {
            SqlParameter[] inParams = new SqlParameter[2];

            inParams[0] = new SqlParameter("@loss_type", SqlDbType.NVarChar);
            inParams[0].Value = lossType;
            inParams[1] = new SqlParameter("@isFound", SqlDbType.Bit);
            inParams[1].Direction = ParameterDirection.Output;

            pTransactionSuccessful = true;
            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "checkLossType", inParams);

            }
            catch (SqlException InsertError)
            {
                pErrorMessage = InsertError.Message.ToString();
                pErrorNumber = InsertError.Number;
                pErrorClass = InsertError.Class;
                pErrorState = InsertError.State;
                pErrorLineNumber = InsertError.LineNumber;
                pTransactionSuccessful = false;
            }
            pisLossTypeFound = (bool)inParams[1].Value;

        }


        #endregion

    }




}
