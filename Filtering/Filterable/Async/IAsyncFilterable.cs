using System.Linq.Expressions;
using ResultAndOption.Options;

namespace Filtering.Filterable.Async;

public interface IAsyncFilterable<T> where T : notnull
{
    public Task<int> Count();
    public IAsyncFilterable<T> Where(Expression<Func<T, bool>> predicate);
    public IAsyncFilterable<T> OrderBy<TSelected>(Expression<Func<T, TSelected>> selector);
    public IAsyncFilterable<T> OrderByDescending<TSelected>(Expression<Func<T, TSelected>> selector);
    public IAsyncFilterable<T> Take(int toTake);
    public IAsyncFilterable<T> Skip(int toSkip);
    public Task<Option<T>> Single(Expression<Func<T, bool>> predicate);
    public Task<Option<T>> First(Expression<Func<T, bool>> predicate);
    public Task<List<T>> Execute();
}