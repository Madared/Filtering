namespace Filtering.Identification;

/// <summary>
/// A collection of objects which will be represented with their <see cref="ToString"/> method
/// </summary>
/// <param name="collection"></param>
/// <typeparam name="T"></typeparam>
public sealed class StringRepresentableCollection<T>(IEnumerable<T> collection) where T : notnull
{
    /// <inheritdoc />
    public override string ToString() => $"[{string.Join(", ", collection.Select(item => item.ToString()))}]";
}