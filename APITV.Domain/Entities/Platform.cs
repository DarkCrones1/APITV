using APITV.Common.Entities;

namespace APITV.Domain.Entities;

public partial class Platform : CatalogBaseAuditablePaginationEntity
{
    public virtual ICollection<Subscription> Subscription { get; } = new List<Subscription>();
}