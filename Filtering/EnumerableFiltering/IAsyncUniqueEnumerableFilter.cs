using Filtering.Identification;
using ResultAndOption.Options;

namespace Filtering.EnumerableFiltering;

/// <summary>
/// Represents an asynchronous enumerable filter.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IAsyncUniqueEnumerableFilter<T> where T : notnull
{
    /// <summary>
    /// Will uniquely filter the <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    Task<Option<T>> Filter(IEnumerable<T> enumerable);
}

/// <summary>
/// Represents an identifiable asynchronous unique enumerable filter.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IIdentifiableAsyncUniqueEnumerableFilter<T> : IAsyncUniqueEnumerableFilter<T>, IIdentifiable
    where T : notnull;