using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccessLayer;

namespace BusinessLayer
{
   public class DonorProgramBAL
    {

        DonorProgramDAL objDonorProgramDAL = new DonorProgramDAL();

        public List<DonorProgramBO> GetDonorList()
        {
            return objDonorProgramDAL.GetDonorList();
        }

        public string SaveorUpdateDonor(DonorProgramBO objDonorProgramBO, int iUserId)
        {
            return objDonorProgramDAL.SaveorUpdateDonor(objDonorProgramBO, iUserId);
        }

        public DonorProgramBO EditDonor(int iDonorProgramId)
        {
            return objDonorProgramDAL.EditDonor(iDonorProgramId);
        }

        public string deleteDonor(int iDonorProgramId)
        {
            return objDonorProgramDAL.deleteDonor(iDonorProgramId);
        }
    }
}
