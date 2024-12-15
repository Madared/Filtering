using Filtering.Identification;

namespace Filtering.QueryFiltering;

/// <summary>
/// A query filter that can be identified
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IIdentifiableQueryFilter<T> : IQueryFilter<T>, IIdentifiable where T : notnull;