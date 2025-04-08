using Cqrs.Domain.Aggregates.TodoAggregates;
using Cqrs.Domain.Interfaces.Dispatchers;
using Cqrs.Infrastructure.Repositories;
using MediatR;

namespace Cqrs.Application.Command.ChangeTodo;

public class ChangeTodoCommandHandler(
    IEventStoreRepository eventStoreRepository,
    IDomainEventDispatcher dispatcher) : IRequestHandler<ChangeTodoCommand>
{
    public async Task Handle(
        ChangeTodoCommand request, 
        CancellationToken cancellationToken)
    {
        var todo = await eventStoreRepository.LoadAsync<Todo>(request.Id);
        
        todo.Change(request.TodoName, request.IsCompleted);

        await eventStoreRepository.SaveAsync(todo);
        
        await dispatcher.DispatchEventsAsync(todo);
    }
}