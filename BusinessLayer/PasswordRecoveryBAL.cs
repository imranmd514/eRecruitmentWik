using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PasswordRecoveryBAL
    {
        PasswordRecoveryDAL objPasswordRecoveryDAL = new PasswordRecoveryDAL();
        public string getAllApplicantsList(string strEmailAddress,string strNewPassword)
        {
            return objPasswordRecoveryDAL.getUpdatePassword(strEmailAddress, strNewPassword);
        }
    }
}
