using Filtering.Identification;

namespace Filtering.EnumerableFiltering;

/// <summary>
/// A compound enumerable filter
/// </summary>
/// <param name="filters"></param>
/// <typeparam name="T"></typeparam>
public sealed class CompoundEnumerableFilter<T>(params IIdentifiableEnumerableFilter<T>[] filters) : IIdentifiableEnumerableFilter<T>
    where T : notnull
{
    /// <inheritdoc />
    public IEnumerable<T> Filter(IEnumerable<T> query) =>
        filters.Aggregate(query, (filtered, next) => next.Filter(filtered));

    /// <inheritdoc />
    public IdentifyingInformation Information() =>
        new CompoundIdentifyingInformation(filters.Select(filter => filter.Information()));
}