using Carpet.Application.Orders.Create;
using Carpet.Domain.Orders;

namespace Carpet.API.Controllers.Orders;

public class OrderRequest
{
    public string? Description { get; set; }
    public int Discount { get; set; }
    public int ShippingPrice { get; set; }
    public Guid CustomerId { get; set; }
    public List<OrderItemRequest> OrderItems { get; set; }
}
