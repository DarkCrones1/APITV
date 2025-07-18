using APITV.Common.Entities;

namespace APITV.Domain.Entities;

public partial class Service : CatalogBaseAuditablePaginationEntity
{
    public int TVCount { get; set; }

    public decimal MonthlyPrice { get; set; }

    public virtual ICollection<Subscription> Subscription { get; } = new List<Subscription>();
}