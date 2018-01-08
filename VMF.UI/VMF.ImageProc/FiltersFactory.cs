using System;
using VMF.ImageProc.Interfaces;
using VMF.ImageProc.Filters;
using VMF.ImageProc.Exceptions;
using CommonTypes;

namespace VMF.ImageProc
{
    public class FiltersFactory : IFiltersFactory
    {
        public IFilter CreateFilter(FilterType FilterName)
        {
            switch (FilterName)
            {
                case FilterType.GrayScale:
                    return new GrayScaleFilter();
                case FilterType.Binaryzation:
                    return new BinaryzationFilter();
                default:
                    return new EmptyFilter();
            }
        }
    }
}
