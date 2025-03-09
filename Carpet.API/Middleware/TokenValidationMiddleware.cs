using Carpet.Infrastructure.TokenServices;

namespace Carpet.API.Middleware;

public class TokenValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ITokenService _tokenService;

    public TokenValidationMiddleware(RequestDelegate next, ITokenService tokenService)
    {
        _next = next;
        _tokenService = tokenService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (!string.IsNullOrEmpty(token) && !_tokenService.IsTokenValid(token))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid token.");
            return;
        }

        await _next(context);
    }
}
