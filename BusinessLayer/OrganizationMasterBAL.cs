using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace BusinessLayer
{
   public class OrganizationMasterBAL
    {
        OrganizationMasterDAL objOrganizationMasterDAL = new OrganizationMasterDAL();

        public List<OrganizationMasterBO> selectOrganisationList()
        {
            return objOrganizationMasterDAL.selectOrganisationList();
        }
        public string SaveorUpdateOrganizationMaster(OrganizationMasterBO objOrganizationMasterBO, int iUserId)
        {
            return objOrganizationMasterDAL.SaveorUpdateOrganizationMaster(objOrganizationMasterBO, iUserId);
        }
        public OrganizationMasterBO EditOrganization(int iOrganisationId)
        {
            return objOrganizationMasterDAL.EditOrganization(iOrganisationId);
        }
        public string deleteOrganisation(int iOrganisationId)
        {
            return objOrganizationMasterDAL.deleteOrganization(iOrganisationId);
        }
    }
}
