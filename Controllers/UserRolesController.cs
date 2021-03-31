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

namespace OASIS.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly OasisContext _oasisContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserRolesController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager, OasisContext oasisContext)
        {
            _oasisContext = oasisContext;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        // GET: UserRoles
        public async Task<IActionResult> Index()
        {
            List<IdentityRoleVM> userRoles = await GetAllRoles();
            PopulateDropDownLists();
            var claims = User.Claims.ToList();

            return View("Index", userRoles);
        }

        // GET: UserRoles/Create
        public IActionResult Create()
        {
            IdentityRoleVM role = new IdentityRoleVM();

            return View(role);
        }

        // GET: UserRoles/Edit
        public async Task<IActionResult> Edit(string roleName)
        {
            var roleToUpdate = await _roleManager.FindByNameAsync(roleName);

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
        public async Task<IActionResult> UserClaimEdit(string userName)
        {
            var roleToUpdate = await _userManager.FindByNameAsync(userName);

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
        public IActionResult Create([Bind("RoleName")] IdentityRoleVM role)
        {
            if (ModelState.IsValid)
            {
                CreateRole(role.RoleName);
                return RedirectToAction(nameof(Index));
            }

            return View(role);
        }

        // POST: UserRoles/AddUserToRole
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpGet]
        public async Task<JsonResult> AddUserToRole(string userName, string roleName)
        {
            IdentityUser user = await _userManager.FindByNameAsync(userName);
            var result = _userManager.AddToRoleAsync(user, roleName).Result;
            var employeeName = _oasisContext.Employees.SingleOrDefault(p => p.UserName == userName).FullName;

            if (result.Succeeded)
            {
                //Add all the claims of the role to the user
                var role = await _roleManager.FindByNameAsync(roleName);
                var roleClaims = await _roleManager.GetClaimsAsync(role);
                await _userManager.AddClaimsAsync(user, roleClaims.AsEnumerable());

                return Json(employeeName);
            }

            return Json(null);

        }

        // POST: UserRoles/RemoveUserFromRole
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpGet]
        public async Task<JsonResult> RemoveUserFromRole(string userName, string roleName)
        {
            IdentityUser user = await _userManager.FindByNameAsync(userName);
            var result = _userManager.RemoveFromRoleAsync(user, roleName).Result;

            if (result.Succeeded)
            {
                //remove all the claims of the role to the user
                var role = await _roleManager.FindByNameAsync(roleName);
                var roleClaims = await _roleManager.GetClaimsAsync(role);
                await _userManager.RemoveClaimsAsync(user, roleClaims.AsEnumerable());

                return Json(true);
            }

            return Json(false);

        }

        // POST: UserRoles/LoginUser
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<JsonResult> LoginUser([FromBody] UserAuthenticationVM Loginuser)
        {

            var result = await _signInManager.PasswordSignInAsync(Loginuser.Username,
            Loginuser.Password, Loginuser.RememberMe, false);

            if (result.Succeeded)
            {
                return Json(true);
            }

            return Json(false);
        }

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
                            return Json("Role Privilage updated sucessfuly");
                        }

                    }
                    catch
                    {
                        return Json("Could not update Role Privilage");
                    }


                }
            }
            catch
            {
                return Json("Role does not have the selected Privilage");

            }

            return Json("Could not update Role Privilage");


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
                            return Json("Role Privilage updated sucessfuly");
                        }

                    }
                    catch
                    {
                        return Json("Could not update Role Privilage");
                    }


                }
            }
            catch
            {
                return Json("Role does not have the selected Privilage");

            }

            return Json("Could not update Role Privilage");


        }

        public List<PageClaims> SortClaims(IList<Claim> claims,string roleName)
        {
            List<PageClaims> allClaims = new List<PageClaims>();

            PageClaims empClamis = new PageClaims { PageName = "Employee", Claims = claims.Where(p => p.Type.Contains("Employee")).Select(p => p).ToList(),RoleName= roleName };
            PageClaims cusClamis = new PageClaims { PageName = "Customer", Claims = claims.Where(p => p.Type.Contains("Customer")).Select(p => p).ToList(), RoleName = roleName };
            PageClaims projectClamis = new PageClaims { PageName = "Project", Claims = claims.Where(p => p.Type.Contains("Project")).Select(p => p).ToList(), RoleName = roleName };
            PageClaims bidClamis = new PageClaims { PageName = "Bid", Claims = claims.Where(p => p.Type.Contains("Bid")).Select(p => p).ToList(), RoleName = roleName };
            PageClaims productClamis = new PageClaims { PageName = "Product", Claims = claims.Where(p => p.Type.Contains("Product")).Select(p => p).ToList(), RoleName = roleName };

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

        // get all users in a role
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
        }

        [HttpGet]
        public JsonResult GetEmployees(int? ID)
        {
            return Json(EmployeeSelectList(ID, null));
        }

    }

}



