using MediatR;
using Cqrs.Infrastructure.Repositories;
using Cqrs.Domain.Interfaces.Dispatchers;
using Cqrs.Domain.Aggregates.TodoAggregates;

namespace Cqrs.Application.Command.DeleteTodo;

public class DeleteTodoCommandHandler(IEventStoreRepository eventStoreRepository,
    IDomainEventDispatcher domainEventDispatcher) : IRequestHandler<DeleteTodoCommand>
{
    
    
    
    public async Task Handle(
        DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await eventStoreRepository.LoadAsync<Todo>(request.Id);
        
        todo.Delete();

        await eventStoreRepository.SaveAsync(todo);
        
        await domainEventDispatcher.DispatchEventsAsync(todo);
    }
}