using Carpet.Application.Abstraction.Messaging;
using Carpet.Domain.Orders;

namespace Carpet.Application.Orders.Create;

public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, Guid>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    { 
        var order = Order.Create(request.CustomerId,
                                  request.ShippingPrice,
                                  request.Discount,
                                  request.Description,
                                  request.DeliveryTime,
                                  request.Price);
        var orderItems = request.OrderItems.Select(orderItemRequest => OrderItem.Create(order.Id,orderItemRequest.ItemNumber,
                                                           orderItemRequest.ItemPrice, orderItemRequest.OrderITemType)).ToList();

        order.AddOrderItems(orderItems);

        _orderRepository.CreateAsync(order);
        return order.Id;

    }
}
