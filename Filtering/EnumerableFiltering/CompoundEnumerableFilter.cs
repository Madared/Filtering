using Filtering.Identification;

namespace Filtering.EnumerableFiltering;

internal sealed class CompoundEnumerableFilter<T>(params IIdentifiableEnumerableFilter<T>[] filters) : IIdentifiableEnumerableFilter<T>
    where T : notnull
{
    public IEnumerable<T> Filter(IEnumerable<T> query) =>
        filters.Aggregate(query, (filtered, next) => next.Filter(filtered));

    public IdentifyingInformation Information() =>
        new CompoundIdentifyingInformation(filters.Select(filter => filter.Information()));
}