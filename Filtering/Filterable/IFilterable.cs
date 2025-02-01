using System.Linq.Expressions;
using ResultAndOption.Options;
using ResultAndOption.Results;

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

public interface IFilter2<T> where T : notnull
{
    public TFilterable Filter<TFilterable>(IFilterable<T, TFilterable> filterable)
        where TFilterable : IFilterable<T, TFilterable>;
}

public interface IFilterableExecutable<T> : IFilterable<T, IFilterableExecutable<T>> where T : notnull
{
    public int Count();
    public Option<T> First(Expression<Func<T, bool>> predicate);
    public Option<T> Last(Expression<Func<T, bool>> predicate);
    public Option<T> Single(Expression<Func<T, bool>> predicate);
    public IEnumerable<T> Execute();
}

public interface IAsyncFilterableExecutable<T> : IFilterable<T, IFilterableExecutable<T>> where T : notnull
{
    public Task<int> Count();
    public Task<Option<T>> First<TSelected>(Expression<Func<T, TSelected>> selector);
    public Task<Option<T>> Last<TSelected>(Expression<Func<T, TSelected>> selector);
    public Task<Result<T>> Single<TSelected>(Expression<Func<T, TSelected>> selector);
    public IAsyncEnumerable<T> ExecuteToAsync();
    public Task<IEnumerable<T>> Execute();
}