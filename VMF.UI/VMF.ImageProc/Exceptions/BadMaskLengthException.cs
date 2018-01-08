using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMF.ImageProc.Exceptions
{
    public class BadMaskLengthException : Exception
    {
        public BadMaskLengthException()
        {
        }

        public BadMaskLengthException(string message) : base(message)
        {
        }
    }
}
