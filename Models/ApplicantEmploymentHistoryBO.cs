using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
   public class ApplicantEmploymentHistoryBO
    {
        #region Employment History
        public int EmploymentHistoryId { get; set; }

        public int ApplicantId { get; set; }

        [Display(Name = "Employer Name")]
        [Required]
        public string EmployerName { get; set; }

        public int TypeOfIndustryId { get; set; }

        [Display(Name = "Type Of Industry")]
        [Required]
        public string TypeOfIndustry { get; set; }

        [Display(Name = "Employee Address")]
        [Required]
        public string EmpAddress { get; set; }

        [Display(Name = "Telephone Number")]
        [Required]
        public string TelephoneNo { get; set; }

        [Display(Name = "Job Title")]
        [Required]
        public string JobTitle { get; set; }

        [Display(Name = "Title Of Supervisor")]
        [Required]
        public string TitleOfSupervisor { get; set; }

        [Display(Name = "Start Date")]
        [Required]
        public string EmpStartDate { get; set; }

        public string EmpEndDate { get; set; }

        [Display(Name = "Responsibility")]
        [Required]
        public string Responsibility { get; set; }

        [Display(Name = "Monthly Salary")]
        [Required]

        public string NoticePeriod { get; set; }

        public string Reasonforleaving { get; set; }

        [Display(Name = "Job Description")]
        [Required]
        public string MonthlySalary { get; set; }

        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

        [Display(Name = "Postal Code")]
        [Required]

        public string EmpFirstName
        {
            get; set;
        }
        public string SecondName
        {
            get; set;
        }
        public string Position
        {
            get; set;
        }
        public string RelationshipTOApplicant
        {
            get; set;
        }
        public string NameOfTheOrganization
        {
            get; set;
        }
        public string TelephoneContact
        {
            get; set;
        }
        public string EmpEmailAddress
        {
            get; set;
        }
        public bool IsActive { get; set; }
        public int SubjectCombinations { get; set; }

        public string Subject { get; set; }


        #endregion
    }
}
