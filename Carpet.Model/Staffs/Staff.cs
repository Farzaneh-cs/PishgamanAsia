using Carpet.Domain.ServiceProviders;

namespace Carpet.Domain.Staffs;

public class Staff
{
    public Guid Id { get; set; }
    public Guid ServiceProviderId { get; set; }
    public string Family { get; set; }
    public string Mobile { get; set; }
    public string? Address { get; set; }
    public StaffType StaffType { get; set; }
    public ServiceCarpet ServiceProvider { get; set; }
    private Staff() { }

    private Staff(string family,
                 string mobile,
                 string? address,
                 StaffType staffType,
                 Guid serviceProviderId)
    {
        Family = family;
        Mobile = mobile;
        Address = address;
        StaffType = staffType;
        ServiceProviderId = serviceProviderId;
    }

    public static Staff Create(string family,
                               string mobile,
                               string? address,
                               StaffType staffType,
                               Guid serviceProviderId)
        => new Staff(family, mobile, address, staffType, serviceProviderId);

}

public enum StaffType
{
    Manger,
    Driver,
    Cleaner,
    Other
}
