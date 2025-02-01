using System.Linq.Expressions;
using ResultAndOption.Options;
using ResultAndOption.Options.Extensions;

namespace Filtering.Filterable;

internal sealed class FilterableQueryWrapper<T>(IQueryable<T> queryable) : IFilterable<T, IFilterableExecutable<T>>, IFilterableExecutable<T> where T : notnull
{
    public int Count() => queryable.Count();
    public IFilterableExecutable<T> Where(Expression<Func<T, bool>> predicate)
    {
        IQueryable<T> filtered = queryable.Where(predicate);
        return new FilterableQueryWrapper<T>(filtered);
    }

    public IFilterableExecutable<T> OrderBy<TSelected>(Expression<Func<T, TSelected>> selector)
    {
        IQueryable<T> ordered = queryable.OrderBy(selector);
        return new FilterableQueryWrapper<T>(ordered);
    }

    public IFilterableExecutable<T> OrderByDescending<TSelected>(Expression<Func<T, TSelected>> selector)
    {
        IOrderedQueryable<T> ordered = queryable.OrderByDescending(selector);
        return new FilterableQueryWrapper<T>(ordered);
    }

    public IFilterableExecutable<T> Take(int toTake)
    {
        IQueryable<T> taken = queryable.Take(toTake);
        return new FilterableQueryWrapper<T>(taken);
    }

    public IFilterableExecutable<T> Skip(int toSkip)
    {
        IQueryable<T> skipped = queryable.Skip(toSkip);
        return new FilterableQueryWrapper<T>(skipped);
    }
    public Option<T> Single(Expression<Func<T, bool>> predicate) => queryable
        .SingleOrDefault(predicate)
        .ToOption();
    
    public Option<T> First(Expression<Func<T, bool>> predicate) => queryable
        .FirstOrDefault(predicate)
        .ToOption();

    public Option<T> Last(Expression<Func<T, bool>> predicate) => queryable
        .FirstOrDefault(predicate)
        .ToOption();
    
    public IEnumerable<T> Execute() => queryable.ToList();
}