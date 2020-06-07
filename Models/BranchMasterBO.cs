using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
   public class BranchMasterBO
    {

        public int BranchId { get; set; }

        public int OrganizationId { get; set; }

        [Display(Name = "Branch Name")]
        [Required(ErrorMessage = "Branch Name Required")]
        public string BranchName { get; set; }

        [Display(Name = "Organization Name")]
        [Required(ErrorMessage = "Organization Name Required")]
        public string OrganizationName { get; set; }

        [Display(Name = "Details")]
        [Required(ErrorMessage = "Details Required")]
        public string Details { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; }

        [Display(Name = "Cell Number")]
        [Required(ErrorMessage = "Cell Number Required")]
        public string CellNumber { get; set; }

        [Display(Name = "Land Number")]
        [Required(ErrorMessage = "Land Number Required")]
        public string LandNumber { get; set; }

        [Display(Name = "Email Id")]
        [Required(ErrorMessage = "Email Id Required")]
        public string EmailId { get; set; }

        [Display(Name = "Website")]
        [Required(ErrorMessage = "Website Required")]
        public string Website { get; set; }

        public Boolean IsMainBranch { get; set; }

        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Logo Required")]
        public string Logo { get; set; }

        public bool IsActive { get; set; }

        public List<CommonDropDownBO> getOrganizationList { get; set; }

    }
}
