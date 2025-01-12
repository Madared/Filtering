using Filtering.Identification;

namespace Filtering.Filterable;

public interface IIdentifiableFilter<T> : IFilter<T>, IIdentifiable where T : notnull;