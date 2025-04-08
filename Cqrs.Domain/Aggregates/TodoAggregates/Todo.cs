using Cqrs.Domain.Core;
using Cqrs.Domain.Events;

namespace Cqrs.Domain.Aggregates.TodoAggregates;

public class Todo : AggregateRoot
{

    public string TodoName { get; set; } = default!;
    public bool IsCompleted { get; set; }


    public Todo()
    {
        
    }

    public Todo(Guid id, string todoName, bool isCompleted)
    {
        ApplyChange(new TodoCreateEvent(id, todoName, isCompleted));
    }

    public void Change(string todoName, bool isCompleted)
    {
        ApplyChange(new TodoChangeEvent(Id, todoName, isCompleted));
    }

    public void Delete()
    {
        ApplyChange(new TodoDeleteEvent(Id));
    }


    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case TodoCreateEvent e:
                Id = e.Id;
                TodoName = e.TodoName;
                IsCompleted = e.IsCompleted;
                break;
            
            case TodoChangeEvent e:
                Id = e.Id;
                TodoName = e.TodoName;
                IsCompleted = e.IsCompleted;
                break;
            
            case TodoDeleteEvent e:
                Id = e.Id;
                break;
           
        }
    }
}