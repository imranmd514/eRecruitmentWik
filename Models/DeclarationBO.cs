using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DeclarationBO
    {
        public int DeclarationID { get; set; }
        public int ApplicantId { get; set; }
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
        public string Date { get; set; }
        public bool IsActive { get; set; }
        public bool Declarationinfo { get; set; }
        public bool Statement { get; set; }
    }
}
