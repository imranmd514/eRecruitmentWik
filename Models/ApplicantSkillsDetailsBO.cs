using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public  class ApplicantSkillsDetailsBO
    {
        public int ApplicantId
        {
            get;
            set;
        }
        public int JobPostingId
        {
            get;
            set;
        }
        public string Skill
        {
            get;set;
        }
        public int RatingId
        {
            get;set;
        }
        public string Rating
        {
            get;set;
        }
        public string EvaluationComments
        {
            get;set;
        }

    }
}
