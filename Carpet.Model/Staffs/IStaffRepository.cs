using Carpet.Domain.Staffs;

namespace Carpet.Domain.Staffs
{
    public interface IStaffRepository
    {
        Guid CreateAsync(Staff staff);
        Task<List<Staff>> GetListAsync(string? lastname, string? nationalCode, int number = 0, int pagesize = 10);
        Task<Staff> GetByIdAsync(Guid id);
        Task<Staff> CheckIsUniqeNameAsync(string name);
    }
}
