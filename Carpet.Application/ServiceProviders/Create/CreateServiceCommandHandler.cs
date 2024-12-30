using Carpet.Application.Abstraction.Messaging;
using Carpet.Application.ServiceProviders.Create;
using Carpet.Domain.ServiceProviders;

namespace Carpet.Application.Customers.Create;

public class CreateServiceCommandHandler : ICommandHandler<CreateServiceCommand, Guid>
{
    private readonly IServiceProviderRepository _serviceProviderRepository;

    public CreateServiceCommandHandler(IServiceProviderRepository serviceProviderRepository)
    {
        _serviceProviderRepository = serviceProviderRepository;
    }
    public async Task<Guid> Handle(CreateServiceCommand command, CancellationToken cancellationToken)
    {
        var service = ServiceCarpet.Create(command.Name,command.Code, command.Address,
                                              command.Tell,command.Mobile, command.Description);         
        return _serviceProviderRepository.CreateAsync(service);      
    }
}
