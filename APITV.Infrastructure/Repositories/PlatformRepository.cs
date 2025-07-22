using Microsoft.EntityFrameworkCore;

using APITV.Domain.Entities;
using APITV.Domain.Interfaces.Repositories;
using APITV.Infrastructure.Data;
using APITV.Domain.Dto.QueryFilters;

namespace APITV.Infrastructure.Repositories;

public class PlatformRepository(ApiTvDbContext context) : CatalogBaseRepository<Platform>(context), IPlatformRepository
{
    public override async Task<IEnumerable<Platform>> GetPaged(Platform entity)
    {
        var query = _dbContext.Platform.AsQueryable();

        return await query.ToListAsync();
    }
    
    public async Task<IEnumerable<Platform>> GetPaged(PlatformQueryFilter entity)
    {
        var query = _dbContext.Platform.AsQueryable();

        if (entity.Id > 0)
            query = query.Where(x => x.Id == entity.Id);

        if (!string.IsNullOrEmpty(entity.Name) && !string.IsNullOrWhiteSpace(entity.Name))
            query = query.Where(x => x.Name.Contains(entity.Name));

        if (!string.IsNullOrEmpty(entity.Description) && !string.IsNullOrWhiteSpace(entity.Description))
            query = query.Where(x => x.Description!.Contains(entity.Description));

        if (entity.IsDeleted.HasValue)
            query = query.Where(x => x.IsDeleted == entity.IsDeleted);


        return await query.ToListAsync();
    }
}