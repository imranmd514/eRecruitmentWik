using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccessLayer;
namespace BusinessLayer
{
    public class JobApplicantBAL
    {
        JobApplicantDAL objJobApplicantDAL = new JobApplicantDAL();
        public List<CommonDropDownBO> GetJobTypeList()
        {
            return objJobApplicantDAL.GetJobTypeList();
        }
        public List<JobApplicantModelBO> GetJobApplicantList(int iJobId)
        {
            return objJobApplicantDAL.GetJobApplicantList(iJobId);
        }
        public JobApplicantModelBO ViewAllApplicants(int iApplicantJobId)
        {
            return objJobApplicantDAL.ViewAllApplicants(iApplicantJobId);
        }
        public string UpdateJobWiseApplicant(JobApplicantModelBO objJobApplicantModelBo, int iUserId)
        {
            return objJobApplicantDAL.UpdateJobWiseApplicant(objJobApplicantModelBo, iUserId);
        }
        public string RejectJobWiseApplicant(JobApplicantModelBO objJobApplicantModelBo, int iUserId)
        {
            return objJobApplicantDAL.RejectJobWiseApplicant(objJobApplicantModelBo, iUserId);
        }
    }
}
