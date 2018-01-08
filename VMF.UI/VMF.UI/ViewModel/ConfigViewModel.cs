using Accord.Video.FFMPEG;
using CommonTypes;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VMF.UI.Messages;

namespace VMF.UI.ViewModel
{
    public class ConfigViewModel : ViewModelBase
    {
        public ConfigViewModel()
        {
            FileName = Properties.Settings.Default[Constants.FileNamePropertyKey].ToString();
            FileType = Properties.Settings.Default[Constants.FileTypePropertyKey].ToString();
        }

        private string fileName = "test";

        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
                RaisePropertyChanged();
            }
        }

        private string fileType = "avi";

        public string FileType
        {
            get
            {
                return fileType;
            }
            set
            {
                fileType = value;
                RaisePropertyChanged();
            }
        }

        private VideoCodec codec = VideoCodec.H264;

        public VideoCodec Codec
        {
            get
            {
                return codec;
            }
            set
            {
                codec = value;
                RaisePropertyChanged();
            }
        }

        private ICommand saveCommand = null;

        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ?? (new RelayCommand<Window>(window =>
                {
                    Properties.Settings.Default[Constants.FileNamePropertyKey] = FileName;
                    Properties.Settings.Default[Constants.FileTypePropertyKey] = FileType;
                    Properties.Settings.Default.Save();
                    MessengerInstance.Send(new NewConfigMessage());
                    window.Close();
                }));
            }
        }
    }
}
