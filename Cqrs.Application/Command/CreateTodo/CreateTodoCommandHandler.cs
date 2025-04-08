using Cqrs.Application.ReadModels;
using Cqrs.Domain.Aggregates.TodoAggregates;
using Cqrs.Domain.Interfaces.Dispatchers;
using Cqrs.Domain.Interfaces.Repositories;
using Cqrs.Infrastructure.Repositories;
using MediatR;

namespace Cqrs.Application.Command.CreateTodo
{
    public class CreateTodoCommandHandler(
        IDomainEventDispatcher domainEventDispatcher,
        IEventStoreRepository eventStoreRepository)
        : IRequestHandler<CreateTodoCommand>
    {
        public async Task Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = new Todo(request.Id, request.TodoName, false);
         
            await eventStoreRepository.SaveAsync(todo);
            await domainEventDispatcher.DispatchEventsAsync(todo);
        }
    }
}
