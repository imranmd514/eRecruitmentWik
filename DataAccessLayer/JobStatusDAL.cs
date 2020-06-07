using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDB;
using Models;
using System.Data;
using Utils;


namespace DataAccessLayer
{
    public class JobStatusDAL
    {
        DBAccess objDBAccess = new DBAccess();
        //public const string ProcGetJobStatusGridList = "usp_GeJobStatusList";
        //public List<JobStatusBO> getAppliedJobsList()
        //{
        //    DataSet objDataSet = null;
        //    JobStatusBO objApplyJobsBo = null;
        //    List<JobStatusBO> objListJobStatusBo = new List<JobStatusBO>();
        //    List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
        //    try
        //    {
        //        objDataSet = objDBAccess.execuitDataSet(ProcGetJobStatusGridList, ref objProcParameterBOList);
        //        if (objDataSet != null && objDataSet.Tables.Count > 0)
        //        {
        //            for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
        //            {
        //                objApplyJobsBo = new JobStatusBO();
        //                objApplyJobsBo.JobPostingId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
        //                objApplyJobsBo.JobName = objDataSet.Tables[0].Rows[i][1].ToString();
        //                objApplyJobsBo.JobDescription = objDataSet.Tables[0].Rows[i][2].ToString();
        //                objApplyJobsBo.JobLocation = objDataSet.Tables[0].Rows[i][3].ToString();
        //                objApplyJobsBo.NoOfPositions = objDataSet.Tables[0].Rows[i][4].ToString();
        //                objApplyJobsBo.Status = objDataSet.Tables[0].Rows[i][5].ToString();
        //                //objApplyJobsBO.Comments = objDataSet.Tables[0].Rows[i][5].ToString();
        //                objListJobStatusBo.Add(objApplyJobsBo);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return objListJobStatusBo;
        //}

        public static string ProcGetAllApplicantsList = "usp_GetJobApplicant";
        public List<JobStatusBO> GetAllApplicantsJobList(int iApplicantId)
        {
            DataSet objDataSet = null;
            JobStatusBO objJobStatusBo = null;
            List<JobStatusBO> objListJobStatusBo = new List<JobStatusBO>();
            List<ProcParameterBO> objProcParameterBOList = new List<ProcParameterBO>();
            try
            {

                ProcParameterBO objProcParameterBo = new ProcParameterBO();
                objProcParameterBo.Direction = ParameterDirection.Input;
                objProcParameterBo.ParameterName = "@iApplicantId";
                objProcParameterBo.dbType = DbType.Int32;
                objProcParameterBo.ParameterValue = iApplicantId;
                objProcParameterBOList.Add(objProcParameterBo);

                objDataSet = objDBAccess.execuitDataSet(ProcGetAllApplicantsList, ref objProcParameterBOList);
                if (objDataSet != null && objDataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                    {
                        objJobStatusBo = new JobStatusBO();
                        objJobStatusBo.ApplicantId = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objJobStatusBo.FullName = objDataSet.Tables[0].Rows[i][1].ToString();
                        objJobStatusBo.PhoneNumber = objDataSet.Tables[0].Rows[i][2].ToString();
                        objJobStatusBo.EmailAddress = objDataSet.Tables[0].Rows[i][3].ToString();
                        objJobStatusBo.Address = objDataSet.Tables[0].Rows[i][4].ToString();
                        objJobStatusBo.StatusId = objDataSet.Tables[0].Rows[i][5].ToString();
                        objJobStatusBo.Comments = objDataSet.Tables[0].Rows[i][6].ToString();
                        objListJobStatusBo.Add(objJobStatusBo);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError.Error_Log(ex, "GetAllApplicantsJobList");
                throw ex;
            }
            return objListJobStatusBo;
        }
    }
}
