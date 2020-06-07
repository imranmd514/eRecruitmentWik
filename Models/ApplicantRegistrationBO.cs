using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class ApplicantRegistrationBO
    {
        //Personal Information

        #region Personal Information
        public int ApplicantId { get; set; }
        public int JobId { get; set; }

        public string MotherTongue { get; set; }        

        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }

        public int TitleId { get; set; }

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

        [Display(Name = "Citizenship")]
        [Required]
        public string Citizenship { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }


        public int IdTypeMasterId { get; set; }
        public string IdType { get; set; }


        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address Required")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = " Enter a valid Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string EmailAddress { get; set; }

        [Display(Name = "MobileNumber")]
        [Required]

        public int CountryId
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
        public string County
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

        [Display(Name = "Application Letter")]
        [Required]
        public string ApplicationLetter { get; set; }

        [Display(Name = "Resume")]
        [Required]
        public string Resume { get; set; }

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

        public string ResumeSaved
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
        #endregion

        #region Qualification

        public int ApplicantQualificationId
        {
            get; set;
        }

        public int AcademicQualificationId { get; set; }
        public string AcademicQualification { get; set; }

        public string OtherCertification { get; set; }
        public string AcademicQualificationAttachment { get; set; }
        public string AttachmentSavedName
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
        public int QuaCountryId
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

        #endregion

        #region Employment History
        public int EmploymentHistoryId { get; set; }

        [Display(Name = "Employer Name")]
        [Required]
        public string EmployerName { get; set; }


        public int TypeOfIndustryId { get; set; }
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

        public string MonthlySalary { get; set; }

        public int SubjectCombinations { get; set; }

        public string Subject { get; set; }

        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

        public string Reasonforleaving { get; set; }
           
        public int RefereesId { get; set; }

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


        #endregion

        #region Motivation
        //Motivation Skills And Experience
      
        
        public string NameofProfessionalBody { get; set; }

        public string MembershipNumber { get; set; }
        public string JobDescription { get; set; }
        public int Validity { get; set; }

        public int Membership
        {
            get;set;
        }
        public string Referer
        {
            get; set;
        }

        public int RefererId
        {
            get; set;
        }
        public string Others { get; set; }
        public string ApplicationNote
        {
            get;
            set;
        }

        [Display(Name = "IsActive")]
        [Required]

        public int ApplicantMotivationId
        {
            get;
            set;
        }

        #endregion

        public int GenderId
        {
            get; set;
        }

        public string OtherLanguages
        {
            get;
            set;
        }

        public int SpecialNeed
        {
            get;
            set;
        }

        public string SpecialNeedDetails
        {
            get;
            set;
        }
        public int RelationId { get; set; }
        public int AnyoneWorkinWIKId { get; set; }
        public string RelativeName { get; set; }
        public string Relationship { get; set; }

        //------------------------------------------------//
        public int LanguageSpokenId { get; set; }
        public string Language { get; set; }
        public string LanguageRead { get; set; }
        public string Write { get; set; }
        public string Speak { get; set; }
        public string Understand { get; set; }

        public string ResumSavedName
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
        //public string IdTypeCopy
        //{
        //    get; set;
        //}

        //public string IdTypeCopySavedName
        //{
        //    get; set;
        //}


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



        public bool IsActive { get; set; }
        public List<CommonDropDownBO> TitleList { get; set; }
        public List<CommonDropDownBO> CountriesList { get; set; }

        public List<CommonDropDownBO> IdTypeList { get; set; }

        public List<CommonDropDownBO> RefererList { get; set; }

        public List<CommonDropDownBO> GenderList { get; set; }

        public List<CommonDropDownBO> AcademicQualificationsList  { get; set; }
        public List<CommonDropDownBO> TypeOfIndustryList { get; set; }
        public string Description { get; set; }
    }
}
