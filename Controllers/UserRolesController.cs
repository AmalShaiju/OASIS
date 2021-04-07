using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OASIS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OASIS.ViewModels;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using OASIS.Utilities;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace OASIS.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly OasisContext _oasisContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailSender _emailSender;


        public UserRolesController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager, OasisContext oasisContext, IEmailSender emailSender)
        {
            _oasisContext = oasisContext;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        // GET: UserRoles
        [Authorize(Policy = "UserRolesViewPolicy")]
        public async Task<IActionResult> Index()
        {
            List<IdentityRoleVM> userRoles = await GetAllRoles();
            PopulateDropDownLists();
            return View("Index", userRoles);
        }

        // GET: UserRoles/Create
        [Authorize(Policy = "UserRolesViewPolicy")]
        public IActionResult Create()
        {
            IdentityRoleVM role = new IdentityRoleVM();

            return View(role);
        }

        // GET: UserRoles/Edit
        [Authorize(Policy = "UserRolesViewPolicy")]
        public async Task<IActionResult> Edit(string roleName)
        {
            var roleToUpdate = await _roleManager.FindByNameAsync(roleName);

            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "UserRoles");


            if (roleToUpdate != null)
            {
                var roleClaims = await _roleManager.GetClaimsAsync(roleToUpdate);
                var sorted = SortClaims(roleClaims, roleName).AsEnumerable();

                return View(sorted);
            }
            else
            {
                return NotFound();
            }
        }


        // GET: UserRoles/UserClaimEdit
        [Authorize(Policy = "UserRolesViewPolicy")]
        public async Task<IActionResult> UserClaimEdit(string userName)
        {
            var roleToUpdate = await _userManager.FindByNameAsync(userName);

            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "UserRoles");


            if (roleToUpdate != null)
            {
                var userClaims = await _userManager.GetClaimsAsync(roleToUpdate);
                var sorted = SortClaims(userClaims, userName).AsEnumerable();

                return View("UserClaimsEdit", sorted);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: UserRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "UserRolesViewPolicy")]
        public IActionResult Create([Bind("RoleName")] IdentityRoleVM role)
        {
            if (ModelState.IsValid)
            {
                CreateRole(role.RoleName);
                return RedirectToAction(nameof(Index));
            }

            return View(role);
        }



        // Helper Functions

        public async void CreateRole(string Role)
        {
            if (Role != null)
            {
                //check if role exist in db
                if (!await _roleManager.RoleExistsAsync(Role))
                {
                    await _roleManager.CreateAsync((new IdentityRole(Role)));

                }
            }

        }

        public List<PageClaims> SortClaims(IList<Claim> claims, string roleName)
        {
            List<PageClaims> allClaims = new List<PageClaims>();

            PageClaims empClamis = new PageClaims { PageName = "Employee", Claims = claims.Where(p => p.Type.Contains("Employee")).Select(p => p).OrderBy(p => p.Type).ToList(), RoleName = roleName };
            PageClaims cusClamis = new PageClaims { PageName = "Customer", Claims = claims.Where(p => p.Type.Contains("Customer")).Select(p => p).OrderBy(p => p.Type).ToList(), RoleName = roleName };
            PageClaims projectClamis = new PageClaims { PageName = "Project", Claims = claims.Where(p => p.Type.Contains("Project")).Select(p => p).OrderBy(p => p.Type).ToList(), RoleName = roleName };
            PageClaims bidClamis = new PageClaims { PageName = "Bid", Claims = claims.Where(p => p.Type.Contains("Bid")).Select(p => p).OrderBy(p => p.Type).ToList(), RoleName = roleName };
            PageClaims productClamis = new PageClaims { PageName = "Product", Claims = claims.Where(p => p.Type.Contains("Product")).Select(p => p).OrderBy(p => p.Type).ToList(), RoleName = roleName };

            allClaims.Add(empClamis);
            allClaims.Add(cusClamis);
            allClaims.Add(projectClamis);
            allClaims.Add(bidClamis);
            allClaims.Add(productClamis);

            return allClaims;
        }

        public async Task<List<IdentityRoleVM>> GetAllRoles()
        {
            List<IdentityUserVM> users = new List<IdentityUserVM>();
            List<IdentityRoleVM> roles = new List<IdentityRoleVM>();

            foreach (var i in _context.Users)
            {
                users.Add(new IdentityUserVM
                {
                    UserID = i.Id,
                    UserName = i.UserName,
                    Roles = await _userManager.GetRolesAsync(i)
                });
            }

            foreach (var i in _context.Roles)
            {
                roles.Add(new IdentityRoleVM
                {
                    RoleID = i.Id,
                    RoleName = i.Name,
                    AssignedCount = users.Where(p => p.Roles.Contains(i.Name)).Count(),
                    AssignedUsers = users.Where(p => p.Roles.Contains(i.Name)).ToList()
                });
            }

            return roles;
        }

        public async Task<List<IdentityUserVM>> GetUserByRole(IdentityRoleVM role)
        {
            List<IdentityUserVM> users = new List<IdentityUserVM>();

            foreach (var i in _context.Users)
            {
                users.Add(new IdentityUserVM
                {
                    UserID = i.Id,
                    UserName = i.UserName,
                    Roles = await _userManager.GetRolesAsync(i)
                });
            }


            return users.Where(u => u.Roles.Contains(role.RoleName)).ToList();
        }

        private SelectList RoleSelectList(int? selectedId)
        {
            return new SelectList(_oasisContext.Roles
                .OrderBy(d => d.Name), "ID", "Name", selectedId);
        }

        private SelectList EmployeeSelectList(int? RoleID, int? selectedId)
        {
            var query = from c in _oasisContext.Employees
                        .Include(c => c.Role)
                        .Where(p => p.IsUser != false)
                        select c;

            if (RoleID.HasValue)
            {
                query = query.Where(p => p.RoleID == RoleID);
            }
            return new SelectList(query.OrderBy(p => p.LastName).ThenBy(p => p.FirstName), "UserName", "FormalName", selectedId);
        }

        private void PopulateDropDownLists()
        {
            ViewData["RoleID"] = RoleSelectList(null);
            ViewData["EmployeeID"] = EmployeeSelectList(null, null);
            ViewData["UserRoleID"] = new SelectList(_roleManager.Roles.OrderBy(p => p.Name), "Name", "Name");

        }

        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }


        // Ajax Call Functions

        [HttpGet]
        public JsonResult GetEmployees(int? ID)
        {
            return Json(EmployeeSelectList(ID, null));

        }

        [HttpGet]
        public async Task<JsonResult> UpdateClaims(string claimType, string claimValue, string roleName)
        {
            // get the role taht require claim update
            var role = await _roleManager.FindByNameAsync(roleName);

            // get all claim of the role
            var allRoleClaims = await _roleManager.GetClaimsAsync(role);

            // get the claim that need to be changed from all roleclaims
            var claimToDelete = allRoleClaims.SingleOrDefault(p => p.Type == claimType);

            try
            {
                // chcek if there is any change between db and user input
                if (claimToDelete.Value != claimType || claimToDelete.Value != claimValue)
                {
                    try
                    {
                        // delete the claim from user
                        var deleteResult = await _roleManager.RemoveClaimAsync(role, claimToDelete);

                        // Add the claim back in with the new claim value
                        if (deleteResult.Succeeded)
                        {
                            var addResult = await _roleManager.AddClaimAsync(role, new Claim(claimType, claimValue));

                            var returnVal = new { success = true, msg = $"{roleName} permission updated successfully" };
                            return Json(returnVal);
                        }

                    }
                    catch
                    {
                        var returnVal = new { success = false, msg = $"Failed to update {roleName} Privilage" };
                        return Json(returnVal);
                    }


                }
            }
            catch
            {
                var returnVal = new { success = false, msg = $"{roleName} does not have the selected Privilage" };
                return Json(returnVal);

            }

            return Json(new { success = false, msg = $"Something went wrong, Please try again later" });


        }

        [HttpGet]
        public async Task<JsonResult> UpdateUserClaims(string claimType, string claimValue, string userName)
        {
            // get the role taht require claim update
            var user = await _userManager.FindByNameAsync(userName);

            // get all claim of the role
            var allUserClaims = await _userManager.GetClaimsAsync(user);

            // get the claim that need to be changed from all roleclaims
            var claimToDelete = allUserClaims.SingleOrDefault(p => p.Type == claimType);

            try
            {
                // chcek if there is any change between db and user input
                if (claimToDelete.Value != claimType || claimToDelete.Value != claimValue)
                {
                    try
                    {
                        // delete the claim from user
                        var deleteResult = await _userManager.RemoveClaimAsync(user, claimToDelete);

                        // Add the claim back in with the new claim value
                        if (deleteResult.Succeeded)
                        {
                            var addResult = await _userManager.AddClaimAsync(user, new Claim(claimType, claimValue));

                            var returnVal = new { success = true, msg = $"{userName} permissions updated successfully" };
                            return Json(returnVal);
                        }

                    }
                    catch
                    {
                        var returnVal = new { success = false, msg = $"Failed to update {userName} permissions" };
                        return Json(returnVal);
                    }


                }
            }
            catch
            {
                var returnVal = new { success = false, msg = $"{userName} does not contain selected permission" };
                return Json(returnVal);

            }

            return Json(new { success = false, msg = $"Something went Wrong, please try again later" });


        }

        [HttpGet]
        public async Task<JsonResult> AddUserToRole(string userName, string roleName)
        {
            IdentityUser user = await _userManager.FindByNameAsync(userName);
            var employeeName = _oasisContext.Employees.SingleOrDefault(p => p.UserName == userName).FullName;
            if (!await _userManager.IsInRoleAsync(user, roleName))
            {
                var result = _userManager.AddToRoleAsync(user, roleName).Result;


                if (result.Succeeded)
                {
                    //Add all the claims of the role to the user
                    var role = await _roleManager.FindByNameAsync(roleName);
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    await _userManager.AddClaimsAsync(user, roleClaims.AsEnumerable());

                    var returnVal = new { success = true, employeeName = employeeName, msg = $"{employeeName} was successfully added to {roleName}" };
                    return Json(returnVal);

                }
                else
                {
                    var returnVal = new { success = false, msg = $"Failed to add {employeeName} to {roleName}" };
                    return Json(returnVal);

                }



            }
            else
            {
                var returnVal = new { success = false, msg = $"{employeeName} already exist in the role {roleName}" };

                return Json(returnVal);
            }
        }

        [HttpGet]
        public async Task<JsonResult> RemoveUserFromRole(string userName, string roleName)
        {
            IdentityUser user = await _userManager.FindByNameAsync(userName);
            var employeeName = _oasisContext.Employees.SingleOrDefault(p => p.UserName == userName).FullName;

            if (await _userManager.IsInRoleAsync(user, roleName))
            {
                var result = _userManager.RemoveFromRoleAsync(user, roleName).Result;
                if (result.Succeeded)
                {
                    //remove all the claims of the role to the user
                    var role = await _roleManager.FindByNameAsync(roleName);
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    await _userManager.RemoveClaimsAsync(user, roleClaims.AsEnumerable());

                    var returnVal = new { success = true, employeeName = employeeName, msg = $"{employeeName} was successfully removed from {roleName}" };
                    return Json(returnVal);
                }
                else
                {
                    var returnVal = new { success = false, msg = $"Failed to remove {employeeName} from {roleName}" };
                    return Json(returnVal);
                }
            }
            else
            {
                var returnVal = new { success = false, msg = $"{employeeName}  does not exist in the role {roleName}" };
                return Json(returnVal);
            }

        }

        [HttpPost]
        public async Task<JsonResult> LoginUser([FromBody] UserAuthenticationVM Loginuser)
        {
            if(Loginuser.Username !="" && Loginuser.Password != "")
            {
                var user = await _userManager.FindByNameAsync(Loginuser.Username) ?? await _userManager.FindByEmailAsync(Loginuser.Username);

                if (user != null)
                {
                    try
                    {
                        var result = await _signInManager.PasswordSignInAsync(user.UserName,
                        Loginuser.Password, Loginuser.RememberMe, false);

                        if (result.Succeeded)
                        {
                            var returnVal = new { success = true, msg = $"Welcome {Loginuser.Username}" };

                            return (Json(returnVal));
                        }
                        else
                        {
                            var returnVal = new { success = false, msg = $"Username and password does not match, Please try again." };

                            return (Json(returnVal));
                        }
                    }
                    catch
                    {
                        var returnVal = new { success = false, msg = $"Something went wrong, Try again later" };

                        return (Json(returnVal));
                    }
                }
                else
                {
                    var returnVal = new { success = false, msg = $"There is no user with the username {Loginuser.Username}" };

                    return (Json(returnVal));
                }

            }
            else
            {
                if(Loginuser.Username == "")
                {
                    var returnVal = new { success = false, msg = $"Please enter your username!" };
                    return (Json(returnVal));

                }
                
                else if(Loginuser.Password == "")
                {
                    var returnVal = new { success = false, msg = $"Please enter your password!" };
                    return (Json(returnVal));
                }
                else
                {
                    return (Json(new { susuccess= false, msg = $"Something went wrong, Try again later" }));
                }

            }



        }

        [HttpPost]
        public async Task<JsonResult> ForgotPassword([FromBody] string userEmail)
        {
            if(userEmail != "")
            {
                try
                {
                    var newPassword = CreatePassword(8);

                    // Update user password
                    IdentityUser user = await _userManager.FindByEmailAsync(userEmail);

                    if(user != null)
                    {
                        var passResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                        await _userManager.ResetPasswordAsync(user, passResetToken, newPassword);
                        await _userManager.UpdateAsync(user);

                        var msg = new EmailMessage()
                        {
                            ToAddress = user.Email,
                            Subject = "Forgotten Password - OASIS",
                            Content = "<p> Please use the password given below to login to your Account and please change it as you wish "+ "<br/>"+
                                             "<a>http://oasis-analytics.azurewebsites.net/</a>" + "<hr>" +"<b/r>"+
                                             $"<p>UserName : {user.UserName}</p>" +
                                             $"<p>Password : {newPassword} </p>"
                        };

                        await _emailSender.SendEmailAsync(msg.ToAddress, msg.Subject, msg.Content);

                        var returnVal = new { success = true, msg = $"Password was reset and sent to {user.Email}, Please check your email." };

                        return (Json(returnVal));

                    }
                    else
                    {
                        var returnVal = new { success = false, msg = $"There is no user registered with the email {userEmail}" };

                        return (Json(returnVal));
                    }

                }
                catch
                {
                    var returnVal = new { success = false, msg = $"Something went wrong, Try again later." };

                    return (Json(returnVal));
                }
            }
            else
            {
                var returnVal = new { success = false, msg = $"Please enter the email registered with the user!" };

                return (Json(returnVal));
            }   
        }
        


    }

}



