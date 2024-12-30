using Carpet.Application.Abstraction.Messaging;
using Carpet.Domain.Customers;

namespace Carpet.Application.Customers.GetById;

public class GetByIdQueryHandler : IQueryHandler<GetByIdQuery, Customer>
{
    private readonly ICustomerRepository _customerRepository;

    public GetByIdQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        return await _customerRepository.GetByIdAsync(request.Id);
    }
}
