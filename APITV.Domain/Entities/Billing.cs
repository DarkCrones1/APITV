using System.Security.Cryptography.X509Certificates;
using APITV.Common.Entities;

namespace APITV.Domain.Entities;

public partial class Billing : BaseAuditablePaginationEntity
{
    public Guid Code { get; set; } = Guid.NewGuid();

    public int SubscriptionId { get; set; }

    public decimal Amount { get; set; }

    public decimal? OutstandingBalance { get; set; }

    public decimal Total => Amount + (OutstandingBalance ?? 0);

    public DateTime BillingDate { get; set; }

    public DateTime? DueDate { get; set; }

    public short Status { get; set; }

    public virtual Subscription Subscription { get; set; } = null!;
    
    public virtual ICollection<Payment> Payment { get; } = new List<Payment>();
}
