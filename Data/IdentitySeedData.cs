using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace OASIS.Data
{
    public static class IdentitySeedData
    {
        public static async Task SeedAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            //Create Roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin", "SuperAdmin" };

            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            //Create Users
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            if (userManager.FindByEmailAsync("admin1@outlook.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "admin1@outlook.com",
                    Email = "admin1@outlook.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
            if (userManager.FindByEmailAsync("super1@outlook.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "super1@outlook.com",
                    Email = "super1@outlook.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "SuperAdmin").Wait();
                }
            }
            if (userManager.FindByEmailAsync("user1@outlook.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "user1@outlook.com",
                    Email = "user1@outlook.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;
                //Not in any role
            }


            List<Claim> claimsToadd = new List<Claim>();
            claimsToadd.Add(new Claim("EmployeeViewClaim", "True"));
            claimsToadd.Add(new Claim("EmployeeCreateClaim", "True"));
            claimsToadd.Add(new Claim("EmployeeEditClaim", "False"));

            claimsToadd.Add(new Claim("CustomerViewClaim", "False"));
            claimsToadd.Add(new Claim("CustomerCreateClaim", "False"));
            claimsToadd.Add(new Claim("CustomerEditClaim", "True"));

            claimsToadd.Add(new Claim("ProjectViewClaim", "True"));
            claimsToadd.Add(new Claim("ProjectCreateClaim", "False"));
            claimsToadd.Add(new Claim("ProjectEditClaim", "True"));

            claimsToadd.Add(new Claim("BidViewClaim", "False"));
            claimsToadd.Add(new Claim("BidCreateClaim", "False"));
            claimsToadd.Add(new Claim("BidEditClaim", "True"));

            claimsToadd.Add(new Claim("ProductViewClaim", "True"));
            claimsToadd.Add(new Claim("ProductCreateClaim", "False"));
            claimsToadd.Add(new Claim("ProductEditClaim", "False"));


            var admin = await RoleManager.FindByNameAsync("Admin");
            var superAdmin = await RoleManager.FindByNameAsync("SuperAdmin");
            var adminClaims = await RoleManager.GetClaimsAsync(admin);
            var superAdminClaims = await RoleManager.GetClaimsAsync(superAdmin);

            foreach (var i in claimsToadd)
            {
                if (!adminClaims.Where(P => P.Type == i.Type).Any())
                {
                    await RoleManager.AddClaimAsync(await RoleManager.FindByNameAsync("Admin"), i);

                }
            }
            foreach (var i in claimsToadd)
            {
                if (!superAdminClaims.Where(P => P.Type == i.Type).Any())
                {
                    await RoleManager.AddClaimAsync(await RoleManager.FindByNameAsync("SuperAdmin"), i);
                }
            }

            //var adminUser = await userManager.FindByEmailAsync("admin1@outlook.com");
            //var sample = new Claim("EmployeeViewClaim", "True");

            //await userManager.AddClaimAsync(adminUser, sample);

        }
    }
}
