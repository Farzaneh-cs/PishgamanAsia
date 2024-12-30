using Carpet.Application.Orders.Create;
using Carpet.Domain.Orders;

namespace Carpet.Application.Orders.GetById;

public class OrderDetilDto
{
    public Guid Id { get; set; }
    public string CustomerFamily { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerMobile1 { get; set; }
    public int? FinalPrice { get; set; }
    public DateTime DeliveryTime { get; set; }
    public DateTime? RecieveTime { get; set; }
    public bool? IsPayed { get; set; }
    public List<OrderItemDetails> OrderItems { get; set; }
}
public class OrderItemDetails
{
    public Guid Id { get; set; }
    public int ItemNumber { get; set; }
    public int ItemPrice { get; set; }
    public OrderITemType OrderITemType { get; set; }
}