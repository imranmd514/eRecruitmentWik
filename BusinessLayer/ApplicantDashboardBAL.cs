using DataAccessLayer;
using Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class ApplicantDashboardBAL
    {
        ApplicantDashboardDAL objApplicantDashboardDAL = new ApplicantDashboardDAL();

        public List<CommonDropDownBO> TitleList()
        {
            return objApplicantDashboardDAL.TitleList();
        }
        public List<CommonDropDownBO> CountryList()
        {
            return objApplicantDashboardDAL.CountryList();
        }
        public List<CommonDropDownBO> GenderList()
        {
            return objApplicantDashboardDAL.GenderList();
        }
        public string SavePersonalInformation(ApplicantPersonalInformationBO objApplicantPersonalInformationBO, int iUserId)
        {
            return objApplicantDashboardDAL.SavePersonalInformation(objApplicantPersonalInformationBO, iUserId);
        }
        public string SaveApplicantQualification(ApplicantQualificationBO objApplicantQualificationBO, int iUserId)
        {
            return objApplicantDashboardDAL.SaveApplicantQualification(objApplicantQualificationBO, iUserId);
        }
        public string SaveApplicantEmploymentHistory(ApplicantEmploymentHistoryBO objApplicantEmploymentHistoryBO, int iUserId)
        {
            return objApplicantDashboardDAL.SaveApplicantEmploymentHistory(objApplicantEmploymentHistoryBO, iUserId);
        }
        public string SaveApplicantMotivation(ApplicantMotivationBO objApplicantMotivationBO, int iUserId)
        {
            return objApplicantDashboardDAL.SaveApplicantMotivation(objApplicantMotivationBO, iUserId);
        }
        public ApplicantPersonalInformationBO editPersonalInformation(int iApplicantId)
        {
            return objApplicantDashboardDAL.editPersonalInformation(iApplicantId);
        }

        public ApplicantQualificationBO editQualification(int iApplicantId)
        {
            return objApplicantDashboardDAL.editQualification(iApplicantId);
        }
        public ApplicantEmploymentHistoryBO editEmploymentHistory(int iApplicantId)
        {
            return objApplicantDashboardDAL.editEmploymentHistory(iApplicantId);
        }
        public ApplicantMotivationBO EditMotivation(int iApplicantId)
        {
            return objApplicantDashboardDAL.EditMotivation(iApplicantId);
        }
    }
}
