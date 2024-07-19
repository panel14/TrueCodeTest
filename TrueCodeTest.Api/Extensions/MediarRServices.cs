using TrueCodeTest.Application.Commands.ToDoItems;
using TrueCodeTest.Application.CommandsHandlers.ToDoItems;

namespace TrueCodeTest.Api.Extensions
{
    public static class MediarRServices
    {
        public static void AddMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(AddToDoItemCommandHandler).Assembly);
            });
        }
    }
}
