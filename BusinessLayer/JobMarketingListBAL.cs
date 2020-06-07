using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace BusinessLayer
{
    public class JobMarketingListBAL
    {
        JobMarketingListDAL objJobMarketingListDAL = new JobMarketingListDAL();
        public List<JobMarketingListBO> getJobMarketingList()
        {
            return objJobMarketingListDAL.getJobMarketingList();
        }
    }
}
