using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMF.ImageProc.Helpers;
using VMF.ImageProc.Exceptions;
using VMF.ImageProc.Interfaces;

namespace VMF.ImageProc.Filters
{
    class BinaryzationFilter : IFilter
    {
        private int threshhold = 128;

        private bool adaptive = true;

        public Task<Bitmap> RunFilter(Bitmap inputImage)
        {
            return Task.Run(() =>
            {
                Bitmap result = new Bitmap(inputImage.Width, inputImage.Height);
                if (adaptive)
                {
                    Histogram histogram = new Histogram(inputImage);
                    threshhold = histogram.CalculateThreshhold();
                }
                for(int i = 0; i<inputImage.Width; ++i)
                {
                    for (int j = 0; j < inputImage.Height; ++j)
                    {
                        if (inputImage.GetPixel(i, j).R > threshhold)
                        {
                            result.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            result.SetPixel(i, j, Color.Black);
                        }
                    }
                }
                return result;
            });
        }

        public void SetParameter(string key, object value)
        {
            switch (key)
            {
                case "Threshhold":
                    if (value is int threshholdVal)
                    {
                        if (threshholdVal >= 0 && threshholdVal <= 255)
                        {
                            threshhold = threshholdVal;
                        }
                        else
                        {
                            throw new ValueOutOfRangeException();
                        }
                    }
                    else
                    {
                        throw new FormatException();
                    }
                    break;
                case "Adaptive":
                    if(value is bool adaptiveVal)
                    {
                        adaptive = adaptiveVal;
                    }
                    else
                    {
                        throw new FormatException();
                    }
                    break;
                default:
                    throw new UnknownParameterException("Binaryzation Filter does not accept parameter with name: " + key);
            }
        }
    }
}
