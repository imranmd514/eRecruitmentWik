using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class JobMarketingDAL
    {
        DBAccess objDBAccess = new DBAccess();
        public static string ProcDonorProgram = "usp_getDonorProgram";
        public List<CommonDropDownBO> DonorProgramList(int iUserId)
        {
            DataSet objDataSet = null;
            CommonDropDownBO objCommonDropDownBO = null;
            List<CommonDropDownBO> objCommonDropDownBOList = new List<CommonDropDownBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iUserId";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = iUserId;
                objProcParameterBOList.Add(objDBparameter);

                objDataSet = objDBAccess.execuitDataSet(ProcDonorProgram, ref objProcParameterBOList);
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
                ExceptionError.Error_Log(ex, "DonorProgramList");
                throw ex;
            }
            return objCommonDropDownBOList;
        }


        public static string ProcJobMarketingList = "usp_SCH_getJobMarketingList";
        public List<JobMarketingBO> getJobMarketingList()
        {
            DataSet objDataSet = null;
            JobMarketingBO objJobMarketingBO = null;
            List<JobMarketingBO> objJobMarketingBOList = new List<JobMarketingBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcJobMarketingList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objJobMarketingBO = new JobMarketingBO();
                        objJobMarketingBO.JobPostingId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objJobMarketingBO.JobName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objJobMarketingBO.JobDescription = objDataSet.Tables[0].Rows[i][2].ToString();
                        objJobMarketingBO.JobLocation = objDataSet.Tables[0].Rows[i][3].ToString();
                        objJobMarketingBO.NoOfPositions = Convert.ToInt32(objDataSet.Tables[0].Rows[i][4].ToString());
                        objJobMarketingBO.Status = objDataSet.Tables[0].Rows[i][5].ToString();
                        objJobMarketingBO.MarketingStatus= objDataSet.Tables[0].Rows[i][6].ToString();
                        objJobMarketingBO.MarketingComments = objDataSet.Tables[0].Rows[i][7].ToString();
                        objJobMarketingBOList.Add(objJobMarketingBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getJobMarketingList");
                throw ex;
            }
            return objJobMarketingBOList;
        }

        public static string ProcsaveJobMarketing = "usp_SCH_saveJobMarketing";
        public string SaveJobMarketing(JobMarketingBO objJobMarketingBO, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iJobPostingId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objJobMarketingBO.JobPostingId;
                objProcParameterBOList.Add(objDBparameter);
                
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strMarket_Comments";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objJobMarketingBO.MarketingComments;
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


                objDBAccess.executeNonQuery(ProcsaveJobMarketing, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveJobMarketing");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }


        public static string ProcEditJobMarketing = "usp_SCH_EditJobMarketing";
        public JobMarketingBO EditJobMarketing(int iJobPostingId)
        {
            DataSet objDataSet = null;
            JobMarketingBO objJobMarketingBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iJobPostingId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iJobPostingId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditJobMarketing, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objJobMarketingBO = new JobMarketingBO();
                    objJobMarketingBO.JobPostingId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objJobMarketingBO.JobName = objDataSet.Tables[0].Rows[0][1].ToString();
                    objJobMarketingBO.JobCode = objDataSet.Tables[0].Rows[0][2].ToString();
                    objJobMarketingBO.JobDescription = objDataSet.Tables[0].Rows[0][3].ToString();
                    objJobMarketingBO.NoOfPositions = Convert.ToInt32(objDataSet.Tables[0].Rows[0][4].ToString());
                    objJobMarketingBO.JobLocation = objDataSet.Tables[0].Rows[0][5].ToString();
                    objJobMarketingBO.JobTimings = objDataSet.Tables[0].Rows[0][6].ToString();
                    objJobMarketingBO.JobDuration = objDataSet.Tables[0].Rows[0][7].ToString();
                    objJobMarketingBO.Qualification = objDataSet.Tables[0].Rows[0][8].ToString();
                    objJobMarketingBO.Experience = objDataSet.Tables[0].Rows[0][9].ToString();
                    objJobMarketingBO.Skills = objDataSet.Tables[0].Rows[0][10].ToString();
                    objJobMarketingBO.StatusId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][11].ToString());
                    objJobMarketingBO.MarketingComments = objDataSet.Tables[0].Rows[0][12].ToString();
                    objJobMarketingBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][13].ToString());
                    objJobMarketingBO.DonorProgramId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][14].ToString());
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditJobMarketing");
                throw ex;
            }
            return objJobMarketingBO;
        }


        public static string ProcViewJobMarketing = "usp_SCH_ViewJobMarketing";
        public JobMarketingBO DisplayJobMarketing(int iJobPostingId)
        {
            DataSet objDataSet = null;
            JobMarketingBO objJobMarketingBO = null;
            List<ProcParameterBO> ObjProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iJobPostingId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iJobPostingId;
                ObjProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcViewJobMarketing, ref ObjProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objJobMarketingBO = new JobMarketingBO();
                    objJobMarketingBO.JobName = objDataSet.Tables[0].Rows[0][0].ToString();
                    objJobMarketingBO.JobCode = objDataSet.Tables[0].Rows[0][1].ToString();
                    objJobMarketingBO.JobDescription = objDataSet.Tables[0].Rows[0][2].ToString();
                    objJobMarketingBO.NoOfPositions = Convert.ToInt32(objDataSet.Tables[0].Rows[0][3].ToString());
                    objJobMarketingBO.JobLocation = objDataSet.Tables[0].Rows[0][4].ToString();
                    objJobMarketingBO.JobTimings = objDataSet.Tables[0].Rows[0][5].ToString();
                    objJobMarketingBO.JobDuration = objDataSet.Tables[0].Rows[0][6].ToString();
                    objJobMarketingBO.DonorProgramName = objDataSet.Tables[0].Rows[0][7].ToString();
                    objJobMarketingBO.Qualification = objDataSet.Tables[0].Rows[0][8].ToString();
                    objJobMarketingBO.Experience = objDataSet.Tables[0].Rows[0][9].ToString();
                    objJobMarketingBO.Skills = objDataSet.Tables[0].Rows[0][10].ToString();
                    objJobMarketingBO.Comments = objDataSet.Tables[0].Rows[0][11].ToString();
                    objJobMarketingBO.MarketedDate =  objDataSet.Tables[0].Rows[0][12].ToString();

                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "DisplayJobMarketing");
                throw ex;
            }
            return objJobMarketingBO;
        }


        //Delete JobMarketing
        public static string ProcDeleteJobMarketing = "usp_SCH_deleteJobMarketing";
        public string deleteJobMarketing(int iJobPostingId)
        {
            string strResult = "";
            try
            {
                List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
                ProcParameterBO objDbParameter = null;

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iJobPostingId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iJobPostingId;
                objProcParameterBOList.Add(objDbParameter);

                objDBAccess.executeNonQuery(ProcDeleteJobMarketing, ref objProcParameterBOList);
                strResult = "DELETED";
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "deleteJobMarketing");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

    }
}
