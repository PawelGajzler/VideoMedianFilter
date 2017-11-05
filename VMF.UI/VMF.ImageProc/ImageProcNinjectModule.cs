using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
