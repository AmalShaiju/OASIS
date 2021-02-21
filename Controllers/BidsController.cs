using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OASIS.Data;
using OASIS.Models;
using OASIS.ViewModels;

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
            var oasisContext = _context.Bids.Include(b => b.BidStatus)
                .Include(b => b.Designer).
                Include(b => b.SalesAsscociate)
                .Include(b => b.project)
                .Include(b => b.BidProducts)
                .Include(b => b.BidLabours);
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
            PopulateAssignedProducts(bid);
            return View();
        }

        // POST: Bids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DateCreated,EstAmount,ProjectStartDate,ProjectEndDate,EstBidStartDate,EstBidEndDate,comments,DesignerID,SalesAsscociateID,ProjectID,BidStatusID,approvalComment")] Bid bid, 
            int DesignerStatusID, int ClientStatusID, string approvalComment, string[] selectedOptions)
        {

            updateBidProducts(selectedOptions, bid);
            if (ModelState.IsValid)
            {
                _context.Add(bid);
                await _context.SaveChangesAsync();
                updateApprovalStatus(bid, DesignerStatusID, ClientStatusID, approvalComment);
                return RedirectToAction(nameof(Index));
            }


            PopulateDropDownLists(bid, DesignerStatusID, ClientStatusID, approvalComment);
            PopulateAssignedProducts(bid);
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
                .Include(a => a.BidProducts)
                .Include(a => a.BidLabours)
                .AsNoTracking()
                .SingleOrDefaultAsync(a => a.ID == id);

            if (bid == null)
            {
                return NotFound();
            }

            PopulateDropDownLists(bid, bid.Approval.DesignerStatusID, bid.Approval.ClientStatusID, bid.Approval.Comments);
            PopulateAssignedProducts(bid);
            return View(bid);
        }

        // POST: Bids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int DesignerStatusID, int ClientStatusID, string approvalComment, string[] selectedOptions)
        {
            var bidToUpdate = await _context.Bids
            .Include(a => a.Approval)
            .ThenInclude(d => d.ApprovalStatuses)
            .Include(a => a.BidProducts)
             .Include(a => a.BidLabours)
            .FirstOrDefaultAsync(a => a.ID == id);

            if (bidToUpdate == null)
            {
                return NotFound();
            }

            updateBidProducts(selectedOptions ,bidToUpdate);

            if (await TryUpdateModelAsync<Bid>(bidToUpdate, "", p => p.DateCreated, p => p.EstAmount, p => p.ProjectStartDate, p => p.ProjectEndDate, p => p.EstBidEndDate, p => p.EstBidStartDate, p => p.comments
           , p => p.DesignerID, p => p.SalesAsscociateID, p => p.BidStatusID, p => p.ProjectID))
            {

                try
                {
                    await _context.SaveChangesAsync();
                    updateApprovalStatus(bidToUpdate, DesignerStatusID, ClientStatusID, approvalComment);
                    //return RedirectToAction(nameof(Index)); 
                    return RedirectToAction("Details", new { bidToUpdate.ID });


                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidExists(bidToUpdate.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            PopulateDropDownLists(bidToUpdate, DesignerStatusID, ClientStatusID, approvalComment);
            PopulateAssignedProducts(bidToUpdate);
            return View(bidToUpdate);
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

        private void PopulateDropDownLists(Bid bid = null, int designerStatusID = 1, int clientStatusID = 1, string note = "No Comment")
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

            ViewData["SalesAsscociateID"] = new SelectList(SalesAssociateQuery, "ID", "FormalName", bid.SalesAsscociateID);

            // Approvals
            var approvalStatusQuery = from d in _context.ApprovalStatuses
                                      orderby d.Name
                                      select d;

            ViewData["ClientStatusID"] = new SelectList(approvalStatusQuery, "ID", "Name", (bid != null && bid.Approval.ClientStatusID != clientStatusID) ? clientStatusID : bid.Approval.ClientStatusID);

            ViewData["DesignerStatusID"] = new SelectList(approvalStatusQuery, "ID", "Name", (bid != null && bid.Approval.DesignerStatusID != clientStatusID) ? designerStatusID : bid.Approval.DesignerStatusID);

            ViewData["approvalComment"] = (bid != null && bid.Approval.Comments == note) ? bid.Approval.Comments : note;

        }

        private void updateApprovalStatus(Bid bid, int designerID, int clientID, string comments)
        {
            var approval = _context.Approvals.SingleOrDefault(p => p.BidID == bid.ID);

            if (designerID != bid.Approval.DesignerStatusID)
            {

                approval.DesignerStatusID = designerID;
            }

            if (clientID != bid.Approval.ClientStatusID)
            {
                approval.ClientStatusID = clientID;

            }

            if (comments != bid.Approval.Comments)
            {
                approval.Comments = comments;
            }

            _context.SaveChangesAsync();

        }

        private void PopulateAssignedProducts(Bid bid)
        {
            var allOptions = _context.Products;
            var currentOptionsHS = new HashSet<int>(bid.BidProducts.Select(b => b.ProductID));
            var selected = new List<ListOptionVM>();
            var available = new List<ListOptionVM>();
            foreach (var s in allOptions)
            {
                if (currentOptionsHS.Contains(s.ID))
                {
                    selected.Add(new ListOptionVM
                    {
                        ID = s.ID,
                        DisplayText = s.Code
                    });
                }
                else
                {
                    available.Add(new ListOptionVM
                    {
                        ID = s.ID,
                        DisplayText = s.Code
                    });
                }
            }

            ViewData["selOpts"] = new MultiSelectList(selected.OrderBy(s => s.DisplayText), "ID", "DisplayText");
            ViewData["availOpts"] = new MultiSelectList(available.OrderBy(s => s.DisplayText), "ID", "DisplayText");
        }

        private void updateBidProducts(string[] selectedOptions, Bid bidToUpdate)
        {
            if (selectedOptions == null)
            {
                bidToUpdate.BidProducts = new List<BidProduct>();
                return;
            }

            var selectedOptionsHS = new HashSet<string>(selectedOptions);
            var currentOptionsHS = new HashSet<int>(bidToUpdate.BidProducts.Select(b => b.ProductID));
            foreach (var s in _context.Products)
            {
                if (selectedOptionsHS.Contains(s.ID.ToString()))
                {
                    if (!currentOptionsHS.Contains(s.ID))
                    {
                        bidToUpdate.BidProducts.Add(new BidProduct
                        {
                            ProductID = s.ID,
                            BidID = bidToUpdate.ID
                        });
                    }
                }
                else
                {
                    if (currentOptionsHS.Contains(s.ID))
                    {
                        BidProduct specToRemove = bidToUpdate.BidProducts.SingleOrDefault(d => d.ProductID == s.ID);
                        _context.Remove(specToRemove);
                    }
                }
            }
        }

    }


}
