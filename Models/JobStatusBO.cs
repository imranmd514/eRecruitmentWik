using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class JobStatusBO
    {
        public int ApplicantId
        {
            get;
            set;
        }
        public string FullName
        {
            get;
            set;
        }
        public string PhoneNumber
        {
            get;
            set;
        }
        public string EmailAddress
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string Comments
        {
            get;
            set;
        }
        public string StatusId
        {
            get;
            set;
        }
    }
}
