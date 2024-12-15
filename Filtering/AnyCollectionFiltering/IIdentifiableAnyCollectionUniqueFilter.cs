using Filtering.EnumerableFiltering;
using Filtering.QueryFiltering;

namespace Filtering.AnyCollectionFiltering;

/// <summary>
/// Applies both identifiable unique query filtering and identifiable unique enumerable filtering
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IIdentifiableAnyCollectionUniqueFilter<T> : IAnyCollectionUniqueFilter<T>, IIdentifiableUniqueQueryFilter<T>, IIdentifiableUniqueEnumerableFilter<T> where T : notnull;