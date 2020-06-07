using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;


namespace BusinessLayer
{
    public class HOPUpdateBAL
    {
        HOPUpdateDAL objHOPUpdateDAL = new HOPUpdateDAL();

        public List<CommonDropDownBO> GetDropDownDonorProgramList(int iUserId)
        {
            return objHOPUpdateDAL.GetDropDownDonorProgramList(iUserId);
        }

        public List<AllJobsBO> getHOPUpdateGridList()
        {
            return objHOPUpdateDAL.getHOPUpdateGridList();
        }
        public string SaveHOPApprovedJob(AllJobsBO objAllJobsBO, int iUserId)
        {
            return objHOPUpdateDAL.SaveHOPApprovedJob(objAllJobsBO, iUserId);
        }

        public AllJobsBO EditHOPGrid(int iJobPostingId)
        {
            return objHOPUpdateDAL.EditHOPGrid(iJobPostingId);
        }

        public AllJobsBO DisplayHOPAllJob(int iJobPostingId)
        {
            return objHOPUpdateDAL.DisplayHOPAllJob(iJobPostingId);
        }

    }
}
