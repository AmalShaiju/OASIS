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
    public class BidsController : Controller
    {
        private readonly OasisContext _context;

        public BidsController(OasisContext context)
        {
            _context = context;
        }

        // GET: Bids
        public async Task<IActionResult> Index()
        {
            var oasisContext = _context.Bid.Include(b => b.Designer).Include(b => b.SalesAsscociate).Include(b => b.project);
            return View(await oasisContext.ToListAsync());
        }

        // GET: Bids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bid
                .Include(b => b.Designer)
                .Include(b => b.SalesAsscociate)
                .Include(b => b.project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        // GET: Bids/Create
        public IActionResult Create()
        {
            ViewData["DesignerID"] = new SelectList(_context.Employees, "ID", "AddressLineOne");
            ViewData["SalesAsscociateID"] = new SelectList(_context.Employees, "ID", "AddressLineOne");
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "City");
            return View();
        }

        // POST: Bids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DateCreated,EstAmount,ProjectStartDate,ProjectEndDate,EstBidStartDate,EstBidEndDate,comments,DesignerID,SalesAsscociateID,ProjectID")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DesignerID"] = new SelectList(_context.Employees, "ID", "AddressLineOne", bid.DesignerID);
            ViewData["SalesAsscociateID"] = new SelectList(_context.Employees, "ID", "AddressLineOne", bid.SalesAsscociateID);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "City", bid.ProjectID);
            return View(bid);
        }

        // GET: Bids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bid.FindAsync(id);
            if (bid == null)
            {
                return NotFound();
            }
            ViewData["DesignerID"] = new SelectList(_context.Employees, "ID", "AddressLineOne", bid.DesignerID);
            ViewData["SalesAsscociateID"] = new SelectList(_context.Employees, "ID", "AddressLineOne", bid.SalesAsscociateID);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "City", bid.ProjectID);
            return View(bid);
        }

        // POST: Bids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DateCreated,EstAmount,ProjectStartDate,ProjectEndDate,EstBidStartDate,EstBidEndDate,comments,DesignerID,SalesAsscociateID,ProjectID")] Bid bid)
        {
            if (id != bid.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidExists(bid.ID))
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
            ViewData["DesignerID"] = new SelectList(_context.Employees, "ID", "AddressLineOne", bid.DesignerID);
            ViewData["SalesAsscociateID"] = new SelectList(_context.Employees, "ID", "AddressLineOne", bid.SalesAsscociateID);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "City", bid.ProjectID);
            return View(bid);
        }

        // GET: Bids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bid
                .Include(b => b.Designer)
                .Include(b => b.SalesAsscociate)
                .Include(b => b.project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        // POST: Bids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bid = await _context.Bid.FindAsync(id);
            _context.Bid.Remove(bid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BidExists(int id)
        {
            return _context.Bid.Any(e => e.ID == id);
        }
    }
}
