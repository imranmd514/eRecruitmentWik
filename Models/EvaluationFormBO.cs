using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
   public class EvaluationFormBO
    {
        #region Evaluation
        public int ApplicantEvaluationId { get; set; }
        public int AppliedJobId { get; set; }
        public int EvaluationFormId { get; set; }
        public int ApplicantId { get; set; }
        public string ApplicantName { get; set; }
        public int JobPostingId { get; set; }
        public string JobCode { get; set; }
        public int DonorProgramId { get; set; }
        public string ProgramName { get; set; }
      
        public int CommunicationSkillsId { get; set; }
        public string CommunicationSkills { get; set; }
        public int ExperienceId { get; set; }
        public string Experience { get; set; }
        public string Skill { get; set; }
        public int SkillId { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public int ApplicantSkillId { get; set; }
        public int YearId { get; set; }
        public string Year { get; set; }
        public int MonthId { get; set; }
        public string Month { get; set; }
        public int RatingId { get; set; }
        public string Rating { get; set; }
        public string EvaluationComments { get; set; }
        public bool IsActive { get; set; }

        public int AcademicQualificationId { get; set; }
        public string HighestQualification { get; set; }
        #endregion
        public List<CommonDropDownBO> CommunicationSkillList
        {
            get;set;
        }
        public List<CommonDropDownBO>  ExperienceList
        {
            get;set;
        }
        public List<CommonDropDownBO> getMonthsList
        {
            get;set;
        }
        public List<CommonDropDownBO> getYearList
        {
            get; set;
        }
        public List<CommonDropDownBO> RatingList
        {
            get;set;
        }

        public List<ApplicantSkillsDetailsBO> ApplicantSkillDetails
        {
            get;set;
        }

     
    }
}
