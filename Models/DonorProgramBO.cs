using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public  class DonorProgramBO
    {
        public int DonorProgramId
        {
            get;set;
        }

        public string DonorProgram
        {
            get;set;
        }
        public Boolean IsActive
        {
            get;set;
        }
    }
}
