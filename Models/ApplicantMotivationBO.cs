using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Models
{
   public class ApplicantMotivationBO
    {
        #region Motivation

        public int ApplicantId { get; set; }
        public string Friends
        {
            get; set;
        }
        public string WIKWebsite
        {
            get; set;
        }
        public string SocialMedia
        {
            get; set;
        }
        public string PostalCode { get; set; }

        public string JobDescription { get; set; }

        [Display(Name = "IsActive")]
        [Required]

        public int ApplicantMotivationId
        {
            get;
            set;
        }
        public bool IsActive { get; set; }

        #endregion

    }
}
