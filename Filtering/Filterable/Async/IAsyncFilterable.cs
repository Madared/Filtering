using System.Linq.Expressions;
using ResultAndOption.Options;

namespace Filtering.Filterable.Async;

public interface IAsyncFilterable<T> where T : notnull
{
    public Task<IAsyncFilterable<T>> Where(Expression<Func<T, bool>> predicate);
    public Task<IAsyncFilterable<T>> OrderBy<TSelected>(Expression<Func<T, TSelected>> selector);
    public Task<IAsyncFilterable<T>> OrderByDesending<TSelected>(Expression<Func<T, TSelected>> selector);
    public Task<IAsyncFilterable<T>> Take(int toTake);
    public Task<IAsyncFilterable<T>> Skip(int toSkip);
    public Task<Option<T>> Single(Expression<Func<T, bool>> predicate);
    public Task<Option<T>> First(Expression<Func<T, bool>> predicate);
    public Task<List<T>> Execute();
}