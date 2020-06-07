using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Models
{
   public class OrganizationMasterBO
    {
        public int OrganisationId { get; set; }

        public string OrganisationName { get; set; }

        public string Details { get; set; }

        public Boolean IsActive { get; set; }
    }
}
