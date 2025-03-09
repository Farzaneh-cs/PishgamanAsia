using Microsoft.AspNetCore.Authorization;

namespace Carpet.DBContext.Initialize;

public static class AuthorizationPolicies
{
    public static void AddCustomAuthorizationPolicies(AuthorizationOptions options)
    {
        options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));

        options.AddPolicy("CanReadPloicy", policy => policy.RequireRole("Admin","User"));

    }
}

