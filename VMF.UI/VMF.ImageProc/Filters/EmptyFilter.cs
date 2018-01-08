using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMF.ImageProc.Interfaces;

namespace VMF.ImageProc.Filters
{
    class EmptyFilter : IFilter
    {
        public Task<Bitmap> RunFilter(Bitmap inputImage)
        {
            return Task.Run(() =>
            {
                return inputImage;
            });
        }

        public void SetParameter(string key, object value)
        {
            throw new NotImplementedException();
        }
    }
}
