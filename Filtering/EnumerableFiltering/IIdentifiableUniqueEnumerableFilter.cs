using Filtering.Identification;

namespace Filtering.EnumerableFiltering;

public interface IIdentifiableUniqueEnumerableFilter<T> : IUniqueEnumerableFilter<T>, IIdentifiable where T : notnull;