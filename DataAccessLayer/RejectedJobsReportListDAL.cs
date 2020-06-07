using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CommonDB;
using Models;
using Utils;

namespace DataAccessLayer
{
    public class RejectedJobsReportListDAL
    {
        DBAccess objDBAccess = new DBAccess();

        public static string ProcGetRejectedJobsReportList = "usp_SCH_RejectedJobsReportList";
        public List<JobsReportBO> getRejectedJobsReportList()
        {
            DataSet objDataSet = null;
            JobsReportBO objJobsReportBO = null;
            List<JobsReportBO> objJobsReportBOList = new List<JobsReportBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {
                objDataSet = objDBAccess.execuitDataSet(ProcGetRejectedJobsReportList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objJobsReportBO = new JobsReportBO();
                        objJobsReportBO.JobName = objDataSet.Tables[0].Rows[i][0].ToString();
                        objJobsReportBO.JobDescription = objDataSet.Tables[0].Rows[i][1].ToString();
                        objJobsReportBO.NoOfPositions = objDataSet.Tables[0].Rows[i][2].ToString();
                        objJobsReportBO.JobLocation = objDataSet.Tables[0].Rows[i][3].ToString();
                        objJobsReportBO.DonorProgramName = objDataSet.Tables[0].Rows[i][4].ToString();
                        objJobsReportBO.RequiredStaffLevel = objDataSet.Tables[0].Rows[i][5].ToString();
                        objJobsReportBO.CurrentStaffLevel = objDataSet.Tables[0].Rows[i][6].ToString();
                        objJobsReportBO.Gaps = objDataSet.Tables[0].Rows[i][7].ToString();
                        objJobsReportBO.Status = objDataSet.Tables[0].Rows[i][8].ToString();
                        objJobsReportBOList.Add(objJobsReportBO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "getRejectedJobsReportList");
                throw ex;
            }
            return objJobsReportBOList;
        }
    }
}
