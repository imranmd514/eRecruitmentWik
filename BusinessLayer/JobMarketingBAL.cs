using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace BusinessLayer
{
    public class JobMarketingBAL
    {
        JobMarketingDAL objJobMarketingDAL = new JobMarketingDAL();
        public List<CommonDropDownBO> DonorProgramList(int iUserId)
        {
            return objJobMarketingDAL.DonorProgramList(iUserId);
        }
        public string SaveJobMarketing(JobMarketingBO objJobMarketingBO, int iUserId)
        {
            return objJobMarketingDAL.SaveJobMarketing(objJobMarketingBO, iUserId);
        }
        public List<JobMarketingBO> getJobMarketingList()
        {
            return objJobMarketingDAL.getJobMarketingList();
        }
        public JobMarketingBO EditJobMarketing(int iJobPostingId)
        {
            return objJobMarketingDAL.EditJobMarketing(iJobPostingId);
        }

        public JobMarketingBO DisplayJobMarketing(int iJobPostingId)
        {
            return objJobMarketingDAL.DisplayJobMarketing(iJobPostingId);
        }

        public string deleteJobMarketing(int iJobPostingId)
        {
            return objJobMarketingDAL.deleteJobMarketing(iJobPostingId);
        }

    }
}
