namespace Carpet.API.Controllers.Customers;
public class CustomersSearchRequest
{
    public Guid ServiceProvider { get; set; }
    public string? Family{ get; set; }
    public string? Mobile{ get; set; }
    public string? Code{ get; set; }
}      