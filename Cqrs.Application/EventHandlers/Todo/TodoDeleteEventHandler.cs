using MediatR;
using Cqrs.Domain.Events;
using Cqrs.Application.ReadModels;
using Cqrs.Domain.Interfaces.Repositories;

namespace Cqrs.Application.EventHandlers.Todo;

public class TodoDeleteEventHandler(IDbRepository<TodoReadModel> dbRepository)
    : INotificationHandler<TodoDeleteEvent>
{
    public async Task Handle(
        TodoDeleteEvent notification,
        CancellationToken cancellationToken)
    {
        var todoDetails = await dbRepository.GetByIdAsync(notification.Id);

        if (todoDetails == null)
            throw new Exception($"Todo with Id {todoDetails.Id} doesn't exist");
        
        await dbRepository.DeleteAsync(notification.Id);
    }
}