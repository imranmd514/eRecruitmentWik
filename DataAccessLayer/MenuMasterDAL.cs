using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class MenuMasterDAL
    {
        DBAccess objDbAcess = new DBAccess();

        public static string ProcGetMenuList = "usp_SCH_MenuMasterList";
        public List<MenuMasterBO> getMenuList()
        {
            DataSet objDataSet = null;
            MenuMasterBO objMenuMasterBO = null;
            List<MenuMasterBO> objMenuMasterBOList = new List<MenuMasterBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDbAcess.execuitDataSet(ProcGetMenuList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objMenuMasterBO = new MenuMasterBO();
                        objMenuMasterBO.MenuId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objMenuMasterBO.MenuName = objDataSet.Tables[0].Rows[i][1].ToString();                      
                        objMenuMasterBO.DisplayOrder = Convert.ToInt32(objDataSet.Tables[0].Rows[i][2].ToString());                                            
                        objMenuMasterBO.MenuKey = objDataSet.Tables[0].Rows[i][3].ToString();
                        objMenuMasterBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[i][4].ToString());
                        objMenuMasterBO.CreatedOn = objDataSet.Tables[0].Rows[i][5].ToString();
                        objMenuMasterBOList.Add(objMenuMasterBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getMenuList");
                throw ex;
            }
            return objMenuMasterBOList;
        }

        //Save MenuMaster
        public static string ProcSaveMenu = "usp_SCH_saveMenuMaster";

        public string SaveorUpdateMenuMaster(MenuMasterBO objMenuMasterBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iMenuId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objMenuMasterBO.MenuId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strMenuName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objMenuMasterBO.MenuName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iParentMenuId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objMenuMasterBO.ParentMenuId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iDisplayOrder";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objMenuMasterBO.DisplayOrder;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strPageURL";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objMenuMasterBO.PageURL;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strImageURL";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objMenuMasterBO.ImageURL;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iMenuGroupId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objMenuMasterBO.MenuGroupId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strMenuKey";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objMenuMasterBO.MenuKey;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strfaIcon";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objMenuMasterBO.faIcon;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strHelpURL";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objMenuMasterBO.HelpURL;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strHelpDocURL";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objMenuMasterBO.HelpDocURL;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strLocalVideo";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objMenuMasterBO.LocalVideo;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strLocalDocument";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objMenuMasterBO.LocalDocument;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objMenuMasterBO.IsActive;
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

                objDbAcess.executeNonQuery(ProcSaveMenu, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveorUpdateMenuMaster");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        //Edit MenuMaster
        public static string ProcEditMenuMaster = "usp_SCH_EditMenuMaster";

        public MenuMasterBO EditMenuMaster(int iMenuId)
        {
            DataSet objDataSet = null;
            MenuMasterBO objMenuMasterBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iMenuId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iMenuId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDbAcess.execuitDataSet(ProcEditMenuMaster, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objMenuMasterBO = new MenuMasterBO();
                    objMenuMasterBO.MenuId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objMenuMasterBO.MenuName = objDataSet.Tables[0].Rows[0][1].ToString();
                    objMenuMasterBO.ParentMenuId = objDataSet.Tables[0].Rows[0][2].ToString();
                    objMenuMasterBO.DisplayOrder = Convert.ToInt32(objDataSet.Tables[0].Rows[0][3].ToString());
                    objMenuMasterBO.PageURL = objDataSet.Tables[0].Rows[0][4].ToString();
                    objMenuMasterBO.ImageURL = objDataSet.Tables[0].Rows[0][5].ToString();
                    objMenuMasterBO.MenuGroupId = objDataSet.Tables[0].Rows[0][6].ToString();
                    objMenuMasterBO.MenuKey = objDataSet.Tables[0].Rows[0][7].ToString();
                    objMenuMasterBO.faIcon = objDataSet.Tables[0].Rows[0][8].ToString();
                    objMenuMasterBO.HelpURL = objDataSet.Tables[0].Rows[0][9].ToString();
                    objMenuMasterBO.HelpDocURL = objDataSet.Tables[0].Rows[0][10].ToString();
                    objMenuMasterBO.LocalVideo = objDataSet.Tables[0].Rows[0][11].ToString();
                    objMenuMasterBO.LocalDocument = objDataSet.Tables[0].Rows[0][12].ToString();
                    objMenuMasterBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][13].ToString());
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditMenuMaster");
                //throw ex;
            }
            return objMenuMasterBO;
        }

        //View Menu
        public static string ProcViewMenuMaster = "usp_SCH_viewMenu";
        public MenuMasterBO ViewMenuMaster(int iMenuId)
        {
            DataSet objDataSet = null;
            MenuMasterBO objMenuMasterBO = null;
            List<ProcParameterBO> ObjProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iMenuId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iMenuId;
                ObjProcParameterBOList.Add(objDbParameter);

                objDataSet = objDbAcess.execuitDataSet(ProcViewMenuMaster, ref ObjProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objMenuMasterBO = new MenuMasterBO();
                    objMenuMasterBO.MenuId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objMenuMasterBO.MenuName = objDataSet.Tables[0].Rows[0][1].ToString();
                    objMenuMasterBO.ParentMenuId =objDataSet.Tables[0].Rows[0][2].ToString();
                    objMenuMasterBO.DisplayOrder = Convert.ToInt32(objDataSet.Tables[0].Rows[0][3].ToString());
                    objMenuMasterBO.PageURL = objDataSet.Tables[0].Rows[0][4].ToString();
                    objMenuMasterBO.ImageURL = objDataSet.Tables[0].Rows[0][5].ToString();
                    objMenuMasterBO.MenuGroupId = objDataSet.Tables[0].Rows[0][6].ToString();
                    objMenuMasterBO.MenuKey = objDataSet.Tables[0].Rows[0][7].ToString();
                    objMenuMasterBO.faIcon = objDataSet.Tables[0].Rows[0][8].ToString();
                    objMenuMasterBO.HelpURL = objDataSet.Tables[0].Rows[0][9].ToString();
                    objMenuMasterBO.HelpDocURL = objDataSet.Tables[0].Rows[0][10].ToString();
                    objMenuMasterBO.LocalVideo = objDataSet.Tables[0].Rows[0][11].ToString();
                    objMenuMasterBO.LocalDocument = objDataSet.Tables[0].Rows[0][12].ToString();
                    objMenuMasterBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][13].ToString());
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "ViewMenuMaster");
                throw ex;
            }
            return objMenuMasterBO;
        }

        //Delete MenuMaster
        public static string ProcdeleteMenuMaster = "usp_SCH_deleteMenuMaster";
        public string deleteMenuMaster(int iMenuId)
        {
            string strResult = "";
            try
            {
                List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
                ProcParameterBO objDbParameter = null;

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iMenuId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iMenuId;
                objProcParameterBOList.Add(objDbParameter);

                objDbAcess.executeNonQuery(ProcdeleteMenuMaster, ref objProcParameterBOList);
                strResult = "DELETED";
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "deleteMenuMaster");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }
    }
}