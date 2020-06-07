using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class OrganizationMasterDAL
    {

        DBAccess objDBAccess = new DBAccess();

        public static string ProcselectOrganizationList = "usp_SCH_selectOrganisationList";
        public List<OrganizationMasterBO> selectOrganisationList()
        {
            DataSet objDataSet = null;
            OrganizationMasterBO objOrganizationMasterBO = null;
            List<OrganizationMasterBO> objListOrganizationMasterBO = new List<OrganizationMasterBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcselectOrganizationList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objOrganizationMasterBO = new OrganizationMasterBO();
                        objOrganizationMasterBO.OrganisationId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objOrganizationMasterBO.OrganisationName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objOrganizationMasterBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][3].ToString());
                        objListOrganizationMasterBO.Add(objOrganizationMasterBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "selectOrganisationList");
                throw ex;
            }
            return objListOrganizationMasterBO;
        }

        //Save Branch

        public static string ProcsaveOrganizationMaster = "usp_SCH_saveOrganizationMaster";
        public string SaveorUpdateOrganizationMaster(OrganizationMasterBO objOrganizationMasterBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iOrganisationId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objOrganizationMasterBO.OrganisationId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strOrganisationName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objOrganizationMasterBO.OrganisationName;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strDetails";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objOrganizationMasterBO.Details;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objOrganizationMasterBO.IsActive;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iUserId";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = iUserId;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Output;
                objDBparameter.ParameterName = "@strResult";
                objDBparameter.dbType = DbType.String;
                objDBparameter.Size = 100;
                objProcParameterBOList.Add(objDBparameter);


                objDBAccess.executeNonQuery(ProcsaveOrganizationMaster, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveorUpdateOrganizationMaster");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        //Edit Branch

        public static string ProcEditOrganization = "usp_SCH_EditOrganization";
        public OrganizationMasterBO EditOrganization(int iOrganisationId)
        {
            DataSet objDataSet = null;
            OrganizationMasterBO objOrganizationMasterBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iOrganisationId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iOrganisationId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditOrganization, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objOrganizationMasterBO = new OrganizationMasterBO();
                    objOrganizationMasterBO.OrganisationId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objOrganizationMasterBO.OrganisationName = objDataSet.Tables[0].Rows[0][1].ToString();
                    objOrganizationMasterBO.Details = objDataSet.Tables[0].Rows[0][2].ToString();
                    objOrganizationMasterBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][3].ToString());
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditOrganization");
                throw ex;
            }
            return objOrganizationMasterBO;
        }


        //Delete Branch
        public static string ProcdeleteOrganisation = "usp_SCH_deleteOrganisation";
        public string deleteOrganization(int iOrganisationId)
        {
            string strResult = "";
            try
            {
                List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
                ProcParameterBO objDbParameter = null;

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iOrganisationId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iOrganisationId;
                objProcParameterBOList.Add(objDbParameter);

                objDBAccess.executeNonQuery(ProcdeleteOrganisation, ref objProcParameterBOList);
                strResult = "DELETED";
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "deleteOrganization");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

    }

}


