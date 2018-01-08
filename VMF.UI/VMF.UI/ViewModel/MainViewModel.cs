using System;
using CommonTypes;
using GalaSoft.MvvmLight;
using VMF.UI.Model;
using VMF.UI.Messages;

namespace VMF.UI.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private FilterType currentFilter=FilterType.None;

        public FilterType CurrentFilter
        {
            get
            {
                return currentFilter;
            }
            set
            {
                if (currentFilter == value)
                {
                    return;
                }
                currentFilter = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            RegisterMessages();           
        }

        private void RegisterMessages()
        {
            MessengerInstance.Register<FilterViewMessage>(this, filterMessageHandler);
        }

        private void filterMessageHandler(FilterViewMessage obj)
        {
            CurrentFilter = obj.Type;
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}