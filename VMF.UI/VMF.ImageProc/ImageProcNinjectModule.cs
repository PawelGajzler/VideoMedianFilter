using Ninject.Modules;
using VMF.ImageProc.Interfaces;

namespace VMF.ImageProc
{
    public class ImageProcNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFiltersFactory>().To<FiltersFactory>();
        }
    }
}
