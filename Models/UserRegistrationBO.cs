  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
   public class UserRegistrationBO
    {
        public int UserId { get; set; }

        [Display(Name ="First Name")]
        [Required(ErrorMessage ="First Name Required")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [Required(ErrorMessage = "Middle Name Required")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name Required")]
        public string LastName { get; set; }

        [Display(Name = "Photo")]
        [Required(ErrorMessage = "Photo Required")]
        public string Photo { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

        [Display(Name ="Confirm Password")]
        [Required(ErrorMessage = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and Confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "Date Of Birth Required")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender Required")]
        public string Gender { get; set; }

        public int GenderId { get; set;  }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Mobile Number Required")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter proper Mobile Number")]
        public string MobileNumber { get; set; }


        [Display(Name = "Alternate Mobile Number")]    
        public string AlternateMobileNumber { get; set; }

        public string FileSavedName
        {
            get; set;
        }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string EmailAddress { get; set; }

        [Display(Name = "Language")]
        
        public string Language { get; set; }

        [Display(Name = "Qualification")]
        
        public string Qualification { get; set; }

        [Display(Name = "College")]
       
        public string College { get; set; }

        [Display(Name = "University")]
        
        public string University { get; set; }

        [Display(Name = "Aggregate Percentage")]
       
        public string AggregatePercentage { get; set; }


        [Display(Name = "Joining Date")]
        public string JoiningDate { get; set; }


        [Display(Name = "Country")]  
        public string Country { get; set; }
       
        public int CountryId { get; set; }

        [Display(Name = "State")]     
        public string State { get; set; }
       
        public int StateId { get; set; }


        [Display(Name = "City")]
      
        public string City { get; set; }

        public int LocationId { get; set; }
        public string Location { get; set; }


        [Display(Name = "User Type")]
       
        public string UserType { get; set; }

        
        public string DonorProgram { get; set; }

        public int UserRoleId { get; set; }

        [Display(Name = "User Role")]
        public string UserRole { get; set; }

        [Display(Name = "Department")]

        [Required(ErrorMessage = "Department Required")]
        public string Department { get; set; }

        [Display(Name = "Address")]
      
        public string Address { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive = true; 

        public List<CommonDropDownBO> CountriesList { get; set; }
        public List<CommonDropDownBO> StatesList { get; set; }

        public List<CommonDropDownBO> GenderList { get; set; }

        public List<CommonDropDownBO> RolesList { get; set; }

        public List<CommonDropDownBO> DonorProgramList { get; set; }

        public List<CommonDropDownBO> LocationList { get; set; }
    }
}
