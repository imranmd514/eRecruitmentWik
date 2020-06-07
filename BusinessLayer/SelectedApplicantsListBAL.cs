using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace BusinessLayer
{
    public class SelectedApplicantsListBAL
    {
        SelectedApplicantsListDAL objSelectedApplicantsListDAL = new SelectedApplicantsListDAL();

        public List<CommonDropDownBO> GetJobTypeList()
        {
            return objSelectedApplicantsListDAL.GetJobTypeList();
        }
        public List<SelectedApplicantsListBO> getSelectedApplicantsList(int iJobId)
        {
            return objSelectedApplicantsListDAL.getSelectedApplicantsList(iJobId);
        }
    }
}
