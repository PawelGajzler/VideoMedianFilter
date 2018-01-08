using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Video.FFMPEG;
using VMF.ImageProc.Interfaces;
using System.Threading;
using System.IO;
using Accord.Video;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System.Drawing;
using VMF.UI.Messages;
using VMF.UI.Interfaces;
using System.Diagnostics;

namespace VMF.UI.Model
{
    public class VideoFilterEngine : IVideoFilterEngine
    {
        public async void FilterVideo(IFilter filter, VideoOptions options, CancellationToken token)
        {
            try
            {
                VideoFileReader videoFileReader = new VideoFileReader();
                videoFileReader.Open(options.InputPath);
                Messenger.Default.Send(new TraceLogMessage($"File resolution {videoFileReader.Width}x{videoFileReader.Height}, frame rate {videoFileReader.FrameRate.Value:2f}fps"));
                VideoFileWriter videoFileWriter = new VideoFileWriter();
                videoFileWriter.Open($"{options.OutputPath}\\{options.FileName}.wmv", videoFileReader.Width, videoFileReader.Height, videoFileReader.FrameRate, options.Codec);
                for(int i=0; i<videoFileReader.FrameCount; ++i)
                {
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                    Bitmap currentBitmap = videoFileReader.ReadVideoFrame();
                    Bitmap newBitmap = await filter.RunFilter(currentBitmap);
                    videoFileWriter.WriteVideoFrame(newBitmap);
                    double progress = (i / videoFileReader.FrameCount) * 100;
                    Debug.WriteLine(progress);
                    Messenger.Default.Send(new ProgressMessage((int)progress));
                }
                videoFileReader.Close();
                videoFileWriter.Close();
                Messenger.Default.Send(new TraceLogMessage("Operation completed"));
            }
            catch (IOException)
            {
                Messenger.Default.Send(new TraceLogMessage("Cannot find a file with the given path"));
            }
            catch (VideoException)
            {
                Messenger.Default.Send(new TraceLogMessage("Cannot open a video from file with the given path"));
            }
            catch (AccessViolationException)
            {
                Messenger.Default.Send(new TraceLogMessage("File format don't fit to current codec"));
            }
        }
    }
}
