using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;


namespace BusinessLayer
{
    public class PMUpdateBAL
    {
        PMUpdateDAL objPMUpdateDAL = new PMUpdateDAL();
        public List<CommonDropDownBO> GetDropDownDonorProgramList(int iUserId)
        {
            return objPMUpdateDAL.GetDropDownDonorProgramList(iUserId);
        }

        public List<AllJobsBO> getHOPUpdateGridList()
        {
            return objPMUpdateDAL.getHOPUpdateGridList();
        }
        public AllJobsBO EditPMGrid(int iJobPostingId)
        {
            return objPMUpdateDAL.EditPMGrid(iJobPostingId);
        }
        public string SavePMApprovedJob(AllJobsBO objAllJobsBO, int iUserId)
        {
            return objPMUpdateDAL.SavePMApprovedJob(objAllJobsBO, iUserId);
        }
        public AllJobsBO DisplayPMAllJob(int iJobPostingId)
        {
            return objPMUpdateDAL.DisplayPMAllJob(iJobPostingId);
        }
    }
}
