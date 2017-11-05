using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMF.ImageProc.Exceptions
{
    public class FilterNotFoundException : Exception
    {
        public FilterNotFoundException() { }

        public FilterNotFoundException(string message) : base(message) { }
    }
}
