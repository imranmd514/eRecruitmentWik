using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccessLayer;

namespace BusinessLayer
{
    public class RejectedJobsReportListBAL
    {
        RejectedJobsReportListDAL objRejectedJobsReportListDAL = new RejectedJobsReportListDAL();

        public List<JobsReportBO> getRejectedJobsReportList()
        {
            return objRejectedJobsReportListDAL.getRejectedJobsReportList();
        }
    }
}
