namespace Filtering.EnumerableFiltering;

public interface IEnumerableFilter<T> where T : notnull
{
    public IEnumerable<T> Filter(IEnumerable<T> enumerable);
}