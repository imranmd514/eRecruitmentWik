using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class ApplyJobsDal
    {

        DBAccess objDBAccess = new DBAccess();

        public static string ProcGetJobsList = "usp_getApplyJobsList";
        public List<ApplyJobsBO> getAppliedJobsList(int iApplicantId)
        {
            DataSet objDataSet = null;
            ApplyJobsBO objApplyJobsBO = null;
            List<ApplyJobsBO> objobjApplyJobsBOList = new List<ApplyJobsBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objProcParameterBo = new ProcParameterBO();
                objProcParameterBo.Direction = ParameterDirection.Input;
                objProcParameterBo.ParameterName = "@iApplicantId";
                objProcParameterBo.dbType = DbType.Int32;
                objProcParameterBo.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objProcParameterBo);


                objDataSet = objDBAccess.execuitDataSet(ProcGetJobsList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objApplyJobsBO = new ApplyJobsBO();
                        objApplyJobsBO.JobPostingId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objApplyJobsBO.JobName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objApplyJobsBO.JobDescription = objDataSet.Tables[0].Rows[i][2].ToString();
                        objApplyJobsBO.JobLocation = objDataSet.Tables[0].Rows[i][3].ToString();
                        objApplyJobsBO.NoOfPositions = objDataSet.Tables[0].Rows[i][4].ToString();
                        objApplyJobsBO.ApplicantComments = objDataSet.Tables[0].Rows[i][5].ToString();
                        objApplyJobsBO.AppliedStatus = objDataSet.Tables[0].Rows[i][6].ToString();
                        objobjApplyJobsBOList.Add(objApplyJobsBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getAppliedJobsList");
                throw ex;
            }
            return objobjApplyJobsBOList;
        }

        public static string ProcViewApplyJob = "usp_ViewApplyJob";
        public ApplyJobsBO DisplayApplyJob(int iJobPostingId,int iApplicantId)
        {
            DataSet objDataSet = null;
            ApplyJobsBO objApplyJobsBO = null;
            List<ProcParameterBO> ObjProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iJobPostingId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iJobPostingId;
                ObjProcParameterBOList.Add(objDbParameter);

                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                ObjProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcViewApplyJob, ref ObjProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objApplyJobsBO = new ApplyJobsBO();
                    objApplyJobsBO.JobPostingId = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objApplyJobsBO.JobName = objDataSet.Tables[0].Rows[0][1].ToString();
                    objApplyJobsBO.JobDescription = objDataSet.Tables[0].Rows[0][2].ToString();
                    objApplyJobsBO.NoOfPositions = objDataSet.Tables[0].Rows[0][3].ToString();
                    objApplyJobsBO.JobLocation = objDataSet.Tables[0].Rows[0][4].ToString();
                    objApplyJobsBO.JobTimings = objDataSet.Tables[0].Rows[0][5].ToString();
                    objApplyJobsBO.JobDuration = objDataSet.Tables[0].Rows[0][6].ToString();
                    objApplyJobsBO.DonorProgramName = objDataSet.Tables[0].Rows[0][7].ToString();
                    objApplyJobsBO.Qualification = objDataSet.Tables[0].Rows[0][8].ToString();
                    objApplyJobsBO.Experience = objDataSet.Tables[0].Rows[0][9].ToString();
                    objApplyJobsBO.Skills = objDataSet.Tables[0].Rows[0][10].ToString();
                    objApplyJobsBO.Comments = objDataSet.Tables[0].Rows[0][11].ToString();
                    objApplyJobsBO.JobDescriptionFile = objDataSet.Tables[0].Rows[0][12].ToString();
                    objApplyJobsBO.JobDescriptionFileSavedName = objDataSet.Tables[0].Rows[0][13].ToString();
                    objApplyJobsBO.AppliedStatus = objDataSet.Tables[0].Rows[0][14].ToString();

                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "DisplayApplyJob");
                throw ex;
            }
            return objApplyJobsBO;
        }

        public static string ProcApplyJob = "usp_ERT_SaveAppliedJobs";
        public string SaveApplyJob(ApplyJobsBO objAppliedJobsModelBo,int iApplicantId, int iUserId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDBparameter = null;
            string strResult = "";
            try
            {
                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iApplicantJobId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objAppliedJobsModelBo.ApplicantJobId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@IApplicantId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@iJobId";
                objDBparameter.dbType = DbType.Int32;
                objDBparameter.ParameterValue = objAppliedJobsModelBo.JobPostingId;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strComments";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAppliedJobsModelBo.Comments;
                objProcParameterBOList.Add(objDBparameter);

                objDBparameter = new ProcParameterBO();
                objDBparameter.Direction = ParameterDirection.Input;
                objDBparameter.ParameterName = "@strApplicantComments";
                objDBparameter.dbType = DbType.String;
                objDBparameter.ParameterValue = objAppliedJobsModelBo.ApplicantComments;
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

                objDBAccess.executeNonQuery(ProcApplyJob, ref objProcParameterBOList);

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
                ExceptionError.Error_Log(ex, "SaveApplyJob");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        public string ProcGetCheckApplicantExist = "usp_SCH_CheckApplicantExist";
        public string CheckApplicantExist(int iApplicantId)
        {
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            ProcParameterBO objDbParameter = null;
            string strResult = "";
            try
            {
                objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iApplicantId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objDbParameter);

                strResult = objDBAccess.executeScalar(ProcGetCheckApplicantExist, ref objProcParameterBOList).ToString();

            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "CheckApplicantExist");
                strResult = "FAILED";
                throw ex;
            }
            return strResult;
        }

        //public static string ProcSaveAppliedJob = "usp_saveAppliedJob";
        //public string SaveApplyJob(int iJobPostingId, int iUserId)
        //{
        //    List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
        //    ProcParameterBO objDBparameter = null;
        //    string strResult = "";
        //    try
        //    {

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@iJobPostingId";
        //        objDBparameter.dbType = DbType.Int32;
        //        objDBparameter.ParameterValue = iJobPostingId;
        //        objProcParameterBOList.Add(objDBparameter);



        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Input;
        //        objDBparameter.ParameterName = "@iUserId";
        //        objDBparameter.dbType = DbType.Int32;
        //        objDBparameter.ParameterValue = iUserId;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBparameter = new ProcParameterBO();
        //        objDBparameter.Direction = ParameterDirection.Output;
        //        objDBparameter.ParameterName = "@strResult";
        //        objDBparameter.dbType = DbType.String;
        //        objDBparameter.Size = 100;
        //        objProcParameterBOList.Add(objDBparameter);

        //        objDBAccess.executeNonQuery(ProcSaveAppliedJob, ref objProcParameterBOList);

        //        for (int i = 0; i < objProcParameterBOList.Count; i++)
        //        {
        //            if (objProcParameterBOList[i].Direction == ParameterDirection.Output)
        //            {
        //                strResult = objProcParameterBOList[i].ParameterValue.ToString();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        strResult = "FAILED";
        //        throw ex;
        //    }
        //    return strResult;
        //}
    }
}
