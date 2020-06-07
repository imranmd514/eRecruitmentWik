using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccessLayer;

namespace BusinessLayer
{
   public class LocationMasterBAL
    {
        LocationMasterDAL objLocationMasterDAL = new LocationMasterDAL();
        public List<LocationMasterBO> GetLocationMasterList()
        {
            return objLocationMasterDAL.GetLocationMasterList();
        }
        public string SaveorUpdateLocationMaster(LocationMasterBO objLocationMasterBO, int iUserId)
        {
            return objLocationMasterDAL.SaveorUpdateLocationMaster(objLocationMasterBO, iUserId);
        }
        public LocationMasterBO EditLocationMaster(int iLocationId)
        {
            return objLocationMasterDAL.EditLocationMaster(iLocationId);
        }
        public string DeleteLocationMaster(int iLocationId)
        {
            return objLocationMasterDAL.DeleteLocationMaster(iLocationId);
        }
    }
}
