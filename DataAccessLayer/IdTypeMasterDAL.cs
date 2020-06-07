using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models;
using CommonDB;
using Utils;

namespace DataAccessLayer
{
    public class IdTypeMasterDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public static string ProcGetIdTypeMasterList = "usp_SCH_GetIdTypeMasterListDetails";
        public List<IdTypeMasterBO> GetIdTypeMasterList()
        {
            DataSet objDataSet = null;
            IdTypeMasterBO objIdTypeMasterBO = null;
            List<IdTypeMasterBO> objIdTypeMasterBOList = new List<IdTypeMasterBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcGetIdTypeMasterList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objIdTypeMasterBO = new IdTypeMasterBO();
                        objIdTypeMasterBO.IdTypeMasterId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objIdTypeMasterBO.IdType = objDataSet.Tables[0].Rows[i][1].ToString();
                        objIdTypeMasterBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[i][2].ToString());
                        objIdTypeMasterBOList.Add(objIdTypeMasterBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "GetIdTypeMasterList");
                throw ex;
            }
            return objIdTypeMasterBOList;
        }

        public static string ProcSaveorUpdateIdTypeMaster = "usp_SCH_SaveorUpdateIdTypeMaster";
        public string SaveorUpdateIdTypeMaster(IdTypeMasterBO objIdTypeMasterBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iIdTypeMasterId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objIdTypeMasterBO.IdTypeMasterId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strIdType";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objIdTypeMasterBO.IdType;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objIdTypeMasterBO.IsActive;
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


                objDBAccess.executeNonQuery(ProcSaveorUpdateIdTypeMaster, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveorUpdateIdTypeMaster");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        public static string ProcEditIdTypeMaster = "usp_SCH_EditIdTypeMaster";
        public IdTypeMasterBO EditIdTypeMaster(int iIdTypeMasterId)
        {
            DataSet objDataSet = null;
            IdTypeMasterBO objIdTypeMasterBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iIdTypeMasterId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iIdTypeMasterId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditIdTypeMaster, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objIdTypeMasterBO = new IdTypeMasterBO();
                    objIdTypeMasterBO.IdTypeMasterId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objIdTypeMasterBO.IdType = objDataSet.Tables[0].Rows[0][1].ToString();
                    objIdTypeMasterBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][2].ToString());
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditIdTypeMaster");
                throw ex;
            }
            return objIdTypeMasterBO;
        }


        public static string ProcDeleteIdTypeMaster = "usp_SCH_DeleteIdTypeMaster";
        public string DeleteIdTypeMaster(int iIdTypeMasterId)
        {
            string strResult = "";
            try
            {
                List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
                ProcParameterBO objDbParameter = null;

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iIdTypeMasterId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iIdTypeMasterId;
                objProcParameterBOList.Add(objDbParameter);

                objDBAccess.executeNonQuery(ProcDeleteIdTypeMaster, ref objProcParameterBOList);
                strResult = "DELETED";
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "DeleteIdTypeMaster");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

    }
}
