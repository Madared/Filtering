using Filtering.EnumerableFiltering;
using Filtering.Identification;
using Filtering.QueryFiltering;

namespace Filtering.AnyCollectionFiltering;

/// <summary>
/// Represents a unique asynchronous filter for any collection
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IAsyncAnyCollectionUniqueFilter<T> : IAsyncUniqueQueryFilter<T>, IAsyncUniqueEnumerableFilter<T>
    where T : notnull;

/// <summary>
/// Represents an identifiable unique asynchronous filter for any collection.
/// </summary
/// <typeparam name="T"></typeparam>
public interface IIdentifiableAsyncAnyCollectionUniqueFilter<T> : IAsyncAnyCollectionUniqueFilter<T>,
    IIdentifiableAsyncUniqueEnumerableFilter<T>, IIdentifiableAsyncUniqueQueryFilter<T> where T : notnull;