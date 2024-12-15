using Filtering.Identification;

namespace Filtering.EnumerableFiltering;

/// <summary>
/// An enumerable filter which can be identified
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IIdentifiableEnumerableFilter<T> : IEnumerableFilter<T>, IIdentifiable where T : notnull;