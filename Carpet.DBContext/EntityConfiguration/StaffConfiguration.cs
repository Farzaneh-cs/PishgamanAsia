using Carpet.Domain.Staffs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carpet.DBContext.EntityConfiguration;

internal class StaffConfiguration : IEntityTypeConfiguration<Staff>
{
    public void Configure(EntityTypeBuilder<Staff> builder)
    {
        builder.ToTable("Staffs");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.StaffType).IsRequired();
        builder.Property(e => e.ServiceProviderId);
        builder.Property(e => e.Address);
        builder.Property(e => e.Family).IsRequired();
        builder.Property(e => e.Mobile).IsRequired();
    }
}
