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
    public Option<T> Filter(IEnumerable<T> query)
    {
        Option<T> firstFilter = filters.Length == 0
            ? Option<T>.None()
            : filters[0].Filter(query);
        bool isCorrect = firstFilter.IsSome() &&
                         filters.Select(filter => filter.IsCorrectValue(firstFilter.Data)).All(correct => correct);
        return isCorrect ? firstFilter : Option<T>.None();
    }

    /// <inheritdoc />
    public bool IsCorrectValue(T data) => filters.All(filter => filter.IsCorrectValue(data));

    /// <inheritdoc />
    public IdentifyingInformation Information() => filters
        .Select(filter => filter.Information())
        .Pipe(infos => new CompoundIdentifyingInformation(infos));
}