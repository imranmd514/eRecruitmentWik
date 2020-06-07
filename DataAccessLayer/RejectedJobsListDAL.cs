using CommonDB;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using Utils;

namespace DataAccessLayer
{
    public class RejectedJobsListDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public static string ProcGetRejectedobsList = "usp_rpt_RejectedjobsList";
        public List<RejectedJobsListBO> getRejectedJobsList()
        {
            DataSet objDataSet = null;
            RejectedJobsListBO objRejectedJobsListBO = null;
            List<RejectedJobsListBO> objRejectedJobsBOList = new List<RejectedJobsListBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcGetRejectedobsList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objRejectedJobsListBO = new RejectedJobsListBO();
                        objRejectedJobsListBO.JobName = objDataSet.Tables[0].Rows[i][0].ToString();
                        objRejectedJobsListBO.JobDescription = objDataSet.Tables[0].Rows[i][1].ToString();
                        objRejectedJobsListBO.JobLocation = objDataSet.Tables[0].Rows[i][2].ToString();
                        objRejectedJobsListBO.NoOfPositions = Convert.ToInt32(objDataSet.Tables[0].Rows[i][3].ToString());
                        objRejectedJobsListBO.RejectedDate = objDataSet.Tables[0].Rows[i][4].ToString();
                        objRejectedJobsListBO.Status = objDataSet.Tables[0].Rows[i][5].ToString();
                        objRejectedJobsListBO.Comments = objDataSet.Tables[0].Rows[i][6].ToString();
                        objRejectedJobsBOList.Add(objRejectedJobsListBO);
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
    }
}
