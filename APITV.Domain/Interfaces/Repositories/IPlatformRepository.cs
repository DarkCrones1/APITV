using System.Linq.Expressions;
using APITV.Common.Interfaces.Repositories;
using APITV.Domain.Dto.QueryFilters;
using APITV.Domain.Entities;

namespace APITV.Domain.Interfaces.Repositories;
public interface IPlatformRepository : ICatalogBaseRepository<Platform>, IQueryFilterPagedRepository<Platform, PlatformQueryFilter>
{
    
}