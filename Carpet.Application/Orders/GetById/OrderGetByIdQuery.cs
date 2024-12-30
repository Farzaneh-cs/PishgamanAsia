using Carpet.Application.Abstraction.Messaging;

namespace Carpet.Application.Orders.GetById;

public record OrderGetByIdQuery(Guid Id):IQuery<OrderDetilDto>;

