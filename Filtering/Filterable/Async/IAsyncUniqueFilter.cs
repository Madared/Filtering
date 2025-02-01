using ResultAndOption.Options;
using ResultAndOption.Results;

namespace Filtering.Filterable.Async;

public interface IAsyncUniqueFilter<T> where T : notnull
{
    public Task<Result<T>> Filter(IAsyncFilterableExecutable<T> filterable);
}