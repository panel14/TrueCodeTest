using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrueCodeTest.Domain.Models;

namespace TrueCodeTest.Infrastructure.Configuration
{
    public class PriorityConfiguration : IEntityTypeConfiguration<Priority>
    {
        public void Configure(EntityTypeBuilder<Priority> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasIndex(x => x.Level).IsUnique();
        }
    }
}
