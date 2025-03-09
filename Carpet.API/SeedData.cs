using Carpet.DBContext.Initialize;
using Carpet.Domain.UsersRoles;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Carpet.API;

public static class SeedData
{
    public async static Task SeedUserRole(WebApplication app,
                             IConfiguration configuration)
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

            var seedUsers = configuration.GetSection("SeedUsers").Get<List<SeedUser>>();
            
            foreach (var item in seedUsers)
            {
                if (await userManager.FindByNameAsync(item.Username) == null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = item.Username,
                    };

                    var result = await userManager.CreateAsync(user, item.Password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, item.Role);
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
}
