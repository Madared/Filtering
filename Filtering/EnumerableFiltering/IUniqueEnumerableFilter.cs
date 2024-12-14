using ResultAndOption.Options;

namespace Filtering.EnumerableFiltering;

public interface IUniqueEnumerableFilter<T> where T : notnull
{
    public Option<T> Filter(IEnumerable<T> enumerable);
    public bool IsCorrectValue(T value);
}