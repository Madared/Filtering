using Filtering.Identification;
using ResultAndOption.Options;

namespace Filtering.QueryFiltering;

/// <summary>
/// Represents an asynchronous query filter
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IAsyncUniqueQueryFilter<T> where T : notnull
{
    /// <summary>
    /// Will uniquely filter the <see cref="IQueryable{T}"/> asynchronously
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public Task<Option<T>> Filter(IQueryable<T> query);

    /// <summary>
    /// Checks if value conforms to the unique query filter.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool IsCorrect(T value);
}

/// <summary>
/// Represents an identifiable asynchronous query filter.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IIdentifiableAsyncUniqueQueryFilter<T> : IAsyncUniqueQueryFilter<T>, IIdentifiable where T : notnull;