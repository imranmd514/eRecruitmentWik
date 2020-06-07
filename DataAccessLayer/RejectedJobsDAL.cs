using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class RejectedJobsDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public static string ProcRejectedJobsList = "usp_getRejectedJobsList";
        public List<RejectedJobsBO> getRejectedJobsList()
        {

            DataSet objDataSet = null;
            RejectedJobsBO objRejectedJobsBO = null;
            List<RejectedJobsBO> objRejectedJobsBOList = new List<RejectedJobsBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcRejectedJobsList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objRejectedJobsBO = new RejectedJobsBO();
                        objRejectedJobsBO.JobPostingId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objRejectedJobsBO.JobName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objRejectedJobsBO.JobDescription = objDataSet.Tables[0].Rows[i][2].ToString();
                        objRejectedJobsBO.JobLocation = objDataSet.Tables[0].Rows[i][3].ToString();
                        objRejectedJobsBO.NoOfPositions = objDataSet.Tables[0].Rows[i][4].ToString();
                       // objRejectedJobsBO.RejectedBy = Convert.ToInt32(objDataSet.Tables[0].Rows[i][4].ToString());
                        objRejectedJobsBO.RejectedDate = objDataSet.Tables[0].Rows[i][5].ToString();
                        objRejectedJobsBO.Comments = objDataSet.Tables[0].Rows[i][6].ToString();
                        objRejectedJobsBOList.Add(objRejectedJobsBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getRejectedJobsList");
                throw ex;
            }
            return objRejectedJobsBOList;
        }


        public static string ProcViewRejectedJob = "usp_SCH_ViewRejectedJobs";
        public RejectedJobsBO DisplayRejectedJob(int iJobPostingId)
        {
            DataSet objDataSet = null;
            RejectedJobsBO objRejectedJobsBO = null;
            List<ProcParameterBO> ObjProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                ProcParameterBO objDbParameter = new ProcParameterBO();
                objDbParameter.Direction = ParameterDirection.Input;
                objDbParameter.ParameterName = "@iJobPostingId";
                objDbParameter.dbType = DbType.Int32;
                objDbParameter.ParameterValue = iJobPostingId;
                ObjProcParameterBOList.Add(objDbParameter);

                objDataSet = objDBAccess.execuitDataSet(ProcViewRejectedJob, ref ObjProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    objRejectedJobsBO = new RejectedJobsBO();
                    objRejectedJobsBO.JobName = objDataSet.Tables[0].Rows[0][0].ToString();
                    objRejectedJobsBO.JobCode = objDataSet.Tables[0].Rows[0][1].ToString();
                    objRejectedJobsBO.JobDescription = objDataSet.Tables[0].Rows[0][2].ToString();
                    objRejectedJobsBO.NoOfPositions = objDataSet.Tables[0].Rows[0][3].ToString();
                    objRejectedJobsBO.JobLocation = objDataSet.Tables[0].Rows[0][4].ToString();
                    objRejectedJobsBO.JobTimings = objDataSet.Tables[0].Rows[0][5].ToString();
                    objRejectedJobsBO.JobDuration = objDataSet.Tables[0].Rows[0][6].ToString();
                    objRejectedJobsBO.DonorProgramName = objDataSet.Tables[0].Rows[0][7].ToString();
                    objRejectedJobsBO.Qualification = objDataSet.Tables[0].Rows[0][8].ToString();
                    objRejectedJobsBO.Experience = objDataSet.Tables[0].Rows[0][9].ToString();
                    objRejectedJobsBO.Skills = objDataSet.Tables[0].Rows[0][10].ToString();
                    objRejectedJobsBO.Status = Convert.ToInt32(objDataSet.Tables[0].Rows[0][11].ToString());
                    objRejectedJobsBO.RejectedBy = Convert.ToInt32(objDataSet.Tables[0].Rows[0][12].ToString());
                    objRejectedJobsBO.RejectedDate = objDataSet.Tables[0].Rows[0][13].ToString();
                    objRejectedJobsBO.Comments = objDataSet.Tables[0].Rows[0][14].ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "DisplayRejectedJob");
                throw ex;
            }
            return objRejectedJobsBO;
        }


    }
}

