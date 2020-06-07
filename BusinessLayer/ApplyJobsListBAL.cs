using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;
namespace BusinessLayer
{
    public class ApplyJobsListBAL
    {
        ApplyJobsListDAL objApplyJobsListDAL = new ApplyJobsListDAL();
        public List<ApplyJobsListBO> getApplyJobsList()
        {
            return objApplyJobsListDAL.getApplyJobsList();
        }
    }
}
