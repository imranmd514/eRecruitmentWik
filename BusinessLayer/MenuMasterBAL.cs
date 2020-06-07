using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;
namespace BusinessLayer
{
    public class MenuMasterBAL
    {
        MenuMasterDAL objMenuMasterDAL = new MenuMasterDAL();
        public List<MenuMasterBO> getMenuList()
        {
            return objMenuMasterDAL.getMenuList();
        }
        public string SaveorUpdateMenuMaster(MenuMasterBO objMenuMasterBO, int iUserId)
        {
            return objMenuMasterDAL.SaveorUpdateMenuMaster(objMenuMasterBO, iUserId);
        }
        public MenuMasterBO EditMenuMaster(int iMenuId)
        {
            return objMenuMasterDAL.EditMenuMaster(iMenuId);
        }

        public MenuMasterBO ViewMenuMaster(int iMenuId)
        {
            return objMenuMasterDAL.ViewMenuMaster(iMenuId);
        }

        public string deleteMenuMaster(int iMenuId)
        {
            return objMenuMasterDAL.deleteMenuMaster(iMenuId);
        }

    }
}
