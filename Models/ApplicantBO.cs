using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Models
{
                //Applications
                public class ApplicantBO
                {
                public int ApplicantId { get; set; }

                [Display(Name = "Job Title")]
                [Required]
                public string JobTitle { get; set; }

                //Messages

                [Display(Name = "Subject")]
                [Required]
                public string Subject { get; set; }

                [Display(Name = "Message Description")]
                [Required]
                public string MessageDescription { get; set; }

                [Display(Name = "Message From")]
                [Required]
                public string MessageFrom{ get; set; }

            }
}
