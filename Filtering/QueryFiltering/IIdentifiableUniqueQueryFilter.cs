using Filtering.Identification;

namespace Filtering.QueryFiltering;

/// <summary>
/// A Unique filter that can be identified
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IIdentifiableUniqueQueryFilter<T> : IUniqueQueryFilter<T>, IIdentifiable where T : notnull;