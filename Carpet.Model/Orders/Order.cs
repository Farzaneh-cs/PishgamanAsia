using Carpet.Domain.Customers;
using System.Runtime.CompilerServices;

namespace Carpet.Domain.Orders;

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime DeliveryTime { get; set; }
    public DateTime? RecieveTime { get; set; }
    public int? Price { get; set; }
    public int? ShippingPrice { get; set; }
    public int? Discount { get; set; }
    public int? FinalPrice { get; set; }
    public DateTime? PaymentDate { get; set; }
    public PaymentType? PaymentType { get; set; }
    public bool IsPayed { get; set; }
    public string? Description { get; set; }
    public Customer Costumer { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }

    private Order() { }

    private Order(Guid customerId,
                  int shippingPrice,
                  int discount,
                  string? description,
                  DateTime deliveryTime,
                  int price)
    {
        CustomerId = customerId;
        ShippingPrice = shippingPrice;
        Discount = discount;
        Description = description;
        DeliveryTime = deliveryTime;
        Price = price;
        FinalPrice = shippingPrice + price - Discount;
    }
    public void AddOrderItems(List<OrderItem> orderItems )
    {
        OrderItems = orderItems;
    }
    public static Order Create(Guid customerId,
                  int shippingPrice,
                  int discount,
                  string? description,
                  DateTime deliveryTime,
                  int price)
    => new Order(customerId, shippingPrice, discount, description, deliveryTime, price);
    

    public void PayTheOrder(PaymentType paymentType,
                            DateTime paymentDate)
    {
        IsPayed = true;
        PaymentType = paymentType;
        PaymentDate = paymentDate;

    }
     public void UpdateRecieve(DateTime recievDate)
    {
        RecieveTime = recievDate;
    }
}