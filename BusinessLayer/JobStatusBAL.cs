using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;
namespace BusinessLayer
{
    public class JobStatusBAL
    {
        JobStatusDAL objJobStatusDAL = new JobStatusDAL();
        public List<JobStatusBO> GetAllApplicantsJobList(int iApplicantId)
        {
            return objJobStatusDAL.GetAllApplicantsJobList(iApplicantId);
        }
    }
}
