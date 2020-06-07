using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class JobMarketingBO
    {
        public int JobPostingId { get; set; }

        public int JobMarketingId { get; set; }

        [Display(Name = "Job Name")]
        [Required]
        public string JobName { get; set; }


        public string JobCode { get; set; }

        [Display(Name = "Job Description")]
        [Required]
        public string JobDescription { get; set; }

        [Display(Name = "No Of Positions Required")]
        [Required]
        public int NoOfPositions { get; set; }


        public string JobLocation { get; set; }

        public string JobTimings { get; set; }

        public string JobDuration { get; set; }
        public int DonorProgramId { get; set; }
        public string DonorProgramName { get; set; }

        [Display(Name = "Qualification")]
        [Required]
        public string Qualification { get; set; }

        [Display(Name = "Experience")]
        [Required]
        public string Experience { get; set; }

        [Display(Name = "Skills")]
        [Required]
        public string Skills { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public string ApprovedById { get; set; }
        public int ApprovedBy { get; set; }
        public string ApprovedDate { get; set; }

        public string RejectedById { get; set; }
        public int RejectedBy { get; set; }
        public string RejectedDate { get; set; }

        public string MarketingJob { get; set; }

        public int MarketedById { get; set; }
        public int? MarketedBy { get; set; }
        public string MarketedDate { get; set; }

        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "Comments")]
        public string Comments { get; set; }

        [Required]
        [Display(Name = "Marketing Comments")]
        public string MarketingComments { get; set; }
        public string MarketingStatus { get; set; }

        public List<CommonDropDownBO> DonorProgrammList { get; set; }

    }
}
