using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccessLayer;

namespace BusinessLayer
{
    public class IdTypeMasterBAL
    {
        IdTypeMasterDAL objIdTypeMasterDAL = new IdTypeMasterDAL();

        public List<IdTypeMasterBO> GetIdTypeMasterList()
        {
            return objIdTypeMasterDAL.GetIdTypeMasterList();
        }
        public string SaveorUpdateIdTypeMaster(IdTypeMasterBO objIdTypeMasterBO, int iUserId)
        {
            return objIdTypeMasterDAL.SaveorUpdateIdTypeMaster(objIdTypeMasterBO, iUserId);
        }
        public IdTypeMasterBO EditIdTypeMaster(int iIdTypeMasterId)
        {
            return objIdTypeMasterDAL.EditIdTypeMaster(iIdTypeMasterId);
        }
        public string DeleteIdTypeMaster(int iIdTypeMasterId)
        {
            return objIdTypeMasterDAL.DeleteIdTypeMaster(iIdTypeMasterId);
        }
    }
}
