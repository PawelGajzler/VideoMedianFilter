using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VMF.ImageProc.Interfaces
{
    public interface IFilter
    {
        void SetParameter(string key, object value);
        Task<Bitmap> RunFilter(Bitmap inputImage);
    }
}
