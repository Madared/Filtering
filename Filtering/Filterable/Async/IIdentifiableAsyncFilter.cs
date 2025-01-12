using Filtering.Identification;

namespace Filtering.Filterable.Async;

public interface IIdentifiableAsyncFilter<T> : IAsyncFilter<T>, IIdentifiable where T : notnull;