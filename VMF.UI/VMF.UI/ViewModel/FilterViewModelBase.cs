using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMF.UI.Messages;

namespace VMF.UI.ViewModel
{
    public class FilterViewModelBase : ViewModelBase
    {
        protected void ParameterChanged(string key, object value)
        {
            MessengerInstance.Send(new FilterParameterMessage(key, value));
        }
    }
}
