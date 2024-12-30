using Carpet.Application.Abstraction.Messaging;

namespace Carpet.Application.Orders.GetList
{
    public record OrderGetListQuery(Guid CustomerId, bool? IsPsyed, DateTime? DeliveryTime) :IQuery<List<OrderDto>>;
}
