using ResultAndOption.Options;

namespace Filtering.EnumerableFiltering;

/// <summary>
/// Extensions for filtering an <see cref="IEnumerable{T}"/>
/// </summary>
public static class EnumerableFilterExtensions
{
    /// <summary>
    /// Will use the provided filter to filter the <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <param name="enumerable"></param>
    /// <param name="filter"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> enumerable, IEnumerableFilter<T> filter)
        where T : notnull =>
        filter.Filter(enumerable);

    /// <summary>
    /// Will use the provided filter to filter the <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <param name="enumerable"></param>
    /// <param name="filter"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Option<T> Filter<T>(this IEnumerable<T> enumerable, IUniqueEnumerableFilter<T> filter)
        where T : notnull =>
        filter.Filter(enumerable);
}