using ResultAndOption.Options;

namespace Filtering.EnumerableFiltering;

/// <summary>
/// An object which can filter an enumerable to find a unique value
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IUniqueEnumerableFilter<T>  where T : notnull
{
    /// <summary>
    /// Will filter the provided enumerable and return an option either empty or the found result
    /// </summary>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    public Option<T> FilterEnumerable(IEnumerable<T> enumerable);

    /// <summary>
    /// Checks if value conforms to the unique filter.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool IsCorrect(T value);
}