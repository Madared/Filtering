using Filtering.Identification;

namespace Filtering.QueryFiltering;

/// <summary>
/// A Filter which simply returns the original query.
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class EmptyQueryFilter<T> : IIdentifiableQueryFilter<T> where T : notnull
{
    private readonly EmptyQueryFilterIdentifyingInformation _information = new();

    /// <inheritdoc />
    public IQueryable<T> Filter(IQueryable<T> query) => query;

    /// <inheritdoc />
    public IdentifyingInformation Information() => _information;
}