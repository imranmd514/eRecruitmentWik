using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CommonDB
{
    public class ProcParameterBO
    {
        public string ParameterName
        {
            get;
            set;
        }

        public object ParameterValue
        {
            get;
            set;
        }

        public ParameterDirection Direction
        {
            get;
            set;
        }

        public int Size
        {
            get;
            set;
        }

        public DbType dbType
        {
            get;
            set;
        }       

    }
}
