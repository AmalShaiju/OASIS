using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OASIS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OASIS.ViewModels;

namespace OASIS.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityRole> _signInManager;

        public UserRolesController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityRole> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        // GET: UserRoles
        public async Task<IActionResult> Index()
        {
            List<IdentityRoleVM> userRoles = await GetAllRoles();
            return View("Index", userRoles);
        }

        // GET: UserRoles/Create
        public IActionResult Create()
        {
            IdentityRoleVM role = new IdentityRoleVM();

            return View(role);
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

        // POST: UserRoles/Authorization
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Authorization(UserAuthenticationVM Loginuser)
        {

            var result = await _signInManager.PasswordSignInAsync(Loginuser.Username,
               Loginuser.Password, Loginuser.RememberMe, false);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(Loginuser.ReturnUrl) && Url.IsLocalUrl(Loginuser.ReturnUrl))
                {
                    return Json(Loginuser.ReturnUrl);
                }
                else
                {
                    return Json("Url is not valid");
                }
            }

            return Json("faied to sign in user");
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

    }



}
