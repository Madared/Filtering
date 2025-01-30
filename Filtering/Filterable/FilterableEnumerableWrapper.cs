using System.Collections;
using System.Linq.Expressions;
using ResultAndOption.Options;
using ResultAndOption.Options.Extensions;

namespace Filtering.Filterable;

internal sealed class FilterableEnumerableWrapper<T>(IEnumerable<T> enumerable) : IFilterable<T> where T : notnull
{
    private IEnumerable<T> _enumerable = enumerable;

    public int Count() => _enumerable.Count();
    public IFilterable<T> Where(Expression<Func<T, bool>> predicate)
    {
        IEnumerable<T> filtered = _enumerable.Where(predicate.Compile());
        return new FilterableEnumerableWrapper<T>(filtered);
    }
    public IFilterable<T> OrderBy<TSelected>(Expression<Func<T, TSelected>> selector)
    {
        IEnumerable<T> ordered = _enumerable.OrderBy(selector.Compile());
        return new FilterableEnumerableWrapper<T>(ordered);
    }
    public IFilterable<T> OrderByDescending<TSelected>(Expression<Func<T, TSelected>> selector)
    {
        IEnumerable<T> ordered = _enumerable.OrderByDescending(selector.Compile());
        return new FilterableEnumerableWrapper<T>(ordered);
    }
    public IFilterable<T> Take(int toTake)
    {
        IEnumerable<T> taken = _enumerable.Take(toTake);
        return new FilterableEnumerableWrapper<T>(taken);
    }
    public IFilterable<T> Skip(int toSkip)
    {
        IEnumerable<T> skipped = _enumerable.Skip(toSkip);
        return new FilterableEnumerableWrapper<T>(skipped);
    }
    public Option<T> Single(Expression<Func<T, bool>> predicate) => _enumerable
        .SingleOrDefault(predicate.Compile())
        .ToOption();
    
    public Option<T> First(Expression<Func<T, bool>> predicate) => _enumerable
        .FirstOrDefault(predicate.Compile())
        .ToOption();
    
    public List<T> Execute() => _enumerable.ToList();
}