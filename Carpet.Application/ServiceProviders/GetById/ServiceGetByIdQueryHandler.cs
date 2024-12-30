using Carpet.Application.Abstraction.Messaging;
using Carpet.Domain.ServiceProviders;

namespace Carpet.Application.ServiceProviders.GetById;

public class ServiceGetByIdQueryHandler : IQueryHandler<ServiceGetByIdQuery, ServiceCarpet>
{
    private readonly IServiceProviderRepository _serviceProviderRepository;

    public ServiceGetByIdQueryHandler(IServiceProviderRepository serviceProviderRepository)
    {
        _serviceProviderRepository = serviceProviderRepository;
    }

    public async Task<ServiceCarpet> Handle(ServiceGetByIdQuery request, CancellationToken cancellationToken)
    {
        return await _serviceProviderRepository.GetByIdAsync(request.Id);
    }
}
