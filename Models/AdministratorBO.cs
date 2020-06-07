using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
                //Users
                public class AdministratorBO
                {
                public int UserId { get; set; }

                [Display(Name = "User Name")]
                [Required(ErrorMessage = "User Name Required")]
                public string UserName { get; set; }

                [Display(Name = "User PhoneNumber Name")]
                [Required(ErrorMessage = "User PhoneNumber Required")]
                public string UserPhoneNumber { get; set; }

                [Display(Name = "User Type")]
                [Required(ErrorMessage = "User Type Required")]
                public string UserType { get; set; }
             
                //Requisition

                [Display(Name = "Requistion")]
                [Required(ErrorMessage = "Requisition Required")]
                public string Requisition { get; set; }

                [Display(Name = "Job Title")]
                [Required(ErrorMessage = "Job Title Required")]
                public string JobTitle { get; set; }

                [Display(Name = "Description")]
                [Required(ErrorMessage = "Description Required")]
                public string Description { get; set; }

                [Display(Name = "Experience")]
                [Required(ErrorMessage = "Experience Required")]
                public string Experience { get; set; }

                //Applicants

                [Display(Name = "Applicant Name")]
                [Required(ErrorMessage = "Applicant Name Required")]
                public string ApplicantName { get; set; }

                [Display(Name = "User Type")]
                [Required(ErrorMessage = "User Type Required")]
                public string ApplicantPhoneNumber { get; set; }

                [Display(Name = "Applicant Type")]
                [Required(ErrorMessage = "Applicant Type Required")]
                public string ApplicantType { get; set; }

                [Display(Name = "Gender")]
                [Required(ErrorMessage = "Gender Required")]
                public string Gender { get; set; }

                [Display(Name = "Email")]
                [Required(ErrorMessage = "Email Required")]
                public string Email { get; set; }

                //Messages

                [Display(Name = "Subject")]
                [Required(ErrorMessage = "Subject Required")]
                public string Subject { get; set; }

                [Display(Name = "Message Description")]
                [Required(ErrorMessage = "Message Description")]
                public string MessageDescription { get; set; }

                [Display(Name = "Message From")]
                [Required(ErrorMessage = "Message From Required")]
                public string MessageFrom { get; set; }
             }
  }
