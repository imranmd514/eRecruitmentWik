using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PostJobBO
    {
        public int JobPostingId
        {
            get;
            set;
        }

        public string JobName
        {
            get;
            set;
        }

        public string JobCode
        {
            get;
            set;
        }

        public string JobDescription
        {
            get;
            set;
        }

        public string JobDescriptionFile
        {
            get;
            set;
        }
        public string JobDescriptionFileSavedName
        {
            get; set;
        }
        public string NoOfPositions
        {
            get;
            set;
        }

        public string JobLocation
        {
            get;
            set;
        }

        public string JobTimings
        {
            get;
            set;
        }

        public string JobDuration
        {
            get;
            set;
        }

        public string Qualification
        {
            get;
            set;
        }

        public string Experience
        {
            get;
            set;
        }

        public string Skills
        {
            get;
            set;
        }

        public int StatusId
        {
            get;
            set;
        }


        public string Status
        {
            get;
            set;
        }

        public int DonorProgramId
        {
            get;
            set;
        }

        public string DonorProgram
        {
            get;
            set;
        }

        public List<CommonDropDownBO> DonorProgramList
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }

        public string ApproverComments
        {
            get;
            set;
        }

        public string RejectComments
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }
        public string HOD_Date
        {
            get;
            set;
        }
        public string HOD_Comments
        {
            get;
            set;
        }

    }
}
