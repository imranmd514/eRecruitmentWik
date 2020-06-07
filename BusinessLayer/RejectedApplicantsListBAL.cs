using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace BusinessLayer
{
    public class RejectedApplicantsListBAL
    {
        RejectedApplicantsListDAL objRejectedApplicantsListDAL = new RejectedApplicantsListDAL();

        public List<CommonDropDownBO> GetJobTypeList()
        {
            return objRejectedApplicantsListDAL.GetJobTypeList();
        }

        public List<RejectedApplicantsListBO> getRejectedApplicantsList(int iJobId)
        {
            return objRejectedApplicantsListDAL.getRejectedApplicantsList(iJobId);
        }
    }
}
