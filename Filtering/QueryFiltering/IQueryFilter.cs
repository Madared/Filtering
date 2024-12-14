using Filtering.EnumerableFiltering;

namespace Filtering.QueryFiltering;

public interface IQueryFilter<T> : IEnumerableFilter<T> where T : notnull
{
    public IQueryable<T> Filter(IQueryable<T> query);

    IEnumerable<T> IEnumerableFilter<T>.Filter(IEnumerable<T> enumerable) => Filter(enumerable.AsQueryable());
}