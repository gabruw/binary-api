using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class DiffRightConfiguration : IEntityTypeConfiguration<DiffRight>
    {
        public void Configure(EntityTypeBuilder<DiffRight> builder)
        {
            builder.HasKey(dr => dr.Id);
            builder.Property(dr => dr.Value).IsRequired().HasMaxLength(255).HasColumnType("VARCHAR(255)");
        }
    }
}
