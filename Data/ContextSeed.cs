using GestionChevauxBlazor.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionChevauxBlazor.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager, Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Moniteur.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Cavalier.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Technique.ToString()));
        }

        public static async Task SeedSuperAdminAsync(Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager, Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "superadmin@sa.com",
                Email = "superadmin@sa.com",
                FirstName = "Big",
                LastName = "Boss",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Password@0");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Cavalier.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Moniteur.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Technique.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.SuperAdmin.ToString());
                }

            }
        }
    }
}
