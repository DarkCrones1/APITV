using APITV.Common.Interfaces.Repositories;
using APITV.Domain.Entities;
using APITV.Domain.Interfaces.Repositories;

namespace APITV.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICrudRepository<Customer> CustomerRepository { get; }

    ICrudRepository<Billing> BillingRepository { get; }

    ICatalogBaseRepository<Service> ServiceRepository { get; }

    ICrudRepository<Subscription> SubscriptionRepository { get; }

    ICrudRepository<Payment> PaymentRepository { get; }

    IPlatformRepository PlatformRepository { get; }

    void SaveChanges();

    Task SaveChangesAsync();
}