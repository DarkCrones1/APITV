using APITV.Common.Entities;

namespace APITV.Domain.Entities;

public partial class Customer : BaseRemovableAuditablePaginationEntity
{
    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string CellPhone { get; set; } = null!;

    public string? Phone { get; set; }

    public short? Gender { get; set; }

    public DateTime? BirthDate { get; set; }

    public bool IsActive { get; set; } = true;

    public string FullName { get => $"{FirstName} {MiddleName} {LastName}".Trim(); }

    public virtual ICollection<Subscription> Subscription { get; } = [];
}