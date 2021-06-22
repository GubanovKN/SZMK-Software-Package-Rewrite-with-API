using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Domain.Exceptions
{
    public class OutOfRangeSessionsException: Exception
    {
        public OutOfRangeSessionsException() { }

        public OutOfRangeSessionsException(String message) : base(message) { }
    }
}
