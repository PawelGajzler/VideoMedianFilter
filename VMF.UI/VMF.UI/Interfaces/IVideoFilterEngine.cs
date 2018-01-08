using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VMF.ImageProc.Interfaces;
using VMF.UI.Model;

namespace VMF.UI.Interfaces
{
    public interface IVideoFilterEngine
    {
        void FilterVideo(IFilter filter, VideoOptions options, CancellationToken token);
    }
}
