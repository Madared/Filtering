using Filtering.Identification;

namespace Filtering.QueryFiltering;

/// <summary>
/// A compound query filter
/// </summary>
/// <param name="filters"></param>
/// <typeparam name="T"></typeparam>
public sealed class CompoundQueryFilter<T>(params IIdentifiableQueryFilter<T>[] filters) : IIdentifiableQueryFilter<T>
    where T : notnull
{
    /// <inheritdoc />
    public IQueryable<T> Filter(IQueryable<T> query) =>
        filters.Aggregate(query, (filtered, next) => next.Filter(filtered));

    /// <inheritdoc />
    public IdentifyingInformation Information() =>
        new CompoundIdentifyingInformation(filters.Select(filter => filter.Information()));
}