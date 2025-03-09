using Carpet.Application.Abstraction.Messaging;
using Carpet.Application.Staffs.GetList;

namespace Carpet.API.Controllers.Staffs;
public class StaffSearchRequest
{
    public string? Family{ get; set; }
    public string? NationalCode{ get; set; }
}