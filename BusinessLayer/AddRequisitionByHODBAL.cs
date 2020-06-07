using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccessLayer;
namespace BusinessLayer
{
    public class AddRequisitionByHODBAL
    {
        AddRequisitionByHODDAL objAddRequisitionByHODDAL = new AddRequisitionByHODDAL();
        public string SaveAddRequisitionByHOD(AddRequisitionByHODBO objAddRequisitionByHODBO, int iUserId)
        {
            return objAddRequisitionByHODDAL.SaveAddRequisitionByHOD(objAddRequisitionByHODBO, iUserId);

        }
    }

}