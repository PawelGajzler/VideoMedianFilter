using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMF.UI.Messages
{
    public class ProgressMessage
    {
        public int Value { get; }

        public ProgressMessage(int Value)
        {
            this.Value = Value;
        }
    }
}
