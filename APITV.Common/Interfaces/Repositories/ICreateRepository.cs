using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITV.Common.Interfaces.Entities;

namespace APITV.Common.Interfaces.Repositories;
public interface ICreateRepository<T> where T : IBaseQueryable
{
    Task<int> Create(T entity);

    Task CreateRange(IEnumerable<T> entities);
}
