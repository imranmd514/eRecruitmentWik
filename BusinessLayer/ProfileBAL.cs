using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace BusinessLayer
{
    public class ProfileBAL
    {
        ProfileDAL objProfileDAL = new ProfileDAL();
        public ProfileBO DisplayUser(int iUserId)
        {
            return objProfileDAL.DisplayUser(iUserId);
        }
        //public ApplicantRegistrationBO ViewApplicant(int iApplicantId)
        //{
        //    return objProfileDAL.ViewApplicant(iApplicantId);
        //}
    }
}
