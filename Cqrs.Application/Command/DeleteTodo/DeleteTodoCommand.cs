using MediatR;

namespace Cqrs.Application.Command.DeleteTodo;

public class DeleteTodoCommand(Guid id) : IRequest
{
    public Guid Id { get; } = id;
}