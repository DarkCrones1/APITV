using APITV.Common.Entities;
using APITV.Common.Interfaces.Services;
using APITV.Domain.Dto.QueryFilters;
using APITV.Domain.Entities;
using APITV.Domain.Enumerations;
using APITV.Domain.Interfaces;
using APITV.Domain.Interfaces.Services;

namespace APITV.Application.Services;

public class PlatformService(IUnitOfWork unitOfWork) : CatalogBaseService<Platform>(unitOfWork), IPlatformservice
{
    public async Task<PagedList<Platform>> GetPaged(PlatformQueryFilter filter)
    {
        var result = await _unitOfWork.PlatformRepository.GetPaged(filter);
        var pagedItems = PagedList<Platform>.Create(result, filter.PageNumber, filter.PageSize);
        return pagedItems;
    }
    
}