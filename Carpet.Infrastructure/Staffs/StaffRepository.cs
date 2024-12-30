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

    public async Task<List<Staff>> GetListAsync(Guid serviceProvider, string? Family, string? mobile)
    {
        var staffs = _context.Staffs.Where(x => x.ServiceProviderId == serviceProvider).AsNoTracking();

        if (Family != null)
        {
            staffs = staffs.Where(x => x.Family.Contains(Family));
        }
        if (mobile != null)
        {
            staffs = staffs.Where(x => x.Mobile == mobile );
        }
        return await staffs.ToListAsync();
    }
}
