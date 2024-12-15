using Filtering.EnumerableFiltering;

namespace Filtering.QueryFiltering;

/// <summary>
/// Represents an object which can filter a query
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IQueryFilter<T> : IEnumerableFilter<T> where T : notnull
{
    /// <summary>
    /// Will filter the provided query and return the consequent <see cref="IQueryable"/>
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public IQueryable<T> Filter(IQueryable<T> query);

    IEnumerable<T> IEnumerableFilter<T>.Filter(IEnumerable<T> enumerable) => Filter(enumerable.AsQueryable());
}