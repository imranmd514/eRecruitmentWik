using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ApplyJobsBO
    {

        public int ApplicantJobId { get; set; }
        public int CandidateAppliedJobId
        {
            get;set;
        }
        public int JobPostingId { get; set; }

        public int EmployeeId
        {
            get;set;
        }

        public int ApplicantId
        {
            get;set;
        }

        [Display(Name = "Job Name")]
        [Required]
        public string JobName { get; set; }
        [Display(Name = "Job Description")]
        [Required]
        public string JobDescription { get; set; }

        public string JobDescriptionFile { get; set; }
        public string JobDescriptionFileSavedName { get; set; }

        [Display(Name = "No Of Positions Required")]
        [Required]
        public string NoOfPositions { get; set; }
        public string AppliedStatus { get; set; }
        

        public string JobLocation { get; set; }

        public string JobTimings { get; set; }

        public string JobDuration { get; set; }
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
        
        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "Comments")]
        public string Comments { get; set; }

        public string ApplicantComments { get; set; }
    }
}
