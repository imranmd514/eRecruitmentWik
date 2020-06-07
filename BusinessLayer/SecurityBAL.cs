using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLayer
{
    public class SecurityBAL
    {
        SecurityDAL objSecurityDAL = new SecurityDAL();
        public UserMasterBO verifyLogin(string strUserName, string strPassword, ref string strResult)
        {
            return objSecurityDAL.verifyLogin(strUserName, strPassword, ref strResult);
        }
    }
}
