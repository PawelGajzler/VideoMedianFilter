using System;
using System.Drawing;
using System.Threading.Tasks;
using VMF.ImageProc.Interfaces;

namespace VMF.ImageProc.Filters
{
    public class GrayScaleFilter : IFilter
    {
        public Task<Bitmap> RunFilter(Bitmap inputImage)
        {
            return Task.Run(() =>
            {
                Bitmap result = new Bitmap(inputImage.Width, inputImage.Height);
                for(int i=0; i < inputImage.Width; ++i)
                {
                    for (int j = 0; j < inputImage.Height; ++j)
                    {
                        Color pixelColor = inputImage.GetPixel(i, j);
                        double grayScale = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                        result.SetPixel(i, j, Color.FromArgb((int)grayScale, (int)grayScale, (int)grayScale));
                    }
                }
                return result;
            });
        }

        public void SetParameter(string key, object value)
        {
            throw new NotImplementedException();
        }
    }
}
