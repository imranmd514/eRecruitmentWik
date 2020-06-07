using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class AllJobsDAL
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


        public static string ProcAllJobs = "usp_SCH_selectAllJobsDetails";
        public List<PostJobBO> getAllJobsList()
        {
            DataSet objDataSet = null;
            PostJobBO objJobPostingsBO = null;
            List<PostJobBO> objAllJobsBOList = new List<PostJobBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcAllJobs, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objJobPostingsBO = new PostJobBO();
                        objJobPostingsBO.JobPostingId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objJobPostingsBO.JobName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objJobPostingsBO.JobDescription = objDataSet.Tables[0].Rows[i][2].ToString();
                        objJobPostingsBO.JobLocation = objDataSet.Tables[0].Rows[i][3].ToString();
                        objJobPostingsBO.NoOfPositions = objDataSet.Tables[0].Rows[i][4].ToString();
                        objJobPostingsBO.Status = objDataSet.Tables[0].Rows[i][5].ToString();
                        objJobPostingsBO.Skills = objDataSet.Tables[0].Rows[i][6].ToString();
                        objJobPostingsBO.Qualification = objDataSet.Tables[0].Rows[i][7].ToString();
                        objJobPostingsBO.Experience = objDataSet.Tables[0].Rows[i][8].ToString();
                        objJobPostingsBO.DonorProgram = objDataSet.Tables[0].Rows[i][9].ToString();
                        objAllJobsBOList.Add(objJobPostingsBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getAllJobsList");
                throw ex;
            }
            return objAllJobsBOList;
        }

        //   Save Approved Job
        public static string ProcSaveApprovedJob = "usp_SCH_saveApprovedJobPosting";
        public string SaveApprovedJob(AllJobsBO objAllJobsBO, int iUserId, int iRoleId)
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
                objDBparameter.ParameterValue = iRoleId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iJobPostingId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objAllJobsBO.JobPostingId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.JobName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobCode";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.JobCode;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobDescription";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.JobDescription;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iNoOfPositions";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.NoOfPositions;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobLocation";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.JobLocation;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobTimings";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.JobTimings;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobDuration";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.JobDuration;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strQualification";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.Qualification;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strExperience";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.Experience;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSkills";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.Skills;
                objProcParameterBOList.Add(objDBparameter);                

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strComments";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.Comments;
                objProcParameterBOList.Add(objDBparameter);
               
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iDonorProgrammId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objAllJobsBO.DonorProgramId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iRequiredStaffLevel";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.RequiredStaffLevel;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iCurrentStaffLevel";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.CurrentStaffLevel;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iGaps";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.Gaps;
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


                objDBAccess.executeNonQuery(ProcSaveApprovedJob, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveApprovedJob");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        public string ProcGetHOPPMHAFUsersList = "usp_GetHOPPMHAFUsersList";
        public List<string> GetHOPPMHAFUsersList()
        {
            DataSet objDataSet = null;
            string strEmailAddress = "";
            List<string> objUsersList = new List<string>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcGetHOPPMHAFUsersList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        strEmailAddress = objDataSet.Tables[0].Rows[i][0].ToString();
                        objUsersList.Add(strEmailAddress);
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "GetHOPPMHAFUsersList");
                throw ex;
            }
            return objUsersList;
        }

        public string ProcGetEDUsersList = "usp_GetEDUsersList";
        public List<string> GetEDUsersList()
        {
            DataSet objDataSet = null;
            string strEmailAddress = "";
            List<string> objUsersList = new List<string>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcGetEDUsersList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        strEmailAddress = objDataSet.Tables[0].Rows[i][0].ToString();
                        objUsersList.Add(strEmailAddress);
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "GetEDUsersList");
                throw ex;
            }
            return objUsersList;
        }


        public string ProcGetMarketerUsersList = "usp_GetMarketerUsersList";
        public List<string> GetMarketerUsersList()
        {
            DataSet objDataSet = null;
            string strEmailAddress = "";
            List<string> objUsersList = new List<string>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcGetMarketerUsersList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        strEmailAddress = objDataSet.Tables[0].Rows[i][0].ToString();
                        objUsersList.Add(strEmailAddress);
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "GetMarketerUsersList");
                throw ex;
            }
            return objUsersList;
        }


        //   Save Rejected Job
        public static string ProcRejectedJob = "usp_SCH_saveRejectedJobPosting";
        public string SaveRejectedJob(AllJobsBO objAllJobsBO, int iUserId, int iRoleId)
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
                objDBparameter.ParameterValue = iRoleId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iJobPostingId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objAllJobsBO.JobPostingId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.JobName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobCode";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.JobCode;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobDescription";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.JobDescription;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iNoOfPositions";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.NoOfPositions;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobLocation";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.JobLocation;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobTimings";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.JobTimings;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobDuration";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.JobDuration;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strQualification";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.Qualification;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strExperience";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.Experience;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSkills";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.Skills;
                objProcParameterBOList.Add(objDBparameter);
                
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strComments";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.Comments;
                objProcParameterBOList.Add(objDBparameter);
                
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iDonorProgrammId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objAllJobsBO.DonorProgramId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iRequiredStaffLevel";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.RequiredStaffLevel;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iCurrentStaffLevel";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.CurrentStaffLevel;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iGaps";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.Gaps;
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


                objDBAccess.executeNonQuery(ProcRejectedJob, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveRejectedJob");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }
        
        //  Save OnHoldJob
        public static string ProcOnholdindJob = "usp_SCH_saveOnHoldJobPosting";
        public string SaveOnHoldJob(AllJobsBO objAllJobsBO, int iUserId, string strRoleName)
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
                objDBparameter.ParameterValue = objAllJobsBO.JobPostingId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.JobName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobCode";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.JobCode;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobDescription";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.JobDescription;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iNoOfPositions";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.NoOfPositions;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobLocation";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.JobLocation;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobTimings";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.JobTimings;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobDuration";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.JobDuration;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strQualification";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.Qualification;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strExperience";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.Experience;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSkills";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.Skills;
                objProcParameterBOList.Add(objDBparameter);
                
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strComments";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAllJobsBO.Comments;
                objProcParameterBOList.Add(objDBparameter);
                
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iDonorProgrammId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objAllJobsBO.DonorProgramId;
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


                objDBAccess.executeNonQuery(ProcOnholdindJob, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveOnHoldJob");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        public static string ProcEditJobPosting = "usp_SCH_EditJobPosting";
        public AllJobsBO EditAllJobs(int iJobPostingId)
        {
            DataSet objDataSet = null;
            AllJobsBO objAllJobsBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iJobPostingId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iJobPostingId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcEditJobPosting, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objAllJobsBO = new AllJobsBO();
                    objAllJobsBO.JobPostingId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objAllJobsBO.JobName = objDataSet.Tables[0].Rows[0][1].ToString();
                    objAllJobsBO.JobCode = objDataSet.Tables[0].Rows[0][2].ToString();
                    objAllJobsBO.JobDescription = objDataSet.Tables[0].Rows[0][3].ToString();
                    objAllJobsBO.NoOfPositions = objDataSet.Tables[0].Rows[0][4].ToString();
                    objAllJobsBO.JobLocation = objDataSet.Tables[0].Rows[0][5].ToString();
                    objAllJobsBO.JobTimings = objDataSet.Tables[0].Rows[0][6].ToString();
                    objAllJobsBO.JobDuration = objDataSet.Tables[0].Rows[0][7].ToString();
                    objAllJobsBO.Qualification = objDataSet.Tables[0].Rows[0][8].ToString();
                    objAllJobsBO.Experience = objDataSet.Tables[0].Rows[0][9].ToString();
                    objAllJobsBO.Skills = objDataSet.Tables[0].Rows[0][10].ToString();
                    objAllJobsBO.StatusId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][11].ToString());
                    objAllJobsBO.ApprovedById = objDataSet.Tables[0].Rows[0][12].ToString();
                    objAllJobsBO.ApprovedDate = objDataSet.Tables[0].Rows[0][13].ToString();
                    objAllJobsBO.RejectedById = objDataSet.Tables[0].Rows[0][14].ToString();
                    objAllJobsBO.RejectedDate = objDataSet.Tables[0].Rows[0][15].ToString();
                    objAllJobsBO.MarketedById = objDataSet.Tables[0].Rows[0][16].ToString();
                    objAllJobsBO.MarketedDate = objDataSet.Tables[0].Rows[0][17].ToString();
                    objAllJobsBO.Comments = objDataSet.Tables[0].Rows[0][18].ToString();
                    objAllJobsBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][19].ToString());
                    objAllJobsBO.DonorProgramId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][20].ToString());

                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditAllJobs");
                throw ex;
            }
            return objAllJobsBO;
        }


        public static string ProcViewAllJob = "usp_ViewAllJobs";
        public AllJobsBO DisplayAllJob(int iJobPostingId)
        {
            DataSet objDataSet = null;
            AllJobsBO objAllJobsBO = null;
            List<ProcParameterBO> ObjProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iJobPostingId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iJobPostingId;
                ObjProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcViewAllJob, ref ObjProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objAllJobsBO = new AllJobsBO();
                    objAllJobsBO.JobName = objDataSet.Tables[0].Rows[0][0].ToString();
                    objAllJobsBO.JobCode = objDataSet.Tables[0].Rows[0][1].ToString();
                    objAllJobsBO.JobDescription = objDataSet.Tables[0].Rows[0][2].ToString();
                    objAllJobsBO.NoOfPositions = objDataSet.Tables[0].Rows[0][3].ToString();
                    objAllJobsBO.JobLocation = objDataSet.Tables[0].Rows[0][4].ToString();
                    objAllJobsBO.JobTimings = objDataSet.Tables[0].Rows[0][5].ToString();
                    objAllJobsBO.JobDuration = objDataSet.Tables[0].Rows[0][6].ToString();
                    objAllJobsBO.DonorProgramName = objDataSet.Tables[0].Rows[0][7].ToString();
                    objAllJobsBO.Qualification = objDataSet.Tables[0].Rows[0][8].ToString();
                    objAllJobsBO.Experience = objDataSet.Tables[0].Rows[0][9].ToString();
                    objAllJobsBO.Skills = objDataSet.Tables[0].Rows[0][10].ToString();
                    objAllJobsBO.Comments = objDataSet.Tables[0].Rows[0][11].ToString();

                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "DisplayAllJob");
                throw ex;
            }
            return objAllJobsBO;
        }


        public static string ProcDeleteAllJobs = "usp_SCH_deleteJobPosting";
        public string deleteAllJobs(int iJobPostingId)
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

                objDBAccess.executeNonQuery(ProcDeleteAllJobs, ref objProcParameterBOList);
                strResult = "DELETED";
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "deleteAllJobs");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

    }
}

