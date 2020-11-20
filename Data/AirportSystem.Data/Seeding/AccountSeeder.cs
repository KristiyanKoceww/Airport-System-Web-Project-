namespace AirportSystem.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AirportSystem.Common;
    using AirportSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class AccountSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            await CreateUser(
               userManager,
               roleManager,
               GlobalConstants.AdminEmail,
               GlobalConstants.AdministratorRoleName);

            await CreateUser(
              userManager,
              roleManager,
              GlobalConstants.UserEmail
              );
        }

        private static async Task CreateUser(
           UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, string email, string roleName = null)
        {
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
            };

            var password = GlobalConstants.Password;

            if (roleName != null)
            {
                var role = await roleManager.FindByNameAsync(roleName);

                if (!userManager.Users.Any(x => x.Roles.Any(x => x.RoleId == role.Id)))
                {
                    var result = await userManager.CreateAsync(user, password);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, roleName);
                    }
                }
            }
            else
            {
                if (!userManager.Users.Any(x => x.Roles.Count() == 0))
                {
                    var result = await userManager.CreateAsync(user, password);
                }
            }
        }
    }
}
