using Cqrs.Domain.Core;

namespace Cqrs.Domain.Events;

public class TodoCreateEvent : DomainEvent
{
    public TodoCreateEvent(Guid id, string todoName,bool isCompleted)
    {
        Id = id;
        TodoName = todoName;
        IsCompleted = isCompleted;
    }

    public Guid Id { get; set; }
    public string TodoName { get; set; }
    public bool IsCompleted { get; set; }   
}