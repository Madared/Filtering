using Filtering.Identification;

namespace Filtering.QueryFiltering;

internal sealed class CompoundQueryFilter<T>(params IIdentifiableQueryFilter<T>[] filters) : IIdentifiableQueryFilter<T>
    where T : notnull
{
    public IQueryable<T> Filter(IQueryable<T> query) =>
        filters.Aggregate(query, (filtered, next) => next.Filter(filtered));

    public IdentifyingInformation Information() =>
        new CompoundIdentifyingInformation(filters.Select(filter => filter.Information()));
}