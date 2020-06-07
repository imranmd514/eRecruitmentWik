using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;
namespace BusinessLayer
{
    public class JobsListBAL
    {
        JobsListDAL objJobsListDAL = new JobsListDAL();
        public List<JobsListBO> getJobsList()
        {
            return objJobsListDAL.getJobsList();
        }
    }
}
