using CommonTypes;

namespace VMF.ImageProc.Interfaces
{
    public interface IFiltersFactory
    {
        IFilter CreateFilter(FilterType FilterName);
    }
}
