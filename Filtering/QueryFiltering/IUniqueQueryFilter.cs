using Filtering.EnumerableFiltering;
using ResultAndOption.Options;

namespace Filtering.QueryFiltering;

public interface IUniqueQueryFilter<T> : IUniqueEnumerableFilter<T> where T : notnull
{
    public Option<T> Filter(IQueryable<T> query);
    Option<T> IUniqueEnumerableFilter<T>.Filter(IEnumerable<T> enumerable) => Filter(enumerable.AsQueryable());
}