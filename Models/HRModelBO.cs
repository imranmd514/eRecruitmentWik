using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class HRModelBO
    {
                    //Requisitions
                    public int JobId { get; set; }

                    [Display(Name = "Job Title")]
                    [Required(ErrorMessage = "Job Title Required")]
                    public String JobTitle { get; set; }

                    [Display(Name = "Description")]
                    [Required(ErrorMessage = "Description Required")]
                    public String Description { get; set; }

                    [Display(Name = "Qualification")]
                    [Required(ErrorMessage = "Qualification Required")]
                    public String Qualification { get; set; }

                    [Display(Name = "Current Salary")]
                    [Required(ErrorMessage = "Current Salary Required")]
                    public int CurrentSalary { get; set; }

                    [Display(Name = "Expected Salary")]
                    [Required(ErrorMessage = "Expected Salary Required")]
                    public int ExpectedSalary { get; set; }

                    [Display(Name = "Experience")]
                    [Required(ErrorMessage = "Experience Required")]
                    public String Experience { get; set; }

                    [Display(Name = "Skills")]
                    [Required(ErrorMessage = "Skills Required")]
                    public String Skills { get; set; }

                    //Applications

                    [Display(Name = "Applications")]
                    [Required(ErrorMessage = "Applications Required")]
                    public String Applications { get; set; }

                    [Display(Name = "ApplicationStatus")]
                    [Required(ErrorMessage = "ApplicationStatus Required")]
                    public String ApplicationStatus { get; set; }
                    
                    //Messages

                    [Display(Name = "Subject")]
                    [Required(ErrorMessage = "Subject Required")]
                    public String Subject { get; set; }

                    [Display(Name = "Message Description")]
                    [Required(ErrorMessage = "Message Description Required")]
                    public String MessageDescription { get; set; }

                    [Display(Name = "Message From")]
                    [Required(ErrorMessage = "Message From Required")]
                    public String MessageFrom { get; set; }

                    [Display(Name = "Date")]
                    [Required(ErrorMessage = "Date Required")]
                    public String Date {  get; set; }

                    [Display(Name = "Time")]
                    [Required(ErrorMessage = "Time Required")]
                    public String Time { get; set; }

                }
      }
