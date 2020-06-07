using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace BusinessLayer
{
    public class UpdateProfileBAL
    {
        UpdateProfileDAL objUpdateProfileDAL = new UpdateProfileDAL();

        public List<CommonDropDownBO> TitleList()
        {
            return objUpdateProfileDAL.TitleList();
        }
        public List<CommonDropDownBO> CountryList()
        {
            return objUpdateProfileDAL.CountryList();
        }

        public List<CommonDropDownBO> GenderList()
        {
            return objUpdateProfileDAL.GenderList();
        }

        public List<CommonDropDownBO> RefererList()
        {
            return objUpdateProfileDAL.RefererList();
        }

        public List<CommonDropDownBO> IdTypeList()
        {
            return objUpdateProfileDAL.IdTypeList();

        }
        public List<CommonDropDownBO> AcademicQualificationsList()
        {
            return objUpdateProfileDAL.AcademicQualificationsList();
        }
        public ApplicantRegistrationBO GetApplicantDetails(int iApplicantId)
        {
            return objUpdateProfileDAL.GetApplicantDetails(iApplicantId);
        }
        public List<CommonDropDownBO> TypeOfIndustryList()
        {
            return objUpdateProfileDAL.TypeOfIndustryList();
        }

        public string CheckApplicantExist(int iApplicantId)
        {
            return objUpdateProfileDAL.CheckApplicantExist(iApplicantId);
        }
        public string SaveorUpdateApplicantRegistration(ApplicantPersonalInformationBO objApplicantPersonalInformationBO, int iUserId)
        {
            return objUpdateProfileDAL.SaveorUpdateApplicantRegistration(objApplicantPersonalInformationBO, iUserId);
        }
        public string SaveorUpdateApplicantQualification(ApplicantQualificationBO objApplicantQualificationBO, int iUserId)
        {
            return objUpdateProfileDAL.SaveorUpdateApplicantQualification(objApplicantQualificationBO, iUserId);
        }
        public List<ApplicantQualificationBO> GetApplicantQualificationList(int iApplicantId)
        {
            return objUpdateProfileDAL.GetApplicantQualificationList(iApplicantId);
        }
        public ApplicantQualificationBO EditApplicantQualificationList(int iApplicantQualificationId, int iApplicantId)
        {
            return objUpdateProfileDAL.EditApplicantQualificationList(iApplicantQualificationId, iApplicantId);
        }
        public string DeleteApplicantQualification(int iApplicantQualificationId)
        {
            return objUpdateProfileDAL.DeleteApplicantQualification(iApplicantQualificationId);
        }




        public string SaveorUpdateApplicantEmploymentHistory(ApplicantEmploymentHistoryBO objApplicantEmploymentHistoryBO, int iUserId)
        {
            return objUpdateProfileDAL.SaveorUpdateApplicantEmploymentHistory(objApplicantEmploymentHistoryBO, iUserId);
        }
        public List<ApplicantEmploymentHistoryBO> GetEmploymentHistoryList(int iApplicantId)
        {
            return objUpdateProfileDAL.GetEmploymentHistoryList(iApplicantId);
        }
        public ApplicantEmploymentHistoryBO EditApplicantEmploymentHistory(int iEmploymentHistoryId, int iApplicantId)
        {
            return objUpdateProfileDAL.EditApplicantEmploymentHistory(iEmploymentHistoryId, iApplicantId);
        }
        public string DeleteApplicantEmploymentHistory(int iEmploymentHistoryId)
        {
            return objUpdateProfileDAL.DeleteApplicantEmploymentHistory(iEmploymentHistoryId);
        }




        public string SaveorUpdateRefereesDetails(ApplicantRefereesBO objApplicantRefereesBO, int iUserId)
        {
            return objUpdateProfileDAL.SaveorUpdateRefereesDetails(objApplicantRefereesBO, iUserId);
        }
        public List<ApplicantRefereesBO> GetApplicantRefereesList(int iApplicantId)
        {
            return objUpdateProfileDAL.GetApplicantRefereesList(iApplicantId);
        }
        public ApplicantRefereesBO EditApplicantRefereesData(int iRefereesId, int iApplicantId)
        {
            return objUpdateProfileDAL.EditApplicantRefereesData(iRefereesId, iApplicantId);
        }
        public string DeleteApplicantRefereesData(int iRefereesId)
        {
            return objUpdateProfileDAL.DeleteApplicantRefereesData(iRefereesId);
        }

        public string SaveorUpdateMembershipData(ApplicantMotivationalSkillBO objApplicantMotivationalSkillBO, int iUserId)
        {
            return objUpdateProfileDAL.SaveorUpdateMembershipData(objApplicantMotivationalSkillBO, iUserId);
        }


        public string SaveorUpdateMotivationSkills(ApplicantMotivationalSkillBO objApplicantMotivationalSkillBO, int iUserId)
        {
            return objUpdateProfileDAL.SaveorUpdateMotivationSkills(objApplicantMotivationalSkillBO, iUserId);
        }
        public string SaveorUpdateDeclarationDetails(DeclarationBO objDeclarationBO, int iUserId)
        {
            return objUpdateProfileDAL.SaveorUpdateDeclarationDetails(objDeclarationBO, iUserId);
        }


        public string SaveorUpdateApplicantLanguageDetails(LanguageSpokenBO objLanguageSpokenBO, int iUserId)
        {
            return objUpdateProfileDAL.SaveorUpdateApplicantLanguageDetails(objLanguageSpokenBO, iUserId);
        }
        public List<LanguageSpokenBO> GetApplicantLanguageList(int iApplicantId)
        {
            return objUpdateProfileDAL.GetApplicantLanguageList(iApplicantId);
        }
        public LanguageSpokenBO EditApplicantLanguageData(int iLanguageSpokenId, int iApplicantId)
        {
            return objUpdateProfileDAL.EditApplicantLanguageData(iLanguageSpokenId, iApplicantId);
        }
        public string DeleteApplicantLanguageData(int iLanguageSpokenId)
        {
            return objUpdateProfileDAL.DeleteApplicantLanguageData(iLanguageSpokenId);
        }


        public string SaveorUpdateApplicantRelationDetails(ApplicantRelationBO objApplicantRelationBO, int iUserId)
        {
            return objUpdateProfileDAL.SaveorUpdateApplicantRelationDetails(objApplicantRelationBO, iUserId);
        }

        public List<ApplicantRelationBO> GetApplicantRelationDetailsList(int iApplicantId)
        {
            return objUpdateProfileDAL.GetApplicantRelationDetailsList(iApplicantId);
        }

        public ApplicantRelationBO EditApplicantRelativeData(int iRelationId, int iApplicantId)
        {
            return objUpdateProfileDAL.EditApplicantRelativeData(iRelationId, iApplicantId);
        }
        public string DeleteApplicantRelationData(int iRelationId)
        {
            return objUpdateProfileDAL.DeleteApplicantRelationData(iRelationId);
        }
    }
}
