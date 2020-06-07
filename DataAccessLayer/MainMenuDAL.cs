using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace DataAccessLayer
{
    public class MainMenuDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public const string ProcGetMenuDetails = "usp_getMenuDetails";
        public List<MainMenuBO> getUserMenuList(int iUserId)
        {
            DataSet objDataset = null;
            MainMenuBO objMainMenuBO = null;
            List<ProcParameterBO> objListProcParameterBO = new List<ProcParameterBO>();
            List<MainMenuBO> objMainMenuListBo = new List<MainMenuBO>();

            try
            {
                ProcParameterBO objProcParameterBo = new ProcParameterBO();
                objProcParameterBo.Direction = ParameterDirection.Input;
                objProcParameterBo.ParameterName = "@iUserId";
                objProcParameterBo.dbType = DbType.Int32;
                objProcParameterBo.ParameterValue = iUserId;
                objListProcParameterBO.Add(objProcParameterBo);

                objDataset = objDBAccess.execuitDataSet(ProcGetMenuDetails, ref objListProcParameterBO);
                if (objDataset != null && objDataset.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataset.Tables[0].Rows.Count; i++)
                    {
                        objMainMenuBO = new MainMenuBO();
                        objMainMenuBO.MenuId = Convert.ToInt32(objDataset.Tables[0].Rows[i][0].ToString());
                        objMainMenuBO.MenuName = objDataset.Tables[0].Rows[i][1].ToString();
                        objMainMenuBO.ParentMenuId = Convert.ToInt32(objDataset.Tables[0].Rows[i][2].ToString());
                        objMainMenuBO.DisplayOrder = Convert.ToInt32(objDataset.Tables[0].Rows[i][3].ToString());

                        objMainMenuBO.faIcon = objDataset.Tables[0].Rows[i][4].ToString();
                        objMainMenuBO.ImageURL = objDataset.Tables[0].Rows[i][5].ToString();
                        objMainMenuBO.HelpURL = objDataset.Tables[0].Rows[i][6].ToString();

                        objMainMenuBO.HelpDocURL = objDataset.Tables[0].Rows[i][7].ToString();
                        objMainMenuBO.MenuGroupId = Convert.ToInt32(objDataset.Tables[0].Rows[i][8].ToString());
                        objMainMenuBO.LocalDocument = objDataset.Tables[0].Rows[i][9].ToString();

                        objMainMenuBO.LocalVideo = objDataset.Tables[0].Rows[i][10].ToString();
                        objMainMenuBO.MenuKey = objDataset.Tables[0].Rows[i][11].ToString();
                        objMainMenuBO.PageURL = objDataset.Tables[0].Rows[i][12].ToString();

                        objMainMenuListBo.Add(objMainMenuBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getUserMenuList");
                throw ex;
            }

            return objMainMenuListBo;
        }

    }
}
