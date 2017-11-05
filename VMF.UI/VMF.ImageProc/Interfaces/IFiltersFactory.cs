using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMF.ImageProc.Interfaces
{
    public interface IFiltersFactory
    {
        IFilter CreateFilter(string FilterName);
    }
}
