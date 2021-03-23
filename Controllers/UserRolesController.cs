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


            //Task : get all roles with assigned users count

            var roleToAssign = await _roleManager.FindByNameAsync("SAMPLE ROLE");

            foreach (var i in _context.Users)
            {
                await _userManager.AddToRoleAsync(i, roleToAssign.Name);

            }


            // Returns all roles with the number of users assigned

            var roles =
            from r in _context.Roles
            join ur in _context.UserRoles on r.Id equals ur.RoleId into joined
            from grp in joined.DefaultIfEmpty()
            group r by new { r.Id, r.Name } into grp
            orderby grp.Count() descending
            select new IdentityUserRoleVM
            {
                RoleID = grp.Key.Id,
                RoleName = grp.Key.Name,
                Assigned = grp.Count() 
            };


            
            return View(roles);
        }

        // GET: Bids/Create
        public IActionResult Create()
        {
            IdentityUserRoleVM role = new IdentityUserRoleVM();

            return View(role);
        }

        // POST: Approvals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RoleName")] IdentityUserRoleVM role)
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
            if(Role != null)
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









    }



}
