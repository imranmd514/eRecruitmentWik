using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class ApplicantPersonalInformationBO
    {
        #region Personal Information
        public int ApplicantId { get; set; }
        public int JobId { get; set; }

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

        [Display(Name = "Email Address")]
        [Required]
        public string EmailAddress { get; set; }

        public int CountryId
        {
            get; set;
        }
        public int Country { get; set; }
        public string SaveApplicationLetter { get; set; }
        public bool IsActive { get; set; }
        public int IdTypeMasterId { get; set; }
        public string IdType { get; set; }
        public string CitizenShipIdCopy
        {
            get; set;
        }

        public string CitizenShipIdCopySavedName
        {
            get; set;
        }
        [Display(Name = "MobileNumber")]
        [Required]
        public int GenderId
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
        public string MotherTongue { get; set; }
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
        public string CVSavedName
        {
            get; set;
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
        public int AnyoneWorkinWIKId { get; set; }
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
        public string Photo { get; set; }
        public string PhotoSavedName
        {
            get; set;
        }
        public string County
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
        public string ApplicationLetterSavedName
        {
            get; set;
        }
        public List<CommonDropDownBO> TitleList { get; set; }
        public List<CommonDropDownBO> CountriesList { get; set; }

        public List<CommonDropDownBO> GenderList { get; set; }
        #endregion
    }
}
