namespace APITV.Common.Interfaces.Entities;

public interface IRemovableEntity : IBaseQueryable
{
    public bool? IsDeleted { get; set; }
}