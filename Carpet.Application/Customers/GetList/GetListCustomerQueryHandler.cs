using AutoMapper;
using Carpet.Application.Abstraction.Messaging;
using Carpet.Domain.Customers;

namespace Carpet.Application.Customers.GetList;

public class GetListCustomerQueryHandler : IQueryHandler<GetListCustomerQuery, List<CustomerDto>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetListCustomerQueryHandler(ICustomerRepository customerRepository,
                                       IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }
    public async Task<List<CustomerDto>> Handle(GetListCustomerQuery request, CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetListAsync(
           request.serviceProvider,
           request.Family,
           request.code,
           request.mobile);

        var customerDtos = _mapper.Map<List<CustomerDto>>(customers);

        return customerDtos;
    }
}
