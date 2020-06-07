using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccessLayer;


namespace BusinessLayer
{
    public class TypeOfIndustryMasterBAL
    {
        TypeOfIndustryMasterDAL objTypeOfIndustryMasterDAL = new TypeOfIndustryMasterDAL();

        public List<TypeOfIndustryMasterBO> GetTypeOfIndustryList()
        {
            return objTypeOfIndustryMasterDAL.GetTypeOfIndustryList();
        }
        public string SaveorUpdateTypeOfIndustry(TypeOfIndustryMasterBO objTypeOfIndustryMasterBO, int iUserId)
        {
            return objTypeOfIndustryMasterDAL.SaveorUpdateTypeOfIndustry(objTypeOfIndustryMasterBO, iUserId);
        }
        public TypeOfIndustryMasterBO EditTypeOfIndustryMaster(int iTypeOfIndustryId)
        {
            return objTypeOfIndustryMasterDAL.EditTypeOfIndustryMaster(iTypeOfIndustryId);
        }
        public string DeleteTypeOfIndustry(int iTypeOfIndustryId)
        {
            return objTypeOfIndustryMasterDAL.DeleteTypeOfIndustry(iTypeOfIndustryId);
        }
    }
}
