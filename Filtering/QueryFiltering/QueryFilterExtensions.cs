using ResultAndOption.Options;

namespace Filtering.QueryFiltering;

public static class QueryFilterExtensions
{
    public static IQueryable<T> Filter<T>(this IQueryable<T> query, IQueryFilter<T> filter) where T : notnull =>
        filter.Filter(query);

    public static Option<T> Filter<T>(this IQueryable<T> query, IUniqueQueryFilter<T> filter) where T : notnull =>
        filter.Filter(query);
}