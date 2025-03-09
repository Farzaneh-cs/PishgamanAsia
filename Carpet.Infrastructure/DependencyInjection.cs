using Carpet.Domain.LogTables;
using Carpet.Domain.Staffs;
using Carpet.Infrastructure.LogTables;
using Carpet.Infrastructure.Staffs;
using Carpet.Infrastructure.TokenServices;
using Microsoft.Extensions.DependencyInjection;

namespace Carpet.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IStaffRepository, StaffRepository>();
        services.AddScoped<IlogTableRepository, logTableRepository>();
        return services;
    }
}
