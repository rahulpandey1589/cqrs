using Cqrs.Domain.Core;
using Cqrs.Domain.Interfaces.Dispatchers;
using MediatR;

namespace Cqrs.Infrastructure.Services;

public class DomainEventDispatcher(IPublisher mediator) : IDomainEventDispatcher
{
    private readonly IPublisher _mediator = mediator;

    public async Task DispatchEventsAsync<T>(T aggregate) where T : AggregateRoot
    {
        foreach (var domainEvent in aggregate.GetDomainEvents())
        {
            await _mediator.Publish(domainEvent);
        }

        aggregate.ClearDomainEvents();
    }
}