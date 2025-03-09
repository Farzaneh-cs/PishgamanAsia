using Carpet.Application.Abstraction.UnitOfWork;
using Carpet.Application.Staffs.Create;
using Carpet.Application.Staffs.GetById;
using Carpet.Application.Staffs.GetList;
using Carpet.Domain.Staffs;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Carpet.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddTransient<IRequestHandler<CreateStaffCommand, Guid>, CreateStaffCommandHandler>();
        services.AddTransient<IRequestHandler<StaffGetByIdQuery, Staff>, StaffGetByIdQueryHandler>();
        services.AddTransient<IRequestHandler<StaffGetListQuery, List<StaffDto>>, StaffGetListQueryHandler>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
