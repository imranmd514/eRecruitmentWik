using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ApplicantMotivationalSkillBO
    {
        public int ApplicantMotivationId   {  get;  set; }
        public int ApplicantId { get; set; }
        public string NameofProfessionalBody { get; set; }

        public string MembershipNumber { get; set; }
        public string JobDescription { get; set; }
        public int Validity { get; set; }
        public string ValidityData { get; set; }
        public int Membership
        {
            get; set;
        }
        public string MembershipData
        {
            get; set;
        }
        public string Referer
        {
            get; set;
        }

        public int RefererId
        {
            get; set;
        }
        public string ApplicationNote
        {
            get;
            set;
        }
        public string Others { get; set; }
        public bool IsActive { get; set; }
    }
}
