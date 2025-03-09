using Carpet.DBContext.EntityConfiguration;
using Carpet.Domain.LogTables;
using Carpet.Domain.Staffs;
using Carpet.Domain.UsersRoles;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Carpet.DBContext;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options)
    { }

    public DbSet<Staff> Staffs{ get; set; }
    public DbSet<LogTable> LogTables{ get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new StaffConfiguration());
    }
}
