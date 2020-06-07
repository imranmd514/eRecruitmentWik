using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace DataAccess
{
    public class SecurityDAL
    {
        DBAccess objDbAccess = new DBAccess();
        public UserMasterBO verifyLogin(string strUserName, string strPassword, ref string strResult)
        {

            List<ProcParameterBO> objList = new List<ProcParameterBO>();
            ProcParameterBO objDbParameter = null;
            UserMasterBO objUserMasterBO = null;
            DataSet objDataSet = null;
            try
            {
                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@strUserName";
                objDbParameter.dbType = DbType.String;
                objDbParameter.ParameterValue = strUserName;
                objList.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@strPassword";
                objDbParameter.dbType = DbType.String;
                objDbParameter.ParameterValue = strPassword;
                objList.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Output;
                objDbParameter.ParameterName = "@strStatus";
                objDbParameter.dbType = DbType.String;
                objDbParameter.Size = 100;
                objList.Add(objDbParameter);

                objDataSet = objDbAccess.execuitDataSet("usp_SCH_VerifyLogin", ref objList);

                for (int i = 0; i < objList.Count; i++)
                {
                    if (objList[i].Direction == ParameterDirection.Output)
                    {
                        strResult = objList[i].ParameterValue.ToString();
                    }
                }
                if (strResult == "SUCCESS")
                {

                    if (objDataSet != null && objDataSet.Tables.Count > 0)
                    {
                        for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                        {
                            objUserMasterBO = new UserMasterBO();
                            objUserMasterBO.UserId = objDataSet.Tables[0].Rows[i][0].ToString();
                            objUserMasterBO.FirstName = objDataSet.Tables[0].Rows[i][1].ToString();
                            objUserMasterBO.LastName = objDataSet.Tables[0].Rows[i][2].ToString();
                            objUserMasterBO.UserName = objDataSet.Tables[0].Rows[i][3].ToString();
                            objUserMasterBO.EmailId = objDataSet.Tables[0].Rows[i][4].ToString();
                            objUserMasterBO.Gender = objDataSet.Tables[0].Rows[i][5].ToString();
                            objUserMasterBO.Address = objDataSet.Tables[0].Rows[i][6].ToString();
                            objUserMasterBO.PhoneNo = objDataSet.Tables[0].Rows[i][7].ToString();
                            objUserMasterBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[i][8].ToString());
                            objUserMasterBO.RoleId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][9].ToString());
                            objUserMasterBO.RoleName = objDataSet.Tables[0].Rows[i][10].ToString();
                            objUserMasterBO.EmployeeId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][11].ToString());
                        }
                    }
                }

            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "verifyLogin");
                strResult = "FAILED";
                throw ex;
            }
            return objUserMasterBO;
        }
    }
}
