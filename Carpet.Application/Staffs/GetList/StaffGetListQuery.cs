using Carpet.Application.Abstraction.Messaging;

namespace Carpet.Application.Staffs.GetList
{
    public record StaffGetListQuery(string? Family, string? NationalCode, int number, int pagesize) :IQuery<List<StaffDto>>;
}
