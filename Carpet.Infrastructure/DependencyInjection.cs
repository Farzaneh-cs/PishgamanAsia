using Carpet.Domain.Customers;
using Carpet.Domain.Orders;
using Carpet.Domain.ServiceProviders;
using Carpet.Domain.Staffs;
using Carpet.Infrastructure.Customers;
using Carpet.Infrastructure.Order;
using Carpet.Infrastructure.ServiceProviders;
using Carpet.Infrastructure.Staffs;
using Microsoft.Extensions.DependencyInjection;

namespace Carpet.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IServiceProviderRepository, ServiceProviderRepository>();
        services.AddScoped<IStaffRepository, StaffRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        return services;
    }
}
