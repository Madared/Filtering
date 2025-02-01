namespace Filtering.Filterable;

public interface IFilter<T> where T : notnull
{
    public TFilterable Filter<TFilterable>(IFilterable<T, TFilterable> filterable) where TFilterable : IFilterable<T, TFilterable>;
}