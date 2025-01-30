using System.Linq.Expressions;
using ResultAndOption.Options;
using ResultAndOption.Options.Extensions;

namespace Filtering.Filterable;

internal sealed class FilterableQueryWrapper<T>(IQueryable<T> queryable) : IFilterable<T> where T : notnull
{
    private IQueryable<T> _queryable = queryable;

    public int Count() => _queryable.Count();
    public IFilterable<T> Where(Expression<Func<T, bool>> predicate)
    {
        IQueryable<T> filtered = _queryable.Where(predicate);
        return new FilterableQueryWrapper<T>(filtered);
    }

    public IFilterable<T> OrderBy<TSelected>(Expression<Func<T, TSelected>> selector)
    {
        IQueryable<T> ordered = _queryable.OrderBy(selector);
        return new FilterableQueryWrapper<T>(ordered);
    }

    public IFilterable<T> OrderByDescending<TSelected>(Expression<Func<T, TSelected>> selector)
    {
        IOrderedQueryable<T> ordered = _queryable.OrderByDescending(selector);
        return new FilterableQueryWrapper<T>(ordered);
    }

    public IFilterable<T> Take(int toTake)
    {
        IQueryable<T> taken = _queryable.Take(toTake);
        return new FilterableQueryWrapper<T>(taken);
    }

    public IFilterable<T> Skip(int toSkip)
    {
        IQueryable<T> skipped = _queryable.Skip(toSkip);
        return new FilterableQueryWrapper<T>(skipped);
    }
    public Option<T> Single(Expression<Func<T, bool>> predicate) => _queryable
        .SingleOrDefault(predicate)
        .ToOption();
    
    public Option<T> First(Expression<Func<T, bool>> predicate) => _queryable
        .FirstOrDefault(predicate)
        .ToOption();
    
    public List<T> Execute() => _queryable.ToList();
}