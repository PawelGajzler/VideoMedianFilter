using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VMF.ImageProc.Interfaces;
using VMF.UI.Messages;
using CommonTypes;
using System.Threading;
using VMF.UI.Interfaces;

namespace VMF.UI.ViewModel
{
    public class FilterPickerViewModel : ViewModelBase
    {
        private IFilter currentFilter;

        private IFiltersFactory filtersFactory;

        private CancellationTokenSource cancellationTokenSource;

        private IVideoFilterEngine videoFilterEngine;

        private FilterType currentFilterType = FilterType.None;

        private string inputFilePath = string.Empty;

        private string outputDirectoryPath = string.Empty;

        public FilterType CurrentFilterType
        {
            get
            {
                return currentFilterType;
            }
            set
            {
                currentFilterType = value;
                SetFilter();
                RaisePropertyChanged();
            }
        }

        private bool filterRunning = false;

        public bool FilterRunning
        {
            get
            {
                return filterRunning;
            }
            set
            {
                filterRunning = value;
                RaisePropertyChanged();
            }
        }

        private void SetFilter()
        {
            currentFilter = filtersFactory.CreateFilter(CurrentFilterType);
        }

        public FilterPickerViewModel(IFiltersFactory filtersFactory, IVideoFilterEngine videoFilterEngine)
        {
            this.filtersFactory = filtersFactory;
            this.videoFilterEngine = videoFilterEngine;
            this.cancellationTokenSource = new CancellationTokenSource();
            RegisterMessageHandlers();
        }

        private void RegisterMessageHandlers()
        {
            MessengerInstance.Register<FilterParameterMessage>(this, FilterParameterHandler);
            MessengerInstance.Register<FilePathMessage>(this, FileParametersHandler);
        }

        private void FileParametersHandler(FilePathMessage obj)
        {
            if (obj.IsInput)
            {
                inputFilePath = obj.Path;
            }
            else
            {
                outputDirectoryPath = obj.Path;
            }
        }

        private void FilterParameterHandler(FilterParameterMessage obj)
        {
            currentFilter.SetParameter(obj.Key, obj.Value);
        }

        private ICommand convertVideoCommand;

        public ICommand ConvertVideoCommand
        {
            get
            {
                return convertVideoCommand ?? (convertVideoCommand = new RelayCommand(() =>
                {
                    if (FilterRunning)
                    {
                        cancellationTokenSource.Cancel();
                        MessengerInstance.Send(new TraceLogMessage("Operation Canceled"));
                        MessengerInstance.Send(new ProgressMessage(0));
                        FilterRunning = false;
                    }
                    else
                    {
                        MessengerInstance.Send(new TraceLogMessage("Operation Started"));
                        FilterRunning = true;
                        videoFilterEngine.FilterVideo(currentFilter, inputFilePath, outputDirectoryPath, cancellationTokenSource.Token);
                    }
                }));
            }
        }
    }
}
