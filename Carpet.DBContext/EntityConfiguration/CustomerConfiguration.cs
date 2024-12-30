using Carpet.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carpet.DBContext.EntityConfiguration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.ServiceProviderId).IsRequired();
        builder.Property(e => e.Address).IsRequired();
        builder.Property(e => e.MobileNo1).IsRequired();
        builder.Property(e => e.MobileNo2);
        builder.Property(e => e.Code).IsUnicode();
        builder.Property(e => e.Family).IsRequired();
        builder.Property(e => e.ServiceProviderId);
        builder.HasMany(f => f.Orders)
               .WithOne(b => b.Costumer)
               .HasForeignKey(f => f.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
