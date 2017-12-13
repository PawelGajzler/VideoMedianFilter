using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using VMF.UI.Messages;

namespace VMF.UI.ViewModel
{
    public class FileIOViewModel : ViewModelBase
    {
        public FileIOViewModel()
        {

        }

        private string sourceFileLocation = string.Empty;

        public string SourceFileLocation
        {
            get
            {
                return sourceFileLocation;
            }
            set
            {
                sourceFileLocation = value;
                RaisePropertyChanged();
            }
        }

        private string destinationLocation = string.Empty;

        public string DestinationLocation
        {
            get
            {
                return destinationLocation;
            }
            set
            {
                destinationLocation = value;
                RaisePropertyChanged();
            }
        }

        private ICommand pickSourceFileCommand;

        public ICommand PickSourceFileCommand
        {
            get
            {
                return pickSourceFileCommand ?? (pickSourceFileCommand = new RelayCommand(() =>
                {
                    Microsoft.Win32.OpenFileDialog sourceFileDialog = new Microsoft.Win32.OpenFileDialog
                    {
                        Filter = "Video Files|*.avi;*.3gp;*.mov;*.mp4;*.flv;"
                    };
                    Nullable<bool> result = sourceFileDialog.ShowDialog();
                    if(result == true)
                    {
                        SourceFileLocation = sourceFileDialog.FileName;
                        MessengerInstance.Send(new FilePathMessage(SourceFileLocation, true));
                    }
                }));
            }
        }

        private ICommand pickDestinationFolderCommand;

        public ICommand PickDestinationFolderCommand
        {
            get
            {
                return pickDestinationFolderCommand ?? (pickDestinationFolderCommand = new RelayCommand(() =>
                {
                    FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                    DialogResult result = folderBrowserDialog.ShowDialog();
                    if(result==DialogResult.OK && !String.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                    {
                        DestinationLocation = folderBrowserDialog.SelectedPath;
                        MessengerInstance.Send(new FilePathMessage(DestinationLocation, false));
                    }
                }));
            }
        }
    }
}
