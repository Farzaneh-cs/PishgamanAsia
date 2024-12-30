using Carpet.Domain.Customers;
using Carpet.Domain.Staffs;
using Carpet.Domain.UsersRoles;

namespace Carpet.Domain.ServiceProviders;

public class ServiceCarpet
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Code { get; set; }
    public bool? IsRegistered { get; set; }
    public DateTime RegisterDate { get; set; }
    public string Address { get; set; }
    public string Tell { get; set; }
    public string? Mobile { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<Staff> Staffs { get; private set; }
    public virtual ICollection<Customer> Customers { get; private set; }
    public virtual ICollection<ApplicationUser> Users { get; private set; }

    public ServiceCarpet() { }
    private ServiceCarpet(string name,
                            string? code,
                            string address,
                            string tell,
                            string mobile,
                            string? description)
    {
        Name = name;
        Code = code;
        Address = address;
        Tell = tell;
        Mobile = mobile;
        Description = description;
        RegisterDate = DateTime.Now;
    }
    public static ServiceCarpet Create(string name,
                            string? code,
                            string address,
                            string tell,
                            string mobile,
                            string? description)
        => new ServiceCarpet(name,code,address,tell,mobile,description);
}
