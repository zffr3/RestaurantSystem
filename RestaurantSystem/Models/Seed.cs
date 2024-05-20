using Microsoft.AspNetCore.Identity;
using RestaurantSystem.Models.Data;
using System.Net;

namespace RestaurantSystem.Models
{
    public class Seed
    {
        public static async Task SeedUserAndRoleAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRole.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRole.Admin));
                if (!await roleManager.RoleExistsAsync(UserRole.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRole.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<Account>>();
                string adminUserEmail = "test@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new Account()
                    {
                        UserName = "rndName",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Address = "testAddress",
                        OrderHistory = new List<Orders>()
                    };
                    await userManager.CreateAsync(newAdminUser, "HardPass@123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRole.Admin);
                }

                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new Account()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Address = "testAddress",
                        OrderHistory = new List<Orders>()

                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRole.User);
                }
            }
        }
    }
}
