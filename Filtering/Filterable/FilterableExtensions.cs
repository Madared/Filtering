using Filtering.Filterable.Async;
using ResultAndOption.Options;

namespace Filtering.Filterable;

public static class FilterableExtensions
{
    public static IFilterable<T, TFilterable> Filter<T, TFilterable>(this IFilterable<T, TFilterable> filterable, IFilter<T> filter) where T : notnull where TFilterable : IFilterable<T, TFilterable> =>
        filter.Filter(filterable);

    public static Option<T> Filter<T>(this IFilterableExecutable<T> filterable, IUniqueFilter<T> filter) where T : notnull =>
        filter.Filter(filterable);

    public static IFilterableExecutable<T> AsFilterable<T, TFilterable>(this IEnumerable<T> enumerable) where T : notnull =>
        new FilterableEnumerableWrapper<T>(enumerable);

    public static IFilterableExecutable<T> AsFilterable<T>(this IQueryable<T> queryable) where T : notnull =>
        new FilterableQueryWrapper<T>(queryable);
    
    public static Task<Option<T>> Filter<T>(this IAsyncFilterableExecutable<T> filterable, IAsyncUniqueFilter<T> filter)
        where T : notnull => filter.Filter(filterable);
}