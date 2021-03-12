using System;
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
    public class ApprovalStatusController : Controller
    {
        private readonly OasisContext _context;

        public ApprovalStatusController(OasisContext context)
        {
            _context = context;
        }

        // GET: ApprovalStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApprovalStatuses.ToListAsync());
        }

        // GET: ApprovalStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "ApprovalStatus");

            var approvalStatus = await _context.ApprovalStatuses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (approvalStatus == null)
            {
                return NotFound();
            }

            return View(approvalStatus);
        }

        // GET: ApprovalStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApprovalStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] ApprovalStatus approvalStatus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(approvalStatus);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", new { approvalStatus.ID });
                }
            }
            catch (DbUpdateException dex)
            {

                if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed: ApprovalStatus.Name"))
                {
                    ModelState.AddModelError("Name", "Unable to save changes.You cannot have duplicate Approval Status Name.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes.Try again,and if the problem persists see your system administrator.");
                }
            }

            return View(approvalStatus);

        }

        // GET: ApprovalStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approvalStatus = await _context.ApprovalStatuses.FindAsync(id);
            if (approvalStatus == null)
            {
                return NotFound();
            }
            return View(approvalStatus);
        }

        // POST: ApprovalStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] ApprovalStatus approvalStatus)
        {
            if (id != approvalStatus.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(approvalStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApprovalStatusExists(approvalStatus.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException dex)
                {

                    if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed: ApprovalStatus.Name"))
                    {
                        ModelState.AddModelError("Name", "Unable to save changes.You cannot have duplicate Approval Status Name.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes.Try again,and if the problem persists see your system administrator.");
                    }
                }

                return RedirectToAction("Index", new { approvalStatus.ID });

            }
            return View(approvalStatus);
        }

        // GET: ApprovalStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approvalStatus = await _context.ApprovalStatuses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (approvalStatus == null)
            {
                return NotFound();
            }

            return View(approvalStatus);
        }

        // POST: ApprovalStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var approvalStatus = await _context.ApprovalStatuses.FindAsync(id);
            _context.ApprovalStatuses.Remove(approvalStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApprovalStatusExists(int id)
        {
            return _context.ApprovalStatuses.Any(e => e.ID == id);
        }
    }
}
