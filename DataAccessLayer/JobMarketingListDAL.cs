using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class JobMarketingListDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public static string ProcGetJobMarketingList = "usp_rpt_JobMarketingList";
        public List<JobMarketingListBO> getJobMarketingList()
        {
            DataSet objDataSet = null;
            JobMarketingListBO objJobMarketingListBO = null;
            List<JobMarketingListBO> objJobMarketingBOList = new List<JobMarketingListBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcGetJobMarketingList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objJobMarketingListBO = new JobMarketingListBO();
                        objJobMarketingListBO.JobName = objDataSet.Tables[0].Rows[i][0].ToString();
                        objJobMarketingListBO.JobDescription = objDataSet.Tables[0].Rows[i][1].ToString();
                        objJobMarketingListBO.NoOfPositions = Convert.ToInt32(objDataSet.Tables[0].Rows[i][2].ToString());
                        objJobMarketingListBO.JobLocation = objDataSet.Tables[0].Rows[i][3].ToString();
                        objJobMarketingListBO.Status = objDataSet.Tables[0].Rows[i][4].ToString();
                        objJobMarketingListBO.MarketingStatus = objDataSet.Tables[0].Rows[i][5].ToString();
                        objJobMarketingListBO.MarketedBy = Convert.ToInt32(objDataSet.Tables[0].Rows[i][6].ToString());
                        objJobMarketingListBO.MarketingComments = objDataSet.Tables[0].Rows[i][7].ToString();
                        objJobMarketingBOList.Add(objJobMarketingListBO);
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
    }
}
