using APITV.Common.Interfaces.Entities;

namespace APITV.Common.Entities;

public abstract class BaseEntity : IBaseQueryable
{
    public int Id { get; set; }
}