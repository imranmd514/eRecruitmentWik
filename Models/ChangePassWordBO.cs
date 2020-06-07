using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ChangePassWordBO
    {

        public int UserId { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string EmailAddress { get; set; }


        [Display(Name = "OldPassword")]
        [Required(ErrorMessage = "OldPassword Required")]
        public string OldPassword { get; set; }

        [Display(Name = "NewPassword")]
        [Required(ErrorMessage = "NewPassword Required")]
        public string NewPassword { get; set; }


        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "The NewPassword and Confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}
