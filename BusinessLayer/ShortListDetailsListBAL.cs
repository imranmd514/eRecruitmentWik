using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace BusinessLayer
{
    public class ShortListDetailsListBAL
    {
        ShortListDetailsListDAL objShortListDetailsListDAL = new ShortListDetailsListDAL();

        public List<CommonDropDownBO> GetJobTypeList()
        {
            return objShortListDetailsListDAL.GetJobTypeList();
        }

        public List<ShortListDetailsListBO> getShortListDetailsList(int iJobId)
        {
            return objShortListDetailsListDAL.getShortListDetailsList(iJobId);
        }
    }
}
