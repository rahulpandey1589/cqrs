using AutoMapper;
using Cqrs.Application.DTOs;
using Cqrs.Application.ReadModels;
using Cqrs.Domain.Events;

namespace Cqrs.Application.Mappers
{
    public class TodoMappingProfile : Profile
    {
        public TodoMappingProfile()
        {
            CreateMap<TodoReadModel, TodoDTO>().ReverseMap();
            CreateMap<TodoReadModel, TodoCreateEvent>().ReverseMap();
        }
    }
}
