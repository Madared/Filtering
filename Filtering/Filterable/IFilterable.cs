using System.Linq.Expressions;
using ResultAndOption.Options;

namespace Filtering.Filterable;

public interface IFilterable<T> where T : notnull
{
    public IFilterable<T> Where(Expression<Func<T, bool>> predicate);
    public IFilterable<T> OrderBy<TSelected>(Expression<Func<T, TSelected>> selector);
    public IFilterable<T> OrderByDescending<TSelected>(Expression<Func<T, TSelected>> selector);
    public IFilterable<T> Take(int toTake);
    public IFilterable<T> Skip(int toSkip);
    public Option<T> Single(Expression<Func<T, bool>> predicate);
    public Option<T> First(Expression<Func<T, bool>> predicate);
    public List<T> Execute();
}