using APITV.Common.Interfaces.Entities;

namespace APITV.Common.Interfaces.Repositories;

public interface IQueryPagedRepository<T> where T : IBaseQueryable 
{
    Task<IEnumerable<T>> GetPaged(T entity);
}