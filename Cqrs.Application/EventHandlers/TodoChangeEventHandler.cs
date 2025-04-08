using Cqrs.Application.ReadModels;
using Cqrs.Domain.Events;
using Cqrs.Domain.Interfaces.Repositories;
using MediatR;

namespace Cqrs.Application.EventHandlers;

public class TodoChangeEventHandler : INotificationHandler<TodoChangeEvent>
{
    private readonly IDbRepository<TodoReadModel> _readModel;

    public TodoChangeEventHandler(
        IDbRepository<TodoReadModel> readModel)
    {
        _readModel = readModel;
    }
    
    public Task Handle(TodoChangeEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}