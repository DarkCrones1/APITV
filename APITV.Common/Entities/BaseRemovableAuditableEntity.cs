using APITV.Common.Interfaces.Entities;

namespace APITV.Common.Entities;

public abstract class BaseRemovableAuditableEntity : BaseAuditableEntity, IRemovableEntity
{
    public bool? IsDeleted { get; set; }
}