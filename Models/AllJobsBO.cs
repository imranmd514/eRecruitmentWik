using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class AllJobsBO
    {
        public int JobPostingId { get; set; }

        [Display(Name = "Job Name")]
        [Required]
        public string JobName { get; set; }

        public string PM_Comments
        {
            get; set;
        }        

        public string MarketedBy
        {
            get; set;
        }

        public int HRStatus
        {
            get; set;
        }

        public string HOP_Comments
        {
            get; set;
        }
        public string JobCode
        {
            get; set;
        }
        public string JobLocation
        {
            get; set;
        }
        public string JobTimings
        {
            get; set;
        }
        public string JobDuration
        {
            get; set;
        }
        public int DonorProgramId { get; set; }
        public string DonorProgramName { get; set; }
        public string Qualification
        {
            get; set;
        }
        public string Experience
        {
            get; set;
        }
        public string Skills
        {
            get; set;
        }
        public string Comments
        {
            get; set;
        }
        [Display(Name = "Job Description")]
        [Required]
        public string JobDescription { get; set; }

        [Display(Name = "No Of Positions Required")]
        [Required]
        public string NoOfPositions { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public string ApprovedById { get; set; }
        public int ApprovedBy { get; set; }

        public string MarketedById { get; set; }
        public string ApprovedComments { get; set; }

        // public string ApprovedDate { get; set; }
        public string RejectedById { get; set; }
        public int RejectedBy { get; set; }

        // public string RejectedDate { get; set; }
        public string RejectedComments { get; set; }

        public bool IsActive
        {
            get; set;
        }
        public string ApprovedDate
        {
            get; set;
        }
        public string RejectedDate
        {
            get; set;
        }
        public string MarketedDate
        {
            get; set;
        }
        public int MarketedStatus
        {
            get; set;
        }
        public string MarketedComments
        {
            get; set;
        }
        public string HROffice_Comments
        {
            get; set;
        }
        public string RequiredStaffLevel { get; set; }
        public string CurrentStaffLevel { get; set; }
        public string Gaps { get; set; }

        public List<CommonDropDownBO> DonorProgrammList { get; set; }

    }
}
