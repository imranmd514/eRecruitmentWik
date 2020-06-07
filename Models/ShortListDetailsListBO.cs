using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ShortListDetailsListBO
    {
        public int ApplicantId { get; set; }

        public int JobId { get; set; }

        public string FullName { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [Required]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        public string EmailAddress { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "Status")]
        [Required]
        public string Status { get; set; }

        public int StatusId { get; set; }

        [Display(Name = "Experience")]
        [Required]
        public string Experience { get; set; }

        [Display(Name = "Skills")]
        [Required]
        public string Skills { get; set; }
        public int ApprovedById { get; set; }
        public int ApprovedBy { get; set; }
        public string ApprovedDate { get; set; }
        public bool IsActive { get; set; }

        [Display(Name = "Comments")]
        [Required]
        public string HOD_Comments { get; set; }
        public string DonorProgram { get; set; }
        public string RequiredStaffLevel { get; set; }
        public string CurrentStaffLevel { get; set; }
        public string Gaps { get; set; }
        public string JobLocation { get; set; }

        public string AcademicQualification { get; set; }
        public string MotherTongue { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string ProfessionalBodyName { get; set; }
        public string MembershipNumber { get; set; }
        public string Subject { get; set; }
        public string Validity { get; set; }
        public List<CommonDropDownBO> JobList
        {
            get;
            set;
        }
    }
}
