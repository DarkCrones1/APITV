using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITV.Common.Interfaces.Entities;

namespace APITV.Common.Interfaces.Repositories;

public interface IRetrieveRepository<T> : IQueryRepository<T>, IQueryPagedRepository<T> where T : IBaseQueryable
{

}