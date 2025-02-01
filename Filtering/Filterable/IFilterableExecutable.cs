using System.Linq.Expressions;
using ResultAndOption.Options;

namespace Filtering.Filterable;

public interface IFilterableExecutable<T> : IFilterable<T, IFilterableExecutable<T>> where T : notnull
{
    public int Count();
    public Option<T> First(Expression<Func<T, bool>> predicate);
    public Option<T> Last(Expression<Func<T, bool>> predicate);
    public Option<T> Single(Expression<Func<T, bool>> predicate);
    public IEnumerable<T> Execute();
}