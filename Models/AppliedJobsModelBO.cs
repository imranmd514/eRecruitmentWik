using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AppliedJobsModelBO
    {
        public int AppliedJobId { get; set; }
        public int ApplicantId { get; set; } 
        public int JobId { get; set; }
        public string Status { get; set; }
        public string Commenst { get; set; }
    }
}
