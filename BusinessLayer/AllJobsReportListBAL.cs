using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace BusinessLayer
{
    public class AllJobsReportListBAL
    {
        AllJobsReportListDAL objAllJobsReportListDAL = new AllJobsReportListDAL();
        public List<JobsReportBO> getAllJobsReportList()
        {
            return objAllJobsReportListDAL.getAllJobsReportList();
        }
    }
}
