using Filtering.Identification;
using ResultAndOption;
using ResultAndOption.Options;

namespace Filtering.EnumerableFiltering;

/// <summary>
/// A compound unique enumerable filter
/// </summary>
/// <param name="filters"></param>
/// <typeparam name="T"></typeparam>
public sealed class CompoundUniqueEnumerableFilter<T>(params IIdentifiableUniqueEnumerableFilter<T>[] filters)
    : IIdentifiableUniqueEnumerableFilter<T>
    where T : notnull
{
    /// <inheritdoc />
    public Option<T> FilterEnumerable(IEnumerable<T> query)
    {
        Option<T> firstFilter = filters.Length == 0
            ? Option<T>.None()
            : filters[0].FilterEnumerable(query);
        bool isCorrect = firstFilter.IsSome() && IsCorrect(firstFilter.Data);
        return isCorrect ? firstFilter : Option<T>.None();
    }

    /// <inheritdoc />
    public bool IsCorrect(T data) => filters.All(filter => filter.IsCorrect(data));

    /// <inheritdoc />
    public IdentifyingInformation Information() => filters
        .Select(filter => filter.Information())
        .Pipe(infos => new CompoundIdentifyingInformation(infos));
}