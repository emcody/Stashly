using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ItemConfiguration : IEntityTypeConfiguration<Stash>
    {
        public void Configure(EntityTypeBuilder<Stash> builder)
        {
            builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
            builder.Property(s => s.OwnerId).IsRequired();
            builder.Property(s => s.Location).HasMaxLength(50);
            builder.Property(s => s.Description).HasMaxLength(250);
        }
    }
}