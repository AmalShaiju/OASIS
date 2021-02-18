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
            var oasisContext = _context.Bids.Include(b => b.BidStatus).Include(b => b.Designer).Include(b => b.SalesAsscociate).Include(b => b.project);
            return View(await oasisContext.ToListAsync());
        }

        // GET: Bids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bids
                .Include(b => b.BidStatus)
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
            var bid = new Bid();
            
            PopulateDropDownLists(bid);
            return View();
        }

        // POST: Bids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DateCreated,EstAmount,ProjectStartDate,ProjectEndDate,EstBidStartDate,EstBidEndDate,comments,DesignerID,SalesAsscociateID,ProjectID,BidStatusID")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDropDownLists(bid);

            return View(bid);
        }

        // GET: Bids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bids
                .Include(a => a.Approval)
                .ThenInclude(d => d.ApprovalStatuses)
                .AsNoTracking()
                .SingleOrDefaultAsync(a => a.ID == id);

            if (bid == null)
            {
                return NotFound();
            }
            PopulateDropDownLists(bid);
            ////Approvals
            //var approvalStatusQuery = from d in _context.ApprovalStatuses
            //                          orderby d.Name
            //                          select d;
            //ViewData["ClientStatusID"] = new SelectList(approvalStatusQuery, "ID", "Name");

            //ViewData["DesignerStatusID"] = new SelectList(approvalStatusQuery, "ID", "Name");
            return View(bid);
        }

        // POST: Bids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DateCreated,EstAmount,ProjectStartDate,ProjectEndDate,EstBidStartDate,EstBidEndDate,comments,DesignerID,SalesAsscociateID,ProjectID,BidStatusID")] Bid bid)
        {

            bid = await _context.Bids
           .Include(a => a.Approval)
           .ThenInclude(d => d.ApprovalStatuses)
           .AsNoTracking()
           .SingleOrDefaultAsync(a => a.ID == id);

            if (id != bid.ID)
            {
                return NotFound();
            }

           

            ////Approvals
            //var approvalStatusQuery = from d in _context.ApprovalStatuses
            //                          orderby d.Name
            //                          select d;
            //ViewData["ClientStatusID"] = new SelectList(approvalStatusQuery, "ID", "Name");

            //ViewData["DesignerStatusID"] = new SelectList(approvalStatusQuery, "ID", "Name");

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
            PopulateDropDownLists(bid);
            return View(bid);
        }

        // GET: Bids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bids
                .Include(b => b.BidStatus)
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
            var bid = await _context.Bids.FindAsync(id);
            _context.Bids.Remove(bid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BidExists(int id)
        {
            return _context.Bids.Any(e => e.ID == id);
        }

        private void PopulateDropDownLists(Bid bid = null)
        {
            // Bid Status
            var bidStatusQuery = from d in _context.BidStatuses
                                 orderby d.Name
                                 select d;
            ViewData["BidStatusID"] = new SelectList(bidStatusQuery, "ID", "Name", bid?.BidStatusID);

            // Project
            var projectQuery = from d in _context.Projects 
                               orderby d.Name
                               select d;
            ViewData["ProjectID"] = new SelectList(projectQuery, "ID", "Name", bid?.ProjectID);

            //Designer & Sales Associate
            var designerQuery = from d in _context.Employees.Where(p => p.Role.Name == "Designer")
                                orderby d.LastName, d.FirstName
                                select d;
            var SalesAssociateQuery = from d in _context.Employees.Where(p => p.Role.Name == "Botanist")
                                      orderby d.LastName, d.FirstName
                                      select d;
            ViewData["DesignerID"] = new SelectList(designerQuery, "ID", "FormalName", bid?.DesignerID);

            ViewData["SalesAsscociateID"] = new SelectList(SalesAssociateQuery, "ID", "FormalName", bid?.SalesAsscociateID);

            //Approvals
            var approvalStatusQuery = from d in _context.ApprovalStatuses
                                      orderby d.Name
                                      select d;
            ViewData["ClientStatusID"] = new SelectList(approvalStatusQuery, "ID", "Name", bid?.Approval.ClientStatusID);

            ViewData["DesignerStatusID"] = new SelectList(approvalStatusQuery, "ID", "Name", bid?.Approval.ClientStatusID);

        }
    }
}
