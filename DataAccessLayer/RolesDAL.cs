using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class RolesDAL
    {
        DBAccess objDBAccess = new DBAccess();

        //Roles List
        public static string ProcGetRolesList = "usp_SCH_RolesList";
        public List<RolesBO> getRolesList()
        {
            DataSet objDataSet = null;
            RolesBO objRolesBO = null;
            List<RolesBO> objRolesBOList = new List<RolesBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcGetRolesList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objRolesBO = new RolesBO();
                        objRolesBO.RoleId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objRolesBO.RoleName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objRolesBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[i][2].ToString());
                        objRolesBOList.Add(objRolesBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getRolesList");
                throw ex;
            }
            return objRolesBOList;
        }

        //Save Role
        public static string ProcSaveRole = "usp_SCH_saveRole";
        public string SaveorUpdateRole(RolesBO objRolesBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iRoleId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objRolesBO.RoleId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strRoleName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objRolesBO.RoleName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strDescription";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objRolesBO.Description;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objRolesBO.IsActive;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iUserId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = iUserId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Output;
                objDBparameter.ParameterName = "@strResult";
                objDBparameter.dbType = DbType.String;
                objDBparameter.Size = 100;
                objProcParameterBOList.Add(objDBparameter);



                objDBAccess.executeNonQuery(ProcSaveRole, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveorUpdateRole");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        //Edit Role
        public static string ProcEditRole = "usp_SCH_editRole";
        public RolesBO EditRole(int iRoleId)
        {
            DataSet objDataSet = null;
            RolesBO objRolesBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iRoleId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iRoleId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditRole, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objRolesBO = new RolesBO();
                    objRolesBO.RoleId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objRolesBO.RoleName = objDataSet.Tables[0].Rows[0][1].ToString();
                    objRolesBO.Description = objDataSet.Tables[0].Rows[0][2].ToString();
                    objRolesBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][3].ToString());
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditRole");
                throw ex;
            }
            return objRolesBO;
        }

        //Delete Role
        public static string ProcDeleteRole = "usp_SCH_deleteRole";
        public string deleteRole(int iRoleId)
        {
            string strResult = "";
            try
            {
                List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
                ProcParameterBO objDbParameter = null;

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iRoleId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iRoleId;
                objProcParameterBOList.Add(objDbParameter);

                objDBAccess.executeNonQuery(ProcDeleteRole, ref objProcParameterBOList);
                strResult = "DELETED";
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "deleteRole");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }
    }
}
