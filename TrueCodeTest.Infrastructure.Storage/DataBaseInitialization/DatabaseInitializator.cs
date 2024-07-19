using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrueCodeTest.Infrastructure.Context;

namespace TrueCodeTest.Infrastructure.DataBaseInitialization
{
    public static class DatabaseInitializator
    {
        public static async Task InitAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            await context.Database.MigrateAsync();
        }
    }
}
