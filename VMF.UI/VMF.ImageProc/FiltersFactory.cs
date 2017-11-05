using System;
using VMF.ImageProc.Interfaces;
using VMF.ImageProc.Filters;
using VMF.ImageProc.Exceptions;

namespace VMF.ImageProc
{
    public class FiltersFactory : IFiltersFactory
    {
        public IFilter CreateFilter(string FilterName)
        {
            switch (FilterName)
            {
                case "GrayScale":
                    return new GrayScaleFilter();
                case "Binaryzation":
                    return new BinaryzationFilter();
                default:
                    throw new FilterNotFoundException();
            }
        }
    }
}
