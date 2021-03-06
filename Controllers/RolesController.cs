﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OASIS.Data;
using OASIS.Models;
using OASIS.Utilities;

namespace OASIS.Controllers
{
    public class RolesController : Controller
    {
        private readonly OasisContext _context;

        public RolesController(OasisContext context)
        {
            _context = context;
        }

        // GET: Roles
        public async Task<IActionResult> Index(int? page, int? pageSizeID)
        {
            var role = from r in _context.Roles
                       select r;
            //For Paging
            int pageSize;
            if (pageSizeID.HasValue)
            {
                //Value selected from DDL so use and save it to Cookie
                pageSize = pageSizeID.GetValueOrDefault();
                CookieHelper.CookieSet(HttpContext, "pageSizeValue", pageSize.ToString(), 30);
            }
            else
            {
                //Not selected so see if it is in Cookie
                pageSize = Convert.ToInt32(HttpContext.Request.Cookies["pageSizeValue"]);
            }
            pageSize = (pageSize == 0) ? 5 : pageSize;
            ViewData["pageSizeID"] =
                new SelectList(new[] { "3", "5", "10", "20", "30", "40", "50", "100", "500" }, pageSize.ToString());
            var pagedData = await PaginatedList<Role>.CreateAsync(role.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var role = await _context.Roles
                        .Include(p => p.Employees)
                        .FirstOrDefaultAsync(m => m.ID == id);

            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Roles");

            if (id == null)
            {
                return NotFound();
            }

            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Roles");
            if (!TempData.ContainsKey("fromProject"))
                TempData["fromProject"] = "False";

            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,LabourCostPerHr,LabourPricePerHr")] Role role, int employeeTrue)
        {
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Roles");

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(role);
                    await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                    if (employeeTrue == 1)
                    {
                        return RedirectToAction(actionName: "Create", controllerName: "Employees", new {roleID = role.ID });
                    }

                    return RedirectToAction("Details", new { role.ID });

                }
            }
            catch (DbUpdateException dex)
            {
                if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed: Roles.Name"))
                {
                    ModelState.AddModelError("Name", "Unable to save changes.You cannot have duplicate Role Names.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            return View(role);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Roles");

            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Byte[] RowVersion)
        {
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Roles");

            //Role to update
            var roleToUpdate = await _context.Roles.SingleOrDefaultAsync(p => p.ID == id);

            if (roleToUpdate == null)
            {
                return NotFound();
            }

            _context.Entry(roleToUpdate).Property("RowVersion").OriginalValue = RowVersion;

            if (await TryUpdateModelAsync<Role>(roleToUpdate, "",
                p => p.Name, p => p.LabourCostPerHr, p => p.LabourPricePerHr))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                    return RedirectToAction("Details", new { roleToUpdate.ID });

                }

                catch (DbUpdateConcurrencyException ex)// Added for concurrency
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Role)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError("",
                            "Unable to save changes. The Role was deleted by another user.");
                    }
                    else
                    {
                        var databaseValues = (Role)databaseEntry.ToObject();
                        if (databaseValues.Name != clientValues.Name)
                            ModelState.AddModelError("Name", "Current value: "
                                + databaseValues.Name);
                        if (databaseValues.LabourCostPerHr != clientValues.LabourCostPerHr)
                            ModelState.AddModelError("LabourCostPerHr", "Current value: "
                                + databaseValues.LabourCostPerHr);
                        if (databaseValues.LabourPricePerHr != clientValues.LabourPricePerHr)
                            ModelState.AddModelError("LabourPricePerHr", "Current value: "
                                + databaseValues.LabourPricePerHr);


                        ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                                + "was modified by another user after you received your values. The "
                                + "edit operation was canceled and the current values in the database "
                                + "have been displayed. If you still want to save your version of this record, click "
                                + "the Save button again. Otherwise click the 'Back to List' hyperlink.");
                        roleToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
                catch (DbUpdateException dex)
                {
                    if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed: Roles.Name"))
                    {
                        ModelState.AddModelError("Name", "Unable to save changes.You cannot have duplicate Role Names.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                    }
                }


            }
            return View(roleToUpdate);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Projects");


            var role = await _context.Roles
                         .Include(p => p.Employees)
                         .FirstOrDefaultAsync(m => m.ID == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Projects");

            var role = await _context.Roles
                         .Include(p => p.Employees)
                         .FirstOrDefaultAsync(m => m.ID == id);
            try
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));\
                return Redirect(ViewData["returnURL"].ToString());

            }
            catch (InvalidOperationException dex)
            {
                if (dex.GetBaseException().Message.Contains("foreign key"))
                {
                    ModelState.AddModelError("", "Unable to Delete Role. You cannot delete a Role that has Employees assigned.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            catch (DbUpdateException dex)
            {
                if (dex.GetBaseException().Message.Contains("FOREIGN KEY constraint failed"))
                {
                    ModelState.AddModelError("", "Unable to Delete Role. You cannot delete a Role that has Employees assigned.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            return View(role);

        }

        private bool RoleExists(int id)
        {
            return _context.Roles.Any(e => e.ID == id);
        }
    }
}
