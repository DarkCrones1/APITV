using APITV.Common.Entities;
using APITV.Common.Interfaces.Entities;
using APITV.Common.Interfaces.Repositories;
using APITV.Common.Interfaces.Services;
using APITV.Domain.Entities;

using APITV.Domain.Interfaces;

namespace APITV.Application.Services;

public class CatalogBaseService<T> : CrudService<T>, ICatalogBaseService<T> where T : CatalogBaseEntity
{
    protected new ICatalogBaseRepository<T> _repository;
    public CatalogBaseService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        this._repository = GetRepository();
    }

    protected override ICatalogBaseRepository<T> GetRepository()
    {
        var typeRep = typeof(T);

        if (typeRep == typeof(Platform))
            return (ICatalogBaseRepository<T>)this._unitOfWork.PlatformRepository;

        return (ICatalogBaseRepository<T>)this._unitOfWork.ServiceRepository;
    }
}