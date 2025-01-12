using Filtering.Filterable.Async;
using ResultAndOption.Options;

namespace Filtering.Filterable;

public static class FilterableExtensions
{
    public static IFilterable<T> Filter<T>(this IFilterable<T> filterable, IFilter<T> filter) where T : notnull =>
        filter.Filter(filterable);

    public static Option<T> Filter<T>(this IFilterable<T> filterable, IUniqueFilter<T> filter) where T : notnull =>
        filter.Filter(filterable);

    public static IFilterable<T> AsFilterable<T>(this IEnumerable<T> enumerable) where T : notnull =>
        new FilterableEnumerableWrapper<T>(enumerable);

    public static IFilterable<T> AsFilterable<T>(this IQueryable<T> queryable) where T : notnull =>
        new FilterableQueryWrapper<T>(queryable);

    public static Task<IAsyncFilterable<T>> Filter<T>(this IAsyncFilterable<T> filterable, IAsyncFilter<T> filter)
        where T : notnull => filter.Filter(filterable);

    public static Task<Option<T>> Filter<T>(this IAsyncFilterable<T> filterable, IAsyncUniqueFilter<T> filter)
        where T : notnull => filter.Filter(filterable);
}