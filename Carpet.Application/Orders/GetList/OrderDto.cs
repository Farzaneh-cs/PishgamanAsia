namespace Carpet.Application.Orders.GetList;

public class OrderDto
{
    public Guid Id { get; set; }
    public string  CustomerFamily{ get; set; }
    public string  CustomerAddress{ get; set; }
    public string  CustomerMobile1 { get; set; }
    public int? FinalPrice{ get; set; }
    public DateTime DeliveryTime{ get; set; }
    public DateTime? RecieveTime{ get; set; }
    public bool? IsPayed { get; set; }
}
