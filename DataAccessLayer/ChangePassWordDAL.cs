using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using CommonDB;
using Utils;

namespace DataAccessLayer
{
    public class ChangePassWordDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public static string ProcGetEmailAddress = "usp_SCH_GetEmailAddress";
        public ChangePassWordBO GetEmailAddress(int iUserId)
        {
            DataSet objDataSet = null;
            ChangePassWordBO objChangePassWordBO = null;
            List<ProcParameterBO> objListProcParameterBo = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iUserId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iUserId;
                objListProcParameterBo.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcGetEmailAddress, ref objListProcParameterBo);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objChangePassWordBO = new ChangePassWordBO();
                    objChangePassWordBO.UserId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objChangePassWordBO.EmailAddress = objDataSet.Tables[0].Rows[0][1].ToString();
                }
            }
            catch (Exception EX)
            {
                ExceptionError.Error_Log(EX, "GetEmailAddress");
                throw EX;
            }
            return objChangePassWordBO;
        }

        public static string ProcSaveChangePassword = "usp_SCH_ChangePassword";
        public string SaveChangePassword(ChangePassWordBO objChangePassWordBO, int A_iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iUserId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = A_iUserId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strEmailAddress";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objChangePassWordBO.EmailAddress;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strOldPassword";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objChangePassWordBO.OldPassword;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strNewPassword";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objChangePassWordBO.NewPassword;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objChangePassWordBO.IsActive;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@buserid";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = A_iUserId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Output;
                objDBparameter.ParameterName = "@strResult";
                objDBparameter.dbType = DbType.String;
                objDBparameter.Size = 100;
                objProcParameterBOList.Add(objDBparameter);


                objDBAccess.executeNonQuery(ProcSaveChangePassword, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveChangePassword");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }
    }
}
