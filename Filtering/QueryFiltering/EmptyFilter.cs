using Filtering.EnumerableFiltering;
using Filtering.Identification;

namespace Filtering.QueryFiltering;

/// <summary>
/// A Filter which simply returns the original query.
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class EmptyFilter<T> : IIdentifiableQueryFilter<T>, IIdentifiableEnumerableFilter<T> where T : notnull
{
    private readonly EmptyFilterIdentifyingInformation _information = new();

    /// <inheritdoc />
    public IQueryable<T> FilterQuery(IQueryable<T> query) => query;
    
    /// <inheritdoc />
    public IEnumerable<T> FilterEnumerable(IEnumerable<T> enumerable) => enumerable;
    
    /// <inheritdoc />
        public IdentifyingInformation Information() => _information;
}