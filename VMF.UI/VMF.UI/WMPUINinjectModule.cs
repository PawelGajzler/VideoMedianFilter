using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using VMF.UI.ViewModel;
using VMF.ImageProc;
using VMF.UI.Interfaces;
using VMF.UI.Model;

namespace VMF.UI
{
    class WMPUINinjectModule : NinjectModule
    {
        public static IKernel GetKernel()
        {
            return new StandardKernel(new WMPUINinjectModule(), new ImageProcNinjectModule());
        }

        public override void Load()
        {
            Bind<MainViewModel>().ToSelf();
            Bind<FileIOViewModel>().ToSelf();
            Bind<FilterPickerViewModel>().ToSelf();
            Bind<ProgressViewModel>().ToSelf();
            Bind<TraceLogViewModel>().ToSelf();
            Bind<BinaryzationFilterViewModel>().ToSelf();
            Bind<ConfigViewModel>().ToSelf();
            Bind<IVideoFilterEngine>().To<VideoFilterEngine>();
        }
    }
}
