using ResultAndOption.Options;

namespace Filtering.QueryFiltering;

/// <summary>
/// Extensions for <see cref="IQueryable"/> filtering
/// </summary>
public static class QueryFilterExtensions
{
    /// <summary>
    /// Will use the provided query filter to filter the <see cref="IQueryable"/>
    /// </summary>
    /// <param name="query"></param>
    /// <param name="filter"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IQueryable<T> Filter<T>(this IQueryable<T> query, IQueryFilter<T> filter) where T : notnull =>
        filter.FilterQuery(query);

    /// <summary>
    /// Will use the provided query filter to filter the <see cref="IQueryable"/>
    /// </summary>
    /// <param name="query"></param>
    /// <param name="filter"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Option<T> Filter<T>(this IQueryable<T> query, IUniqueQueryFilter<T> filter) where T : notnull =>
        filter.FilterQuery(query);

    public static Task<Option<T>> Filter<T>(this IQueryable<T> query, IAsyncUniqueQueryFilter<T> filter)
        where T : notnull =>
        filter.Filter(query);

    public static async Task<Option<T>> Filter<T>(this Task<IQueryable<T>> asyncQuery, IUniqueQueryFilter<T> filter) where T : notnull
    {
        IQueryable<T> query = await asyncQuery;
        return filter.FilterQuery(query);
    }

    public static async Task<Option<T>> Filter<T>(
        this Task<IQueryable<T>> asyncQuery,
        IAsyncUniqueQueryFilter<T> filter) where T : notnull
    {
        IQueryable<T> query = await asyncQuery;
        return await filter.Filter(query);
    }
}