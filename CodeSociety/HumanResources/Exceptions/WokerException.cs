using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Exceptions
{
    public class WokerException : Exception
    {
        public override string Message
        {
            get
            {
                return "woker’s Job is null";
            }
        }

        public override IDictionary Data
        {
            get
            {
                return base.Data;
            }
        }
    }
}
