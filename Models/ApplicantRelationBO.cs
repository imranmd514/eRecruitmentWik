using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ApplicantRelationBO
    {
        public int RelationId { get; set; }
        public int ApplicantId { get; set; }
        public int AnyoneWorkinWIKId { get; set; }
        public string AnyoneWorkinWIK { get; set; }
        public string RelativeName { get; set; }
        public string Relationship { get; set; }
        public bool IsActive { get; set; }
    }
}
