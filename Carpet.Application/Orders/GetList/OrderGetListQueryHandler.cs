using AutoMapper;
using Carpet.Application.Abstraction.Messaging;
using Carpet.Domain.Orders;

namespace Carpet.Application.Orders.GetList;

public class OrderGetListQueryHandler : IQueryHandler<OrderGetListQuery, List<OrderDto>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderGetListQueryHandler(IOrderRepository orderRepository,
                                       IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    public async Task<List<OrderDto>> Handle(OrderGetListQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetListAsync(request.CustomerId, request.IsPsyed, request.DeliveryTime);

        return orders.Select(order => new OrderDto
        {
            CustomerAddress = order.Costumer.Address,
            CustomerFamily = order.Costumer.Family,
            CustomerMobile1 = order.Costumer.MobileNo1,
            DeliveryTime = order.DeliveryTime,
            FinalPrice = order.FinalPrice,
            Id = order.Id,
            IsPayed = order.IsPayed,
            RecieveTime = order.RecieveTime
        }).ToList();
    }
}
