using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace VMF.UI.ViewModel
{
    public class BinaryzationFilterViewModel : FilterViewModelBase
    {
        private bool adaptiveThreshhold = false;

        public bool AdaptiveThreshhold
        {
            get
            {
                return adaptiveThreshhold;
            }
            set
            {
                adaptiveThreshhold = value;
                RaisePropertyChanged();
                ParameterChanged("Adaptive", adaptiveThreshhold);
            }
        }

        private int threshhold = 128;

        public int Threshhold
        {
            get
            {
                return threshhold;
            }
            set
            {
                threshhold = value;
                RaisePropertyChanged();
                ParameterChanged("Threshhold", threshhold);
            }
        }
    }
}
