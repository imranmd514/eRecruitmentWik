using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class HODModelBO
    {
     public int JobId { get; set; }

        [Display(Name = "Job Type")]
        [Required(ErrorMessage = "Job Type Required")]
        public string JobType { get; set; }

        [Display(Name = "Job Title")]
        [Required(ErrorMessage = "Job Title Required")]
        public string JobTitle { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description Required")]
        public string Description { get; set; }

        [Display(Name = "Qualification")]
        [Required(ErrorMessage = "Qualification Required")]
        public string Qualification { get; set; }

        [Display(Name = "Current Salary")]
        [Required(ErrorMessage = "Current Salary Required")]
        public int CurrentSalary { get; set; }

        [Display(Name = "Expected Salary")]
        [Required(ErrorMessage = "Expected Salary Required")]
        public int ExpectedSalary { get; set; }

        [Display(Name = "Experience")]
        [Required(ErrorMessage = "Experience Required")]
        public string Experience { get; set; }

        [Display(Name = "Skills")]
        [Required(ErrorMessage = "Skills Required")]
        public string Skills { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status Required")]
        public string Status { get; set; }

       }
}
