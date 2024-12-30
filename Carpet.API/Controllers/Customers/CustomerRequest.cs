namespace Carpet.API.Controllers.Customers;

public class CustomerRequest
{
    public string Family { get; set; }
    public string? Mobile1 { get; set; }
    public string? Mobile2 { get; set; }
    public string Address{ get; set; }
    public string Code{ get; set; }
    public Guid ServiceProviderId { get; set; }
}