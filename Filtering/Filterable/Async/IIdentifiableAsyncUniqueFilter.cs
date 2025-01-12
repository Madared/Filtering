using Filtering.Identification;

namespace Filtering.Filterable.Async;

public interface IIdentifiableAsyncUniqueFilter<T> : IAsyncUniqueFilter<T>, IIdentifiable where T : notnull;