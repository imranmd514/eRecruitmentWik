using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;
namespace BusinessLayer
{

    public class AllJobsBAL
    {
        AllJobsDAL objAllJobsDAL = new AllJobsDAL();

        public List<CommonDropDownBO> DonorProgramList(int iUserId)
        {
            return objAllJobsDAL.DonorProgramList(iUserId);
        }
        public List<PostJobBO> getAllJobsList()
        {
            return objAllJobsDAL.getAllJobsList();
        }
        public string SaveApprovedJob(AllJobsBO objAllJobsBO, int iUserId, int iRoleId)
        {
            return objAllJobsDAL.SaveApprovedJob(objAllJobsBO, iUserId, iRoleId);
        }
        public List<string> GetHOPPMHAFUsersList()
        {
            return objAllJobsDAL.GetHOPPMHAFUsersList();
        }
        public List<string> GetEDUsersList()
        {
            return objAllJobsDAL.GetEDUsersList();
        }
        public List<string> GetMarketerUsersList()
        {
            return objAllJobsDAL.GetMarketerUsersList();
        }
        public string SaveRejectedJob(AllJobsBO objAllJobsBO, int iUserId, int iRoleId)
        {
            return objAllJobsDAL.SaveRejectedJob(objAllJobsBO, iUserId, iRoleId);
        }

        public string SaveOnHoldJob(AllJobsBO objAllJobsBO, int iUserId, string strRoleName)
        {
            return objAllJobsDAL.SaveOnHoldJob(objAllJobsBO, iUserId, strRoleName);
        }

        public AllJobsBO EditAllJobs(int iJobPostingId)
        {
            return objAllJobsDAL.EditAllJobs(iJobPostingId);
        }

        public string deleteAllJobs(int iJobPostingId)
        {
            return objAllJobsDAL.deleteAllJobs(iJobPostingId);
        }

        public AllJobsBO DisplayAllJob(int iJobPostingId)
        {
            return objAllJobsDAL.DisplayAllJob(iJobPostingId);
        }

    }
}
