﻿using Microsoft.AspNetCore.Identity;
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
                return Json(true);
            }

            return Json(false);

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



