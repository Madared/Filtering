using System.Linq.Expressions;
using ResultAndOption.Options;
using ResultAndOption.Options.Extensions;

namespace Filtering.Filterable;

internal sealed class FilterableQueryWrapper<T>(IQueryable<T> queryable) : IFilterable<T> where T : notnull
{
    private IQueryable<T> _queryable = queryable;

    public IFilterable<T> Where(Expression<Func<T, bool>> predicate)
    {
        _queryable = _queryable.Where(predicate);
        return this;
    }

    public IFilterable<T> OrderBy<TSelected>(Expression<Func<T, TSelected>> selector)
    {
        _queryable = _queryable.OrderBy(selector);
        return this;
    }

    public IFilterable<T> OrderByDescending<TSelected>(Expression<Func<T, TSelected>> selector)
    {
        _queryable = _queryable.OrderByDescending(selector);
        return this;
    }

    public IFilterable<T> Take(int toTake)
    {
        _queryable = _queryable.Take(toTake);
        return this;
    }

    public IFilterable<T> Skip(int toSkip)
    {
        _queryable = _queryable.Skip(toSkip);
        return this;
    }
    public Option<T> Single(Expression<Func<T, bool>> predicate) => _queryable
        .SingleOrDefault(predicate)
        .ToOption();
    
    public Option<T> First(Expression<Func<T, bool>> predicate) => _queryable
        .FirstOrDefault(predicate)
        .ToOption();
    
    public List<T> Execute() => _queryable.ToList();
}