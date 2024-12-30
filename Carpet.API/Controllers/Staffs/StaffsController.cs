using Carpet.Application.Staffs.Create;
using Carpet.Application.Staffs.GetById;
using Carpet.Application.Staffs.GetList;
using Carpet.Domain.Staffs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Carpet.API.Controllers.Staffs;

[ApiController]
[Route("api/[controller]")]
public class StaffsController : ControllerBase
{
    private readonly ISender _sender;

    public StaffsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateStaff([FromBody] StaffRequest request,
                                                   CancellationToken cancellationToken)
    {
        var command = new CreateStaffCommand(request.Family, request.Mobile, request.Address,
                                            (StaffType)Enum.ToObject(typeof(StaffType), 
                                            request.StaffType), request.ServiceProviderId);
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
        var query = new StaffGetByIdQuery(Guid.Parse(id.ToString()));
        var result = await _sender.Send(query,cancellationToken);
        if (result == null)
        {
            return NotFound(result);
        }

        return Ok(result);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetList([FromQuery] StaffSearchRequest request, CancellationToken cancellationToken)
    {
        var query = new StaffGetListQuery(request.ServiceProvider, request.Family, request.Mobile);
        var result = await _sender.Send(query, cancellationToken);
        if (result == null)
        {
            return NotFound(result);
        }

        return Ok(result);
    }
}