using APITV.Common.Interfaces.Entities;

namespace APITV.Common.Entities;

public abstract class BaseRemovableEntity : BaseEntity, IRemovableEntity
{
    public bool? IsDeleted { get; set; }
}