﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMF.UI.Messages
{
    public class TraceLogMessage
    {
        public string Message { get; }

        public TraceLogMessage(string Message)
        {
            this.Message = Message;
        }
    }
}
