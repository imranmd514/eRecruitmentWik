using DataAccessLayer;
using Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class ApplyJobsBAL
    {
        ApplyJobsDal objApplyJobsDal = new ApplyJobsDal();
        public List<ApplyJobsBO> getAppliedJobsList(int iApplicantId)
        {
            return objApplyJobsDal.getAppliedJobsList(iApplicantId);
        }
        public ApplyJobsBO DisplayApplyJob(int iJobPostingId, int iApplicantId)
        {
            return objApplyJobsDal.DisplayApplyJob(iJobPostingId, iApplicantId);
        }
        //public string SaveApplyJob(int iJobPostingId, int iUserId)
        //{
        //    return objApplyJobsDal.SaveApplyJob(iJobPostingId, iUserId);
        //}
        public string SaveApplyJob(ApplyJobsBO objAppliedJobsModelBo, int iApplicantId, int iUserId)
        {
            return objApplyJobsDal.SaveApplyJob(objAppliedJobsModelBo, iApplicantId, iUserId);
        }
        public string CheckApplicantExist(int iApplicantId)
        {
            return objApplyJobsDal.CheckApplicantExist(iApplicantId);
        }
    }
}
