using Carpet.Application.Staffs.Create;
using Carpet.Application.Staffs.GetById;
using Carpet.Application.Staffs.GetList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
    [Authorize(Policy = "AdminPolicy")]
    //[ServiceFilter(typeof(IPFilterAttribute))]
    public async Task<IActionResult> CreateStaff([FromQuery] StaffRequest request,
                                                   CancellationToken cancellationToken)
    {
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        var userId = userIdClaim?.Value;
        var command = new CreateStaffCommand(request.Family, request.name, request.fatherName,
                                            request.mobile,request.nationalCode, request.image,Guid.Parse(userId));
        var result = await _sender.Send(command,cancellationToken);

        if (result == null)
        {
            return NotFound(result);
        }

        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Policy = "CanReadPloicy")]
    //[ServiceFilter(typeof(IPFilterAttribute))]
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
    [Authorize(Policy = "CanReadPloicy")]
    // [ServiceFilter(typeof(IPFilterAttribute))]
    public async Task<IActionResult> GetList([FromQuery] int number, [FromQuery] int pagesize, [FromQuery] StaffSearchRequest request, CancellationToken cancellationToken)
    {
        var query = new StaffGetListQuery( request.Family, request.NationalCode, number, pagesize);
        var result = await _sender.Send(query, cancellationToken);
        if (result == null)
        {
            return NotFound(result);
        }

        return Ok(result);
    }
}