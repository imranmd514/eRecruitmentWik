using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LanguageSpokenBO
    {
        public int LanguageSpokenId {get;set;}
        public int ApplicantId { get; set; }
        public string Language { get; set; }
        public string LanguageRead { get; set; }
        public string Write { get; set; }
        public string Speak { get; set; }
        public string Understand { get; set; }
        public bool IsActive { get; set; }
    }
}
