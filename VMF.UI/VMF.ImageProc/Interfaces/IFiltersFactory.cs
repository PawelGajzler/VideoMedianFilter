namespace VMF.ImageProc.Interfaces
{
    public interface IFiltersFactory
    {
        IFilter CreateFilter(string FilterName);
    }
}
