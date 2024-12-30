using Carpet.Application.Abstraction.Messaging;
using Carpet.Domain.Orders;

namespace Carpet.Application.Orders.Create;

public record CreateOrderCommand(Guid CustomerId,
                                 int ShippingPrice,
                                 int Discount,
                                 string? Description,
                                 DateTime DeliveryTime,
                                 int Price,
                                 List<OrderItemRequest> OrderItems):ICommand<Guid>;

public class OrderItemRequest
{
    public int ItemNumber { get; set; }
    public int ItemPrice { get; set; }
    public OrderITemType OrderITemType { get; set; }
}