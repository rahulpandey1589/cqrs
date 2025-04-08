using Cqrs.Domain.Core;

namespace Cqrs.Domain.Events;

public class TodoDeleteEvent : DomainEvent
{
    public TodoDeleteEvent(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }  
}