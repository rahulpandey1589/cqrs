using Cqrs.Application.ReadModels;
using Cqrs.Domain.Interfaces.Repositories;
using MediatR;

namespace Cqrs.Application.Command.CreateTodo
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand>
    {
        private readonly IDbRepository<TodoReadModel> dbRepository;

        public CreateTodoCommandHandler(IDbRepository<TodoReadModel> dbRepository)
        {
            this.dbRepository = dbRepository;
        }

        public Task Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {

            this.dbRepository.InsertAsync(new TodoReadModel()
            {
                TodoName = request.TodoName
            });

           

            throw new NotImplementedException();
        }
    }
}
