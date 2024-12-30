namespace Carpet.API.Controllers.Orders;
public class OrdersSearchRequest
{
    public Guid CustomerId { get; set; }
    public bool? IsPsyed { get; set; }
    public DateTime? DeliveryTime { get; set; }
}