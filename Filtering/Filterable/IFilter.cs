namespace Filtering.Filterable;

public interface IFilter<T> where T : notnull
{
    public IFilterable<T, TFilterable> Filter<TFilterable>(IFilterable<T, TFilterable> filterable) where TFilterable : IFilterable<T, TFilterable>;
}