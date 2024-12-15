using Filtering.EnumerableFiltering;
using Filtering.QueryFiltering;

namespace Filtering.AnyCollectionFiltering;

/// <summary>
/// Applies both unique query filtering and unique enumerable filtering
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IAnyCollectionUniqueFilter<T> : IUniqueQueryFilter<T>, IUniqueEnumerableFilter<T> where T : notnull;