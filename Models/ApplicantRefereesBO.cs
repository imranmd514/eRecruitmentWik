using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ApplicantRefereesBO
    {
        public int RefereesId { get; set; }

        public int ApplicantId { get; set; }

        public string EmpFirstName
        {
            get; set;
        }
        public string SecondName
        {
            get; set;
        }
        public string Position
        {
            get; set;
        }
        public string RelationshipTOApplicant
        {
            get; set;
        }
        public string NameOfTheOrganization
        {
            get; set;
        }
        public string TelephoneContact
        {
            get; set;
        }
        public string EmpEmailAddress
        {
            get; set;
        }
        public bool IsActive
        {
            get; set;
        }
    }
}
