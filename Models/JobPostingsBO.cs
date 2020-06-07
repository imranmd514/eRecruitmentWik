﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class JobPostingsBO
    {
        public int JobPostingId { get; set; }

        public string DonorProgramName { get; set; }

        [Display(Name = "Job Name")]
        [Required]
        public string JobName { get; set; }


        public string JobCode { get; set; }

        [Display(Name = "Job Description")]
        [Required]
        public string JobDescription { get; set; }

        [Display(Name = "Marketing Job")]
        [Required]
        public string MarketingJob { get; set; }

        [Display(Name = "No Of Positions Required")]
        [Required]
        public string NoOfPositions { get; set; }


        public string JobLocation { get; set; }

        public string JobTimings { get; set; }

        public string JobDuration { get; set; }

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

        public int MarketedById { get; set; }
        public string MarketedBy { get; set; }
        public string MarketedDate { get; set; }

        public List<CommonDropDownBO> DonorProgram
        {
            get;
            set;
        }

        public int DonorProgramId
        {
            get;
            set;
        }

        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "Comments")]
        public string Comments { get; set; }
    }
}
