using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
   public class AddRequisitionByHODBO
    {
        public int JobId { get; set; }

        [Display(Name = "Job Title")]
        [Required(ErrorMessage = "Job Title Required")]
        public String JobTitle  { get; set; }

        [Display(Name = "Job Type")]
        [Required(ErrorMessage = "Job Type Required")]
        public String JobType  { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description Required")]
        public String Description { get; set; }

        [Display(Name = "Qualification")]
        [Required(ErrorMessage = "Qualifictaion Required")]
        public String Qualification { get; set; }

        [Display(Name = "Current Salary")]
        [Required(ErrorMessage = "Current Salary Required")]
        public int CurrentSalary { get; set; }

        [Display(Name = "Expected Salary")]
        [Required(ErrorMessage = "Expected Salary Required")]
        public int ExpectedSalary { get; set; }

        [Display(Name = "Experience")]
        [Required(ErrorMessage = "Experience Required")]
        public int Experience { get; set; }

        [Display(Name = "Skills")]
        [Required(ErrorMessage = "Skills Required")]
        public String Skills { get; set; }
        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status Required")]
        public string Status { get; set; }

        [Display(Name ="IsActive")]
        public bool IsActive { get; set; }

    }
}
