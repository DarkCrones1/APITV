using APITV.Common.Entities;

namespace APITV.Domain.Entities;

public partial class Payment : BaseAuditablePaginationEntity
{
    public int BillingId { get; set; }

    public int SubscriptionId { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal Amount { get; set; }

    public virtual Billing Billing { get; set; } = null!;

    public virtual Subscription Subscription { get; set; } = null!;
}