using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;
namespace BusinessLayer
{
    public class ApprovedJobsListBAL
    {
        ApprovedJobsListDAL objApprovedJobsListDAL = new ApprovedJobsListDAL();
        public List<ApprovedJobsListBO> getApprovedJobsList()
        {
            return objApprovedJobsListDAL.getApprovedJobsList();
        }
    }
}
