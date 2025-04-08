using AutoMapper;
using Cqrs.Application.DTOs;
using Cqrs.Application.ReadModels;
using Cqrs.Domain.Interfaces.Repositories;
using MediatR;

namespace Cqrs.Application.Queries.GetTodo
{
    internal class GetTodoQueryHandler(
        IMapper mapper,
        IDbRepository<TodoReadModel> todoDbRepository)
        : IRequestHandler<GetTodoQuery, IEnumerable<TodoDTO>>
    {
        public async Task<IEnumerable<TodoDTO>> Handle(GetTodoQuery request, CancellationToken cancellationToken)
        {
            var todoRm = await todoDbRepository.GetAllAsync();
            var todoDto = mapper.Map<List<TodoDTO>>(todoRm);
            return todoDto;
        }
    }
}
