using System.Linq.Expressions;
using ResultAndOption.Options;
using ResultAndOption.Results;

namespace Filtering.Filterable.Async;

public interface IAsyncFilterableExecutable<T> : IFilterable<T, IFilterableExecutable<T>> where T : notnull
{
    public Task<int> Count();
    public Task<Option<T>> First<TSelected>(Expression<Func<T, TSelected>> selector);
    public Task<Option<T>> Last<TSelected>(Expression<Func<T, TSelected>> selector);
    public Task<Result<T>> Single<TSelected>(Expression<Func<T, TSelected>> selector);
    public IAsyncEnumerable<T> ExecuteToAsync();
    public Task<IEnumerable<T>> Execute();
}