using Carpet.Domain.Staffs;

namespace Carpet.Domain.Staffs
{
    public interface IStaffRepository
    {
        Guid CreateAsync(Staff staff);
        Task<List<Staff>> GetListAsync(Guid serviceProvider, string? Family, string? mobile);
        Task<Staff> GetByIdAsync(Guid id);
    }
}
