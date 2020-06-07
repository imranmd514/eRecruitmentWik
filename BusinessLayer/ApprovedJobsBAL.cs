using DataAccessLayer;
using Models;
using System.Collections.Generic;
namespace BusinessLayer
{
    public class ApprovedJobsBAL
    {
        ApprovedJobsDAL objApprovedJobsDAL = new ApprovedJobsDAL();

        public List<PostJobBO> getApprovedJobsList(int iUserId, int iRoleId, int iStatusId)
        {
            return objApprovedJobsDAL.getApprovedJobsList(iUserId, iRoleId, iStatusId);
        }

        public ApprovedJobsBO DisplayApprovedJob(int iJobPostingId)
        {
            return objApprovedJobsDAL.DisplayApprovedJob(iJobPostingId);
        }
    }
}
