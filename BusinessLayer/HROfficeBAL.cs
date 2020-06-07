using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace BusinessLayer
{
    public class HROfficeBAL
    {
        HROfficeDAL objHROfficeDAL = new HROfficeDAL();

        public List<CommonDropDownBO> GetDropDownDonorProgramList(int iUserId)
        {
            return objHROfficeDAL.GetDropDownDonorProgramList(iUserId);
        }

        public List<AllJobsBO> getHROfficeGridList()
        {
            return objHROfficeDAL.getHROfficeGridList();
        }
        public AllJobsBO EditHROfficeGrid(int iJobPostingId)
        {
            return objHROfficeDAL.EditHROfficeGrid(iJobPostingId);
        }
        public string SaveHRApprovedJob(AllJobsBO objAllJobsBO, int iUserId,int iStatusId)
        {
            return objHROfficeDAL.SaveHRApprovedJob(objAllJobsBO, iUserId, iStatusId);
        }
        public string SaveHRRejectedJob(AllJobsBO objAllJobsBO, int iUserId)
        {
            return objHROfficeDAL.SaveHRRejectedJob(objAllJobsBO, iUserId);
        }
        public AllJobsBO DisplayHRAllJob(int iJobPostingId)
        {
            return objHROfficeDAL.DisplayHRAllJob(iJobPostingId);
        }
    }
}
