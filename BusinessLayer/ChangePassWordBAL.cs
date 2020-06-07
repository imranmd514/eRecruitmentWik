using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace BusinessLayer
{
    public class ChangePassWordBAL
    {
        ChangePassWordDAL objChangePassWordDAL = new ChangePassWordDAL();

        public ChangePassWordBO GetEmailAddress(int iUserId)
        {
            return objChangePassWordDAL.GetEmailAddress(iUserId);
        }

        public string SaveChangePassword(ChangePassWordBO objChangePassWordBO, int A_iUserId)
        {
            return objChangePassWordDAL.SaveChangePassword(objChangePassWordBO, A_iUserId);
        }
    }
}