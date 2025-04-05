using AutoMapper;
using Cqrs.Application.DTOs;
using Cqrs.Application.ReadModels;

namespace Cqrs.Application.Mappers
{
    public class TodoMappingProfile : Profile
    {
        public TodoMappingProfile()
        {
            CreateMap<TodoReadModel, TodoDTO>().ReverseMap();
        }
    }
}
