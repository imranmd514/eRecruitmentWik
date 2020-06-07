using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using CommonDB;
using Utils;


namespace DataAccessLayer
{
   public class LocationMasterDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public static string ProcGetLocationMasterListDetails = "usp_SCH_GetLocationMasterListDetails";
        public List<LocationMasterBO> GetLocationMasterList()
        {
            DataSet objDataSet = null;
            LocationMasterBO objLocationMasterBO = null;
            List<LocationMasterBO> objLocationMasterBOList = new List<LocationMasterBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcGetLocationMasterListDetails, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objLocationMasterBO = new LocationMasterBO();
                        objLocationMasterBO.LocationId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objLocationMasterBO.Location = objDataSet.Tables[0].Rows[i][1].ToString();
                        objLocationMasterBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[i][2].ToString());
                        objLocationMasterBOList.Add(objLocationMasterBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "GetLocationMasterList");
                throw ex;
            }
            return objLocationMasterBOList;
        }

        public static string ProcSaveorUpdateLocationMaster = "usp_SCH_SaveorUpdateLocationMaster";
        public string SaveorUpdateLocationMaster(LocationMasterBO objLocationMasterBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iLocationId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objLocationMasterBO.LocationId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strLocation";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objLocationMasterBO.Location;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objLocationMasterBO.IsActive;
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


                objDBAccess.executeNonQuery(ProcSaveorUpdateLocationMaster, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveorUpdateLocationMaster");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        public static string ProcEditLocationMaster = "usp_SCH_EditLocationMaster";
        public LocationMasterBO EditLocationMaster(int iLocationId)
        {
            DataSet objDataSet = null;
            LocationMasterBO objLocationMasterBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iLocationId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iLocationId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditLocationMaster, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objLocationMasterBO = new LocationMasterBO();
                    objLocationMasterBO.LocationId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objLocationMasterBO.Location = objDataSet.Tables[0].Rows[0][1].ToString();
                    objLocationMasterBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][2].ToString());
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditLocationMaster");
                throw ex;
            }
            return objLocationMasterBO;
        }


        public static string ProcDeleteLocationMaster = "usp_SCH_DeleteLocationMaster";
        public string DeleteLocationMaster(int iLocationId)
        {
            string strResult = "";
            try
            {
                List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
                ProcParameterBO objDbParameter = null;

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iLocationId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iLocationId;
                objProcParameterBOList.Add(objDbParameter);

                objDBAccess.executeNonQuery(ProcDeleteLocationMaster, ref objProcParameterBOList);
                strResult = "DELETED";
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "DeleteLocationMaster");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }
    }
}
