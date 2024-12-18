namespace Filtering.EnumerableFiltering;

/// <summary>
/// An object which can filter an IEnumerable
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IEnumerableFilter<T> where T : notnull
{
    /// <summary>
    /// Will filter the provided enumerable and return the corresponding filtered enumerable
    /// </summary>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    public IEnumerable<T> FilterEnumerable(IEnumerable<T> enumerable);
}