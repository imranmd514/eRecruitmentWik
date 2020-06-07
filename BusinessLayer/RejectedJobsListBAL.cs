using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace BusinessLayer
{
    public class RejectedJobsListBAL
    {
        RejectedJobsListDAL objRejectedjobsListDAL = new RejectedJobsListDAL();
        public List<RejectedJobsListBO> getRejectedJobsList()
        {
            return objRejectedjobsListDAL.getRejectedJobsList();
        }
    }
}
