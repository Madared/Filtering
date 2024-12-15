using Filtering.Identification;

namespace Filtering.EnumerableFiltering;

/// <summary>
/// An enumerable filter which simply returns the original enumerable.
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class EmptyEnumerableFilter<T> : IIdentifiableEnumerableFilter<T> where T : notnull
{
    private readonly EmptyEnumerableFilterInformation _information = new ();

    /// <inheritdoc />
    public IEnumerable<T> Filter(IEnumerable<T> enumerable) => enumerable;

    /// <inheritdoc />
    public IdentifyingInformation Information() => _information;
}