using Cqrs.Domain.Core;

namespace Cqrs.Domain.Events;

public class TodoChangeEvent(Guid id, string todoName, bool isCompleted) : DomainEvent
{
    public Guid Id { get; set; } = id;
    public string TodoName { get; set; } = todoName;
    public bool IsCompleted { get; set; } = isCompleted;
}