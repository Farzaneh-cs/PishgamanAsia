using Carpet.API.Controllers.ServiceCarpet;
using Carpet.Application.ServiceProviders.Create;
using Carpet.Application.ServiceProviders.GetById;
using Carpet.Application.ServiceProviders.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Carpet.API.Controllers.ServiceCarpets
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceCarpetController : ControllerBase
    {
        private readonly ISender _sender;

        public ServiceCarpetController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateServiceCarpet([FromBody] ServiceCarpetRequest request,
                                                       CancellationToken cancellationToken)
        {
            var command = new CreateServiceCommand(request.Name, request.Code, request.Address,
                                                   request.Tell, request.Mobile, request.Description);
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
            var query = new ServiceGetByIdQuery(Guid.Parse(id.ToString()));
            var result = await _sender.Send(query,cancellationToken);
            if (result == null)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList([FromQuery] ServiceSearchRequest request, CancellationToken cancellationToken)
        {
            var query = new GetListServiceQuery(request.Code, request.Mobile, request.Name);
            var result = await _sender.Send(query, cancellationToken);
            if (result == null)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}