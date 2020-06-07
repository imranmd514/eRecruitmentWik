using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace BusinessLayer
{
    public class AccountsBAL
    {
        AccountsDAL objAccountsDAL = new AccountsDAL();

        public string GetPasswordData(string strEmailAddress, string strPassword)
        {
            return objAccountsDAL.GetPasswordData(strEmailAddress, strPassword);
        }
    }
}
