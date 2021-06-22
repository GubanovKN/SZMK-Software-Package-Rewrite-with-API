using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Domain.Exceptions
{
    public class InvalidAccessTokenException : Exception
    {
        public InvalidAccessTokenException() { }

        public InvalidAccessTokenException(String message) : base(message) { }
    }
}
