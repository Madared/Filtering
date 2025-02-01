using System.Linq.Expressions;

namespace Filtering.Filterable;

public interface IFilterable<T, out TFilterableType>
    where T : notnull where TFilterableType : IFilterable<T, TFilterableType>
{
    public TFilterableType Where(Expression<Func<T, bool>> predicate);
    public TFilterableType OrderBy<TSelected>(Expression<Func<T, TSelected>> selector);
    public TFilterableType OrderByDescending<TSelected>(Expression<Func<T, TSelected>> selector);
    public TFilterableType Take(int toTake);
    public TFilterableType Skip(int toSkip);
}