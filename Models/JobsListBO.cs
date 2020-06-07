using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class JobsListBO
    {
        public int JobPostingId { get; set; }

        [Display(Name = "Job Name")]
        [Required]
        public string JobName { get; set; }

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
        public int NoOfPositions { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public string ApprovedById { get; set; }
        public int ApprovedBy { get; set; }

        public string MarketedBy { get; set; }
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
    }
}
