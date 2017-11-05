using System;

namespace VMF.ImageProc.Exceptions
{
    class ValueOutOfRangeException : Exception
    {
        public ValueOutOfRangeException() { }

        public ValueOutOfRangeException(string message) : base(message) { }
    }
}
