using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;
namespace BusinessLayer
{
    public class ApplicantsListBAL
    {
        ApplicantsListDAL objApplicantsListDAL = new ApplicantsListDAL();

        public List<CommonDropDownBO> GetJobTypeList()
        {
            return objApplicantsListDAL.GetJobTypeList();
        }
        public List<ApplicantsListBO> getApplicantsList(int iJobId)
        {
            return objApplicantsListDAL.getApplicantsList(iJobId);
        }
    }
}
