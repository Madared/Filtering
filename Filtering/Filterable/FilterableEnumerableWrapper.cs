using System.Linq.Expressions;
using ResultAndOption.Options;
using ResultAndOption.Options.Extensions;

namespace Filtering.Filterable;

internal sealed class FilterableEnumerableWrapper<T>(IEnumerable<T> enumerable) : IFilterable<T> where T : notnull
{
    private IEnumerable<T> _enumerable = enumerable;
    
    public IFilterable<T> Where(Expression<Func<T, bool>> predicate)
    {
        _enumerable = _enumerable.Where(predicate.Compile());
        return this;
    }
    public IFilterable<T> OrderBy<TSelected>(Expression<Func<T, TSelected>> selector)
    {
        _enumerable = _enumerable.OrderBy(selector.Compile());
        return this;
    }
    public IFilterable<T> OrderByDescending<TSelected>(Expression<Func<T, TSelected>> selector)
    {
        _enumerable = _enumerable.OrderByDescending(selector.Compile());
        return this;
    }
    public IFilterable<T> Take(int toTake)
    {
        _enumerable = _enumerable.Take(toTake);
        return this;
    }
    public IFilterable<T> Skip(int toSkip)
    {
        _enumerable = _enumerable.Skip(toSkip);
        return this;
    }
    public Option<T> Single(Expression<Func<T, bool>> predicate) => _enumerable
        .SingleOrDefault(predicate.Compile())
        .ToOption();
    
    public Option<T> First(Expression<Func<T, bool>> predicate) => _enumerable
        .FirstOrDefault(predicate.Compile())
        .ToOption();
    
    public List<T> Execute() => _enumerable.ToList();
}