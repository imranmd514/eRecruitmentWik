using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class HRInteractionBO
    {
        public int ApplicantId { get; set; }

        [Display(Name ="Applicant Name")]
        public string ApplicantName { get; set; }
        public string EmailId { get; set; }
        public int RequestId { get; set; }

        [Display(Name = "Subject")]
        [Required]
        public string Subject { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public string RequestDate { get; set; }
        public string ResponseDate { get; set; }
        public string Comments { get; set; }
        

    }
}
