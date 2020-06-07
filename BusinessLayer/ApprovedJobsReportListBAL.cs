using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace BusinessLayer
{
    public class ApprovedJobsReportListBAL
    {
        ApprovedJobsReportListDAL objApprovedJobsReportListDAL = new ApprovedJobsReportListDAL();

        public List<JobsReportBO> getApprovedJobsReportList()
        {
            return objApprovedJobsReportListDAL.getApprovedJobsReportList();
        }
    }
}
