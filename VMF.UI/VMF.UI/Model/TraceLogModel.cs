using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMF.UI.Model
{
    public class TraceLogModel
    {
        public string Message { get; set; }

        public DateTime MessageTime { get; set; }

        public TraceLogModel(string Message)
        {
            this.Message = Message;
            this.MessageTime = DateTime.Now;
        }

        public TraceLogModel(string Message, DateTime MessageTime)
        {
            this.Message = Message;
            this.MessageTime = MessageTime;
        }
    }
}
