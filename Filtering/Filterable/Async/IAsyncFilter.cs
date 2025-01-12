namespace Filtering.Filterable.Async;

public interface IAsyncFilter<T> where T : notnull
{
    public Task<IAsyncFilterable<T>> Filter(IAsyncFilterable<T> filterable);
}