using Carpet.Application.Customers.Create;
using Carpet.Application.Customers.GetById;
using Carpet.Application.Customers.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Carpet.API.Controllers.Customers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ISender _sender;

    public CustomersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateStaff([FromBody] CustomerRequest request,
                                                   CancellationToken cancellationToken)
    {
        var command = new CreateCustomerCommand(request.Family, request.Mobile1, request.Mobile2,
                                                request.Address, request.Code, request.ServiceProviderId);
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
        var query = new GetByIdQuery(Guid.Parse(id.ToString()));
        var result = await _sender.Send(query,cancellationToken);
        if (result == null)
        {
            return NotFound(result);
        }

        return Ok(result);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetList([FromQuery] CustomersSearchRequest request, CancellationToken cancellationToken)
    {
        var query = new GetListCustomerQuery(request.ServiceProvider, request.Family,request.Code, request.Mobile);
        var result = await _sender.Send(query, cancellationToken);
        if (result == null)
        {
            return NotFound(result);
        }

        return Ok(result);
    }
}