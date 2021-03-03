using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OASIS.Data;
using OASIS.Models;

namespace OASIS.Controllers
{
    public class BidStatusController : Controller
    {
        private readonly OasisContext _context;

        public BidStatusController(OasisContext context)
        {
            _context = context;
        }

        // GET: BidStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.BidStatuses.ToListAsync());
        }

        // GET: BidStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidStatus = await _context.BidStatuses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bidStatus == null)
            {
                return NotFound();
            }

            return View(bidStatus);
        }

        // GET: BidStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BidStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] BidStatus bidStatus)
        {
           try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(bidStatus);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", new { bidStatus.ID });
                }
            }
            catch (DbUpdateException dex)
            {

                if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed: BidStatus.Name"))
                {
                    ModelState.AddModelError("Name", "Unable to save changes.You cannot have duplicate Bid Status Name.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes.Try again,and if the problem persists see your system administrator.");
                }
            }

            return View(bidStatus);
        }

        // GET: BidStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidStatus = await _context.BidStatuses.FindAsync(id);
            if (bidStatus == null)
            {
                return NotFound();
            }
            return View(bidStatus);
        }

        // POST: BidStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] BidStatus bidStatus)
        {
            if (id != bidStatus.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bidStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidStatusExists(bidStatus.ID))
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

                    if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed: BidStatus.Name"))
                    {
                        ModelState.AddModelError("Name", "Unable to save changes.You cannot have duplicate Bid Status Name.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes.Try again,and if the problem persists see your system administrator.");
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            return View(bidStatus);
        }

        // GET: BidStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidStatus = await _context.BidStatuses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bidStatus == null)
            {
                return NotFound();
            }

            return View(bidStatus);
        }

        // POST: BidStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bidStatus = await _context.BidStatuses
                            .Include(p => p.Bids)
                         .FirstOrDefaultAsync(m => m.ID == id);
            try
            {
                _context.BidStatuses.Remove(bidStatus);
                await _context.SaveChangesAsync();
                //  return RedirectToAction(nameof(Index));
                return Redirect(ViewData["returnURL"].ToString());

            }
            catch (InvalidOperationException dex)
            {
                if (dex.GetBaseException().Message.Contains("foreign key"))
                {
                    ModelState.AddModelError("", "Unable to Delete Bid Status. You cannot delete a Bid Status that has Bids assigned.");
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
                    ModelState.AddModelError("", "Unable to Delete Bid Status. You cannot delete a Role that has Bids assigned.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            return View(bidStatus);
        }

        private bool BidStatusExists(int id)
        {
            return _context.BidStatuses.Any(e => e.ID == id);
        }
    }
}
