using System.ComponentModel.DataAnnotations.Schema;
using APITV.Common.Interfaces.Entities;

namespace APITV.Common.Entities;

public abstract class CatalogBaseAuditablePaginationEntity : CatalogBaseAuditableEntity, IPaginationQueryable
{
    [NotMapped]
    public int PageSize { get; set; }

    [NotMapped]
    public int PageNumber { get; set; }
}