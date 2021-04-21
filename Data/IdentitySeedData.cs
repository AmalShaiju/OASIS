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
            var oasisContext = serviceProvider.GetRequiredService<OasisContext>();

            string[] roleNames = { "Admin", "Sales", "Designer", "Management" };

            #region claims
            List<Claim> adminClaim = new List<Claim>();

            adminClaim.Add(new Claim("EmployeeViewClaim", "True"));
            adminClaim.Add(new Claim("EmployeeCreateClaim", "True"));
            adminClaim.Add(new Claim("EmployeeEditClaim", "True"));

            adminClaim.Add(new Claim("CustomerViewClaim", "True"));
            adminClaim.Add(new Claim("CustomerCreateClaim", "True"));
            adminClaim.Add(new Claim("CustomerEditClaim", "True"));

            adminClaim.Add(new Claim("ProjectViewClaim", "True"));
            adminClaim.Add(new Claim("ProjectCreateClaim", "True"));
            adminClaim.Add(new Claim("ProjectEditClaim", "True"));

            adminClaim.Add(new Claim("BidViewClaim", "True"));
            adminClaim.Add(new Claim("BidCreateClaim", "True"));
            adminClaim.Add(new Claim("BidEditClaim", "True"));

            adminClaim.Add(new Claim("ProductViewClaim", "True"));
            adminClaim.Add(new Claim("ProductCreateClaim", "True"));
            adminClaim.Add(new Claim("ProductEditClaim", "True"));
            adminClaim.Add(new Claim("UserRolesViewClaim", "True"));

            List<Claim> salesClaim = new List<Claim>();

            salesClaim.Add(new Claim("EmployeeViewClaim", "False"));
            salesClaim.Add(new Claim("EmployeeCreateClaim", "False"));
            salesClaim.Add(new Claim("EmployeeEditClaim", "False"));

            salesClaim.Add(new Claim("CustomerViewClaim", "True"));
            salesClaim.Add(new Claim("CustomerCreateClaim", "True"));
            salesClaim.Add(new Claim("CustomerEditClaim", "True"));

            salesClaim.Add(new Claim("ProjectViewClaim", "True"));
            salesClaim.Add(new Claim("ProjectCreateClaim", "True"));
            salesClaim.Add(new Claim("ProjectEditClaim", "True"));

            salesClaim.Add(new Claim("BidViewClaim", "False"));
            salesClaim.Add(new Claim("BidCreateClaim", "False"));
            salesClaim.Add(new Claim("BidEditClaim", "False"));

            salesClaim.Add(new Claim("ProductViewClaim", "False"));
            salesClaim.Add(new Claim("ProductCreateClaim", "False"));
            salesClaim.Add(new Claim("ProductEditClaim", "False"));



            List<Claim> designerClaim = new List<Claim>();

            designerClaim.Add(new Claim("EmployeeViewClaim", "False"));
            designerClaim.Add(new Claim("EmployeeCreateClaim", "False"));
            designerClaim.Add(new Claim("EmployeeEditClaim", "False"));

            designerClaim.Add(new Claim("CustomerViewClaim", "False"));
            designerClaim.Add(new Claim("CustomerCreateClaim", "False"));
            designerClaim.Add(new Claim("CustomerEditClaim", "False"));

            designerClaim.Add(new Claim("ProjectViewClaim", "True"));
            designerClaim.Add(new Claim("ProjectCreateClaim", "False"));
            designerClaim.Add(new Claim("ProjectEditClaim", "False"));

            designerClaim.Add(new Claim("BidViewClaim", "True"));
            designerClaim.Add(new Claim("BidCreateClaim", "True"));
            designerClaim.Add(new Claim("BidEditClaim", "True"));

            designerClaim.Add(new Claim("ProductViewClaim", "False"));
            designerClaim.Add(new Claim("ProductCreateClaim", "False"));
            designerClaim.Add(new Claim("ProductEditClaim", "False"));



            List<Claim> managementClaims = new List<Claim>();

            managementClaims.Add(new Claim("EmployeeViewClaim", "False"));
            managementClaims.Add(new Claim("EmployeeCreateClaim", "False"));
            managementClaims.Add(new Claim("EmployeeEditClaim", "False"));

            managementClaims.Add(new Claim("CustomerViewClaim", "False"));
            managementClaims.Add(new Claim("CustomerCreateClaim", "False"));
            managementClaims.Add(new Claim("CustomerEditClaim", "False"));

            managementClaims.Add(new Claim("ProjectViewClaim", "True"));
            managementClaims.Add(new Claim("ProjectCreateClaim", "False"));
            managementClaims.Add(new Claim("ProjectEditClaim", "False"));

            managementClaims.Add(new Claim("BidViewClaim", "True"));
            managementClaims.Add(new Claim("BidCreateClaim", "False"));
            managementClaims.Add(new Claim("BidEditClaim", "True"));

            managementClaims.Add(new Claim("ProductViewClaim", "False"));
            managementClaims.Add(new Claim("ProductCreateClaim", "False"));
            managementClaims.Add(new Claim("ProductEditClaim", "False"));

            #endregion claims

            // create roles 
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));

                    if (roleResult.Succeeded)
                    {

                        if (roleName == "Admin")
                        {
                            foreach (var i in adminClaim)
                            {
                                await RoleManager.AddClaimAsync(await RoleManager.FindByNameAsync("Admin"), i);

                            }
                        }
                        else if (roleName == "Sales")
                        {

                            foreach (var i in salesClaim)
                            {
                                await RoleManager.AddClaimAsync(await RoleManager.FindByNameAsync("Sales"), i);

                            }
                        }
                        else if (roleName == "Designer")
                        {

                            foreach (var i in designerClaim)
                            {
                                await RoleManager.AddClaimAsync(await RoleManager.FindByNameAsync("Designer"), i);

                            }
                        }
                        else
                        {

                            foreach (var i in managementClaims)
                            {
                                await RoleManager.AddClaimAsync(await RoleManager.FindByNameAsync("Management"), i);

                            }
                        }
                    }

                }
            }


            //Create Users 
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var allEmployees = oasisContext.Employees.ToList();

            if (allEmployees.Where(p => p.IsUser == true).Where(p => p.UserName == null).Any())
            {
                foreach (var employee in allEmployees)
                {
                    if (employee.IsUser)
                    {
                        var userName = employee.SetUserName;
                        IdentityUser user = new IdentityUser
                        {
                            UserName = userName,
                            Email = employee.Email
                        };

                        IdentityResult result = userManager.CreateAsync(user, "password").Result;

                        if (result.Succeeded)
                        {
                            employee.UserName = userName;
                            employee.Password = "password";

                            oasisContext.Update(employee);
                            await oasisContext.SaveChangesAsync();

                        }
                    }
                   
                }


            }



            // Add admin account
            if (userManager.FindByEmailAsync("admin1@outlook.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "Admin1",
                    Email = "admin1@outlook.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                    await userManager.AddClaimsAsync(user, adminClaim.AsEnumerable());
                }
            }

        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity;
