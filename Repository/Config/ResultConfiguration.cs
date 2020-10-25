using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class ResultConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.HasKey(dl => dl.Id);
            builder.Property(dl => dl.Value).IsRequired().HasMaxLength(255).HasColumnType("VARCHAR(255)");
        }
    }
}
