using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDB;
using Models;
using System.Data;
using Utils;


namespace DataAccessLayer
{
    public class ApplicantRegisterDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public static string ProcSaveApplicantRegisterEmail= "usp_SCH_SaveApplicantRegisterEmail";
        public string SaveorUpdateApplicantRegisterEmail(EmailAddressBO objEmailAddressBO, string strPassword, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strPassword";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = strPassword;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objEmailAddressBO.ApplicantId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strEmailAddress";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objEmailAddressBO.EmailAddress;
                objProcParameterBOList.Add(objDBparameter);                
                
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Output;
                objDBparameter.ParameterName = "@strResult";
                objDBparameter.dbType = DbType.String;
                objDBparameter.Size = 100;
                objProcParameterBOList.Add(objDBparameter);

                objDBAccess.executeNonQuery(ProcSaveApplicantRegisterEmail, ref objProcParameterBOList);

                for (int i = 0; i < objProcParameterBOList.Count; i++)
                {
                    if (objProcParameterBOList[i].Direction == ParameterDirection.Output)
                    {
                        strResult = objProcParameterBOList[i].ParameterValue.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "SaveorUpdateApplicantRegisterEmail");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }
    }
}
