using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Models
{
    public class SelectedListBO
    {
        //Personal Information

        public int ApplicantId { get; set; }

        public string ApplicantName { get; set; }
        public int JobId { get; set; }

        public string MotherTongue { get; set; }

        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [Required]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Date Of Birth")]
        [Required]
        public string DateOfBirth { get; set; }

        //[Display(Name = "Citizenship")]
        //[Required]
        //public string Citizenship { get; set; }

        public int IdTypeMasterId { get; set; }
        public string IdType { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }


        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address Required")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = " Enter a valid Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string EmailAddress { get; set; }

        [Display(Name = "MobileNumber")]
        [Required]

        public string CountryId
        {
            get; set;
        }

        public string Gender
        {
            get; set;
        }
        public int State
        {
            get; set;
        }

        [Required(ErrorMessage = "Enter PhoneNumber")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter proper Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter PhoneNumber")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter proper Phone Number")]
        [Display(Name = "Alternate Mobile Number")]
        public string AlternativePhoneNumber { get; set; }

        [Display(Name = "Language Spoken")]
        [Required]
        public string LanguageSpoken { get; set; }

        [Display(Name = "Nationality")]
        [Required]
        public string Nationality { get; set; }
        public string County
        {
            get; set;
        }

        [Display(Name = "Application Letter")]
        [Required]
        public string ApplicationLetter { get; set; }

        public string CV
        {
            get; set;
        }
        public string CVSavedName
        {
            get; set;
        }
        [Display(Name = "Status")]
        [Required]
        public int StatusId { get; set; }

        public int ApprovedBy
        {
            get; set;
        }
        public string ApprovedDate
        {
            get; set;
        }
        public int RejectedBy
        {
            get; set;
        }
        public string RejectedDate
        {
            get; set;
        }
        public string Comments
        {
            get; set;
        }


        public string Photo
        {
            get; set;
        }

        public string PhotoSavedName
        {
            get; set;
        }
      

        public int ApplicantQualificationId
        {
            get; set;
        }

        [Display(Name = "Bachelors")]
        [Required]
        public string Bachelors { get; set; }


        [Display(Name = "Masters")]
        [Required]
        public string MSC { get; set; }

        [Display(Name = "Diploma")]
        [Required]
        public string Diploma { get; set; }

        [Display(Name = "PHD")]
        [Required]
        public string PHD { get; set; }

        [Display(Name = "Discipline")]
        [Required]
        public string Discipline { get; set; }

        [Display(Name = "University")]
        [Required]
        public string University { get; set; }

        [Display(Name = "Country")]
        [Required]
        public string Country { get; set; }

        [Display(Name = "Degree")]
        [Required]

        public string Degree { get; set; }

        [Display(Name = "CreditScoreClass")]
        [Required]
        public string CreditScoreClass { get; set; }

        [Display(Name = "Edu Nationality")]
        [Required]
        public string EduNationality { get; set; }

        public string Class
        {
            get; set;
        }
        [Display(Name = "Start Date")]
        [Required]
        public string QuaStartDate
        {
            get; set;
        }
        [Display(Name = "End Date")]
        [Required]
        public string QuaEndDate
        {
            get; set;
        }
        public string QuaCountry
        {
            get; set;
        }
        public string QuaNationality
        {
            get; set;
        }
        public int EmploymentHistoryId { get; set; }

        [Display(Name = "Employer Name")]
        [Required]
        public string EmployerName { get; set; }

        [Display(Name = "Type Of Industry")]
        [Required]
        public string TypeOfIndustry { get; set; }

        [Display(Name = "Employee Address")]
        [Required]
        public string EmpAddress { get; set; }

        [Display(Name = "Telephone Number")]
        [Required]
        public string TelephoneNo { get; set; }

        [Display(Name = "Job Title")]
        [Required]
        public string JobTitle { get; set; }

        [Display(Name = "Title Of Supervisor")]
        [Required]
        public string TitleOfSupervisor { get; set; }

        [Display(Name = "Start Date")]
        [Required]
        public string EmpStartDate { get; set; }

        public string EmpEndDate { get; set; }

        [Display(Name = "Responsibility")]
        [Required]
        public string Responsibility { get; set; }

        [Display(Name = "Monthly Salary")]
        [Required]

        public string NoticePeriod { get; set; }

        [Display(Name = "Job Description")]
        [Required]
        public string MonthlySalary { get; set; }

        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

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

        public string JobDescription { get; set; }


        public string Referer
        {
            get; set;
        }

        public int RefererId
        {
            get; set;
        }


        public int ApplicantMotivationId
        {
            get;
            set;
        }

        public int GenderId
        {
            get; set;
        }

        public string OtherLanguages
        {
            get;
            set;
        }

        public string SpecialNeed
        {
            get;
            set;
        }

        public string SpecialNeedDetails
        {
            get;
            set;
        }


        public string CitizenShipIdCopy
        {
            get; set;
        }

        public string CitizenShipIdCopySavedName
        {
            get; set;
        }

        public string ApplicationLetterSavedName
        {
            get; set;
        }

        public string BachelorsSavedName
        {
            get; set;
        }
        public string DiplomaSavedName
        {
            get; set;
        }
        public string MSCSavedName
        {
            get; set;
        }
        public string PHDSavedName
        {
            get; set;
        }

        public bool English
        {
            get;
            set;
        }

        public bool Kiswahili
        {
            get;
            set;
        }

        public int Validity { get; set; }
        public string ValidityData { get; set; }
        public string NameofProfessionalBody { get; set; }
        public string ApplicationNote { get; set; }
        public string MembershipNumber { get; set; }
        public int Membership { get; set; }
        public string MembershipData { get; set; }

        public bool IsActive { get; set; }

        //----------Declaration Fields------------
        public int DeclarationID { get; set; }
        public string TerminatedId { get; set; }
        public string Terminatation { get; set; }
        public string MisconductId { get; set; }
        public string Misconduct { get; set; }
        public string ManagementId { get; set; }
        public string Management { get; set; }
        public string InvestigationId { get; set; }
        public string Investigation { get; set; }
        public string CriminalOffenceId { get; set; }
        public string CriminalOffence { get; set; }
        public string ConvictionsId { get; set; }
        public string Convictions { get; set; }
        public string CorruptionId { get; set; }
        public string Corruption { get; set; }
        public string DisciplinaryId { get; set; }
        public string Disciplinary { get; set; }
        public string RelationToChildId { get; set; }
        public string RelationToChild { get; set; }
        public string RelationToAdultId { get; set; }
        public string RelationToAdult { get; set; }
        public string RelativeId { get; set; }
        public string Relative { get; set; }
        public string DealingsWithWIKId { get; set; }
        public string DealingsWithWIK { get; set; }
        public bool Declarationinfo { get; set; }
        public bool Statement { get; set; }

        public int Applicantjobid { get; set; }
        public string FullName { get; set; }


        [Display(Name = "Status")]
        [Required]
        public string Status { get; set; }

        public int ApprovedById { get; set; }

        public int RejectedById { get; set; }

        public string RejectComments { get; set; }

        [Display(Name = "Qualification")]
        public string Qualification { get; set; }

        [Display(Name = "Skills")]
        public string Skills { get; set; }

        public int SelectedById { get; set; }
        public string SelectedBy { get; set; }

        public int CommunicationSkillsId { get; set; }
        public string CommunicationSkills { get; set; }
        public int ExperienceId { get; set; }
        public string Experience { get; set; }
        public int YearId { get; set; }
        public string Year { get; set; }
        public int MonthId { get; set; }
        public string Month { get; set; }

        public int ApplicantSkillId { get; set; }
        public string Skill { get; set; }
        public int RatingId { get; set; }
        public string EvaluationComments { get; set; }

        public List<CommonDropDownBO> JobList
        {
            get;
            set;
        }
        public List<ApplicantRelationBO> ApplicantRelationList
        {
            get;
            set;
        }
        public List<LanguageSpokenBO> ApplicantLanguageList
        {
            get;
            set;
        }
        public List<ApplicantQualificationBO> ApplicantQualificationList
        {
            get;
            set;
        }
        public List<ApplicantEmploymentHistoryBO> ApplicantEmploymentList
        {
            get;
            set;
        }
        public List<ApplicantRefereesBO> ApplicantRefereesList
        {
            get;
            set;
        }
        public List<ApplicantSkillsDetailsBO> SkillsList
        {
            get;
            set;
        }
       

    }
}

