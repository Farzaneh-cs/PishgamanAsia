using Carpet.Application.Abstraction.Messaging;

namespace Carpet.Application.Staffs.GetList
{
    public record StaffGetListQuery(Guid ServiceProvider, string? Family, string? Mobile) :IQuery<List<StaffDto>>;
}
