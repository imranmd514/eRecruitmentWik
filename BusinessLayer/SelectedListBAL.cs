using DataAccessLayer;
using Models;
using System.Collections.Generic;
namespace BusinessLayer
{
    public class SelectedListBAL
    {
        SelectedListDAL objSelectedListDAL = new SelectedListDAL();

        public List<CommonDropDownBO> GetJobTypeList()
        {
            return objSelectedListDAL.GetJobTypeList();
        }
        public List<SelectedListBO> getSelectedList(int iJobId)
        {
            return objSelectedListDAL.getSelectedList(iJobId);
        }
        public SelectedListBO ViewSelectedApplicant(int iApplicantId, int iJobPostingId)
        {
            return objSelectedListDAL.ViewSelectedApplicant(iApplicantId, iJobPostingId);
        }
        //public List<SelectedListBO> getSkillsInfoList(int iApplicantId, int iJobPostingId)
        //{
        //    return objSelectedListDAL.getSkillsInfoList(iApplicantId, iJobPostingId);
        //}
    }
}
