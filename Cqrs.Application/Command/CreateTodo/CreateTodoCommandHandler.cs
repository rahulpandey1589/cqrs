using MediatR;

namespace Cqrs.Application.Command.CreateTodo
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand>
    {
        public Task Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
