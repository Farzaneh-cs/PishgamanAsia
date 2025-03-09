using Carpet.DBContext;
using Carpet.Domain.Staffs;
using Microsoft.EntityFrameworkCore;

namespace Carpet.Infrastructure.Staffs;

public class StaffRepository : IStaffRepository
{
    private readonly ApplicationDbContext _context;

    public StaffRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Staff> CheckIsUniqeNameAsync(string name)
    {
       return await _context.Staffs.FirstOrDefaultAsync(e => e.LastName == name);
    }

    public Guid CreateAsync(Staff staff)
    {
        _context.AddAsync(staff);
        _context.SaveChanges();
        return staff.Id;
    }

    public async Task<Staff?> GetByIdAsync(Guid id)
    {
        return await _context.Staffs.FindAsync(id);
    }


    public async Task<List<Staff>> GetListAsync(string? lastname, string? nationalCode, int number, int pageSize)
    {
        var staffs = _context.Staffs.AsNoTracking();

        if (lastname != null)
        {
            staffs = staffs.Where(x => x.LastName.Contains(lastname));
        }
        if (nationalCode != null)
        {
            staffs = staffs.Where(x => x.NationalCode == nationalCode);
        }

        staffs = staffs.Skip((number - 1) * pageSize).Take(pageSize);
        return await staffs.ToListAsync();
    }
}
