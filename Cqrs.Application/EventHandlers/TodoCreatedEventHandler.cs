using AutoMapper;
using Cqrs.Application.ReadModels;
using Cqrs.Domain.Events;
using Cqrs.Domain.Interfaces.Repositories;
using MediatR;

namespace Cqrs.Application.EventHandlers;

public class TodoCreatedEventHandler(
    IDbRepository<TodoReadModel> todoRepository,
    IMapper mapper): INotificationHandler<TodoCreateEvent>
{
    private readonly IMapper _mapper = mapper;
    private readonly IDbRepository<TodoReadModel> _todoRepository = todoRepository;


    public async Task Handle(TodoCreateEvent notification, CancellationToken cancellationToken)
    {
        var todoDto = _mapper.Map<TodoReadModel>(notification);
        await _todoRepository.InsertAsync(todoDto);
}
}