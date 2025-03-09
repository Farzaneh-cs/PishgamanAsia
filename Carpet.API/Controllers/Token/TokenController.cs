using Carpet.Infrastructure.TokenServices;
using Microsoft.AspNetCore.Mvc;

namespace Carpet.API.Controllers.Token;

[Route("api/[controller]")]
[ApiController]
public class TokensController : ControllerBase
{
    private readonly ITokenService _tokenService;

    public TokensController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("invalidate")]
    public IActionResult InvalidateTokens([FromBody] UserRequest request)
    {
        if (string.IsNullOrEmpty(request.Username))
        {
            return BadRequest("Username is required.");
        }

        _tokenService.InvalidateTokens(request.Username);
        return Ok($"Tokens for {request.Username} have been invalidated.");
    }
}

public class UserRequest
{
    public string Username { get; set; }
}
