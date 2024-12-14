namespace Filtering.Identification;

public sealed class StringRepresentableCollection<T>(IEnumerable<T> collection) where T : notnull
{
    public override string ToString() => $"[{string.Join(", ", collection.Select(item => item.ToString()))}]";
}