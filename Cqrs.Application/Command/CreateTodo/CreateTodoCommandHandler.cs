using Cqrs.Application.ReadModels;
using Cqrs.Domain.Aggregates.TodoAggregates;
using Cqrs.Domain.Interfaces.Dispatchers;
using Cqrs.Domain.Interfaces.Repositories;
using Cqrs.Infrastructure.Repositories;
using MediatR;

namespace Cqrs.Application.Command.CreateTodo
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand>
    {
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        private readonly IEventStoreRepository _eventStoreRepository;

        public CreateTodoCommandHandler(
            IDomainEventDispatcher domainEventDispatcher, 
            IEventStoreRepository eventStoreRepository)
        {
            _domainEventDispatcher = domainEventDispatcher;
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = new Todo(request.Id, request.TodoName, false);
         
            await _eventStoreRepository.SaveAsync(todo);
            await _domainEventDispatcher.DispatchEventsAsync(todo);
        }
    }
}
