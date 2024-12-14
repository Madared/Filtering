using Filtering.Identification;

namespace Filtering.QueryFiltering;

public interface IIdentifiableUniqueQueryFilter<T> : IUniqueQueryFilter<T>, IIdentifiable where T : notnull;