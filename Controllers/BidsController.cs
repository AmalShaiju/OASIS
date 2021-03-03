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
            PopuateSelectedProducts(bid);
            PopuateSelectedRoles(bid);
            return View();
        }

        // POST: Bids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DateCreated,EstAmount,ProjectStartDate,ProjectEndDate,EstBidStartDate,EstBidEndDate,comments,DesignerID,SalesAsscociateID,ProjectID,BidStatusID,approvalComment")] Bid bid,
            int DesignerStatusID, int ClientStatusID, string approvalComment, string[] selectedProducts, string[] selectedQuantity, string[] selectedRoles, string[] requiredHours)
        {

            updateBidProducts(selectedProducts, selectedQuantity, bid);
            updateBidLabours(selectedRoles, requiredHours, bid);

            if (ModelState.IsValid)
            {
                _context.Add(bid);
                await _context.SaveChangesAsync();
                UpdateApprovalStatus(bid, DesignerStatusID, ClientStatusID, approvalComment);
                return RedirectToAction(nameof(Index));
            }


            PopulateDropDownLists(bid, DesignerStatusID, ClientStatusID, approvalComment);
            PopuateSelectedProducts(bid);
            PopuateSelectedRoles(bid);
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
            PopuateSelectedProducts(bid);
            PopuateSelectedRoles(bid);
            return View(bid);
        }

        // POST: Bids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int DesignerStatusID, int ClientStatusID, string approvalComment, string[] selectedProducts, string[] selectedQuantity,
            string[] selectedRoles, string[] requiredHours)//string[] selectedOptions)
        {
            var bidToUpdate = await _context.Bids
            .Include(a => a.Approval)
            .ThenInclude(d => d.ApprovalStatuses)
            .Include(a => a.BidProducts)
             .Include(a => a.BidLabours)
            .FirstOrDefaultAsync(a => a.ID == id);

            updateBidProducts(selectedProducts, selectedQuantity, bidToUpdate);
            updateBidLabours(selectedRoles, requiredHours, bidToUpdate);


            if (bidToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Bid>(bidToUpdate, "", p => p.DateCreated, p => p.EstAmount, p => p.ProjectStartDate, p => p.ProjectEndDate, p => p.EstBidEndDate, p => p.EstBidStartDate, p => p.comments
           , p => p.DesignerID, p => p.SalesAsscociateID, p => p.BidStatusID, p => p.ProjectID))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    UpdateApprovalStatus(bidToUpdate, DesignerStatusID, ClientStatusID, approvalComment);
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
            PopuateSelectedProducts(bidToUpdate);
            PopuateSelectedRoles(bidToUpdate);
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

        [HttpGet]
        public JsonResult GetProducts(int? ID)
        {
            return Json(ProductSelectList(ID, null));
        }

        private bool BidExists(int id)
        {
            return _context.Bids.Any(e => e.ID == id);
        }
        private SelectList ProductTypeSelectList(int? selectedId)
        {
            return new SelectList(_context.ProductTypes
                .OrderBy(d => d.Name), "ID", "Name", selectedId);
        }
        private SelectList ProductSelectList(int? ProductTypeID, int? selectedId)
        {
            var query = from c in _context.Products.Include(c => c.ProductType)
                        select c;
            if (ProductTypeID.HasValue)
            {
                query = query.Where(p => p.ProductTypeID == ProductTypeID);
            }
            return new SelectList(query.OrderBy(p => p.Code), "ID", "Code", selectedId);
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

            //Roles
            var roleQuery = from d in _context.Roles
                            orderby d.Name
                            select d;

            ViewData["ClientStatusID"] = new SelectList(approvalStatusQuery, "ID", "Name", (bid != null && bid.Approval.ClientStatusID != clientStatusID) ? clientStatusID : bid.Approval.ClientStatusID);

            ViewData["DesignerStatusID"] = new SelectList(approvalStatusQuery, "ID", "Name", (bid != null && bid.Approval.DesignerStatusID != clientStatusID) ? designerStatusID : bid.Approval.DesignerStatusID);

            ViewData["approvalComment"] = (bid != null && bid.Approval.Comments == note) ? bid.Approval.Comments : note;

            //Product and product Types
            ViewData["ProductTypeID"] = ProductTypeSelectList(null);
            ViewData["ProductID"] = ProductSelectList(null, null);

            //Roles
            ViewData["RoleID"] = new SelectList(roleQuery, "ID", "Name");

        }



        private void UpdateApprovalStatus(Bid bid, int designerID, int clientID, string comments)
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

        private void PopuateSelectedProducts(Bid bid)
        {
            var allBidProducts = new HashSet<BidProduct>(_context.BidProducts.Where(p => p.BidID == bid.ID)); // All BidProduct Model
            var AssignedProducts = new List<ListOptionVM>();
            var AssignedQuantity = new List<ListOptionVM>();

            foreach (var s in allBidProducts)
            {
                AssignedProducts.Add(new ListOptionVM
                {
                    ID = s.ProductID,
                    DisplayText = _context.Products.SingleOrDefault(p => p.ID == s.ProductID).Code
                });

                AssignedQuantity.Add(new ListOptionVM
                {
                    ID = s.Quantity,
                    DisplayText = s.Quantity.ToString()
                });
            }



            ViewData["selOpts"] = new MultiSelectList(AssignedProducts, "ID", "DisplayText");
            ViewData["qntyOpts"] = new MultiSelectList(AssignedQuantity, "ID", "DisplayText");
        }

        private void updateBidProducts(string[] selectedOptions, string[] selectedQuantity, Bid bidToUpdate)
        {
            var allProducts = _context.Products.Select(p => p.ID); // All product ID's

            if (selectedOptions.Length < 1 || selectedQuantity.Length < 1)
            {
                bidToUpdate.BidProducts = new List<BidProduct>();
                return;
            }

           
            foreach (var product in allProducts)
            {
                //if input array contains this product
                if (selectedOptions.Contains(product.ToString()))
                {
                    var selctedOptionIndex = Array.IndexOf(selectedOptions, product.ToString()); // index of product in selectedOptions
                    var inputQnty = Convert.ToInt32(selectedQuantity[selctedOptionIndex]); //  input Qnty

                    var bidproductrow = bidToUpdate.BidProducts.SingleOrDefault(p => p.ProductID == product); // bid product row

                    //if product is alreay assigned to the bid
                    if(bidproductrow != null)
                    {
                        // check if the qnty is not same as inputed qnty
                        if (bidproductrow.Quantity != Convert.ToInt32(selectedQuantity[selctedOptionIndex]))
                        {
                            //change the quantity to input qnty
                            bidproductrow.Quantity = inputQnty;
                        }
                    }
                    else // assign the produc to bid
                    {

                        var specToAdd = new BidProduct
                        {
                            BidID = bidToUpdate.ID,
                            ProductID = product,
                            Quantity = inputQnty
                        };

                        _context.BidProducts.Add(specToAdd);
                    }

                   
                }
                //else not delete the row 
                else
                {
                    // try to delete if the product actually is assigned to the bid
                    try
                    {
                        var specToRemove = bidToUpdate.BidProducts.SingleOrDefault(p => p.ProductID == product); 
                        _context.Remove(specToRemove);
                    }
                    catch
                    {
                        // Do nothing and loop
                    }
                    

                }

            }
            _context.SaveChangesAsync();

        }
        private void PopuateSelectedRoles(Bid bid)
        {
            var allBidLabours = new HashSet<BidLabour>(_context.BidLabours.Where(p => p.BidID == bid.ID)); // All BidLabour Model
            var AssignedLabours = new List<ListOptionVM>();
            var AssignedHours = new List<ListOptionVM>();

            foreach (var s in allBidLabours)
            {
                AssignedLabours.Add(new ListOptionVM
                {
                    ID = s.RoleID,
                    DisplayText = _context.Roles.SingleOrDefault(p => p.ID == s.RoleID).Name
                });

                AssignedHours.Add(new ListOptionVM
                {
                    ID = (int)s.Hours,
                    DisplayText = s.Hours.ToString()
                });
            }



            ViewData["selRoles"] = new MultiSelectList(AssignedLabours, "ID", "DisplayText");
            ViewData["reqHrs"] = new MultiSelectList(AssignedHours, "ID", "DisplayText");
        }

        private void updateBidLabours(string[] selectedRoles, string[] requiredHours, Bid bidToUpdate)
        {
            var allRoles= _context.Roles.Select(p => p.ID); // All product ID's

            if (selectedRoles.Length < 1 || requiredHours.Length < 1)
            {
                bidToUpdate.BidProducts = new List<BidProduct>();
                return;
            }


            foreach (var role in allRoles)
            {
                //if input array contains this product
                if (selectedRoles.Contains(role.ToString()))
                {
                    var selctedOptionIndex = Array.IndexOf(selectedRoles, role.ToString()); // index of product in selectedRoles
                    var inputHrs = Convert.ToInt32(requiredHours[selctedOptionIndex]); //  input hrs

                    var bidRoleRow = bidToUpdate.BidLabours.SingleOrDefault(p => p.RoleID == role); // bid Labour row

                    //if product is alreay assigned to the bid
                    if (bidRoleRow != null)
                    {
                        // check if the qnty is not same as inputed qnty
                        if (bidRoleRow.Hours != Convert.ToInt32(requiredHours[selctedOptionIndex]))
                        {
                            //change the quantity to input qnty
                            bidRoleRow.Hours = inputHrs;
                        }
                    }
                    else // assign the produc to bid
                    {

                        var specToAdd = new BidLabour
                        {
                            BidID = bidToUpdate.ID,
                            RoleID = role,
                            Hours = inputHrs
                        };

                        _context.BidLabours.Add(specToAdd);
                    }


                }
                //else not delete the row 
                else
                {
                    // try to delete if the product actually is assigned to the bid
                    try
                    {
                        var specToRemove = bidToUpdate.BidLabours.SingleOrDefault(p => p.RoleID == role);
                        _context.Remove(specToRemove);
                    }
                    catch
                    {
                        // Do nothing and loop
                    }


                }

            }
            _context.SaveChangesAsync();
          
        }


    }



}
