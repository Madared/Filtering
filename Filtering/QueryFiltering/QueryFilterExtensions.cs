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

    /// <summary>
    /// Will use the provided <see cref="IAsyncUniqueQueryFilter{T}"/> to filter the <see cref="IQueryable{T}"/> asynchronously
    /// </summary>
    /// <param name="query"></param>
    /// <param name="filter"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Task<Option<T>> Filter<T>(this IQueryable<T> query, IAsyncUniqueQueryFilter<T> filter)
        where T : notnull =>
        filter.Filter(query);

    /// <summary>
    /// Will use the provided <see cref="IUniqueQueryFilter{T}"/> to filter the Task of <see cref="IQueryable{T}"/> asynchronously
    /// </summary>
    /// <param name="asyncQuery"></param>
    /// <param name="filter"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task<Option<T>> Filter<T>(this Task<IQueryable<T>> asyncQuery, IUniqueQueryFilter<T> filter) where T : notnull
    {
        IQueryable<T> query = await asyncQuery;
        return filter.FilterQuery(query);
    }

    /// <summary>
    /// Will use the provided <see cref="IAsyncUniqueQueryFilter{T}"/> to filter the Task ok <see cref="IQueryable{T}"/> asynchronously
    /// </summary>
    /// <param name="asyncQuery"></param>
    /// <param name="filter"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task<Option<T>> Filter<T>(
        this Task<IQueryable<T>> asyncQuery,
        IAsyncUniqueQueryFilter<T> filter) where T : notnull
    {
        IQueryable<T> query = await asyncQuery;
        return await filter.Filter(query);
    }
}