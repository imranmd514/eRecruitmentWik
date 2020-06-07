using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class LocationMasterBO
    {
        public int LocationId
        {
            get; set;
        }

        public string Location
        {
            get; set;
        }
        public Boolean IsActive
        {
            get; set;
        }
    }
}
