using Carpet.Application.Abstraction.UnitOfWork;
using Carpet.Application.Customers.Create;
using Carpet.Application.Customers.GetById;
using Carpet.Application.Customers.GetList;
using Carpet.Application.Orders.Create;
using Carpet.Application.Orders.GetById;
using Carpet.Application.Orders.GetList;
using Carpet.Application.ServiceProviders.Create;
using Carpet.Application.ServiceProviders.GetById;
using Carpet.Application.ServiceProviders.GetList;
using Carpet.Application.Staffs.Create;
using Carpet.Application.Staffs.GetById;
using Carpet.Application.Staffs.GetList;
using Carpet.Domain.Customers;
using Carpet.Domain.Orders;
using Carpet.Domain.ServiceProviders;
using Carpet.Domain.Staffs;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Carpet.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IRequestHandler<CreateCustomerCommand, Guid>, CreateCustomerCommandHandler>();
        services.AddTransient<IRequestHandler<GetByIdQuery, Customer>, GetByIdQueryHandler>();
        services.AddTransient<IRequestHandler<GetListCustomerQuery, List<CustomerDto>>, GetListCustomerQueryHandler>();

        services.AddTransient<IRequestHandler<CreateOrderCommand, Guid>, CreateOrderCommandHandler>();
        services.AddTransient<IRequestHandler<OrderGetByIdQuery, OrderDetilDto>, OrderGetByIdQueryHandler>();
        services.AddTransient <IRequestHandler <OrderGetListQuery,List <OrderDto>>, OrderGetListQueryHandler>();

        services.AddTransient<IRequestHandler<CreateServiceCommand, Guid>, CreateServiceCommandHandler>();
        services.AddTransient<IRequestHandler<ServiceGetByIdQuery, ServiceCarpet>, ServiceGetByIdQueryHandler>();
        services.AddTransient<IRequestHandler<GetListServiceQuery, List<ServiceDto>>, GetListServiceQueryHandler>();

        services.AddTransient<IRequestHandler<CreateStaffCommand, Guid>, CreateStaffCommandHandler>();
        services.AddTransient<IRequestHandler<StaffGetByIdQuery, Staff>, StaffGetByIdQueryHandler>();
        services.AddTransient<IRequestHandler<StaffGetListQuery, List<StaffDto>>, StaffGetListQueryHandler>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
