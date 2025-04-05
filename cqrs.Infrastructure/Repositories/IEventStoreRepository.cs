using Cqrs.Domain.Core;

namespace Cqrs.Infrastructure.Repositories;

public interface IEventStoreRepository
{
    Task<T> LoadAsync<T>(Guid aggregateId) where T : AggregateRoot, new();
    Task SaveAsync<T>(T aggregate) where T : AggregateRoot, new();
}