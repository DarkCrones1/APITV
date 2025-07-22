using APITV.Common.Entities;
using APITV.Common.Interfaces.Services;
using APITV.Domain.Dto.QueryFilters;
using APITV.Domain.Entities;

namespace APITV.Domain.Interfaces.Services;

public interface IPlatformservice : ICatalogBaseService<Platform>
{
    Task<PagedList<Platform>> GetPaged(PlatformQueryFilter filter);
}