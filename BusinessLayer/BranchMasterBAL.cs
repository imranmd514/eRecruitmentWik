using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace BusinessLayer
{
   public class BranchMasterBAL
    {
        BranchMasterDAL objBranchMasterDAL = new BranchMasterDAL();

        public List<BranchMasterBO> selectBranchList()
        {
            return objBranchMasterDAL.selectBranchList();
        }
        public List<CommonDropDownBO> dropdownOrganization()
        {
            return objBranchMasterDAL.dropdownOrganization();
        }
        public string SaveorUpdateBranchMaster(BranchMasterBO objBranchMasterBO, int iUserId)
        {
            return objBranchMasterDAL.SaveorUpdateBranchMaster(objBranchMasterBO, iUserId);
        }
        public BranchMasterBO EditBranch(int iBranchId)
        {
            return objBranchMasterDAL.EditBranch(iBranchId);
        }

        public BranchMasterBO ViewBranchMaster(int iBranchId)
        {
            return objBranchMasterDAL.ViewBranchMaster(iBranchId);
        }
        public string deleteBranch(int iBranchId)
        {
            return objBranchMasterDAL.deleteBranch(iBranchId);
        }
    }
}
