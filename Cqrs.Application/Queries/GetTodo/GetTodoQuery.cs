using Cqrs.Application.DTOs;
using MediatR;

namespace Cqrs.Application.Queries.GetTodo
{
    public class GetTodoQuery : IRequest<IEnumerable<TodoDTO>>
    {
    }
}
