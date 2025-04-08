using MediatR;

namespace Cqrs.Application.Command.ChangeTodo;

public class ChangeTodoCommand(
    Guid id, 
    string todoName,
    bool isCompleted) : IRequest
{
    public Guid Id { get; } = id;

    public string TodoName { get; } = todoName;

    public bool IsCompleted { get; } = isCompleted;

}