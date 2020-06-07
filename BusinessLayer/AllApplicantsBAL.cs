using DataAccessLayer;
using Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class AllApplicantsBAL
    {
        AllApplicantsDAL objAllApplicantsDAL = new AllApplicantsDAL();
        public List<AllApplicantsBO> getAllApplicantsList()
        {
            return objAllApplicantsDAL.getAllApplicantsList();
        }
        public string saveApprovedApplicant(AllApplicantsBO objAllApplicantsBO, int iUserId)
        {
            return objAllApplicantsDAL.saveApprovedApplicant(objAllApplicantsBO, iUserId);
        }

        public string saveRejectedApplicant(AllApplicantsBO objAllApplicantsBO, int iUserId)
        {
            return objAllApplicantsDAL.saveRejectedApplicant(objAllApplicantsBO, iUserId);
        }

        public string saveOnHoldApplicant(AllApplicantsBO objAllApplicantsBO, int iUserId)
        {
            return objAllApplicantsDAL.saveOnHoldApplicant(objAllApplicantsBO, iUserId);
        }

        public AllApplicantsBO ViewAllApplicant(int iApplicantId)
        {
            return objAllApplicantsDAL.ViewAllApplicant(iApplicantId);
        }
        public AllApplicantsBO EditAllApplicants(int iApplicantId)
        {
            return objAllApplicantsDAL.EditAllApplicants(iApplicantId);
        }
        public string deleteAllApplicants(int iApplicantId)
        {
            return objAllApplicantsDAL.deleteAllApplicants(iApplicantId);
        }

    }
}
