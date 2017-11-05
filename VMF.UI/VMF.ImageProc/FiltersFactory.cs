using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMF.ImageProc.Interfaces;

namespace VMF.ImageProc
{
    public class FiltersFactory : IFiltersFactory
    {
        public IFilter CreateFilter(string FilterName)
        {
            throw new NotImplementedException();
        }
    }
}
