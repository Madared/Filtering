using ResultAndOption.Options;

namespace Filtering.Filterable;

public interface IUniqueFilter<T> where T : notnull
{
    public Option<T> Filter(IFilterable<T> filterable);
    public bool IsCorrect(T value);
}