using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VMF.ImageProc.Interfaces;

namespace VMF.UI.Interfaces
{
    public interface IVideoFilterEngine
    {
        void FilterVideo(IFilter filter, string inputFile, string outputDirectory, CancellationToken token);
    }
}
