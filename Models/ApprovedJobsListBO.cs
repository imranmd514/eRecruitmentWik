using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ApprovedJobsListBO
    {
        public int JobPostingId { get; set; }

        [Display(Name = "Job Name")]
        [Required]
        public string JobName { get; set; }

        [Display(Name = "Job Description")]
        [Required]
        public string JobDescription { get; set; }

        [Display(Name = "Job location")]
        [Required]
        public string JobLocation { get; set; }

        public int NoOfPositions { get; set; }

        public string ApprovedDate { get; set; }

        public string Status { get; set; }

        public int StatusId { get; set; }

        [Display(Name = "Comments")]
        [Required]
        public string Comments { get; set; }

    }
}
