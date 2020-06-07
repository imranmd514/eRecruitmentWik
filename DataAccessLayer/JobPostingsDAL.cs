using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;


namespace DataAccessLayer
{
    public class JobPostingsDAL
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

        //Jobs List
        public static string ProcGetJobsList = "usp_SCH_selectJobPostingDetails";
        public List<PostJobBO> getJobsList(int iUserId)
        {
            DataSet objDataSet = null;
            PostJobBO objJobPostingsBO = null;
            List<PostJobBO> objJobPostingsBOList = new List<PostJobBO>();
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

                objDataSet = objDBAccess.execuitDataSet(ProcGetJobsList, ref objProcParameterBOList);
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
                        objJobPostingsBOList.Add(objJobPostingsBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getJobsList");
                throw ex;
            }
            return objJobPostingsBOList;
        }
        
        //Save JobPosting
        public static string ProcSaveJobPosting = "usp_SCH_saveJobPosting";
        public string SaveorUpdateJobPosting(PostJobBO objJobPostingsBO, int iUserId)
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
                objDBparameter.ParameterValue = objJobPostingsBO.JobPostingId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objJobPostingsBO.JobName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobCode";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objJobPostingsBO.JobCode;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobDescription";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objJobPostingsBO.JobDescription;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobDescriptionFile";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objJobPostingsBO.JobDescriptionFile;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobDescriptionFileSavedName";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objJobPostingsBO.JobDescriptionFileSavedName;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iNoOfPositions";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objJobPostingsBO.NoOfPositions;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobLocation";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objJobPostingsBO.JobLocation;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobTimings";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objJobPostingsBO.JobTimings;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strJobDuration";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objJobPostingsBO.JobDuration;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strQualification";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objJobPostingsBO.Qualification;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strExperience";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objJobPostingsBO.Experience;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strSkills";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objJobPostingsBO.Skills;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strStatusId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objJobPostingsBO.StatusId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iDonorProgramId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objJobPostingsBO.DonorProgramId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strComments";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objJobPostingsBO.Comments;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strApproveComments";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objJobPostingsBO.ApproverComments;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strRejectComments";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objJobPostingsBO.RejectComments;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strHODComments";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objJobPostingsBO.HOD_Comments;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@bIsActive";
                objDBparameter.dbType = DbType.Boolean;
                objDBparameter.ParameterValue = objJobPostingsBO.IsActive;
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


