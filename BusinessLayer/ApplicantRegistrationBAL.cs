using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;
using Models;
namespace BusinessLayer
{
    public class ApplicantRegistrationBAL
    {
        ApplicantRegistrationDAL objApplicantRegistrationDAL = new ApplicantRegistrationDAL();
        public List<CommonDropDownBO> TitleList()
        {
            return objApplicantRegistrationDAL.TitleList();
        }
        public List<CommonDropDownBO> CountryList()
        {
            return objApplicantRegistrationDAL.CountryList();
        }

        public List<CommonDropDownBO> GenderList()
        {
            return objApplicantRegistrationDAL.GenderList();
        }

        public List<CommonDropDownBO> RefererList()
        {
            return objApplicantRegistrationDAL.RefererList();
        }
        public List<CommonDropDownBO> IdTypeList()
        {
            return objApplicantRegistrationDAL.IdTypeList();
        }
        public List<ApplicantRegistrationBO> getApplicantsList()
        {
            return objApplicantRegistrationDAL.getApplicantsList();
        }
        public string SaveorUpdateApplicantRegistration(ApplicantRegistrationBO objApplicantRegistrationBO,string strPassword, int iUserId)
        {
            return objApplicantRegistrationDAL.SaveorUpdateApplicantRegistration(objApplicantRegistrationBO,strPassword, iUserId);
        }
        public ApplicantRegistrationBO EditApplicantDetails(int iApplicantId)
        {
            return objApplicantRegistrationDAL.EditApplicantDetails(iApplicantId);
        }
        public ApplicantRegistrationBO ViewApplicant(int iApplicantId)
        {
            return objApplicantRegistrationDAL.ViewApplicant(iApplicantId);
        }
        public string deleteApplicant(int iApplicantId)
        {
            return objApplicantRegistrationDAL.deleteApplicant(iApplicantId);
        }

     
    }
}
