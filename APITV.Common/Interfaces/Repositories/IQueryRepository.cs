using System.Linq.Expressions;
using APITV.Common.Interfaces.Entities;
// using APITV.Common.QueryFilters;

namespace APITV.Common.Interfaces.Repositories;

public interface IQueryRepository<T>  : IQueryExpresionFilterRepository<T>, IFirstOrDefaultRepository<T> where T : IBaseQueryable
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    //IEnumerable<T> GetBy(T entity);
}