using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMF.UI.Messages;

namespace VMF.UI.ViewModel
{
    public class ProgressViewModel : ViewModelBase
    {
        public ProgressViewModel()
        {
            InitializeMessageHandlers();
        }

        private void InitializeMessageHandlers()
        {
            MessengerInstance.Register<ProgressMessage>(this, ProgressMessageHandler);
        }

        private void ProgressMessageHandler(ProgressMessage obj)
        {
            ProgressValue = obj.Value;
        }

        private int progressValue = 0;

        public int ProgressValue
        {
            get
            {
                return progressValue;
            }
            set
            {
                progressValue = value;
                RaisePropertyChanged();
            }
        }
    }
}
