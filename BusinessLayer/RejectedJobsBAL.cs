using DataAccessLayer;
using Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class RejectedJobsBAL
    {
        RejectedJobsDAL objRejectedJobsDAL = new RejectedJobsDAL();

        public List<RejectedJobsBO> getRejectedJobsList()
        {
            return objRejectedJobsDAL.getRejectedJobsList();
        }

        public RejectedJobsBO DisplayRejectedJob(int iJobPostingId)
        {
            return objRejectedJobsDAL.DisplayRejectedJob(iJobPostingId);
        }
    }
}
