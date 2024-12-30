namespace Carpet.API.Controllers.Staffs;

public class StaffRequest
{
    public string Family { get; set; }
    public string? Mobile { get; set; }
    public string Address{ get; set; }
    public Guid ServiceProviderId { get; set; }
    public int StaffType { get; set; }
}