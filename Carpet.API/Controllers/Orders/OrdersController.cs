using Carpet.Application.Orders.Create;
using Carpet.Application.Orders.GetById;
using Carpet.Application.Orders.GetList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carpet.API.Controllers.Orders;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ISender _sender;
    private readonly ILogger<OrdersController> _logger;

    public OrdersController(ISender sender,
                            ILogger<OrdersController> logger)
    {
        _sender = sender;
       _logger = logger;
    }

    [HttpPost("create")]
    // [Authorize(Policy = "CanCreateOrder")]
    [Authorize(Roles = "Manager,Admin")]
    public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request,
                                                   CancellationToken cancellationToken)
    {
        var price = request.OrderItems.Sum(x => x.ItemPrice * x.ItemNumber);
        var command = new CreateOrderCommand(request.CustomerId, request.ShippingPrice, request.Discount,
                                             request.Description, DateTime.Now, price, request.OrderItems);
        var result = await _sender.Send(command,cancellationToken);

        if (result == null)
        {
            return NotFound(result);
        }

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var query = new OrderGetByIdQuery(Guid.Parse(id.ToString()));
        var result = await _sender.Send(query,cancellationToken);
        if (result == null)
        {
            return NotFound(result);
        }

        return Ok(result);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetList([FromQuery] OrdersSearchRequest request, CancellationToken cancellationToken)
    {
        var query = new OrderGetListQuery(request.CustomerId, request.IsPsyed,request.DeliveryTime);
        var result = await _sender.Send(query, cancellationToken);
        if (result == null)
        {
            return NotFound(result);
        }

        return Ok(result);
    }
}