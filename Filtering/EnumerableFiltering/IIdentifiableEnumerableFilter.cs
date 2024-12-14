using Filtering.Identification;

namespace Filtering.EnumerableFiltering;

public interface IIdentifiableEnumerableFilter<T> : IEnumerableFilter<T>, IIdentifiable where T : notnull;