using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class MarketerBO
    {
        public int RequisitionId { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Department Required")]
        public String Department { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status Required")]
        public String Status { get; set; }

    }
}
