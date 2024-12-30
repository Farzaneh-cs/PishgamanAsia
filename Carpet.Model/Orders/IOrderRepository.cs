namespace Carpet.Domain.Orders
{
    public interface IOrderRepository
    {
        Guid CreateAsync(Order order);
        void UpdateAsync(Order order);
        Task<List<Order>> GetListAsync(Guid CustormId, bool? isPayed,DateTime? DateDelivery);
        Task<List<OrderItem>> GetListItemsAsync(Guid orderId);
        Task<Order> GetByIdAsync(Guid id);
    }
}
