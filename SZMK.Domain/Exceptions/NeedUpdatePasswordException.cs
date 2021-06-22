using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Domain.Exceptions
{
    public class NeedUpdatePasswordException : Exception
    {
        public NeedUpdatePasswordException() { }

        public NeedUpdatePasswordException(String message) : base(message) { }
    }
}
