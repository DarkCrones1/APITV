using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using APITV.Domain.Entities;

namespace APITV.Infrastructure.Data.Configurations;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.Property(e => e.StartDate)
            .HasDefaultValueSql("getdate()")
            .HasColumnType("datetime");

        builder.Property(e => e.EndDate)
            .HasColumnType("datetime");

        builder.HasOne(d => d.Customer)
            .WithMany(p => p.Subscription)
            .HasForeignKey(d => d.CustomerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Subscription_Customer");

        builder.HasOne(d => d.Service)
            .WithMany(p => p.Subscription)
            .HasForeignKey(d => d.ServiceId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Subscription_Service");

        builder.HasOne(d => d.Platform)
            .WithMany(p => p.Subscription)
            .HasForeignKey(d => d.PlatformId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Subscription_Platform");

        
    }
}