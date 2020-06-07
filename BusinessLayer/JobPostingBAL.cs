using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccessLayer;
namespace BusinessLayer
{
    public class JobPostingBAL
    {
        JobPostingsDAL objJobPostingsDAL = new JobPostingsDAL();

        public List<CommonDropDownBO> DonorProgramList(int iUserId)
        {
            return objJobPostingsDAL.DonorProgramList(iUserId);
        }

        public List<PostJobBO> getJobsList(int iUserId)
        {
            return objJobPostingsDAL.getJobsList(iUserId);
        }
        public string SaveorUpdateJobPosting(PostJobBO objJobPostingsBO, int iUserId)
        {
            return objJobPostingsDAL.SaveorUpdateJobPosting(objJobPostingsBO, iUserId);
        }
        public PostingJobBO EditJobPosting(int iJobPostingId)
        {
            return objJobPostingsDAL.EditJobPosting(iJobPostingId);
        }
        public JobPostingsBO ViewJobPosting(int iJobPostingId)
        {
            return objJobPostingsDAL.ViewJobPosting(iJobPostingId);
        }
        public string deleteJobPosting(int iJobPostingId)
        {
            return objJobPostingsDAL.deleteJobPosting(iJobPostingId);
        }
        public List<string> getHRofficeUsersList()
        {
            return objJobPostingsDAL.getHRofficeUsersList();
        }

    }
}
