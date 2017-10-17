using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VMF.UI.Messages;

namespace VMF.UI.ViewModel
{
    public class FilterPickerViewModel : ViewModelBase
    {
        private List<string> options = new List<string>();

        public List<string> Options
        {
            get
            {
                return options;
            }
            set
            {
                options = value;
                RaisePropertyChanged();
            }
        }

        private ICommand convertVideoCommand;

        public ICommand ConvertVideoCommand
        {
            get
            {
                return convertVideoCommand ?? (convertVideoCommand = new RelayCommand(() =>
                {
                    MessengerInstance.Send(new TraceLogMessage("Operation Started"));
                }));
            }
        }
    }
}
