using Carpet.Domain.ServiceProviders;

namespace Carpet.Domain.ServiceProviders
{
    public interface IServiceProviderRepository
    {
        Guid CreateAsync(ServiceCarpet serviceProvider);
        Task<List<ServiceCarpet>> GetListAsync(string? code, string? mobile, string? name);
        Task<ServiceCarpet> GetByIdAsync(Guid id);
    }
}
