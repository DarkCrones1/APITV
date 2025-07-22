using Microsoft.Extensions.Configuration;

using APITV.Common.Interfaces.Repositories;
using APITV.Domain.Interfaces;
// using Api.Domain.Interfaces.Repositories;
// using Api.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using APITV.Infrastructure.Data;
using APITV.Domain.Entities;
using APITV.Infrastructure;
using APITV.Infrastructure.Repositories;
using APITV.Domain.Interfaces.Repositories;

namespace APITV.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    protected readonly ApiTvDbContext _dbContext;

    private readonly IConfiguration _configuration;

    private readonly IWebHostEnvironment _env;

    private readonly IHttpContextAccessor _httpContextAccessor;

    protected ICrudRepository<Customer> _CustomerRepository;

    protected ICrudRepository<Billing> _BillingRepository;

    protected ICatalogBaseRepository<Service> _ServiceRepository;

    protected ICrudRepository<Subscription> _SubscriptionRepository;

    protected ICrudRepository<Payment> _PaymentRepository;

    protected IPlatformRepository _PlatformRepository;

    private bool disposed;

    public UnitOfWork(ApiTvDbContext dbContext, IConfiguration configuration, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;

        this._configuration = configuration;

        this._env = env;

        this._httpContextAccessor = httpContextAccessor;

        disposed = false;

        _CustomerRepository = new CrudRepository<Customer>(_dbContext);

        _BillingRepository = new CrudRepository<Billing>(_dbContext);

        _ServiceRepository = new CatalogBaseRepository<Service>(_dbContext);

        _SubscriptionRepository = new CrudRepository<Subscription>(_dbContext);

        _PaymentRepository = new CrudRepository<Payment>(_dbContext);

        _PlatformRepository = new PlatformRepository(_dbContext);
    }

    public ICrudRepository<Customer> CustomerRepository => _CustomerRepository;

    public ICrudRepository<Billing> BillingRepository => _BillingRepository;

    public ICatalogBaseRepository<Service> ServiceRepository => _ServiceRepository;

    public ICrudRepository<Subscription> SubscriptionRepository => _SubscriptionRepository;

    public ICrudRepository<Payment> PaymentRepository => _PaymentRepository;

    public IPlatformRepository PlatformRepository => _PlatformRepository;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
            if (disposing)
                _dbContext.Dispose();

        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}