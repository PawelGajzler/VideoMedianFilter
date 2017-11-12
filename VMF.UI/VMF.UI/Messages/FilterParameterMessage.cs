using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMF.UI.Messages
{
    public class FilterParameterMessage
    {
        public string Key { get; set; }

        public object Value { get; set; }

        public FilterParameterMessage(string Key, object Value)
        {
            this.Key = Key;
            this.Value = Value;
        }
    }
}
