using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITV.Common.Interfaces.Entities;

namespace APITV.Common.Interfaces.Services;
public interface IUpdateService<T> where T : IBaseQueryable
{
    Task Update(T entity);
}