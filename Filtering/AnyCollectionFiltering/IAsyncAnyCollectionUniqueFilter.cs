using Filtering.EnumerableFiltering;
using Filtering.Identification;
using Filtering.QueryFiltering;

namespace Filtering.AnyCollectionFiltering;

public interface IAsyncAnyCollectionUniqueFilter<T> : IAsyncUniqueQueryFilter<T>, IAsyncUniqueEnumerableFilter<T>
    where T : notnull;

public interface IIdentifiableAsyncAnyCollectionUniqueFilter<T> : IAsyncAnyCollectionUniqueFilter<T>,
    IIdentifiableAsyncUniqueEnumerableFilter<T>, IIdentifiableAsyncUniqueQueryFilter<T> where T : notnull;