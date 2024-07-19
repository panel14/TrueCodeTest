using TrueCodeTest.Infrastructure.Web.ToDoItems.Mapper;
using TrueCodeTest.Infrastructure.Web.Users.Mapper;

namespace TrueCodeTest.Api.Extensions
{
    public static class MappingServices
    {
        public static void AddMappingServices(this IServiceCollection services) 
        {
            services.AddAutoMapper(mc =>
            {
                mc.AddProfile(new ToDoItemMapperProfile());
                mc.AddProfile(new UserMapperProfile());
            });
        }
    }
}
