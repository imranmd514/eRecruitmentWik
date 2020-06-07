using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class ApprovedJobsDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public static string ProcApprovedJobsList = "usp_getApprovedJobsList";
        public List<PostJobBO> getApprovedJobsList(int iUserId, int iRoleId, int iStatusId)
        {
            DataSet objDataSet = null;
            PostJobBO objApprovedJobsBO = null;
            List<PostJobBO> objApprovedJobsBOList = new List<PostJobBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDbParameter = null;
            try
            {
                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iUserId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iUserId;
                objProcParameterBOList.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iRoleId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iRoleId;
                objProcParameterBOList.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iStatusId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iStatusId;
                objProcParameterBOList.Add(objDbParameter);


                objDataSet = objDBAccess.execuitDataSet(ProcApprovedJobsList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objApprovedJobsBO = new PostJobBO();
                        objApprovedJobsBO.JobPostingId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objApprovedJobsBO.JobName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objApprovedJobsBO.JobCode = objDataSet.Tables[0].Rows[i][2].ToString();
                        objApprovedJobsBO.JobDescription = objDataSet.Tables[0].Rows[i][3].ToString();
                        objApprovedJobsBO.NoOfPositions = objDataSet.Tables[0].Rows[i][4].ToString();
                        objApprovedJobsBO.JobLocation = objDataSet.Tables[0].Rows[i][5].ToString();
                        objApprovedJobsBO.JobTimings = objDataSet.Tables[0].Rows[i][6].ToString();
                        objApprovedJobsBO.JobDuration = objDataSet.Tables[0].Rows[i][7].ToString();
                        objApprovedJobsBO.Qualification = objDataSet.Tables[0].Rows[i][8].ToString();
                        objApprovedJobsBO.Experience = objDataSet.Tables[0].Rows[i][9].ToString();
                        objApprovedJobsBO.Skills = objDataSet.Tables[0].Rows[i][10].ToString();
                        objApprovedJobsBO.StatusId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][11].ToString());
                        objApprovedJobsBO.DonorProgramId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][12].ToString());
                        objApprovedJobsBO.DonorProgram = objDataSet.Tables[0].Rows[i][13].ToString();
                        objApprovedJobsBOList.Add(objApprovedJobsBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getApprovedJobsList");
                throw ex;
            }
            return objApprovedJobsBOList;
        }


        public static string ProcViewApprovedJob = "usp_SCH_ViewApprovedJobs";
        public ApprovedJobsBO DisplayApprovedJob(int iJobPostingId)
        {
            DataSet objDataSet = null;
            ApprovedJobsBO objApprovedJobsBO = null;
            List<ProcParameterBO> ObjProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iJobPostingId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iJobPostingId;
                ObjProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcViewApprovedJob, ref ObjProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objApprovedJobsBO = new ApprovedJobsBO();
                    objApprovedJobsBO.JobName = objDataSet.Tables[0].Rows[0][0].ToString();
                    objApprovedJobsBO.JobCode = objDataSet.Tables[0].Rows[0][1].ToString();
                    objApprovedJobsBO.JobDescription = objDataSet.Tables[0].Rows[0][2].ToString();
                    objApprovedJobsBO.NoOfPositions = objDataSet.Tables[0].Rows[0][3].ToString();
                    objApprovedJobsBO.JobLocation = objDataSet.Tables[0].Rows[0][4].ToString();
                    objApprovedJobsBO.JobTimings = objDataSet.Tables[0].Rows[0][5].ToString();
                    objApprovedJobsBO.JobDuration = objDataSet.Tables[0].Rows[0][6].ToString();
                    objApprovedJobsBO.Qualification = objDataSet.Tables[0].Rows[0][7].ToString();
                    objApprovedJobsBO.Experience = objDataSet.Tables[0].Rows[0][8].ToString();
                    objApprovedJobsBO.Skills = objDataSet.Tables[0].Rows[0][9].ToString();
                    objApprovedJobsBO.Status = objDataSet.Tables[0].Rows[0][10].ToString();
                    objApprovedJobsBO.DonorProgramId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][11].ToString());
                    objApprovedJobsBO.DonorProgram = objDataSet.Tables[0].Rows[0][12].ToString();
                    objApprovedJobsBO.Comments = objDataSet.Tables[0].Rows[0][13].ToString();
                    objApprovedJobsBO.ApprovedBy = objDataSet.Tables[0].Rows[0][14].ToString();
                    objApprovedJobsBO.ApprovedDate = objDataSet.Tables[0].Rows[0][15].ToString();
                    objApprovedJobsBO.ApproverComments = objDataSet.Tables[0].Rows[0][16].ToString();
                    objApprovedJobsBO.RejectedBy = objDataSet.Tables[0].Rows[0][17].ToString();
                    objApprovedJobsBO.RejectedDate = objDataSet.Tables[0].Rows[0][18].ToString();
                    objApprovedJobsBO.RejectedComments = objDataSet.Tables[0].Rows[0][19].ToString();
                    objApprovedJobsBO.MarketedBy = objDataSet.Tables[0].Rows[0][20].ToString();
                    objApprovedJobsBO.MarketedDate = objDataSet.Tables[0].Rows[0][21].ToString();
                    objApprovedJobsBO.MarketingComments = objDataSet.Tables[0].Rows[0][22].ToString();
                    objApprovedJobsBO.MarketingStatus = objDataSet.Tables[0].Rows[0][23].ToString();
                    objApprovedJobsBO.HROfficeBy = objDataSet.Tables[0].Rows[0][24].ToString();
                    objApprovedJobsBO.HROffice_Date = objDataSet.Tables[0].Rows[0][25].ToString();
                    objApprovedJobsBO.HROffice_Comments = objDataSet.Tables[0].Rows[0][26].ToString();
                    objApprovedJobsBO.HOPBy = objDataSet.Tables[0].Rows[0][27].ToString();
                    objApprovedJobsBO.HOP_Comments = objDataSet.Tables[0].Rows[0][28].ToString();
                    objApprovedJobsBO.HOP_Date = objDataSet.Tables[0].Rows[0][29].ToString();
                    objApprovedJobsBO.PMBy = objDataSet.Tables[0].Rows[0][30].ToString();
                    objApprovedJobsBO.PM_Comments = objDataSet.Tables[0].Rows[0][31].ToString();
                    objApprovedJobsBO.PM_Date = objDataSet.Tables[0].Rows[0][32].ToString();
                    objApprovedJobsBO.AdminBy = objDataSet.Tables[0].Rows[0][33].ToString();
                    objApprovedJobsBO.Admin_Date = objDataSet.Tables[0].Rows[0][34].ToString();
                    objApprovedJobsBO.Admin_Comments = objDataSet.Tables[0].Rows[0][35].ToString();
                    objApprovedJobsBO.AdminStatus = objDataSet.Tables[0].Rows[0][36].ToString();
                    objApprovedJobsBO.HAFBy = objDataSet.Tables[0].Rows[0][37].ToString();
                    objApprovedJobsBO.HAF_Date = objDataSet.Tables[0].Rows[0][38].ToString();
                    objApprovedJobsBO.HAF_Comments = objDataSet.Tables[0].Rows[0][39].ToString();
                    objApprovedJobsBO.HAF_Status = objDataSet.Tables[0].Rows[0][40].ToString();
                    objApprovedJobsBO.HRBy = objDataSet.Tables[0].Rows[0][41].ToString();
                    objApprovedJobsBO.HRComments = objDataSet.Tables[0].Rows[0][42].ToString();
                    objApprovedJobsBO.HRStatus = objDataSet.Tables[0].Rows[0][43].ToString();
                    objApprovedJobsBO.IsActive = objDataSet.Tables[0].Rows[0][44].ToString();
                    objApprovedJobsBO.CreatedBy = objDataSet.Tables[0].Rows[0][45].ToString();
                    objApprovedJobsBO.CreatedOn = objDataSet.Tables[0].Rows[0][46].ToString();
                    objApprovedJobsBO.JobPostingId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][47].ToString());
                    objApprovedJobsBO.JobDescriptionFile = objDataSet.Tables[0].Rows[0][48].ToString();
                    objApprovedJobsBO.JobDescriptionFileSavedName = objDataSet.Tables[0].Rows[0][49].ToString();
                    objApprovedJobsBO.HOD_Comments = objDataSet.Tables[0].Rows[0][50].ToString();
                    objApprovedJobsBO.HOD_Date = objDataSet.Tables[0].Rows[0][51].ToString();
                    objApprovedJobsBO.RequiredStaffLevel = objDataSet.Tables[0].Rows[0][52].ToString();
                    objApprovedJobsBO.CurrentStaffLevel = objDataSet.Tables[0].Rows[0][53].ToString();
                    objApprovedJobsBO.Gaps = objDataSet.Tables[0].Rows[0][54].ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "DisplayApprovedJob");
                throw ex;
            }
            return objApprovedJobsBO;
        }

    }
}
