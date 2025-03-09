using Carpet.Domain.Staffs;

namespace Carpet.Application.Staffs.GetList;

public class StaffDto
{
    public Guid Id { get; set; }
    public string  Family{ get; set; }
    public string  NationalCode{ get; set; }
    public string  Mobile { get; set; }
}
