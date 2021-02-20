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
    public class ApprovalsController : Controller
    {
        private readonly OasisContext _context;

        public ApprovalsController(OasisContext context)
        {
            _context = context;
        }

        // GET: Approvals
        public async Task<IActionResult> Index()
        {
            var oasisContext = _context.Approvals.Include(a => a.Bid).Include(a => a.ClientStatus).Include(a => a.DesignerStatus);
            return View(await oasisContext.ToListAsync());
        }

        // GET: Approvals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approval = await _context.Approvals
                .Include(a => a.Bid)
                .Include(a => a.ClientStatus)
                .Include(a => a.DesignerStatus)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (approval == null)
            {
                return NotFound();
            }

            return View(approval);
        }

        // GET: Approvals/Create
        public IActionResult Create()
        {
            ViewData["BidID"] = new SelectList(_context.Bids, "ID", "ID");
            ViewData["ClientStatusID"] = new SelectList(_context.ApprovalStatuses, "ID", "Name");
            ViewData["DesignerStatusID"] = new SelectList(_context.ApprovalStatuses, "ID", "Name");
            return View();
        }

        // POST: Approvals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Comments,ClientStatusID,DesignerStatusID,BidID")] Approval approval)
        {
            if (ModelState.IsValid)
            {
                _context.Add(approval);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BidID"] = new SelectList(_context.Bids, "ID", "ID", approval.BidID);
            ViewData["ClientStatusID"] = new SelectList(_context.ApprovalStatuses, "ID", "Name", approval.ClientStatusID);
            ViewData["DesignerStatusID"] = new SelectList(_context.ApprovalStatuses, "ID", "Name", approval.DesignerStatusID);
            return View(approval);
        }

        // GET: Approvals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approval = await _context.Approvals.FindAsync(id);
            if (approval == null)
            {
                return NotFound();
            }
            ViewData["BidID"] = new SelectList(_context.Bids, "ID", "ID", approval.BidID);
            ViewData["ClientStatusID"] = new SelectList(_context.ApprovalStatuses, "ID", "Name", approval.ClientStatusID);
            ViewData["DesignerStatusID"] = new SelectList(_context.ApprovalStatuses, "ID", "Name", approval.DesignerStatusID);
            return View(approval);
        }

        // POST: Approvals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Comments,ClientStatusID,DesignerStatusID,BidID")] Approval approval)
        {
            if (id != approval.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(approval);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApprovalExists(approval.ID))
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
            ViewData["BidID"] = new SelectList(_context.Bids, "ID", "ID", approval.BidID);
            ViewData["ClientStatusID"] = new SelectList(_context.ApprovalStatuses, "ID", "Name", approval.ClientStatusID);
            ViewData["DesignerStatusID"] = new SelectList(_context.ApprovalStatuses, "ID", "Name", approval.DesignerStatusID);
            return View(approval);
        }

        // GET: Approvals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approval = await _context.Approvals
                .Include(a => a.Bid)
                .Include(a => a.ClientStatus)
                .Include(a => a.DesignerStatus)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (approval == null)
            {
                return NotFound();
            }

            return View(approval);
        }

        // POST: Approvals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var approval = await _context.Approvals.FindAsync(id);
            _context.Approvals.Remove(approval);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApprovalExists(int id)
        {
            return _context.Approvals.Any(e => e.ID == id);
        }
    }
}
