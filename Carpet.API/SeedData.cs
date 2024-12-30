using Carpet.DBContext.Initialize;
using Carpet.Domain.UsersRoles;
using Microsoft.AspNetCore.Identity;

namespace Carpet.API;

public static class SeedData
{
    public async static Task SeedUserRole(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            try
            {
                await RoleInitializer.Initialize(serviceProvider);
            }
            catch (Exception ex)
            {
                var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while seeding roles.");
            }
        }

        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            string userName = "admin";
            string password = "$Admin123";


            if (await userManager.FindByNameAsync(userName) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = userName,
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    // Log or handle errors if user creation fails
                    throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
        }

    }
}
