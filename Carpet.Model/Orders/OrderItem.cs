namespace Carpet.Domain.Orders;

public class OrderItem
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public int ItemNumber { get; set; }
    public int ItemPrice { get; set; }
    public OrderITemType OrderITemType { get; set; }
    public Order Order { get; set; }

    private OrderItem() { }
    private OrderItem(Guid orderId,
                     int itmeNumber,
                     int itemPrice,
                     OrderITemType orderITemType)
    {
        ItemNumber = itmeNumber;
        ItemPrice = itemPrice;
        OrderId = orderId;
        OrderITemType = orderITemType;
    }

    public static OrderItem Create(Guid orderId,
                                   int itmeNumber,
                                   int itemPrice,
                                   OrderITemType orderITemType)
        => new OrderItem(orderId,itmeNumber, itemPrice, orderITemType);
}