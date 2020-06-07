using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class ApprovedJobsListDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public static string ProcGetApprovedJobsList = "usp_rpt_ApprovedJobsList";
        public List<ApprovedJobsListBO> getApprovedJobsList()
        {
            DataSet objDataSet = null;
            ApprovedJobsListBO objApprovedJobsListBO = null;
            List<ApprovedJobsListBO> objApprovedJobsBOList = new List<ApprovedJobsListBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcGetApprovedJobsList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objApprovedJobsListBO = new ApprovedJobsListBO();
                        objApprovedJobsListBO.JobName = objDataSet.Tables[0].Rows[i][0].ToString();
                        objApprovedJobsListBO.JobDescription = objDataSet.Tables[0].Rows[i][1].ToString();
                        objApprovedJobsListBO.JobLocation = objDataSet.Tables[0].Rows[i][2].ToString();
                        objApprovedJobsListBO.NoOfPositions = Convert.ToInt32(objDataSet.Tables[0].Rows[i][3].ToString());
                        objApprovedJobsListBO.ApprovedDate = objDataSet.Tables[0].Rows[i][4].ToString();
                        objApprovedJobsListBO.Status = objDataSet.Tables[0].Rows[i][5].ToString();
                        objApprovedJobsListBO.Comments = objDataSet.Tables[0].Rows[i][6].ToString();
                        objApprovedJobsBOList.Add(objApprovedJobsListBO);
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
    }
}
