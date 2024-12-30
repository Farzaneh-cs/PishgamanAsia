using Carpet.Application.Abstraction.Messaging;
using Carpet.Domain.ServiceProviders;

namespace Carpet.Application.ServiceProviders.GetById;
public record ServiceGetByIdQuery(Guid Id) : IQuery<ServiceCarpet>;