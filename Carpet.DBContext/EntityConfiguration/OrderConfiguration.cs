using Carpet.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carpet.DBContext.EntityConfiguration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.PaymentType);
        builder.Property(e => e.CustomerId);
        builder.Property(e => e.PaymentDate);
        builder.Property(e => e.DeliveryTime).IsRequired();
        builder.Property(e => e.RecieveTime);
        builder.Property(e => e.Price);
        builder.Property(e => e.FinalPrice);
        builder.Property(e => e.Discount);
        builder.Property(e => e.ShippingPrice);
        builder.HasMany(f => f.OrderItems)
               .WithOne(b => b.Order)
               .HasForeignKey(f => f.OrderId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
