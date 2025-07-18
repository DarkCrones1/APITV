using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using APITV.Domain.Entities;

namespace APITV.Infrastructure.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        // Don't Delete, Manual configuration
        builder.Ignore(x => x.FullName);

        builder.Property(e => e.CellPhone)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.CreatedBy)
            .HasMaxLength(50)
            .HasDefaultValueSql("(N'Admin')");
        builder.Property(e => e.CreatedDate)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder.Property(e => e.FirstName)
            .HasMaxLength(200)
            .IsUnicode(false);
        builder.Property(e => e.LastModifiedBy).HasMaxLength(50);
        builder.Property(e => e.LastModifiedDate).HasColumnType("datetime");
        builder.Property(e => e.LastName)
            .HasMaxLength(200)
            .IsUnicode(false);
        builder.Property(e => e.MiddleName)
            .HasMaxLength(150)
            .IsUnicode(false);
        builder.Property(e => e.Phone)
            .HasMaxLength(50)
            .IsUnicode(false);
    }
}