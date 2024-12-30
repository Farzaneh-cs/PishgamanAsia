using Carpet.Domain.Staffs;

namespace Carpet.Application.Staffs.GetList;

public class StaffDto
{
    public Guid Id { get; set; }
    public string  Family{ get; set; }
    public string  Address{ get; set; }
    public string  Mobile { get; set; }
    public StaffType StaffType{ get; set; }
}
