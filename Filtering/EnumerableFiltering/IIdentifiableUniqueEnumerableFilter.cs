using Filtering.Identification;

namespace Filtering.EnumerableFiltering;

/// <summary>
/// A unique enumerable filter which can be identified
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IIdentifiableUniqueEnumerableFilter<T> : IUniqueEnumerableFilter<T>, IIdentifiable where T : notnull;