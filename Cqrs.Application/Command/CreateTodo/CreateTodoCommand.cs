using MediatR;

namespace Cqrs.Application.Command.CreateTodo
{
    public class CreateTodoCommand(
        Guid id,
        string todoName
        ) : IRequest
    {
        public Guid Id { get; } = id;
        public string TodoName { get; } = todoName;
    }
}
