using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Threading.Tasks;

namespace Carpet.API.Middleware;

public class IPMiddleware
{
    private readonly RequestDelegate _next;
    private readonly List<IPNetwork> _allowedIPNetworks;

    public IPMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        var allowedIPRanges = configuration.GetSection("NotAllowedIPRanges").Get<List<string>>();
        _allowedIPNetworks = allowedIPRanges.Select(IPNetwork.Parse).ToList();
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var remoteIp = context.Connection.RemoteIpAddress;
        if (remoteIp == null || !_allowedIPNetworks.Any(network => network.Contains(remoteIp)))
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("Forbidden: Invalid IP address");
            return;
        }

        await _next(context);
    }
}
