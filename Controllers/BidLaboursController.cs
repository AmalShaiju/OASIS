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
    public class BidLaboursController : Controller
    {
        private readonly OasisContext _context;

        public BidLaboursController(OasisContext context)
        {
            _context = context;
        }

        // GET: BidLabours
        public async Task<IActionResult> Index()
        {
            var oasisContext = _context.BidLabours.Include(b => b.Bid).Include(b => b.Role);
            return View(await oasisContext.ToListAsync());
        }

        // GET: BidLabours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidLabour = await _context.BidLabours
                .Include(b => b.Bid)
                .Include(b => b.Role)
                .FirstOrDefaultAsync(m => m.BidID == id);
            if (bidLabour == null)
            {
                return NotFound();
            }

            return View(bidLabour);
        }

        // GET: BidLabours/Create
        public IActionResult Create()
        {
            ViewData["BidID"] = new SelectList(_context.Bids, "ID", "ID");
            ViewData["RoleID"] = new SelectList(_context.Roles, "ID", "Name");
            return View();
        }

        // POST: BidLabours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BidID,Description,Hours,RoleID")] BidLabour bidLabour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bidLabour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BidID"] = new SelectList(_context.Bids, "ID", "ID", bidLabour.BidID);
            ViewData["RoleID"] = new SelectList(_context.Roles, "ID", "Name", bidLabour.RoleID);
            return View(bidLabour);
        }

        // GET: BidLabours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidLabour = await _context.BidLabours.FindAsync(id);
            if (bidLabour == null)
            {
                return NotFound();
            }
            ViewData["BidID"] = new SelectList(_context.Bids, "ID", "ID", bidLabour.BidID);
            ViewData["RoleID"] = new SelectList(_context.Roles, "ID", "Name", bidLabour.RoleID);
            return View(bidLabour);
        }

        // POST: BidLabours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BidID,Description,Hours,RoleID")] BidLabour bidLabour)
        {
            if (id != bidLabour.BidID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bidLabour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidLabourExists(bidLabour.BidID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BidID"] = new SelectList(_context.Bids, "ID", "ID", bidLabour.BidID);
            ViewData["RoleID"] = new SelectList(_context.Roles, "ID", "Name", bidLabour.RoleID);
            return View(bidLabour);
        }

        // GET: BidLabours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidLabour = await _context.BidLabours
                .Include(b => b.Bid)
                .Include(b => b.Role)
                .FirstOrDefaultAsync(m => m.BidID == id);
            if (bidLabour == null)
            {
                return NotFound();
            }

            return View(bidLabour);
        }

        // POST: BidLabours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bidLabour = await _context.BidLabours.FindAsync(id);
            _context.BidLabours.Remove(bidLabour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BidLabourExists(int id)
        {
            return _context.BidLabours.Any(e => e.BidID == id);
        }
    }
}
