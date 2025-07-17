using System.Linq.Expressions;
using APITV.Common.Interfaces.Entities;

namespace APITV.Common.Interfaces.Services;

    public interface IExistService<T> where T : IBaseQueryable
    {
        Task<bool> Exist(Expression<Func<T, bool>> filters);
    }
