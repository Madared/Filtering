using Filtering.Identification;
using ResultAndOption.Options;

namespace Filtering.QueryFiltering;

public interface IAsyncUniqueQueryFilter<T> where T : notnull
{
    public Task<Option<T>> Filter(IQueryable<T> query);
}

public interface IIdentifiableAsyncUniqueQueryFilter<T> : IAsyncUniqueQueryFilter<T>, IIdentifiable where T : notnull;