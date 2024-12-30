using Carpet.Domain.Orders;
using Carpet.Domain.ServiceProviders;

namespace Carpet.Domain.Customers;

public class Customer
{
    public Guid Id { get; set; }
    public Guid ServiceProviderId { get; set; }
    public string Family { get; set; }
    public string Code { get; set; }
    public string MobileNo1 { get; set; }
    public string? MobileNo2 { get; set; }
    public string Address { get; set; }
    public virtual ICollection<Order> Orders { get;private set; }
    public ServiceCarpet ServiceProvider { get; set; }
    public Customer() { }

    private Customer(string family,
                     string mobile1,
                     string mobile2,
                     string address,
                     string code,
                     Guid serviceProviderId)
    {

        Family = family;
        MobileNo1 = mobile1;
        MobileNo2 = mobile2;
        Address = address;
        Code = code;
        ServiceProviderId = serviceProviderId;
    }

    public static Customer Create(string family,
                                  string mobile1,
                                  string mobile2,
                                  string address,
                                  string code,
                                  Guid serviceProviderId)
        => new Customer(family, mobile1, mobile2, address, code, serviceProviderId);
}
