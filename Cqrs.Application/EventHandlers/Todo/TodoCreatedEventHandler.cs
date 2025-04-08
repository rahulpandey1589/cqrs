using AutoMapper;
using Cqrs.Application.ReadModels;
using Cqrs.Domain.Events;
using Cqrs.Domain.Interfaces.Repositories;
using MediatR;

namespace Cqrs.Application.EventHandlers.Todo;

public class TodoCreatedEventHandler(
    IDbRepository<TodoReadModel> todoRepository,
    IMapper mapper) : INotificationHandler<TodoCreateEvent>
{
    
    public async Task Handle(TodoCreateEvent notification, CancellationToken cancellationToken)
    { 
        var todoDto = mapper.Map<TodoReadModel>(notification);
        await todoRepository.InsertAsync(todoDto);
    }
}