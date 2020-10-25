using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class DiffLeftConfiguration : IEntityTypeConfiguration<DiffLeft>
    {
        public void Configure(EntityTypeBuilder<DiffLeft> builder)
        {
            builder.HasKey(dl => dl.Id);
            builder.Property(dl => dl.Value).IsRequired().HasMaxLength(255).HasColumnType("VARCHAR(255)");
        }
    }
}
