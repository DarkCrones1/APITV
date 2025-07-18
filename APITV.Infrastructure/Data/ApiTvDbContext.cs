using APITV.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APITV.Infrastructure.Data;

public partial class ApiTvDbContext : DbContext
{
    public ApiTvDbContext()
    {
    }

    public ApiTvDbContext(DbContextOptions<ApiTvDbContext> options)
        : base(options)
    {
    }

    public DbSet<Billing> Billing { get; set; }

    public DbSet<Customer> Customer { get; set; }

    public DbSet<Payment> Payment { get; set; }

    public DbSet<Platform> Platform { get; set; }

    public DbSet<Service> Service { get; set; }

    public DbSet<Subscription> Subscription { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            option => option.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery).MigrationsAssembly("APITV.Api")
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiTvDbContext).Assembly);
    }
}