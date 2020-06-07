using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDB;
using System.Data;
using Models;
using Utils;

namespace DataAccessLayer
{
    public class HRInteractionDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public static string ProcHRInteractionList = "usp_getHRInteractionList";
        public List<HRInteractionBO> getHRInteractionList()
        {
            DataSet objDataSet = null;
            HRInteractionBO objHRInteractionBO = null;
            List<HRInteractionBO> objHRInteractionBOList = new List<HRInteractionBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcHRInteractionList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objHRInteractionBO = new HRInteractionBO();
                        objHRInteractionBO.RequestId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objHRInteractionBO.ApplicantName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objHRInteractionBO.Subject = objDataSet.Tables[0].Rows[i][2].ToString();
                        objHRInteractionBO.RequestDate = objDataSet.Tables[0].Rows[i][3].ToString();
                        objHRInteractionBO.ResponseDate = objDataSet.Tables[0].Rows[i][4].ToString();                        
                        objHRInteractionBO.Status = objDataSet.Tables[0].Rows[i][5].ToString();
                        objHRInteractionBO.Comments = objDataSet.Tables[0].Rows[i][6].ToString();
                        objHRInteractionBOList.Add(objHRInteractionBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getHRInteractionList");
                throw ex;
            }
            return objHRInteractionBOList;
        }

        public static string ProcSaveHRInteraction = "usp_saveHRInteraction";
        public string SaveHRInteraction(HRInteractionBO objHRInteractionBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iRequestId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objHRInteractionBO.RequestId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strApplicantName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objHRInteractionBO.ApplicantName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strEmailId";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objHRInteractionBO.EmailId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSubject";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objHRInteractionBO.Subject;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strDescription";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objHRInteractionBO.Description;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strRequestDate";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objHRInteractionBO.RequestDate;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iStatusId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objHRInteractionBO.StatusId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objHRInteractionBO.IsActive;
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


                objDBAccess.executeNonQuery(ProcSaveHRInteraction, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveHRInteraction");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }


        public static string ProcSaveHRReply = "usp_saveHRReply";
        public string SaveHRReply(HRInteractionBO objHRInteractionBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iRequestId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objHRInteractionBO.RequestId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strApplicantName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objHRInteractionBO.ApplicantName;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strEmailId";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objHRInteractionBO.EmailId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSubject";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objHRInteractionBO.Subject;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strDescription";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objHRInteractionBO.Description;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strRequestDate";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objHRInteractionBO.RequestDate;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strResponseDate";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objHRInteractionBO.ResponseDate;
                objProcParameterBOList.Add(objDBparameter);


                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iStatusId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objHRInteractionBO.StatusId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strComments";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objHRInteractionBO.Comments;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objHRInteractionBO.IsActive;
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


                objDBAccess.executeNonQuery(ProcSaveHRReply, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveHRReply");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        public static string ProcEditHRInteraction = "usp_EditHRInteraction";
        public HRInteractionBO EditHRInteraction(int iRequestId)
        {
            DataSet objDataSet = null;
            HRInteractionBO objHRInteractionBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iRequestId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iRequestId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditHRInteraction, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objHRInteractionBO = new HRInteractionBO();
                    objHRInteractionBO.RequestId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objHRInteractionBO.ApplicantName = objDataSet.Tables[0].Rows[0][1].ToString();
                    objHRInteractionBO.EmailId = objDataSet.Tables[0].Rows[0][2].ToString();
                    objHRInteractionBO.Subject = objDataSet.Tables[0].Rows[0][3].ToString();
                    objHRInteractionBO.Description = objDataSet.Tables[0].Rows[0][4].ToString();
                    objHRInteractionBO.RequestDate = objDataSet.Tables[0].Rows[0][5].ToString();
                    objHRInteractionBO.ResponseDate = objDataSet.Tables[0].Rows[0][6].ToString();
                    objHRInteractionBO.Comments = objDataSet.Tables[0].Rows[0][7].ToString();
                    objHRInteractionBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][8].ToString());
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditHRInteraction");
                throw ex;
            }
            return objHRInteractionBO;
        }


        public static string ProcViewHRInteraction = "usp_ViewHRInteraction";
        public HRInteractionBO DisplayHRDetails(int iRequestId)
        {
            DataSet objDataSet = null;
            HRInteractionBO objHRInteractionBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iRequestId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iRequestId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcViewHRInteraction, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objHRInteractionBO = new HRInteractionBO();
                    objHRInteractionBO.RequestId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objHRInteractionBO.ApplicantName = objDataSet.Tables[0].Rows[0][1].ToString();
                    objHRInteractionBO.EmailId = objDataSet.Tables[0].Rows[0][2].ToString();
                    objHRInteractionBO.Subject = objDataSet.Tables[0].Rows[0][3].ToString();
                    objHRInteractionBO.Description = objDataSet.Tables[0].Rows[0][4].ToString();
                    objHRInteractionBO.RequestDate = objDataSet.Tables[0].Rows[0][5].ToString();
                    objHRInteractionBO.ResponseDate = objDataSet.Tables[0].Rows[0][6].ToString();
                    objHRInteractionBO.Comments = objDataSet.Tables[0].Rows[0][7].ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "DisplayHRDetails");
                throw ex;
            }
            return objHRInteractionBO;
        }

        public static string ProcDeleteHRInteraction = "usp_DeleteHRInteraction";
        public string deleteHRInteraction(int iRequestId)
        {
            string strResult = "";
            try
            {
                List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
                ProcParameterBO objDbParameter = null;

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iRequestId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iRequestId;
                objProcParameterBOList.Add(objDbParameter);

                objDBAccess.executeNonQuery(ProcDeleteHRInteraction, ref objProcParameterBOList);
                strResult = "DELETED";
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "deleteHRInteraction");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

    }
}




