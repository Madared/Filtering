using Filtering.EnumerableFiltering;
using ResultAndOption.Options;

namespace Filtering.QueryFiltering;

/// <summary>
/// Represents an object which can find a unique value (or nothing) in a query
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IUniqueQueryFilter<T> : IEquatable<T> where T : notnull
{
    /// <summary>
    /// Will filter the provided query and return an option either empty or the found result
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public Option<T> FilterQuery(IQueryable<T> query);
}