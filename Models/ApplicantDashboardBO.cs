using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ApplicantDashboardBO
    {
        //Personal Information

        #region Personal Information
        public int ApplicantId { get; set; }
        public int JobId { get; set; }

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

        [Display(Name = "Citizenship")]
        [Required]
        public string Citizenship { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        public string EmailAddress { get; set; }

        [Display(Name = "MobileNumber")]
        [Required]

        public string Gender
        {
            get; set;
        }
        public int State
        {
            get; set;
        }
        public string PhoneNumber { get; set; }

        [Display(Name = "Alternate Mobile Number")]
        [Required]
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

        public String ResumeSaved
        {
            get; set;
        }

        public string AttachmentSaveFile
        {
            get; set;
        }

        public string Attachment
        {
            get; set;
        }


        #endregion

        #region Qualification

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

        [Display(Name = "Start Date")]
        [Required]
        public string StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required]
        public string EndDate { get; set; }

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
        public string CountryId { get; set; }
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
        public string QuaStartDate
        {
            get; set;
        }
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

        #endregion

        #region Employment History
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

        [Display(Name = "Postal Code")]
        [Required]

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
        public string Friends
        {
            get; set;
        }
        public string WIKWebsite
        {
            get; set;
        }
        public string SocialMedia
        {
            get; set;
        }

        #endregion

        #region Motivation
        public string PostalCode { get; set; }

        public string JobDescription { get; set; }

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

        public string FileSavedName
        {
            get;
            set;
        }

        public string FileSavedName1
        {
            get; set;
        }

        public string FileSavedName2
        {
            get; set;
        }

        public string FileSavedName3
        {
            get; set;
        }
        public string FileSavedName4
        {
            get; set;
        }
        public string FileSavedName5
        {
            get; set;
        }

        public bool IsActive { get; set; }

        public List<CommonDropDownBO> TitleList { get; set; }
        public List<CommonDropDownBO> CountriesList { get; set; }

        public List<CommonDropDownBO> GenderList { get; set; }

        //Motivation Skills And Experience
        public string Description { get; set; }

    }
}
