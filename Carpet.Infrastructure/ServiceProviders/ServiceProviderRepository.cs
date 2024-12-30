using Carpet.DBContext;
using Carpet.Domain.ServiceProviders;

namespace Carpet.Infrastructure.ServiceProviders;

public class ServiceProviderRepository : IServiceProviderRepository
{
    private readonly ApplicationDbContext _context;

    public ServiceProviderRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public Guid CreateAsync(ServiceCarpet serviceProvider)
    {
        _context.AddAsync(serviceProvider);
        _context.SaveChanges();
        return serviceProvider.Id;
    }

    public async Task<ServiceCarpet?> GetByIdAsync(Guid id)
    {
        return await _context.ServiceProviders.FindAsync(id);
    }

    public async Task<List<ServiceCarpet>> GetListAsync(string? code, string? mobile, string? name)
    {
        var serviceProviders = _context.ServiceProviders.ToList();

        if (code != null)
        {
            serviceProviders = serviceProviders.Where(x => x.Code == code).ToList();
        }
        if (name != null)
        {
            serviceProviders = serviceProviders.Where(x => x.Name.Contains(name)).ToList();
        }
        if (mobile != null)
        {
            serviceProviders = serviceProviders.Where(x => x.Mobile == mobile || x.Tell == mobile).ToList();
        }
        return serviceProviders;
    }
}
