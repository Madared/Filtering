using System.Linq.Expressions;
using ResultAndOption.Options;
using ResultAndOption.Results;

namespace Filtering.Filterable.Async;

/// <summary>
/// An async executable filterable 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IAsyncFilterableExecutable<T> : IFilterable<T, IAsyncFilterableExecutable<T>> where T : notnull
{
    /// <summary>
    /// Asynchronously returns the count of the filterable
    /// </summary>
    /// <returns></returns>
    public Task<int> Count();
    /// <summary>
    /// Asynchronously returns an option of the first item of the filterable
    /// </summary>
    /// <param name="predicate">The predicate</param>
    /// <returns></returns>
    public Task<Option<T>> First(Expression<Func<T, bool>> predicate);
    /// <summary>
    /// Asynchronously returns an option of the last item of the filterable
    /// </summary>
    /// <param name="predicate">The predicate</param>
    /// <returns></returns>
    public Task<Option<T>> Last(Expression<Func<T, bool>> predicate);
    /// <summary>
    /// Asynchronously returns an option of the selected type if it is the only item in the filterable.
    /// </summary>
    /// <param name="predicate">The predicate</param>
    /// <returns></returns>
    public Task<Result<T>> Single(Expression<Func<T, bool>> predicate);
    /// <summary>
    /// Gets the AsyncEnumerable of the filterable
    /// </summary>
    /// <returns></returns>
    public IAsyncEnumerable<T> ExecuteToAsync();
    /// <summary>
    /// Asynchronously gets an IEnumerable of the filterable.
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<T>> Execute();
}