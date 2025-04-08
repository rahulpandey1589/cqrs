using MediatR;
using Cqrs.Application.DTOs;

namespace Cqrs.Application.Queries.GetTodo
{
    public class GetTodoQuery : IRequest<IEnumerable<TodoDTO>>
    {
    }
}
