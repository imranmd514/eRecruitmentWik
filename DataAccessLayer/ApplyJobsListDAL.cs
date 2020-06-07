using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;


namespace DataAccessLayer
{
    public class ApplyJobsListDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public static string ProcGetApplyJobsList = "usp_rpt_ApplyJobsList";
        public List<ApplyJobsListBO> getApplyJobsList()
        {
            DataSet objDataSet = null;
            ApplyJobsListBO objApplyJobsListBO = null;
            List<ApplyJobsListBO> objApplyJobsBOList = new List<ApplyJobsListBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcGetApplyJobsList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objApplyJobsListBO = new ApplyJobsListBO();
                        objApplyJobsListBO.JobName = objDataSet.Tables[0].Rows[i][0].ToString();
                        objApplyJobsListBO.JobDescription = objDataSet.Tables[0].Rows[i][1].ToString();
                        objApplyJobsListBO.JobLocation = objDataSet.Tables[0].Rows[i][2].ToString();
                        objApplyJobsListBO.NoOfPositions = Convert.ToInt32(objDataSet.Tables[0].Rows[i][3].ToString());
                        objApplyJobsListBO.AppliedStatus = objDataSet.Tables[0].Rows[i][4].ToString();
                        objApplyJobsListBO.Comments = objDataSet.Tables[0].Rows[i][5].ToString();
                        objApplyJobsBOList.Add(objApplyJobsListBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getApplyJobsList");
                throw ex;
            }
            return objApplyJobsBOList;
        }
    }
}
