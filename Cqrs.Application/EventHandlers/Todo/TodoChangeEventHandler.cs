using MediatR;
using Cqrs.Domain.Events;
using Cqrs.Application.ReadModels;
using Cqrs.Domain.Interfaces.Repositories;

namespace Cqrs.Application.EventHandlers.Todo;

public class TodoChangeEventHandler(IDbRepository<TodoReadModel> dbRepository) 
    : INotificationHandler<TodoChangeEvent>
{
    public async Task Handle(TodoChangeEvent notification, CancellationToken cancellationToken)
    {
        var current = await dbRepository.GetByIdAsync(notification.Id);

        if (current != null)
        {
            current.TodoName = notification.TodoName;
            current.IsCompleted = notification.IsCompleted; 
            
            dbRepository.UpdateAsync(notification.Id, current);
        }
    }
}