                objDBAccess.executeNonQuery(ProcSaveJobPosting, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveorUpdateJobPosting");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        //Edit JobPosting
        public static string ProcEditJobPosting = "usp_SCH_EditJobPostingDetails";
        public PostingJobBO EditJobPosting(int iJobPostingId)
        {
            DataSet objDataSet = null;
            PostingJobBO objJobPostingsBO = null;
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
                    objJobPostingsBO = new PostingJobBO();
                    objJobPostingsBO.JobPostingId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objJobPostingsBO.JobName = objDataSet.Tables[0].Rows[0][1].ToString();
                    objJobPostingsBO.JobCode = objDataSet.Tables[0].Rows[0][2].ToString();
                    objJobPostingsBO.JobDescription = objDataSet.Tables[0].Rows[0][3].ToString();
                    objJobPostingsBO.JobDescriptionFile = objDataSet.Tables[0].Rows[0][4].ToString();
                    objJobPostingsBO.JobDescriptionFileSavedName = objDataSet.Tables[0].Rows[0][5].ToString();
                    objJobPostingsBO.NoOfPositions = objDataSet.Tables[0].Rows[0][6].ToString();
                    objJobPostingsBO.JobLocation = objDataSet.Tables[0].Rows[0][7].ToString();
                    objJobPostingsBO.JobTimings = objDataSet.Tables[0].Rows[0][8].ToString();
                    objJobPostingsBO.JobDuration = objDataSet.Tables[0].Rows[0][9].ToString();
                    objJobPostingsBO.Qualification = objDataSet.Tables[0].Rows[0][10].ToString();
                    objJobPostingsBO.Experience = objDataSet.Tables[0].Rows[0][11].ToString();
                    objJobPostingsBO.Skills = objDataSet.Tables[0].Rows[0][12].ToString();
                    objJobPostingsBO.StatusId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][13].ToString());
                    objJobPostingsBO.Status = objDataSet.Tables[0].Rows[0][14].ToString();
                    objJobPostingsBO.DonorProgramId = objDataSet.Tables[0].Rows[0][15].ToString();
                    objJobPostingsBO.DonorProgram = objDataSet.Tables[0].Rows[0][16].ToString();
                    objJobPostingsBO.Comments = objDataSet.Tables[0].Rows[0][17].ToString();
                    objJobPostingsBO.ApprovedBy = objDataSet.Tables[0].Rows[0][18].ToString();
                    objJobPostingsBO.ApprovedDate = objDataSet.Tables[0].Rows[0][19].ToString();
                    objJobPostingsBO.ApproverComments = objDataSet.Tables[0].Rows[0][20].ToString();
                    objJobPostingsBO.RejectedBy = objDataSet.Tables[0].Rows[0][21].ToString();
                    objJobPostingsBO.RejectedDate = objDataSet.Tables[0].Rows[0][22].ToString();
                    objJobPostingsBO.RejectedComments = objDataSet.Tables[0].Rows[0][23].ToString();
                    objJobPostingsBO.MarketedBy = objDataSet.Tables[0].Rows[0][24].ToString();
                    objJobPostingsBO.MarketedDate = objDataSet.Tables[0].Rows[0][25].ToString();
                    objJobPostingsBO.MarketingComments = objDataSet.Tables[0].Rows[0][26].ToString();
                    objJobPostingsBO.MarketingStatus = objDataSet.Tables[0].Rows[0][27].ToString();
                    objJobPostingsBO.HROfficeBy = objDataSet.Tables[0].Rows[0][28].ToString();
                    objJobPostingsBO.HROffice_Date = objDataSet.Tables[0].Rows[0][29].ToString();
                    objJobPostingsBO.HROffice_Comments = objDataSet.Tables[0].Rows[0][30].ToString();
                    objJobPostingsBO.HOPBy = objDataSet.Tables[0].Rows[0][31].ToString();
                    objJobPostingsBO.HOP_Comments = objDataSet.Tables[0].Rows[0][32].ToString();
                    objJobPostingsBO.HOP_Date = objDataSet.Tables[0].Rows[0][33].ToString();
                    objJobPostingsBO.PMBy = objDataSet.Tables[0].Rows[0][34].ToString();
                    objJobPostingsBO.PM_Comments = objDataSet.Tables[0].Rows[0][35].ToString();
                    objJobPostingsBO.PM_Date = objDataSet.Tables[0].Rows[0][36].ToString();
                    objJobPostingsBO.AdminBy = objDataSet.Tables[0].Rows[0][37].ToString();
                    objJobPostingsBO.Admin_Date = objDataSet.Tables[0].Rows[0][38].ToString();
                    objJobPostingsBO.Admin_Comments = objDataSet.Tables[0].Rows[0][39].ToString();
                    objJobPostingsBO.AdminStatus = objDataSet.Tables[0].Rows[0][40].ToString();
                    objJobPostingsBO.HAFBy = objDataSet.Tables[0].Rows[0][41].ToString();
                    objJobPostingsBO.HAF_Date = objDataSet.Tables[0].Rows[0][42].ToString();
                    objJobPostingsBO.HAF_Comments = objDataSet.Tables[0].Rows[0][43].ToString();
                    objJobPostingsBO.HAF_Status = objDataSet.Tables[0].Rows[0][44].ToString();
                    objJobPostingsBO.HRBy = objDataSet.Tables[0].Rows[0][45].ToString();
                    objJobPostingsBO.HRComments = objDataSet.Tables[0].Rows[0][46].ToString();
                    objJobPostingsBO.HRStatus = objDataSet.Tables[0].Rows[0][47].ToString();
                    objJobPostingsBO.IsActive = objDataSet.Tables[0].Rows[0][48].ToString();
                    objJobPostingsBO.HOD_Comments = objDataSet.Tables[0].Rows[0][49].ToString();
                    objJobPostingsBO.HOD_Date = objDataSet.Tables[0].Rows[0][50].ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "EditJobPosting");
                throw ex;
            }
            return objJobPostingsBO;
        }

        //View JobPosting
        public static string ProcViewJobPosting = "usp_SCH_viewJobPosting";
        public JobPostingsBO ViewJobPosting(int iJobPostingId)
        {
            DataSet objDataSet = null;
            JobPostingsBO objJobPostingsBO = null;
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iJobPostingId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iJobPostingId;
                objProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcViewJobPosting, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objJobPostingsBO = new JobPostingsBO();
                    objJobPostingsBO.JobPostingId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objJobPostingsBO.JobName = objDataSet.Tables[0].Rows[0][1].ToString();
                    objJobPostingsBO.JobCode = objDataSet.Tables[0].Rows[0][2].ToString();
                    objJobPostingsBO.JobDescription = objDataSet.Tables[0].Rows[0][3].ToString();
                    objJobPostingsBO.NoOfPositions = objDataSet.Tables[0].Rows[0][4].ToString();
                    objJobPostingsBO.JobLocation = objDataSet.Tables[0].Rows[0][5].ToString();
                    objJobPostingsBO.JobTimings = objDataSet.Tables[0].Rows[0][6].ToString();
                    objJobPostingsBO.JobDuration = objDataSet.Tables[0].Rows[0][7].ToString();
                    objJobPostingsBO.Qualification = objDataSet.Tables[0].Rows[0][8].ToString();
                    objJobPostingsBO.Experience = objDataSet.Tables[0].Rows[0][9].ToString();
                    objJobPostingsBO.Skills = objDataSet.Tables[0].Rows[0][10].ToString();
                    objJobPostingsBO.Status = objDataSet.Tables[0].Rows[0][11].ToString();
                    objJobPostingsBO.ApprovedById = objDataSet.Tables[0].Rows[0][12].ToString();
                    objJobPostingsBO.ApprovedDate = objDataSet.Tables[0].Rows[0][13].ToString();
                    objJobPostingsBO.RejectedById = objDataSet.Tables[0].Rows[0][14].ToString();
                    objJobPostingsBO.RejectedDate = objDataSet.Tables[0].Rows[0][15].ToString();
                    objJobPostingsBO.MarketedById = Convert.ToInt32(objDataSet.Tables[0].Rows[0][16].ToString());
                    objJobPostingsBO.MarketedDate = objDataSet.Tables[0].Rows[0][17].ToString();
                    objJobPostingsBO.Comments = objDataSet.Tables[0].Rows[0][18].ToString();
                    objJobPostingsBO.IsActive = Convert.ToBoolean(objDataSet.Tables[0].Rows[0][19].ToString());
                    objJobPostingsBO.DonorProgramName = objDataSet.Tables[0].Rows[0][20].ToString();

                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "ViewJobPosting");
                throw ex;
            }
            return objJobPostingsBO;
        }

        //Delete JobPosting
        public static string ProcDeleteJobPosting = "usp_SCH_deleteJobPosting";
        public string deleteJobPosting(int iJobPostingId)
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

                objDBAccess.executeNonQuery(ProcDeleteJobPosting, ref objProcParameterBOList);
                strResult = "DELETED";
            }

            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "deleteJobPosting");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        public string ProcGetHRofficeUsersList = "usp_getHRofficeUsersList";
        public List<string> getHRofficeUsersList()
        {
            DataSet objDataSet = null;
            string strEmailAddress = "";
            List<string> objUsersList = new List<string>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();

            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcGetHRofficeUsersList, ref objProcParameterBOList);
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
                ExceptionError.Error_Log(ex, "getHRofficeUsersList");
                throw ex;
            }
            return objUsersList;
        }
    }
}
