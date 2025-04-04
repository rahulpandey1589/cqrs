using AutoMapper;
using Cqrs.Application.DTOs;
using Cqrs.Application.ReadModels;
using Cqrs.Domain.Interfaces.Repositories;
using MediatR;

namespace Cqrs.Application.Queries.GetTodo
{
    internal class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, IEnumerable<TodoDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IDbRepository<TodoReadModel> _todoDbRepository;


        public GetTodoQueryHandler(
            IMapper mapper,
            IDbRepository<TodoReadModel> todoDbRepository)
         {
            _todoDbRepository = todoDbRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<TodoDTO>> Handle(GetTodoQuery request, CancellationToken cancellationToken)
        {
            var todoRm = await _todoDbRepository.GetAllAsync();
            var todoDto = _mapper.Map<List<TodoDTO>>(todoRm);
            return todoDto;
        }
    }
}
