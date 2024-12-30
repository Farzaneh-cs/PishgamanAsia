using Carpet.Application.Abstraction.Messaging;
using Carpet.Domain.Customers;

namespace Carpet.Application.Customers.GetById;

public record GetByIdQuery(Guid Id):IQuery<Customer>;

