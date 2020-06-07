using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class UserMasterBO
    {

        public String UserId
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Enter UserName")]
        public string UserName
        {
            get;
            set;
        }

        public int BranchId
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Enter Branch")]
        public string BranchName
        {
            get;
            set;
        }
        public int RoleId
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Enter Role")]
        public string RoleName
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Enter FirstName")]
        public string FirstName
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Enter LastName")]
        public string LastName
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Enter PhoneNo")]
        public string PhoneNo
        {
            get;
            set;
        }
        public Boolean IsActive
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Enter EmailId")]
        public string EmailId
        {
            get;
            set;
        }

        public int GenderId
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Enter Gender")]
        public string Gender
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Enter Password")]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        //[RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Enter ConfirmPassword")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword
        {
            get;
            set;
        }
        public int EmployeeId
        {
            get;
            set;
        }

        public List<CommonDropDownBO> GetBranchList
        {
            get;
            set;
        }
        public List<CommonDropDownBO> GetRoleList
        {
            get;
            set;
        }
        public List<CommonDropDownBO> GetGenderList
        {
            get;
            set;
        }
    }
}
