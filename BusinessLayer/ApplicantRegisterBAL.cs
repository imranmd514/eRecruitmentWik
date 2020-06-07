using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccessLayer;

namespace BusinessLayer
{
    public class ApplicantRegisterBAL
    {
        ApplicantRegisterDAL objApplicantRegisterDAL = new ApplicantRegisterDAL();

        public string SaveorUpdateApplicantRegisterEmail(EmailAddressBO objEmailAddressBO, string strPassword, int iUserId)
        {
            return objApplicantRegisterDAL.SaveorUpdateApplicantRegisterEmail(objEmailAddressBO, strPassword, iUserId);
        }
    }
}
