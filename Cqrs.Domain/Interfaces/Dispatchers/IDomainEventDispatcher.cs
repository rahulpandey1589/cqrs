using Cqrs.Domain.Core;

namespace Cqrs.Domain.Interfaces.Dispatchers;

public interface IDomainEventDispatcher
{
    Task DispatchEventsAsync<T>(T aggregate) where T : AggregateRoot;
}