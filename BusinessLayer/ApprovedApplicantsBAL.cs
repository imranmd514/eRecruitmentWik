using DataAccessLayer;
using Models;
using System.Collections.Generic;
namespace BusinessLayer
{
    public class ApprovedApplicantsBAL
    {
        ApprovedApplicantsDAL objApprovedApplicantsDAL = new ApprovedApplicantsDAL();
        public List<CommonDropDownBO> GetJobTypeList()
        {
            return objApprovedApplicantsDAL.GetJobTypeList();
        }

        public List<CommonDropDownBO> CommunicationSkillList()
        {
            return objApprovedApplicantsDAL.CommunicationSkillList();
        }

        public List<CommonDropDownBO> ExperienceList()
        {
            return objApprovedApplicantsDAL.ExperienceList();
        }

        public List<CommonDropDownBO> RatingList()
        {
            return objApprovedApplicantsDAL.RatingList();
        }

        public List<CommonDropDownBO> getMonthsList()
        {
            return objApprovedApplicantsDAL.getMonthsList();
        }

        public List<CommonDropDownBO> getYearList()
        {
            return objApprovedApplicantsDAL.getYearList();
        }

        public List<ApprovedApplicantsBO> getApprovedApplicants(int iJobId)
        {
            return objApprovedApplicantsDAL.getApprovedApplicants(iJobId);
        }
        public ApprovedApplicantsBO DisplayApprovedApplicant(int iAppliedJobId,int iApplicantId)
        {
            return objApprovedApplicantsDAL.DisplayApprovedApplicant(iAppliedJobId, iApplicantId);
        }
        public ApprovedApplicantsBO EditShortList(int iAppliedJobId, int iApplicantId)
        {
            return objApprovedApplicantsDAL.EditShortList(iAppliedJobId, iApplicantId);
        }
        public string saveSelectedApplicant(EvaluationFormBO objEvaluationFormBO, int iUserId)
        {
            return objApprovedApplicantsDAL.saveSelectedApplicant(objEvaluationFormBO, iUserId);
        }

        public string saveRejectedApplicant(EvaluationFormBO objEvaluationFormBO, int iUserId)
        {
            return objApprovedApplicantsDAL.saveRejectedApplicant(objEvaluationFormBO, iUserId);
        }

        public EvaluationFormBO GetEvaluationApplicantDetails(int iApplicantId,int iJobId)
        {
            return objApprovedApplicantsDAL.GetEvaluationApplicantDetails(iApplicantId, iJobId);
        }

        public string saveSkillInfo(EvaluationFormBO objEvaluationFormBO, int iUserId)
        {
            return objApprovedApplicantsDAL.saveSkillInfo(objEvaluationFormBO, iUserId);
        }

        public List<EvaluationFormBO> getSkillsInfoList(int iApplicantId, int iJobPostingId)
        {
            return objApprovedApplicantsDAL.getSkillsInfoList(iApplicantId, iJobPostingId);
        }

        public string DeleteSkillsList(int iApplicantSkillId)
        {
            return objApprovedApplicantsDAL.DeleteSkillsList(iApplicantSkillId);
        }
    }
}

