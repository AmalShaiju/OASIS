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

        public UserRolesController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: UserRoles
        public async Task<IActionResult> Index()
        {

            // Create a list of user with thier roles assigned
            List<IdentityUserVM> users = new List<IdentityUserVM>();
            foreach (var i in _context.Users)
            {
                users.Add(new IdentityUserVM { UserID = i.Id, UserName = i.UserName, Roles = await _userManager.GetRolesAsync(i) });
            }

            // Return all roles with the number of users assigned
            var roles =
            from r in _context.Roles.AsEnumerable()
            join ur in _context.UserRoles on r.Id equals ur.RoleId
            join u in _context.Users on ur.UserId equals u.Id into joined
            from grp in joined.DefaultIfEmpty()
            group r by new { r.Id, r.Name } into grp
            orderby grp.Count() descending
            select new IdentityRoleVM
            {
                RoleID = grp.Key.Id,
                RoleName = grp.Key.Name,
                AssignedUsers = users.Where(p => p.Roles.Contains(grp.Key.Name)).ToList(),
                AssignedCount = users.Where(p => p.Roles.Contains(grp.Key.Name)).Count()
            };
            
            return View("Index",roles);
        }

        // GET: Bids/Create
        public IActionResult Create()
        {
            IdentityRoleVM role = new IdentityRoleVM();

            return View(role);
        }

        // POST: Approvals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RoleName")] IdentityRoleVM role)
        {
            if (ModelState.IsValid)
            {
                UpateRole(role.RoleName);
                return RedirectToAction(nameof(Index));
            }

            return View(role);
        }

        public async void UpateRole(string Role)
        {
            if (Role != null)
            {
                //check if role exist in db
                if (await _roleManager.RoleExistsAsync(Role))
                {
                    // change name if role exist
                    var roleToAdd = await _roleManager.FindByNameAsync(Role);
                    roleToAdd.Name = Role;
                    await _roleManager.UpdateAsync(roleToAdd);
                }
                else  // role does not exist add role to db
                {
                    await _roleManager.CreateAsync((new IdentityRole(Role)));
                }

            }


        }

        public IQueryable<IdentityUserVM> GetUserByRole(string RoleName)
        {
            return from r in _context.Roles
                   join ur in _context.UserRoles on r.Id equals ur.RoleId  //into joined
                   join u in _context.Users on ur.UserId equals u.Id
                   where r.Name.Contains(RoleName)
                   select new IdentityUserVM { UserName = u.UserName, UserID = u.Id };
        }









    }



}
