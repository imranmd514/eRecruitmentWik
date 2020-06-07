using DataAccessLayer;
using Models;
using System.Collections.Generic;
namespace BusinessLayer
{
    public class RejectedApplicantsBAL
    {
        RejectedApplicantsDAL objRejectedApplicantsDAL = new RejectedApplicantsDAL();

        public List<CommonDropDownBO> GetJobTypeList()
        {
            return objRejectedApplicantsDAL.GetJobTypeList();
        }
        public List<RejectedApplicantsBO> getRejectedApplicantsList(int iJobId)
        {
            return objRejectedApplicantsDAL.getRejectedApplicantsList(iJobId);
        }
        public RejectedApplicantsBO DisplayRejectedApplicant(int iApplicantId, int iJobPostingId)
        {
            return objRejectedApplicantsDAL.DisplayRejectedApplicant(iApplicantId, iJobPostingId);
        }
        //public List<RejectedApplicantsBO> getSkillsInfoList(int iApplicantId, int iJobPostingId)
        //{
        //    return objRejectedApplicantsDAL.getSkillsInfoList(iApplicantId, iJobPostingId);
        //}
    }
}
