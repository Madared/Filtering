using System.Linq.Expressions;
using ResultAndOption.Options;

namespace Filtering.Filterable.Async;

public static class AsyncFilterableExtensions
{
    public static async Task<IAsyncFilterable<T>> Where<T>(
        this Task<IAsyncFilterable<T>> filterable,
        Expression<Func<T, bool>> expression) where T : notnull
    {
        IAsyncFilterable<T> awaited = await filterable;
        return await awaited.Where(expression);
    }

    public static async Task<IAsyncFilterable<T>> OrderBy<T, TSelected>(
        this Task<IAsyncFilterable<T>> filterable,
        Expression<Func<T, TSelected>> selector) where T : notnull where TSelected : notnull
    {
        IAsyncFilterable<T> awaited = await filterable;
        return await awaited.OrderBy(selector);
    }

    public static async Task<IAsyncFilterable<T>> OrderByDescending<T, TSelected>(
        this Task<IAsyncFilterable<T>> filterable,
        Expression<Func<T, TSelected>> selector) where T : notnull where TSelected : notnull
    {
        IAsyncFilterable<T> awaited = await filterable;
        return await awaited.OrderByDesending(selector);
    }
    public static async Task<IAsyncFilterable<T>> Take<T>(this Task<IAsyncFilterable<T>> filterable, int toTake) where T : notnull
    {
        IAsyncFilterable<T> awaited = await filterable;
        return await awaited.Take(toTake);
    }

    public static async Task<IAsyncFilterable<T>> Skip<T>(this Task<IAsyncFilterable<T>> filterable, int toSkip) where T : notnull
    {
        IAsyncFilterable<T> awaited = await filterable;
        return await awaited.Skip(toSkip);
    }

    public static async Task<Option<T>> Single<T>(this Task<IAsyncFilterable<T>> filterable, Expression<Func<T, bool>> predicate) where T : notnull
    {
        IAsyncFilterable<T> awaited = await filterable;
        return await awaited.Single(predicate);
    }

    public static async Task<Option<T>> First<T>(
        this Task<IAsyncFilterable<T>> filterable,
        Expression<Func<T, bool>> predicate) where T : notnull
    {
        IAsyncFilterable<T> awaited = await filterable;
        return await awaited.First(predicate);
    }

    public static async Task<List<T>> Execute<T>(this Task<IAsyncFilterable<T>> filterable) where T : notnull
    {
        IAsyncFilterable<T> awaited = await filterable;
        return await awaited.Execute();
    } 
}