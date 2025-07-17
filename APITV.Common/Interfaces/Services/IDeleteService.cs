using System.Linq.Expressions;
using APITV.Common.Interfaces.Entities;

namespace APITV.Common.Interfaces.Services;
public interface IDeleteService<T> where T : IBaseQueryable
{
    Task<int> Delete(int id);
    Task<int> DeleteRange(IEnumerable<int> idList);
    Task<int> DeleteBy(Expression<Func<T, bool>> filter);
}
