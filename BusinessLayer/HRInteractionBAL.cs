using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccessLayer;

namespace BusinessLayer
{
    public class HRInteractionBAL
    {
        HRInteractionDAL objHRInteractionDAL = new HRInteractionDAL();
        public List<HRInteractionBO> getHRInteractionList()
        {
            return objHRInteractionDAL.getHRInteractionList();
        }
        public string SaveHRInteraction(HRInteractionBO objHRInteractionBO, int iUserId)
        {
            return objHRInteractionDAL.SaveHRInteraction(objHRInteractionBO, iUserId);
        }
        public string SaveHRReply(HRInteractionBO objHRInteractionBO, int iUserId)
        {
            return objHRInteractionDAL.SaveHRReply(objHRInteractionBO, iUserId);
        }
        public HRInteractionBO EditHRInteraction(int iRequestId)
        {
            return objHRInteractionDAL.EditHRInteraction(iRequestId);
        }
        public HRInteractionBO DisplayHRDetails(int iRequestId)
        {
            return objHRInteractionDAL.DisplayHRDetails(iRequestId);
        }
        public string deleteHRInteraction(int iRequestId)
        {
            return objHRInteractionDAL.deleteHRInteraction(iRequestId);
        }
    }
}
