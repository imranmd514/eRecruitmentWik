using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MainMenuBAL
    {
        MainMenuDAL objMainMenuDal = new MainMenuDAL();
        public List<MainMenuBO> getUserMenuList(int iUserId)
        {
            return objMainMenuDal.getUserMenuList(iUserId);
        }
    }
}
