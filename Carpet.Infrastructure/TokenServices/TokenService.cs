namespace Carpet.Infrastructure.TokenServices;

public class TokenService : ITokenService
{
    private readonly List<string> _invalidatedTokens = new List<string>();

    public void InvalidateTokens(string username)
    {
        // Mock: Retrieve and invalidate tokens for the user
        var tokens = GetTokensByUsername(username);
        _invalidatedTokens.AddRange(tokens);
    }

    public bool IsTokenValid(string token)
    {
        return !_invalidatedTokens.Contains(token);
    }

    private List<string> GetTokensByUsername(string username)
    {
        return new List<string> { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI0NDkzZjdlMy1lZjQ1LTQ2NzAtOGY1OC00ZTczNGI1YjAyZTEiLCJ1bmlxdWVfbmFtZSI6InVzZXIxIiwicm9sZSI6IlVzZXIiLCJuYmYiOjE3NDEwMTE3NzYsImV4cCI6MTc0MTA5ODE3NiwiaWF0IjoxNzQxMDExNzc2LCJpc3MiOiJ5b3VyX2lzc3VlciIsImF1ZCI6InlvdXJfYXVkaWVuY2UifQ.GKElhdcq3wDapl8dLEIBx94Iwnj_IxqSq9maKOjgi4U" };
    }
}
