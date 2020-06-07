using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class ProfileBO
    {

        //[Display(Name = "User Name")]
        //public string UserName { get; set; }
        public int UserId { get; set; }
        
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "DateOfBirth")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Mobile Number")]

        public string MobileNumber { get; set; }

        [Display(Name = "Alternate MobileNumber")]

        public string AlternateMobileNumber { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Language Spoken")]
        public string Language { get; set; }

        [Display(Name = "Qualification")]
        public string Qualification { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        public string City { get; set; }
        public string Photo { get; set; }

        public string ActualFileName { get; set; }
        [Display(Name = "User Role")]
        public string UserRole { get; set; }

        public string RoleName { get; set; }

        [Display(Name = "Department")]
        public string Department { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }
        public bool IsActive { get; set; }

    }
}
