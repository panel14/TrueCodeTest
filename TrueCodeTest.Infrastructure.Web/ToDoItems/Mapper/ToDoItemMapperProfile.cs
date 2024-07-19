using AutoMapper;
using TrueCodeTest.Application.Commands.ToDoItems;
using TrueCodeTest.Infrastructure.Web.Base.Mapper;
using TrueCodeTest.Infrastructure.Web.ToDoItems.InputModels;

namespace TrueCodeTest.Infrastructure.Web.ToDoItems.Mapper
{
    public class ToDoItemMapperProfile : Profile
    {
        public ToDoItemMapperProfile() 
        {
            CreateMap<AddToDoItemInputModel, AddToDoItemCommand>();
            CreateMap<UpdateToDoItemInputModel, UpdateToDoItemCommand>().MapId();
        }
    }
}
