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
    public class TypeOfIndustryMasterDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public static string ProcGetTypeOfIndustryMasterList = "usp_SCH_GetTypeOfIndustryMasterListDetails";
        public List<TypeOfIndustryMasterBO> GetTypeOfIndustryList()
        {
            DataSet objDataSet = null;
            TypeOfIndustryMasterBO objTypeOfIndustryMasterBO = null;
            List<TypeOfIndustryMasterBO> objTypeOfIndustryMasterBOList = new List<TypeOfIndustryMasterBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcGetTypeOfIndustryMasterList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objTypeOfIndustryMasterBO = new TypeOfIndustryMasterBO();
                        objTypeOfIndustryMasterBO.TypeOfIndustryId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objTypeOfIndustryMasterBO.TypeOfIndustry = objDataSet.Tables[0].Rows[i][1].ToString();
                        objTypeOfIndustryMasterBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[i][2].ToString());
                        objTypeOfIndustryMasterBOList.Add(objTypeOfIndustryMasterBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "GetTypeOfIndustryList");
                throw ex;
            }
            return objTypeOfIndustryMasterBOList;
        }


        public static string ProcSaveorUpdateTypeOfIndustry = "usp_SCH_SaveorUpdateTypeOfIndustry";
        public string SaveorUpdateTypeOfIndustry(TypeOfIndustryMasterBO objTypeOfIndustryMasterBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iTypeOfIndustryId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objTypeOfIndustryMasterBO.TypeOfIndustryId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strTypeOfIndustry";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objTypeOfIndustryMasterBO.TypeOfIndustry;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objTypeOfIndustryMasterBO.IsActive;
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


                objDBAccess.executeNonQuery(ProcSaveorUpdateTypeOfIndustry, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveorUpdateTypeOfIndustry");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }


        public static string ProcEditTypeOfIndustryMaster = "usp_SCH_EditTypeOfIndustry";
        public TypeOfIndustryMasterBO EditTypeOfIndustryMaster(int iTypeOfIndustryId)
        {
            DataSet objDataSet = null;
            TypeOfIndustryMasterBO objTypeOfIndustryMasterBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iTypeOfIndustryId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iTypeOfIndustryId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditTypeOfIndustryMaster, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objTypeOfIndustryMasterBO = new TypeOfIndustryMasterBO();
                    objTypeOfIndustryMasterBO.TypeOfIndustryId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objTypeOfIndustryMasterBO.TypeOfIndustry = objDataSet.Tables[0].Rows[0][1].ToString();
                    objTypeOfIndustryMasterBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][2].ToString());
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditTypeOfIndustryMaster");
                throw ex;
            }
            return objTypeOfIndustryMasterBO;
        }


        public static string ProcDeleteTypeOfIndustry= "usp_SCH_DeleteTypeOfIndustry";
        public string DeleteTypeOfIndustry(int iTypeOfIndustryId)
        {
            string strResult = "";
            try
            {
                List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
                ProcParameterBO objDbParameter = null;

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iTypeOfIndustryId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iTypeOfIndustryId;
                objProcParameterBOList.Add(objDbParameter);

                objDBAccess.executeNonQuery(ProcDeleteTypeOfIndustry, ref objProcParameterBOList);
                strResult = "DELETED";
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "DeleteTypeOfIndustry");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }
    }
}
