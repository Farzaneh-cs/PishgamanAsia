using Carpet.DBContext.EntityConfiguratio;
using Carpet.DBContext.EntityConfiguration;
using Carpet.Domain.Customers;
using Carpet.Domain.Orders;
using Carpet.Domain.ServiceProviders;
using Carpet.Domain.Staffs;
using Carpet.Domain.UsersRoles;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Carpet.DBContext;

public class ApplicationDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):
        base(options) { }

    public DbSet<ServiceCarpet> ServiceProviders { get; set; }
    public DbSet<Customer> Custumers { get; set; }
    public DbSet<Staff> Staffs{ get; set; }
    public DbSet<Order> Orders  { get; set; }
    public DbSet<OrderItem> OrderItems  { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new CustomerConfiguration());
        builder.ApplyConfiguration(new ServiceProviderConfiguration());
        builder.ApplyConfiguration(new OrderConfiguration());
        builder.ApplyConfiguration(new OrderItemConfiguration());
        builder.ApplyConfiguration(new StaffConfiguration());
    }
}
