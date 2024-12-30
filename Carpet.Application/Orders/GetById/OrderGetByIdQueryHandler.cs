using AutoMapper;
using Carpet.Application.Abstraction.Messaging;
using Carpet.Application.Orders.GetList;
using Carpet.Domain.Orders;

namespace Carpet.Application.Orders.GetById;

public class OrderGetByIdQueryHandler : IQueryHandler<OrderGetByIdQuery, OrderDetilDto>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderGetByIdQueryHandler(IOrderRepository orderRepository,
                                    IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<OrderDetilDto> Handle(OrderGetByIdQuery request, CancellationToken cancellationToken)
    {
        var orderDetail = await _orderRepository.GetByIdAsync(request.Id);
        return new OrderDetilDto
        {
            CustomerAddress = orderDetail.Costumer.Address,
            CustomerFamily = orderDetail.Costumer.Family,
            CustomerMobile1 = orderDetail.Costumer.MobileNo1,
            DeliveryTime = orderDetail.DeliveryTime,
            FinalPrice = orderDetail.FinalPrice,
            Id = orderDetail.Id,
            IsPayed = orderDetail.IsPayed,
            RecieveTime = orderDetail.RecieveTime,
            OrderItems = orderDetail.OrderItems.Select(item => new OrderItemDetails
            {
                Id = item.Id,
                ItemNumber = item.ItemNumber,
                ItemPrice = item.ItemPrice,
                OrderITemType = item.OrderITemType
            }).ToList()
        };
    }
}
