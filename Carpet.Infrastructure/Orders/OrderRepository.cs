using Carpet.DBContext;
using Carpet.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Carpet.Infrastructure.Order;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public Guid CreateAsync(Domain.Orders.Order order)
    {
        _context.Orders.AddAsync(order);
        _context.SaveChanges();
        return order.Id;
    }

    public async Task<Domain.Orders.Order?> GetByIdAsync(Guid id)
    {
        return await _context.Orders.Include(x=> x.Costumer)
                                    .Include(x => x.OrderItems)
                                    .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Domain.Orders.Order>> GetListAsync(Guid CustormId, bool? isPayed, DateTime? DeliveryDate)
    {
        var orders = _context.Orders.Include(x => x.Costumer).Where(x => x.CustomerId == CustormId).AsNoTracking();

        if (isPayed != null)
        {
            orders = orders.Where(x => x.IsPayed == isPayed);
        }
        if (DeliveryDate != null)
        {
            orders = orders.Where(x => x.DeliveryTime <= DateTime.Now);
        }
        return await orders.ToListAsync();
    }

    public async Task<List<OrderItem>> GetListItemsAsync(Guid orderId)
    {
       return await _context.OrderItems.Where(x => x.OrderId == orderId).AsNoTracking().ToListAsync();
    }

    public void UpdateAsync(Domain.Orders.Order order)
    {
        _context.Orders.Update(order);
       _context.SaveChanges();
    }
}
