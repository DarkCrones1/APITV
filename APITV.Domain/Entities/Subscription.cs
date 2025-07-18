using APITV.Common.Entities;

namespace APITV.Domain.Entities;

public partial class Subscription : BaseRemovableAuditablePaginationEntity
{
    public Guid Code { get; set; } = Guid.NewGuid();

    public int CustomerId { get; set; }

    public int ServiceId { get; set; }

    public int PlatformId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool IsCanceled { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;

    public virtual Platform Platform { get; set; } = null!;

    public virtual ICollection<Billing> Billing { get; } = new List<Billing>();
    
    public virtual ICollection<Payment> Payment { get; } = new List<Payment>();
}