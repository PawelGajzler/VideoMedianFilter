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
using VMF.UI.Model;

namespace VMF.UI.ViewModel
{
    public class FilterPickerViewModel : ViewModelBase
    {
        private IFilter currentFilter;

        private IFiltersFactory filtersFactory;

        private CancellationTokenSource cancellationTokenSource;

        private IVideoFilterEngine videoFilterEngine;

        private FilterType currentFilterType = FilterType.None;

        private VideoOptions videoOptions;

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
            this.videoOptions = new VideoOptions();
            this.filtersFactory = filtersFactory;
            this.videoFilterEngine = videoFilterEngine;
            this.cancellationTokenSource = new CancellationTokenSource();
            this.currentFilter = this.filtersFactory.CreateFilter(FilterType.None);
            GetDataFromConfig();
            RegisterMessageHandlers();
        }

        private void RegisterMessageHandlers()
        {
            MessengerInstance.Register<FilterParameterMessage>(this, FilterParameterHandler);
            MessengerInstance.Register<FilePathMessage>(this, FileParametersHandler);
            MessengerInstance.Register<NewConfigMessage>(this, NewConfigHandler);
        }

        private void NewConfigHandler(NewConfigMessage obj)
        {
            GetDataFromConfig();
        }

        private void GetDataFromConfig()
        {
            videoOptions.FileName = Properties.Settings.Default[Constants.FileNamePropertyKey].ToString();
            videoOptions.FileFormat = Properties.Settings.Default[Constants.FileTypePropertyKey].ToString();
        }

        private void FileParametersHandler(FilePathMessage obj)
        {
            if (obj.IsInput)
            {
                videoOptions.InputPath = obj.Path;
            }
            else
            {
                videoOptions.OutputPath= obj.Path;
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
                        videoFilterEngine.FilterVideo(currentFilter, videoOptions, cancellationTokenSource.Token);
                    }
                }));
            }
        }
    }
}
