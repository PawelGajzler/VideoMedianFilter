using Accord.Video.FFMPEG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMF.UI.Model
{
    public class VideoOptions
    {
        public string InputPath { get; set; }

        public string OutputPath { get; set; }

        public string FileName { get; set; }

        public string FileFormat { get; set; }

        public VideoCodec Codec { get; set; }

        public VideoOptions()
        {
            InputPath = string.Empty;
            OutputPath = string.Empty;
            FileName = string.Empty;
            FileFormat = string.Empty;
            Codec = VideoCodec.WMV2;
        }
    }
}
