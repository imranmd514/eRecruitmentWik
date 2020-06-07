using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class BranchMasterDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public static string ProcdropdownOraganizationList = "usp_SCH_dropdownOrganization";
        public List<CommonDropDownBO> dropdownOrganization()
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDropDownBO = null;
            List<CommonDropDownBO> objCommonDropDownBOList = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcdropdownOraganizationList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objCommonDropDownBO = new CommonDropDownBO();
                        objCommonDropDownBO.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objCommonDropDownBO.Value = objDataSet.Tables[0].Rows[i][1].ToString();
                        objCommonDropDownBOList.Add(objCommonDropDownBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "dropdownOrganization");
                throw ex;
            }
            return objCommonDropDownBOList;
        }
        //Branch List

        public static string ProcselectBranchList = "usp_SCH_selectBranchList";
        public List<BranchMasterBO> selectBranchList()
        {
            DataSet objDataSet = null;
            BranchMasterBO objBranchMasterBO = null;
            List<BranchMasterBO> objListBranchMasterBO = new List<BranchMasterBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcselectBranchList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objBranchMasterBO = new BranchMasterBO();
                        objBranchMasterBO.BranchId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objBranchMasterBO.OrganizationName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objBranchMasterBO.BranchName = objDataSet.Tables[0].Rows[i][2].ToString();
                        objBranchMasterBO.Details = objDataSet.Tables[0].Rows[i][3].ToString();
                        objBranchMasterBO.Address = objDataSet.Tables[0].Rows[i][4].ToString();
                        objBranchMasterBO.CellNumber = objDataSet.Tables[0].Rows[i][5].ToString();
                        objBranchMasterBO.LandNumber = objDataSet.Tables[0].Rows[i][6].ToString();
                        objBranchMasterBO.EmailId = objDataSet.Tables[0].Rows[i][7].ToString();
                        objBranchMasterBO.Website = objDataSet.Tables[0].Rows[i][8].ToString();
                        objListBranchMasterBO.Add(objBranchMasterBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "selectBranchList");
                throw ex;
            }
            return objListBranchMasterBO;
        }

        //Save Branch

        public static string ProcsaveBranchMaster = "usp_SCH_saveBranchMaster";
        public string SaveorUpdateBranchMaster(BranchMasterBO objBranchMasterBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iBranchId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objBranchMasterBO.BranchId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iOrganisationId";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objBranchMasterBO.OrganizationId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strBranchName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objBranchMasterBO.BranchName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strDetails";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objBranchMasterBO.Details;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strAddress";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objBranchMasterBO.Address;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strCellNumber";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objBranchMasterBO.CellNumber;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strLandNumber";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objBranchMasterBO.LandNumber;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strEmailId";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objBranchMasterBO.EmailId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strWebsite";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objBranchMasterBO.Website;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsMainBranch";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objBranchMasterBO.IsMainBranch;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objBranchMasterBO.IsActive;
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


                objDBAccess.executeNonQuery(ProcsaveBranchMaster, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveorUpdateBranchMaster");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        //Edit Branch

        public static string ProcEditBranch = "usp_SCH_EditBranch";
        public BranchMasterBO EditBranch(int iBranchId)
        {
            DataSet objDataSet = null;
            BranchMasterBO objBranchMasterBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iBranchId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iBranchId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditBranch, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objBranchMasterBO = new BranchMasterBO();
                    objBranchMasterBO.BranchId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objBranchMasterBO.BranchName = objDataSet.Tables[0].Rows[0][1].ToString();
                    objBranchMasterBO.OrganizationId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][2].ToString());
                    objBranchMasterBO.Details = objDataSet.Tables[0].Rows[0][3].ToString();
                    objBranchMasterBO.Address = objDataSet.Tables[0].Rows[0][4].ToString();
                    objBranchMasterBO.CellNumber = objDataSet.Tables[0].Rows[0][5].ToString();
                    objBranchMasterBO.LandNumber = objDataSet.Tables[0].Rows[0][6].ToString();
                    objBranchMasterBO.EmailId = objDataSet.Tables[0].Rows[0][7].ToString();
                    objBranchMasterBO.Website = objDataSet.Tables[0].Rows[0][8].ToString();
                    objBranchMasterBO.IsMainBranch = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][9].ToString());
                    objBranchMasterBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][10].ToString());
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditBranch");
                throw ex;
            }
            return objBranchMasterBO;
        }
        //View Branch
        public static string ProcViewBranchMaster = "usp_SCH_viewBranch";
        public BranchMasterBO ViewBranchMaster(int iBranchId)
        {
            DataSet objDataSet = null;
            BranchMasterBO objBranchMasterBO = null;
            List<ProcParameterBO> ObjProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iBranchId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iBranchId;
                ObjProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcViewBranchMaster, ref ObjProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objBranchMasterBO = new BranchMasterBO();
                    objBranchMasterBO.BranchId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objBranchMasterBO.BranchName = objDataSet.Tables[0].Rows[0][1].ToString();
                    objBranchMasterBO.OrganizationId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][2].ToString());
                    objBranchMasterBO.Details = objDataSet.Tables[0].Rows[0][3].ToString();
                    objBranchMasterBO.Address = objDataSet.Tables[0].Rows[0][4].ToString();
                    objBranchMasterBO.CellNumber = objDataSet.Tables[0].Rows[0][5].ToString();
                    objBranchMasterBO.LandNumber = objDataSet.Tables[0].Rows[0][6].ToString();
                    objBranchMasterBO.EmailId = objDataSet.Tables[0].Rows[0][7].ToString();
                    objBranchMasterBO.Website = objDataSet.Tables[0].Rows[0][8].ToString();
                    objBranchMasterBO.IsMainBranch = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][9].ToString());
                    objBranchMasterBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][10].ToString());
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "ViewBranchMaster");
                throw ex;
            }
            return objBranchMasterBO;
        }


        //Delete Branch
        public static string ProcdeleteBranch = "usp_SCH_deleteBranch";
        public string deleteBranch(int iBranchId)
        {
            string strResult = "";
            try
            {
                List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
                ProcParameterBO objDbParameter = null;

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iBranchId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iBranchId;
                objProcParameterBOList.Add(objDbParameter);

                objDBAccess.executeNonQuery(ProcdeleteBranch, ref objProcParameterBOList);
                strResult = "DELETED";
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "deleteBranch");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

    }

}


