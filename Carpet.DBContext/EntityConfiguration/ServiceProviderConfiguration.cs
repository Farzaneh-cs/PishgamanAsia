using Carpet.Domain.ServiceProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carpet.DBContext.EntityConfiguratio;

internal class ServiceProviderConfiguration : IEntityTypeConfiguration<ServiceCarpet>
{
    public void Configure(EntityTypeBuilder<ServiceCarpet> builder)
    {
        builder.ToTable("ServiceProviders");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Address).IsRequired();
        builder.Property(e => e.Tell).IsRequired();
        builder.Property(e => e.Mobile);
        builder.Property(e => e.Code).IsUnicode();
        builder.Property(e => e.IsRegistered);
        builder.Property(e => e.Description);
        builder.Property(e => e.Name).IsRequired();
        builder.HasMany(f => f.Customers)
               .WithOne(b => b.ServiceProvider)
               .HasForeignKey(f => f.ServiceProviderId)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(f => f.Staffs)
             .WithOne(b => b.ServiceProvider)
             .HasForeignKey(f => f.ServiceProviderId)
             .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(f => f.Users)
           .WithOne(b => b.ServiceCarpet)
           .HasForeignKey(f => f.ServiceCarpetId)
           .OnDelete(DeleteBehavior.Cascade);
    }
}
