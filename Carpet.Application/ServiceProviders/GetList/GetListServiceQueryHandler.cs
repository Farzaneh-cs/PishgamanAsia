using AutoMapper;
using Carpet.Application.Abstraction.Messaging;
using Carpet.Domain.ServiceProviders;

namespace Carpet.Application.ServiceProviders.GetList;

public class GetListServiceQueryHandler : IQueryHandler<GetListServiceQuery, List<ServiceDto>>
{
    private readonly IServiceProviderRepository _serviceProviderRepository;
    private readonly IMapper _mapper;

    public GetListServiceQueryHandler(IServiceProviderRepository serviceProviderRepository,
                                       IMapper mapper)
    {
        _serviceProviderRepository = serviceProviderRepository;
        _mapper = mapper;
    }
    public async Task<List<ServiceDto>> Handle(GetListServiceQuery request, CancellationToken cancellationToken)
    {
        var services = await _serviceProviderRepository.GetListAsync(request.Code,
                                                                      request.Mobile,
                                                                      request.Name);

        var serviceDtos = _mapper.Map<List<ServiceDto>>(services);

        return serviceDtos;
    }
}
