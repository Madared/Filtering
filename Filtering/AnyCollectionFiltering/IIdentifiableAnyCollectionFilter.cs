using Filtering.EnumerableFiltering;
using Filtering.QueryFiltering;

namespace Filtering.AnyCollectionFiltering;

/// <summary>
/// applies both identifiable query filtering and identifiable enumerable filtering
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IIdentifiableAnyCollectionFilter<T> : IAnyCollectionFilter<T>, IIdentifiableQueryFilter<T>, IIdentifiableEnumerableFilter<T> where T : notnull;