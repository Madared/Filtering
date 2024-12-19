using Filtering.Identification;
using ResultAndOption.Options;

namespace Filtering.EnumerableFiltering;

public interface IAsyncUniqueEnumerableFilter<T> where T : notnull
{
    Task<Option<T>> Filter(IEnumerable<T> enumerable);
}

public interface IIdentifiableAsyncUniqueEnumerableFilter<T> : IAsyncUniqueEnumerableFilter<T>, IIdentifiable
    where T : notnull;