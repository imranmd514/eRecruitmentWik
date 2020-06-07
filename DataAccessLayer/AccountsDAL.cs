using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CommonDB;
using Models;
using Utils;

namespace DataAccessLayer
{
    public class AccountsDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public static string ProcGetPasswordData= "usp_SCH_GetPassword";
        public string GetPasswordData(string strEmailAddress,string strPassword)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDbParameter = null;
            string strResult = "";
            
            try
            {
                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@strEmailAddress";
                objDbParameter.dbType = DbType.String;
                objDbParameter.ParameterValue = strEmailAddress;
                objProcParameterBOList.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@strPassword";
                objDbParameter.dbType = DbType.String;
                objDbParameter.ParameterValue = strPassword;
                objProcParameterBOList.Add(objDbParameter);


                strResult = objDBAccess.executeScalar(ProcGetPasswordData, ref objProcParameterBOList).ToString();
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "GetPasswordData");
                strResult = "FAILED";
                throw ex;
            }

            return strResult;
        }
    }
}
