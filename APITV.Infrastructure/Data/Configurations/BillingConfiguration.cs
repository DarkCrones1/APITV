using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using APITV.Domain.Entities;

namespace APITV.Infrastructure.Data.Configurations;

public class BillingConfiguration : IEntityTypeConfiguration<Billing>
{
    public void Configure(EntityTypeBuilder<Billing> builder)
    {
        builder.Property(e => e.CreatedBy)
            .HasMaxLength(50)
            .HasDefaultValueSql("(N'Admin')");
        builder.Property(e => e.CreatedDate)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");

        builder.Property(e => e.LastModifiedBy)
            .HasMaxLength(50);
        builder.Property(e => e.LastModifiedDate)
            .HasColumnType("datetime");

        builder.HasOne(e => e.Subscription)
            .WithMany(e => e.Billing)
            .HasForeignKey(e => e.SubscriptionId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Billing_Subscription");
    }
}