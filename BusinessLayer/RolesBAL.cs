using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace BusinessLayer
{
    public class RolesBAL
    {
        RolesDAL objRolesDAL = new RolesDAL();
        public List<RolesBO> getRolesList()
        {
            return objRolesDAL.getRolesList();
        }
        public string SaveorUpdateRole(RolesBO objRolesBO, int iUserId)
        {
            return objRolesDAL.SaveorUpdateRole(objRolesBO, iUserId);
        }
        public RolesBO EditRole(int iRoleId)
        {
            return objRolesDAL.EditRole(iRoleId);
        }
        public string deleteRole(int iRoleId)
        {
            return objRolesDAL.deleteRole(iRoleId);
        }

    }
}