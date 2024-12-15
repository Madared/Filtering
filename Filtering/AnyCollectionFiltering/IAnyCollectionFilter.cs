using Filtering.EnumerableFiltering;
using Filtering.QueryFiltering;

namespace Filtering.AnyCollectionFiltering;

/// <summary>
/// Applies both query filtering and enumerable filtering
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IAnyCollectionFilter<T> : IQueryFilter<T>, IEnumerableFilter<T> where T : notnull;