using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class JobsListDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public static string ProcGetJobsList = "usp_rpt_JobsList";
        public List<JobsListBO> getJobsList()
        {
            DataSet objDataSet = null;
            JobsListBO objJobsListBO = null;
            List<JobsListBO> objJobsBOList = new List<JobsListBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcGetJobsList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objJobsListBO = new JobsListBO();
                        objJobsListBO.JobName = objDataSet.Tables[0].Rows[i][0].ToString();
                        objJobsListBO.JobDescription = objDataSet.Tables[0].Rows[i][1].ToString();
                        objJobsListBO.NoOfPositions = Convert.ToInt32(objDataSet.Tables[0].Rows[i][2].ToString());
                        objJobsListBO.JobLocation = objDataSet.Tables[0].Rows[i][3].ToString();
                        objJobsListBO.Status = objDataSet.Tables[0].Rows[i][4].ToString();
                        objJobsListBO.Comments = objDataSet.Tables[0].Rows[i][5].ToString();
                        objJobsBOList.Add(objJobsListBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getJobsList");
                throw ex;
            }
            return objJobsBOList;
        }
    }
}
