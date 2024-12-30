using Carpet.Application.Abstraction.Messaging;

namespace Carpet.Application.ServiceProviders.GetList
{
    public record GetListServiceQuery(string? Code, 
                                       string? Mobile,
                                       string? Name) :IQuery<List<ServiceDto>>;
}
