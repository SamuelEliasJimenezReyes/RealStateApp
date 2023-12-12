using Microsoft.AspNetCore.Identity;
using RealStateApp.Core.Application.Enums;
using RealStateApp.Infrastructure.Identity.Entities;


namespace RealStateApp.Infrastructure.Identity.Seeds
{
    public static class DefaultAgentUser
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            AppUser defaultUser = new();
            defaultUser.UserName = "007";
            defaultUser.Email = "agent@email.com";
            defaultUser.Name = "James";
            defaultUser.LastName = "Bond";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumberConfirmed = true;
            defaultUser.IsActive = true;
            defaultUser.Id = "77ab3005-7d85-42e5-8dfa-b3ffdbb7f0f5";

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Agent.ToString());
                }
            }
        }

    }
}