//using System.Security.Claims;
//using Microsoft.Extensions.DependencyInjection;

//namespace OASIS.Data
//{
//    public static class IdentitySeedData
//    {
//        public static async Task SeedAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
//        {
//            //Create Roles
//            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//            string[] roleNames = { "Admin", "SuperAdmin" };

//            IdentityResult roleResult;
//            foreach (var roleName in roleNames)
//            {
//                var roleExist = await RoleManager.RoleExistsAsync(roleName);
//                if (!roleExist)
//                {
//                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
//                }
//            }
//            //Create Users
//            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
//            if (userManager.FindByEmailAsync("admin1@outlook.com").Result == null)
//            {
//                IdentityUser user = new IdentityUser
//                {
//                    UserName = "admin1@outlook.com",
//                    Email = "admin1@outlook.com"
//                };

//                IdentityResult result = userManager.CreateAsync(user, "password").Result;

//                if (result.Succeeded)
//                {
//                    userManager.AddToRoleAsync(user, "Admin").Wait();
//                }
//            }
//            if (userManager.FindByEmailAsync("super1@outlook.com").Result == null)
//            {
//                IdentityUser user = new IdentityUser
//                {
//                    UserName = "super1@outlook.com",
//                    Email = "super1@outlook.com"
//                };

//                IdentityResult result = userManager.CreateAsync(user, "password").Result;

//                if (result.Succeeded)
//                {
//                    userManager.AddToRoleAsync(user, "SuperAdmin").Wait();
//                }
//            }
//            if (userManager.FindByEmailAsync("user1@outlook.com").Result == null)
//            {
//                IdentityUser user = new IdentityUser
//                {
//                    UserName = "user1@outlook.com",
//                    Email = "user1@outlook.com"
//                };

//                IdentityResult result = userManager.CreateAsync(user, "password").Result;
//                //Not in any role
//            }


//            List<Claim> claimsToadd = new List<Claim>();
//            claimsToadd.Add(new Claim("EmployeeViewClaim", "True"));
//            claimsToadd.Add(new Claim("EmployeeCreateClaim", "True"));
//            claimsToadd.Add(new Claim("EmployeeEditClaim", "False"));

//            claimsToadd.Add(new Claim("CustomerViewClaim", "False"));
//            claimsToadd.Add(new Claim("CustomerCreateClaim", "False"));
//            claimsToadd.Add(new Claim("CustomerEditClaim", "True"));

//            claimsToadd.Add(new Claim("ProjectViewClaim", "True"));
//            claimsToadd.Add(new Claim("ProjectCreateClaim", "False"));
//            claimsToadd.Add(new Claim("ProjectEditClaim", "True"));

//            claimsToadd.Add(new Claim("BidViewClaim", "False"));
//            claimsToadd.Add(new Claim("BidCreateClaim", "False"));
//            claimsToadd.Add(new Claim("BidEditClaim", "True"));

//            claimsToadd.Add(new Claim("ProductViewClaim", "True"));
//            claimsToadd.Add(new Claim("ProductCreateClaim", "False"));
//            claimsToadd.Add(new Claim("ProductEditClaim", "False"));


//            var admin = await RoleManager.FindByNameAsync("Admin");
//            var superAdmin = await RoleManager.FindByNameAsync("SuperAdmin");
//            var adminClaims = await RoleManager.GetClaimsAsync(admin);
//            var superAdminClaims = await RoleManager.GetClaimsAsync(superAdmin);

//            foreach (var i in claimsToadd)
//            {
//                if (!adminClaims.Where(P => P.Type == i.Type).Any())
//                {
//                    await RoleManager.AddClaimAsync(await RoleManager.FindByNameAsync("Admin"), i);

//                }
//            }
//            foreach (var i in claimsToadd)
//            {
//                if (!superAdminClaims.Where(P => P.Type == i.Type).Any())
//                {
//                    await RoleManager.AddClaimAsync(await RoleManager.FindByNameAsync("SuperAdmin"), i);
//                }
//            }

//            //var adminUser = await userManager.FindByEmailAsync("admin1@outlook.com");
//            //var sample = new Claim("EmployeeViewClaim", "True");

//            //await userManager.AddClaimAsync(adminUser, sample);

//        }
//    }
//}
