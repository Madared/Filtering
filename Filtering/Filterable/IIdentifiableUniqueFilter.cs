using Filtering.Identification;

namespace Filtering.Filterable;

public interface IIdentifiableUniqueFilter<T> : IUniqueFilter<T>, IIdentifiable where T : notnull;