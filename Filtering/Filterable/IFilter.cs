namespace Filtering.Filterable;

public interface IFilter<T> where T : notnull
{
    public IFilterable<T> Filter(IFilterable<T> filterable);
}