using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using APITV.Domain.Entities;

namespace APITV.Infrastructure.Data.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.Property(e => e.PaymentDate)
            .HasDefaultValueSql("getdate()")
            .HasColumnType("datetime");

        builder.Property(e => e.Amount)
            .HasColumnType("decimal(18, 2)");

        builder.HasOne(d => d.Billing)
            .WithMany(p => p.Payment)
            .HasForeignKey(d => d.BillingId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Payment_Billing");

        builder.HasOne(d => d.Subscription)
            .WithMany(p => p.Payment)
            .HasForeignKey(d => d.SubscriptionId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Payment_Subscription");
    }
}