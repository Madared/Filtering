using ResultAndOption.Options;

namespace Filtering.Filterable.Async;

public interface IAsyncUniqueFilter<T> where T : notnull
{
    public Task<Option<T>> Filter(IAsyncFilterable<T> filterable);
}