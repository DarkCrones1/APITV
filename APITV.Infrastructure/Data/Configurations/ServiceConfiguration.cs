using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using APITV.Domain.Entities;

namespace APITV.Infrastructure.Data.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.Property(e => e.CreatedBy)
            .HasMaxLength(50)
            .HasDefaultValueSql("(N'Admin')");
        builder.Property(e => e.CreatedDate)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder.Property(e => e.Description).HasMaxLength(10000);
        builder.Property(e => e.LastModifiedBy).HasMaxLength(50);
        builder.Property(e => e.LastModifiedDate).HasColumnType("datetime");
        builder.Property(e => e.Name).HasMaxLength(50);
    }
}