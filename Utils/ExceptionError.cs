using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CommonDB;

namespace Utils
{
    public class ExceptionError
    {
        public const string ProcSaveExceptionError = "usp_SCH_SaveExceptionError";
        public static string Error_Log(Exception exc, string source)
        {
            DBAccess objDBAccess = new DBAccess();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDbParameter = null;
            string strResult = null;
            try
            {
                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@strStackTrace";
                objDbParameter.dbType = DbType.String;
                objDbParameter.ParameterValue = exc.StackTrace;
                objProcParameterBOList.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@strInnerException";
                objDbParameter.dbType = DbType.String;
                objDbParameter.ParameterValue = exc.InnerException;
                objProcParameterBOList.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@strMessage";
                objDbParameter.dbType = DbType.String;
                objDbParameter.ParameterValue = exc.Message;
                objProcParameterBOList.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@strSource";
                objDbParameter.dbType = DbType.String;
                objDbParameter.ParameterValue = source;
                objProcParameterBOList.Add(objDbParameter);

                objDBAccess.executeNonQuery(ProcSaveExceptionError, ref objProcParameterBOList);

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
                strResult = "FAILED";
            }
            return strResult;
        }
    }
}
