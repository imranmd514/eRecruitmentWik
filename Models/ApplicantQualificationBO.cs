using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class ApplicantQualificationBO
    {
        #region Qualification
        public int ApplicantId { get; set; }

        public int ApplicantQualificationId {get; set;}

        public int AcademicQualificationId { get; set; }
        public string AcademicQualification { get; set; }

        public string OtherCertification { get; set; }
        public string AcademicQualificationAttachment { get; set; }
        public string AttachmentSavedName {get; set;}

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Discipline { get; set; }

        public string University { get; set; }

        public int QuaCountryId {get; set;}
        public string QuaCountry {get; set;}

        public string CreditScoreClass { get; set; }

        public bool IsActive { get; set; }




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
        public string QuaStartDate
        {
            get; set;
        }
        public string QuaEndDate
        {
            get; set;
        }
        public string QuaNationality
        {
            get; set;
        }
        public string Degree
        {
            get; set;
        }
        public string Class
        {
            get; set;
        }
        public string SaveBachelors { get; set; }
        public string SaveDiploma { get; set; }
        public string SaveMSC { get; set; }
        public string SavePHD { get; set; }
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

        #endregion
    }
}
