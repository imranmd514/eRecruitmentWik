using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class JobsReportBO
    {
        public int JobPostingId { get; set; }
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        public string JobLocation  {get; set;}
        public int DonorProgramId { get; set; }
        public string DonorProgramName { get; set; }
        public string NoOfPositions { get; set; }
        public string RequiredStaffLevel { get; set; }
        public string CurrentStaffLevel { get; set; }
        public string Gaps { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
    }
}
