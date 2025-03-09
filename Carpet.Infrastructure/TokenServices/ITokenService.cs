namespace Carpet.Infrastructure.TokenServices;

public interface ITokenService
{
    void InvalidateTokens(string username);
    bool IsTokenValid(string token);
}
