using ResultAndOption.Options;

namespace Filtering.EnumerableFiltering;

public static class EnumerableFilterExtensions
{
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> enumerable, IEnumerableFilter<T> filter)
        where T : notnull =>
        filter.Filter(enumerable);

    public static Option<T> Filter<T>(this IEnumerable<T> enumerable, IUniqueEnumerableFilter<T> filter)
        where T : notnull =>
        filter.Filter(enumerable);
}