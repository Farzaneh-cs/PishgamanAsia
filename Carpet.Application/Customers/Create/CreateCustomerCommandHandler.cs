using Carpet.Application.Abstraction.Messaging;
using Carpet.Domain.Customers;

namespace Carpet.Application.Customers.Create;

public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, Guid>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<Guid> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = Customer.Create(command.Family, command.Mobile1, command.Mobile2,
                                       command.Address, command.Code, command.ServiceProviderId);
        return _customerRepository.CreateAsync(customer);      
    }
}
