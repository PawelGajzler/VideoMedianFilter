using System;

namespace VMF.ImageProc.Exceptions
{
    public class UnknownParameterException : Exception
    {
        public UnknownParameterException() { }

        public UnknownParameterException(string message) : base(message) { }
    }
}
