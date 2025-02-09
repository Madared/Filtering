using Filtering.Identification;
using ResultAndOption;
using ResultAndOption.Options;

namespace Filtering.QueryFiltering;

/// <summary>
/// A Compound unique query filter
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class CompoundUniqueQueryFilter<T> : IIdentifiableUniqueQueryFilter<T>
    where T : notnull
{
    private readonly IIdentifiableUniqueQueryFilter<T>[] _filters;

    /// <summary>
    /// A Compound unique query filter constructor using params
    /// </summary>
    /// <param name="filters"></param>
    /// <typeparam name="T"></typeparam>
    public CompoundUniqueQueryFilter(params IIdentifiableUniqueQueryFilter<T>[] filters)
    {
        _filters = filters;
    }

    /// <summary>
    /// A Compound unique query filter constructor using an <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <param name="filters"></param>
    public CompoundUniqueQueryFilter(IEnumerable<IIdentifiableUniqueQueryFilter<T>> filters)
    {
        _filters = filters.ToArray();
    }

    /// <inheritdoc />
    public Option<T> FilterQuery(IQueryable<T> query)
    {
        Option<T> firstFilter = _filters.Length == 0
            ? Option<T>.None()
            : _filters[0].FilterQuery(query);
        bool isCorrect = firstFilter.IsSome() && IsCorrect(firstFilter.Data);
        return isCorrect ? firstFilter : Option<T>.None();
    }

    /// <inheritdoc />
    public bool IsCorrect(T data) => _filters.All(filter => filter.IsCorrect(data));

    /// <inheritdoc />
    public IdentifyingInformation Information() => _filters
        .Select(filter => filter.Information())
        .Pipe(infos => new CompoundIdentifyingInformation(infos));
}