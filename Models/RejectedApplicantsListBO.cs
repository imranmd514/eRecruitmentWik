using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class RejectedApplicantsListBO
    {
        public int ApplicantId { get; set; }
        public int JobId { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string HOD_Comments { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }
        public int RejectedById { get; set; }
        public string RejectedBy { get; set; }
        public string RejectedDate { get; set; }
        public string DonorProgram { get; set; }
        public string RequiredStaffLevel { get; set; }
        public string CurrentStaffLevel { get; set; }
        public string Gaps { get; set; }
        public string JobLocation { get; set; }


        public string AcademicQualification { get; set; }
        public string MotherTongue { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string ProfessionalBodyName { get; set; }
        public string MembershipNumber { get; set; }
        public string Subject { get; set; }
        public string Validity { get; set; }
        public List<CommonDropDownBO> JobList
        {
            get;
            set;
        }
    }
}
