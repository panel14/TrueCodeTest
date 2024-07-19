using Microsoft.EntityFrameworkCore;
using TrueCodeTest.Domain.Interfaces;
using TrueCodeTest.Infrastructure.Context;
using TrueCodeTest.Infrastructure.Repositories;

namespace TrueCodeTest.Api.Extensions
{
    public static class StorageServices
    {
        public static void AddStorageServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
