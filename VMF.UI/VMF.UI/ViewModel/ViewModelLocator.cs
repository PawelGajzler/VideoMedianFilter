/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:VMF.UI.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using VMF.UI.Model;

namespace VMF.UI.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            SimpleIoc.Default.Register<MainViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return WMPUINinjectModule.GetKernel().Get<MainViewModel>();
            }
        }

        public FileIOViewModel FileIO
        {
            get
            {
                return WMPUINinjectModule.GetKernel().Get<FileIOViewModel>();
            }
        }

        public FilterPickerViewModel Filter
        {
            get
            {
                return WMPUINinjectModule.GetKernel().Get<FilterPickerViewModel>();
            }
        }

        public ProgressViewModel Progress
        {
            get
            {
                return WMPUINinjectModule.GetKernel().Get<ProgressViewModel>();
            }
        }

        public TraceLogViewModel TraceLog
        {
            get
            {
                return WMPUINinjectModule.GetKernel().Get<TraceLogViewModel>();
            }
        }

        public BinaryzationFilterViewModel Binaryzation
        {
            get
            {
                return WMPUINinjectModule.GetKernel().Get<BinaryzationFilterViewModel>();
            }
        }

        public ConfigViewModel Config
        {
            get
            {
                return WMPUINinjectModule.GetKernel().Get<ConfigViewModel>();
            }
        }
        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}