using AutoMapper;
using TrueCodeTest.Application.Commands.Users;
using TrueCodeTest.Infrastructure.Web.Base.Mapper;
using TrueCodeTest.Infrastructure.Web.Users.InputModels;

namespace TrueCodeTest.Infrastructure.Web.Users.Mapper
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile() 
        {
            CreateMap<AddUserInputModel, AddUserCommand>();
            CreateMap<UpdateUserInputModel, UpdateUserCommand>().MapId();
        }
    }
}
