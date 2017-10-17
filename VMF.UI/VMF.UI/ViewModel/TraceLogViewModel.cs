using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMF.UI.Messages;
using VMF.UI.Model;

namespace VMF.UI.ViewModel
{
    public class TraceLogViewModel : ViewModelBase
    {
        public TraceLogViewModel()
        {
            InitializeMessageHandlers();
        }

        private void InitializeMessageHandlers()
        {
            MessengerInstance.Register<TraceLogMessage>(this, TraceLogMessageHandler);
        }

        private void TraceLogMessageHandler(TraceLogMessage obj)
        {
            Messages.Add(new TraceLogModel(obj.Message));
        }

        private List<TraceLogModel> messages = new List<TraceLogModel>();

        public List<TraceLogModel> Messages
        {
            get
            {
                return messages;
            }
            set
            {
                messages = value;
                RaisePropertyChanged();
            }
        }
    }
}
