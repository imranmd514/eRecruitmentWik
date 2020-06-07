using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using CommonDB;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class ProfileDAL
    {
        DBAccess objDBAccess = new DBAccess();

        //View User

        public static string ProcViewUser = "usp_SCH_GetUserProfile";
        public ProfileBO DisplayUser(int iUserId)
        {
            DataSet objDataSet = null;
            ProfileBO objProfileBO = null;
            List<ProcParameterBO> ObjProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iUserId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iUserId;
                ObjProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcViewUser, ref ObjProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objProfileBO = new ProfileBO();
                    objProfileBO.UserId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objProfileBO.FirstName = objDataSet.Tables[0].Rows[0][1].ToString();
                    objProfileBO.MiddleName = objDataSet.Tables[0].Rows[0][2].ToString();
                    objProfileBO.LastName = objDataSet.Tables[0].Rows[0][3].ToString();
                    objProfileBO.Gender = objDataSet.Tables[0].Rows[0][4].ToString();
                    objProfileBO.MobileNumber = objDataSet.Tables[0].Rows[0][5].ToString();
                    objProfileBO.AlternateMobileNumber = objDataSet.Tables[0].Rows[0][6].ToString();
                    objProfileBO.EmailAddress = objDataSet.Tables[0].Rows[0][7].ToString();
                    objProfileBO.Language = objDataSet.Tables[0].Rows[0][8].ToString();
                    objProfileBO.Qualification = objDataSet.Tables[0].Rows[0][9].ToString();
                    objProfileBO.Country = objDataSet.Tables[0].Rows[0][10].ToString();
                    objProfileBO.City = objDataSet.Tables[0].Rows[0][11].ToString();
                    objProfileBO.RoleName = objDataSet.Tables[0].Rows[0][12].ToString();
                    objProfileBO.Department = objDataSet.Tables[0].Rows[0][13].ToString();
                    objProfileBO.Address = objDataSet.Tables[0].Rows[0][14].ToString();
                    objProfileBO.Photo = objDataSet.Tables[0].Rows[0][15].ToString();
                    objProfileBO.ActualFileName = objDataSet.Tables[0].Rows[0][16].ToString();
                   
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "DisplayUser");
                throw ex;
            }
            return objProfileBO;
        }
    }
}
