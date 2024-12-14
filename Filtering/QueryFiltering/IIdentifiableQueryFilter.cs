using Filtering.Identification;

namespace Filtering.QueryFiltering;

public interface IIdentifiableQueryFilter<T> : IQueryFilter<T>, IIdentifiable where T : notnull;