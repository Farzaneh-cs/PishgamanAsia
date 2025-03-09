using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace Carpet.API.Middleware;

public class IPFilterAttribute : ActionFilterAttribute
{
    private readonly List<IPNetwork> _allowedIPNetworks;

    public IPFilterAttribute(IConfiguration configuration)
    {
        var allowedIPRanges = configuration.GetSection("NotAllowedIPRanges").Get<List<string>>();
        _allowedIPNetworks = allowedIPRanges.Select(IPNetwork.Parse).ToList();
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var remoteIp = context.HttpContext.Connection.RemoteIpAddress;
        if (remoteIp == null || !_allowedIPNetworks.Any(network => network.Contains(remoteIp)))
        {
            context.Result = new ContentResult
            {
                StatusCode = 403,
                Content = "Forbidden: Invalid IP address"
            };
            return;
        }

        base.OnActionExecuting(context);
    }
}
