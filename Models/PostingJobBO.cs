using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PostingJobBO
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

        public string DonorProgramId
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

        public string ApprovedBy
        {
            get;
            set;
        }

        public string ApprovedDate
        {
            get;
            set;
        }

        public string ApproverComments
        {
            get;
            set;
        }


        public string RejectedBy
        {
            get;
            set;
        }

        public string RejectedDate
        {
            get;
            set;
        }

        public string RejectedComments
        {
            get;
            set;
        }

        public string MarketedBy
        {
            get;
            set;
        }

        public string MarketedDate
        {
            get;
            set;
        }

        public string MarketingComments
        {
            get;
            set;
        }

        public string MarketingStatus
        {
            get;
            set;
        }

        public string HROfficeBy
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
        public string HROffice_Date
        {
            get;
            set;
        }

        public string HROffice_Comments
        {
            get;
            set;
        }

        public string HOPBy
        {
            get;
            set;
        }

        public string HOP_Comments
        {
            get;
            set;
        }

        public string HOP_Date
        {
            get;
            set;
        }

        public string PMBy
        {
            get;
            set;
        }

        public string PM_Comments
        {
            get;
            set;
        }

        public string PM_Date
        {
            get;
            set;
        }
        public string AdminBy
        {
            get;
            set;
        }

        public string Admin_Date
        {
            get;
            set;
        }

        public string Admin_Comments
        {
            get;
            set;
        }

        public string AdminStatus
        {
            get;
            set;
        }

        public string HAFBy
        {
            get;
            set;
        }

        public string HAF_Date
        {
            get;
            set;
        }

        public string HAF_Comments
        {
            get;
            set;
        }

        public string HAF_Status
        {
            get;
            set;
        }

        public string HRBy
        {
            get;
            set;
        }

        public string HRComments
        {
            get;
            set;
        }

        public string HRStatus
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
        
    }
}
