using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMF.ImageProc.Interfaces;

namespace VMF.ImageProc.Filters
{
    class BorderDetectionFilter : IFilter
    {
        public Task<Bitmap> RunFilter(Bitmap inputImage)
        {
            throw new NotImplementedException();
        }

        public void SetParameter(string key, object value)
        {
            throw new NotImplementedException();
        }
    }
}
