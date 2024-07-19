using Microsoft.EntityFrameworkCore;
using TrueCodeTest.Domain.Models;
using TrueCodeTest.Infrastructure.Configuration;

namespace TrueCodeTest.Infrastructure.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<ToDoItem> ToDoItems { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Priority> Priorities { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PriorityConfiguration());
            modelBuilder.ApplyConfiguration(new ToDoItemConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
