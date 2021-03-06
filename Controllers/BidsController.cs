﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OASIS.Data;
using OASIS.Models;
using OASIS.Utilities;
using OASIS.ViewModels;
namespace OASIS.Controllers
{
    public class BidsController : Controller
    {
        private readonly OasisContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public BidsController(OasisContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Bids
        [Authorize(Policy = "BidViewPolicy")]
        public async Task<IActionResult> Index(string QuickSearchName, string SearchProjectName, string BidAmountBelow, string BidAmountAbove,
            string EstStartDateAbove, string EstStartDateBelow, string EstFinishDateBelow, string EstFinishDateAbove,
            int? BidstatusID, int? DesignerStatusID, int? ClientStatusID, int? DesignerID, int? SalesAsscID,
            int? page, int? pageSizeID, string actionButton, string sortDirection = "asc", string sortField = "DateCreated")
        {

            var bids = from b in _context.Bids
                .Include(b => b.BidStatus)
                .Include(b => b.Designer)
                .Include(b => b.BidLabours).ThenInclude(b => b.Role)
                .Include(b => b.SalesAsscociate)
                .Include(b => b.Project).ThenInclude(p => p.Customer)
                .Include(b => b.BidProducts)
                .Include(b => b.BidLabours)
                .Include(b => b.Approval).ThenInclude(b => b.ApprovalStatuses)
                       select b;

            ViewData["Filtering"] = ""; //Assume not filtering

            //DDL
            ViewData["BidstatusID"] = new SelectList(_context
             .BidStatuses
             .OrderBy(c => c.Name), "ID", "Name");

            ViewData["DesignerStatusID"] = new SelectList(_context
            .ApprovalStatuses
            .OrderBy(c => c.Name), "ID", "Name");

            ViewData["ClientStatusID"] = new SelectList(_context
           .ApprovalStatuses
           .OrderBy(c => c.Name), "ID", "Name");

            ViewData["DesignerID"] = new SelectList(_context
            .Employees.Where(p => p.Role.Name == "Designer")
            .OrderBy(c => c.LastName), "ID", "FullName");

            ViewData["SalesAsscID"] = new SelectList(_context
            .Employees.Where(p => p.Role.Name == "Sales Associate")
            .OrderBy(c => c.LastName), "ID", "FullName");


            //Clear the sort/filter/paging URL Cookie
            CookieHelper.CookieSet(HttpContext, "CustomersURL", "", -1);

            if (!String.IsNullOrEmpty(SearchProjectName))
            {
                bids = bids.Where(p => p.Project.Name.ToUpper().Contains(SearchProjectName.ToUpper()));
                ViewData["Filtering"] = "show";
            }

            if (String.IsNullOrEmpty(SearchProjectName))
            {
                if (!String.IsNullOrEmpty(QuickSearchName))
                {
                    bids = bids.Where(p => p.Project.Name.ToUpper().Contains(QuickSearchName.ToUpper()));
                }
            }

            //Estimated Amount
            if (!String.IsNullOrEmpty(BidAmountBelow))
            {
                bids = bids.Where(p => p.EstAmount < (double)Convert.ToDecimal(BidAmountBelow));
                ViewData["Filtering"] = "show";
            }

            if (!String.IsNullOrEmpty(BidAmountAbove))
            {
                bids = bids.Where(p => p.EstAmount > (double)Convert.ToDecimal(BidAmountAbove));
                ViewData["Filtering"] = "show";
            }

            // Est StartDates
            if (!String.IsNullOrEmpty(EstStartDateAbove))
            {
                bids = bids.Where(p => p.EstBidStartDate > Convert.ToDateTime(EstStartDateAbove));
                ViewData["Filtering"] = "show";
            }

            if (!String.IsNullOrEmpty(EstStartDateBelow))
            {
                bids = bids.Where(p => p.EstBidStartDate < Convert.ToDateTime(EstStartDateBelow));
                ViewData["Filtering"] = "show";
            }

            //Est Finish Date
            if (!String.IsNullOrEmpty(EstFinishDateBelow))
            {
                bids = bids.Where(p => p.EstBidEndDate < Convert.ToDateTime(EstFinishDateBelow));
                ViewData["Filtering"] = "show";
            }

            if (!String.IsNullOrEmpty(EstFinishDateAbove))
            {
                bids = bids.Where(p => p.EstBidEndDate > Convert.ToDateTime(EstFinishDateAbove));
                ViewData["Filtering"] = "show";
            }

            // BidStatus
            if (BidstatusID.HasValue)
            {
                bids = bids.Where(p => p.BidStatusID == BidstatusID);
                ViewData["Filtering"] = " show";
            }

            //Designer
            if (DesignerID.HasValue)
            {
                bids = bids.Where(p => p.DesignerID == DesignerID);
                ViewData["Filtering"] = " show";
            }

            //Sales Associate
            if (SalesAsscID.HasValue)
            {
                bids = bids.Where(p => p.SalesAsscociateID == SalesAsscID);
                ViewData["Filtering"] = " show";
            }


            // DesignerStatus
            if (DesignerStatusID.HasValue)
            {
                bids = bids.Where(p => p.Approval.DesignerStatusID == DesignerStatusID);
                ViewData["Filtering"] = " show";
            }

            // ClientStatus
            if (ClientStatusID.HasValue)
            {
                bids = bids.Where(p => p.Approval.ClientStatusID == ClientStatusID);
                ViewData["Filtering"] = " show";
            }

            //Before we sort, see if we have called for a change of filtering or sorting
            if (!String.IsNullOrEmpty(actionButton))
            {
                if (actionButton != "Filter")
                {
                    if (actionButton == sortField)
                    {
                        sortDirection = sortDirection == "asc" ? "desc" : "asc";
                    }
                    sortField = actionButton;
                }
            }

            if (sortField.Contains("DateCreated")) //Sort By product type:Name
            {
                if (sortDirection == "asc")
                {
                    bids = bids
                    .OrderBy(p => p.DateCreated);
                }
                else
                {
                    bids = bids
                    .OrderByDescending(p => p.DateCreated);
                }
            }

            else if (sortField == "Project")
            {
                if (sortDirection == "asc")
                {
                    bids = bids
                        .OrderBy(p => p.Project.Name);
                }
                else
                {
                    bids = bids
                         .OrderByDescending(p => p.Project.Name);
                }
            }
            else if (sortField == "Organization")
            {
                if (sortDirection == "asc")
                {
                    bids = bids
                        .OrderBy(p => p.Project.Customer.OrgName);
                }
                else
                {
                    bids = bids
                         .OrderByDescending(p => p.Project.Customer.OrgName);
                }
            }
            else if (sortField == "Designer")
            {
                if (sortDirection == "asc")
                {
                    bids = bids
                        .OrderBy(p => p.Designer.LastName)
                         .ThenBy(p => p.Designer.FirstName);

                }
                else
                {
                    bids = bids
                         .OrderByDescending(p => p.Designer.LastName)
                         .ThenByDescending(p => p.Designer.FirstName);
                }
            }

            else
            {
                if (sortDirection == "asc")
                {
                    bids = bids
                        .OrderBy(p => p.EstAmount);
                }
                else
                {
                    bids = bids
                       .OrderByDescending(p => p.EstAmount);
                }
            }
            //Set sort for next time
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;


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
            var pagedData = await PaginatedList<Bid>.CreateAsync(bids.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);
        }




        // GET: Bids/Details/5
        [Authorize(Policy = "BidViewPolicy")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Bids");
            ViewData["BidDetails"] = "True";
            var bid = await _context.Bids
                .Include(b => b.BidStatus)
                .Include(b => b.Designer)
                .Include(b => b.SalesAsscociate)
                .Include(b => b.Project).ThenInclude(p => p.Customer)
                .Include(p => p.BidProducts).ThenInclude(p => p.Product)
                .Include(p => p.BidLabours).ThenInclude(p => p.Role)
                .Include(p => p.Approval).ThenInclude(p => p.ApprovalStatuses)

                .FirstOrDefaultAsync(m => m.ID == id);
            if (bid == null)
            {
                return NotFound();
            }

            ViewData["ClientStatus"] = _context.ApprovalStatuses.SingleOrDefault(p => p.ID == bid.Approval.ClientStatusID).Name;
            ViewData["DesignerStatus"] = _context.ApprovalStatuses.SingleOrDefault(p => p.ID == bid.Approval.DesignerStatusID).Name;
            var productIDs = _context.BidProducts.Where(p => p.BidID == bid.ID);
            var labourIDs = _context.BidLabours.Where(p => p.BidID == bid.ID);

            List<BidProductDetails> outputProducts = new List<BidProductDetails>();
            List<BidLabourDetails> outputLabour = new List<BidLabourDetails>();
            double productTotal = 0;
            double LabourtTotal = 0;
            foreach (var i in productIDs)
            {
                productTotal += _context.Products.SingleOrDefault(p => p.ID == i.ProductID).Price * i.Quantity;
                outputProducts.Add(new BidProductDetails
                {
                    Code = _context.Products.SingleOrDefault(p => p.ID == i.ProductID).Code,
                    Description = _context.Products.SingleOrDefault(p => p.ID == i.ProductID).Description,
                    Price = Math.Round(_context.Products.SingleOrDefault(p => p.ID == i.ProductID).Price, 2),
                    Size = _context.Products.SingleOrDefault(p => p.ID == i.ProductID).size,
                    Quantity = i.Quantity,
                    Total = Math.Round(_context.Products.SingleOrDefault(p => p.ID == i.ProductID).Price * i.Quantity, 2)
                });
            }

            foreach (var i in labourIDs)
            {
                LabourtTotal += (double)_context.Roles.SingleOrDefault(p => p.ID == i.RoleID).LabourPricePerHr * i.Hours;

                outputLabour.Add(new BidLabourDetails
                {
                    Name = _context.Roles.SingleOrDefault(p => p.ID == i.RoleID).Name,
                    Price = Math.Round((double)_context.Roles.SingleOrDefault(p => p.ID == i.RoleID).LabourPricePerHr, 2),
                    Hours = i.Hours,
                    Total = Math.Round((double)_context.Roles.SingleOrDefault(p => p.ID == i.RoleID).LabourPricePerHr * i.Hours, 2)

                });
            }

            ViewData["Labour"] = outputLabour;
            ViewData["products"] = outputProducts;
            ViewData["productTotal"] = Math.Round(productTotal, 2);
            ViewData["LabourtTotal"] = Math.Round(LabourtTotal, 2);



            return View(bid);
        }

        // GET: Bids/Create
        [Authorize(Policy = "BidCreatePolicy")]
        public IActionResult Create(int? projectID, int? bidID)
        {
            var bid = new Bid();
            bid.BidStatusID = _context.BidStatuses.SingleOrDefault(p => p.Name == "Design stage").ID;
            

            if (projectID != null)
            {
                bid.ProjectID = (int)projectID;

                //save the customer ID
                TempData["ProjectID"] = projectID;
            }
            else
            {
                TempData["ProjectID"] = 0;
            }

            if (bidID.HasValue)
            {
                bid = _context.Bids.SingleOrDefault(p => p.ID == bidID);
                PopuateSelectedProducts(bid);
                PopuateSelectedRoles(bid);
            }

          
            var ReqApprovalID = bid.Approval.DesignerStatusID = _context.ApprovalStatuses.FirstOrDefault(p => p.Name == "RequiresApproval").ID;
            PopulateDropDownLists(bid, ReqApprovalID, ReqApprovalID);
            PopuateSelectedProducts(bid);
            PopuateSelectedRoles(bid);


            return View();
        }

        // POST: Bids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "BidCreatePolicy")]

        public async Task<IActionResult> Create([Bind("ID,DateCreated,EstBidStartDate,Budget,EstBidEndDate,Comments,SalesAsscociateID,ProjectID,BidStatusID,approvalComment")] Bid bid,
            int DesignerStatusID, int ClientStatusID, string approvalComment, string ProductsAssigned, string RolesAssigned, int projectTrue, int fromProjectID)
        {

            if (fromProjectID != 0)
            {
                //set the tempdata again for post back after error
                TempData["ProjectID"] = fromProjectID;

                bid.ProjectID = fromProjectID;
            }
            else
            {
                //set the tempdata again for post back after error
                TempData["ProjectID"] = 0;
            }

            double total = 0;
            if (ModelState.IsValid)
            {

                var user = await _userManager.GetUserAsync(User);
                var employeeProfile = await _context.Employees.FirstOrDefaultAsync(p => p.UserName == user.UserName);


                bid.DesignerID = employeeProfile.ID;
                _context.Add(bid);
                await _context.SaveChangesAsync();
                List<ProductDeserialize> ProductsToAdd = JsonConvert.DeserializeObject<List<ProductDeserialize>>(ProductsAssigned);
                List<RoleDeserialize> rolesToAdd = JsonConvert.DeserializeObject<List<RoleDeserialize>>(RolesAssigned);
                total += UpdateBidProducts(ProductsToAdd, bid);
                total += UpdateBidLabours(rolesToAdd, bid);
                UpdateApprovalStatus(bid, DesignerStatusID, ClientStatusID, approvalComment);
                CheckIfFinalaized(bid);
                //total += UpdateBidLabours(selectedRoles, requiredHours, bid);
                bid.EstAmount = total;

                await _context.SaveChangesAsync();
                

                return RedirectToAction("Details", new { bid.ID });
            }


            PopulateDropDownLists(bid, DesignerStatusID, ClientStatusID, approvalComment);
            PopuateSelectedProducts(bid);
            PopuateSelectedRoles(bid);
            return View(bid);
        }

       
        [Authorize(Policy = "BidEditPolicy")]
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
        [Authorize(Policy = "BidEditPolicy")]

        public async Task<IActionResult> Edit(int id, int DesignerStatusID, int ClientStatusID, string approvalComment, string ProductsAssigned,
            string RolesAssigned, Byte[] RowVersion)
        {
            double total = 0;

            var bidToUpdate = await _context.Bids
            .Include(a => a.Approval)
            .ThenInclude(d => d.ApprovalStatuses)
            .Include(a => a.BidProducts).ThenInclude(p => p.Product)
            .Include(a => a.BidLabours)
            .FirstOrDefaultAsync(a => a.ID == id);


            if (bidToUpdate == null)
            {
                return NotFound();
            }
            _context.Entry(bidToUpdate).Property("RowVersion").OriginalValue = RowVersion;

            List<ProductDeserialize> ProductsToAdd = JsonConvert.DeserializeObject<List<ProductDeserialize>>(ProductsAssigned);
            List<RoleDeserialize> rolesToAdd = JsonConvert.DeserializeObject<List<RoleDeserialize>>(RolesAssigned);

            total += UpdateBidProducts(ProductsToAdd, bidToUpdate);
            total += UpdateBidLabours(rolesToAdd, bidToUpdate);
            //total += UpdateBidLabours(selectedRoles, requiredHours, bidToUpdate);

            bidToUpdate.EstAmount = total;

            if (await TryUpdateModelAsync<Bid>(bidToUpdate, "", p => p.DateCreated, p => p.EstBidEndDate, p => p.EstBidStartDate, p => p.Comments, P => P.Budget
           , p => p.DesignerID, p => p.SalesAsscociateID, p => p.BidStatusID, p => p.ProjectID))

            {
                try
                {
                    await _context.SaveChangesAsync();
                    UpdateApprovalStatus(bidToUpdate, DesignerStatusID, ClientStatusID, approvalComment);
                    CheckIfFinalaized(bidToUpdate);
                    // return RedirectToAction(nameof(Index)); 
                    return RedirectToAction("Details", new { bidToUpdate.ID });


                }
                catch (DbUpdateConcurrencyException ex)// Added for concurrency
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Bid)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError("",
                            "Unable to save changes. The Bid was deleted by another user.");
                    }
                    else
                    {
                        var databaseValues = (Bid)databaseEntry.ToObject();
                        if (databaseValues.EstAmount != clientValues.EstAmount)
                            ModelState.AddModelError("EstAmount", "Current value: "
                                + databaseValues.EstAmount);
                        if (databaseValues.ProjectStartDate != clientValues.ProjectStartDate)
                            ModelState.AddModelError("ProjectStartDate", "Current value: "
                                + databaseValues.ProjectStartDate?.ToShortDateString());
                        if (databaseValues.ProjectEndDate != clientValues.ProjectEndDate)
                            ModelState.AddModelError("ProjectEndDate", "Current value: "
                                + databaseValues.ProjectEndDate?.ToShortDateString());
                        if (databaseValues.EstBidStartDate != clientValues.EstBidStartDate)
                            ModelState.AddModelError("EstBidStartDate", "Current value: "
                                + databaseValues.EstBidStartDate.ToShortDateString());
                        if (databaseValues.EstBidEndDate != clientValues.EstBidEndDate)
                            ModelState.AddModelError("EstBidEndDate", "Current value: "
                                + databaseValues.EstBidEndDate.ToShortDateString());
                        if (databaseValues.Comments != clientValues.Comments)
                            ModelState.AddModelError("comments", "Current value: "
                                + databaseValues.Comments);

                        //For the foreign key, we need to go to the database to get the information to show
                        if (databaseValues.ProjectID != clientValues.ProjectID)
                        {
                            Project databaseProject = await _context.Projects.SingleOrDefaultAsync(i => i.ID == databaseValues.ProjectID);
                            ModelState.AddModelError("ProjectID", $"Current value: {databaseProject?.Name}");
                        }
                        if (databaseValues.DesignerID != clientValues.DesignerID)
                        {
                            Employee databaseEmployee = await _context.Employees.SingleOrDefaultAsync(i => i.ID == databaseValues.DesignerID);
                            ModelState.AddModelError("DesignerID", $"Current value: {databaseEmployee?.FormalName}");
                        }

                        if (databaseValues.SalesAsscociateID != clientValues.SalesAsscociateID)
                        {
                            Employee databaseEmployee = await _context.Employees.SingleOrDefaultAsync(i => i.ID == databaseValues.SalesAsscociateID);
                            ModelState.AddModelError("SalesAsscociateID", $"Current value: {databaseEmployee?.FormalName}");
                        }

                        if (databaseValues.BidStatusID != clientValues.BidStatusID)
                        {
                            BidStatus databaseBidStatus = await _context.BidStatuses.SingleOrDefaultAsync(i => i.ID == databaseValues.BidStatusID);
                            ModelState.AddModelError("BidStatusID", $"Current value: {databaseBidStatus?.Name}");
                        }

                        if (databaseValues.Approval.ClientStatusID != clientValues.Approval.ClientStatusID) //fail
                        {
                            ApprovalStatus databaseApprovalStatus = await _context.ApprovalStatuses.SingleOrDefaultAsync(i => i.ID == databaseValues.Approval.ClientStatusID);
                            ModelState.AddModelError("Approval.ClientStatusID", $"Current value: {databaseApprovalStatus?.Name}");
                        }

                        if (databaseValues.Approval.DesignerStatusID != clientValues.Approval.DesignerStatusID) // fail
                        {
                            ApprovalStatus databaseApprovalStatus = await _context.ApprovalStatuses.SingleOrDefaultAsync(i => i.ID == databaseValues.Approval.DesignerStatusID);
                            ModelState.AddModelError("Approval.DesignerStatusID", $"Current value: {databaseApprovalStatus?.Name}");
                        }

                        if (databaseValues.Approval.Comments != clientValues.Approval.Comments) // pass
                        {
                            Approval databaseApproval = await _context.Approvals.SingleOrDefaultAsync(i => i.BidID == databaseValues.ID);
                            ModelState.AddModelError("Approval.Comments", $"Current value: {databaseApproval?.Comments}");
                        }


                        //// Get all the Bidproduct.productID in db and client input
                        //var dbBidProudct = _context.BidProducts.Where(p => p.BidID == bidToUpdate.ID);
                        //List<int> dbBidproductIds = new List<int>();

                        //foreach (var i in dbBidProudct)
                        //{
                        //    dbBidproductIds.Add(i.ProductID);
                        //}
                        //var ClientProducIds = clientValues.BidProducts.Select(p => p.ProductID).ToList();

                        //// if the two arrays match dont match the values were upated throw errror with values in db
                        //if (!dbBidproductIds.Equals(ClientProducIds))
                        //{
                        //    string returnValue = "";
                        //    var AllBidProducts = _context.BidProducts.Where(p => p.BidID == bidToUpdate.ID); // related bidProducts


                        //    foreach (var item in AllBidProducts)
                        //    {
                        //        returnValue += "/n" + item.Product.Code + " - " + item.Quantity;
                        //    }

                        //    ModelState.AddModelError("BidProducts", $"Current value: {returnValue}");

                        //}

                        ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                                + "was modified by another user after you received your values. The "
                                + "edit operation was canceled and the current values in the database "
                                + "have been displayed. If you still want to save your version of this record, click "
                                + "the Save button again. Otherwise click the 'Back to List' hyperlink.");

                        bidToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
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
                .Include(b => b.Project)
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

        // send product object requested by ajax
        [HttpGet]
        public JsonResult GetProduct(int? ID)
        {
            return Json(_context.Products.SingleOrDefault(x => x.ID == ID));
        }

        [HttpGet]
        public JsonResult GetRole(int? ID)
        {
            return Json(_context.Roles.SingleOrDefault(x => x.ID == ID));
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
            var query = from c in _context.Products.Include(c => c.ProductType).Select(x => new
            {
                x.ID,
                x.ProductTypeID,
                Display = x.Description + " [" + x.Code + "]" + " - " + "$" + x.Price

            })
                        select c;
            if (ProductTypeID.HasValue)
            {
                query = query.Where(p => p.ProductTypeID == ProductTypeID);
            }
            return new SelectList(query.OrderBy(p => p.Display), "ID", "Display", selectedId);
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
            var SalesAssociateQuery = from d in _context.Employees.Where(p => p.Role.Name == "Sales Associate")
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

        private void CheckIfFinalaized(Bid bid)
        {
            try
            {
                var clientStatusID = _context.Approvals.SingleOrDefault(p => p.BidID == bid.ID).ClientStatusID;
                var designerStatusID = _context.Approvals.SingleOrDefault(p => p.BidID == bid.ID).DesignerStatusID;
                var approvalStatusID = _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID;

                if (clientStatusID == approvalStatusID && designerStatusID == approvalStatusID)
                {
                    bid.IsFinal = true;
                }
                else
                {
                    bid.IsFinal = false;
                }

                _context.Update(bid);
                _context.SaveChangesAsync();
            }
            catch
            {

            }


        }

        private void PopuateSelectedProducts(Bid bid)
        {

            var query = _context.BidProducts.Include(p => p.Product).Where(p => p.BidID == bid.ID).ToList();

            ViewData["AssignedBidProducts"] = query;

        }

        private double UpdateBidProducts(List<ProductDeserialize> ProductsToAdd, Bid bidToUpdate)
        {
            List<string> a = new List<string>();
            List<string> b = new List<string>();

            for (int i = 0; i < ProductsToAdd.Count; i++)
            {
                a.Add(ProductsToAdd[i].ProductID.ToString());
                b.Add(ProductsToAdd[i].Quantity.ToString());
            }

            var selectedOptions = a.ToArray();
            var selectedQuantity = b.ToArray();



            double total = 0;

            var allProducts = _context.Products.ToList(); // All product ID's
            var allProductPrice = _context.Products.Select(p => p.Price); // All product ID's

            if (selectedOptions.Length < 1 || selectedQuantity.Length < 1)
            {
                bidToUpdate.BidProducts = new List<BidProduct>();
                return total;
            }


            foreach (var product in allProducts)
            {
                //if input array contains this product
                if (selectedOptions.Contains(product.ID.ToString()))
                {
                    var selctedOptionIndex = Array.IndexOf(selectedOptions, product.ID.ToString()); // index of product in selectedOptions
                    var inputQnty = Convert.ToDecimal(selectedQuantity[selctedOptionIndex]); //  input Qnty

                    var bidproductrow = bidToUpdate.BidProducts.SingleOrDefault(p => p.ProductID == product.ID); // bid product row

                    //if product is alreay assigned to the bid
                    if (bidproductrow != null)
                    {
                        total += product.Price * (int)inputQnty;
                        // check if the qnty is not same as inputed qnty
                        if (bidproductrow.Quantity != Convert.ToDecimal(selectedQuantity[selctedOptionIndex]))
                        {
                            //change the quantity to input qnty
                            bidproductrow.Quantity = (int)inputQnty;
                        }
                    }
                    else // assign the produc to bid
                    {
                        total += product.Price * (int)inputQnty;

                        var specToAdd = new BidProduct
                        {
                            BidID = bidToUpdate.ID,
                            ProductID = product.ID,
                            Quantity = (int)inputQnty
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
                        var specToRemove = bidToUpdate.BidProducts.SingleOrDefault(p => p.ProductID == product.ID);
                        _context.Remove(specToRemove);

                    }
                    catch
                    {
                        // Do nothing and loop
                    }


                }

            }
            _context.SaveChangesAsync();

            return total;
        }
        private void PopuateSelectedRoles(Bid bid)
        {
            var query = _context.BidLabours.Include(p => p.Role).Where(p => p.BidID == bid.ID).ToList();

            ViewData["AssignedBidlabours"] = query;
        }

        private double UpdateBidLabours(List<RoleDeserialize> rolesToAdd, Bid bidToUpdate)
        {

            List<string> a = new List<string>();
            List<string> b = new List<string>();

            for (int i = 0; i < rolesToAdd.Count; i++)
            {
                a.Add(rolesToAdd[i].RoleID.ToString());
                b.Add(rolesToAdd[i].Hours.ToString());
            }


            var selectedRoles = a.ToArray();
            var requiredHours = b.ToArray();

            double total = 0;

            var allRoles = _context.Roles.ToList(); // All product ID's

            if (selectedRoles.Length < 1 || requiredHours.Length < 1)
            {
                bidToUpdate.BidLabours = new List<BidLabour>();
                return total;

            }

            foreach (var role in allRoles)
            {
                //if input array contains this product
                if (selectedRoles.Contains(role.ID.ToString()))
                {
                    var selctedOptionIndex = Array.IndexOf(selectedRoles, role.ID.ToString()); // index of product in selectedRoles
                    var inputHrs = Convert.ToDecimal(requiredHours[selctedOptionIndex]); //  input hrs

                    var bidRoleRow = bidToUpdate.BidLabours.SingleOrDefault(p => p.RoleID == role.ID); // bid Labour row

                    //if product is alreay assigned to the bid
                    if (bidRoleRow != null)
                    {
                        total += (double)role.LabourPricePerHr * (double)inputHrs;

                        // check if the qnty is not same as inputed qnty
                        if ((int)bidRoleRow.Hours != Convert.ToInt32(requiredHours[selctedOptionIndex]))
                        {
                            //change the quantity to input qnty
                            bidRoleRow.Hours = (int)inputHrs;
                        }
                    }
                    else // assign the produc to bid
                    {
                        total += (double)role.LabourPricePerHr * (double)inputHrs;

                        var specToAdd = new BidLabour
                        {
                            BidID = bidToUpdate.ID,
                            RoleID = role.ID,
                            Hours = (double)inputHrs
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
                        var specToRemove = bidToUpdate.BidLabours.SingleOrDefault(p => p.RoleID == role.ID);
                        _context.Remove(specToRemove);
                    }
                    catch
                    {
                        // Do nothing and loop
                    }


                }



            }
            _context.SaveChangesAsync();
            return total;

        }

        public void PostProducts(string product)
        {
            List<ProductDeserialize> ProductsToAdd = JsonConvert.DeserializeObject<List<ProductDeserialize>>(product);
            int BidId = _context.Bids.OrderByDescending(p => p.ID).FirstOrDefault().ID;

            //loop over the object
            foreach (var i in ProductsToAdd)
            {

                // create a new bidProduct Object and assign the values
                var a = new BidProduct
                {
                    ProductID = i.ProductID,
                    Quantity = i.Quantity,
                    BidID = BidId

                };

                //                    Add the object to the context

                _context.BidProducts.Add(a);
                //                  Save changes

                _context.SaveChangesAsync();


            }
        }

        // GET: Bids/PopulateStartDate/5
        [HttpGet]
        public async Task<JsonResult> PopulateStartDate(int? id)
        {
            var bidToUpdate = await _context.Bids.SingleOrDefaultAsync(p => p.ID == id);

            if (!bidToUpdate.IsFinal)
            {
                var faliurereturnVal = new { success = false, msg = $"Failed to start bid, The Bid requires approval" };
                return Json(faliurereturnVal);
            }

            if (bidToUpdate.ProjectStartDate == null)
            {
                bidToUpdate.ProjectStartDate = DateTime.Today;
                var successreturnVal = new { success = true, msg = $"Bid sucessfully started" };

                try
                {
                    _context.Update(bidToUpdate);
                    await _context.SaveChangesAsync();
                    return Json(successreturnVal);

                }
                catch
                {
                    var faliurereturnVal = new { success = false, msg = $"Failed to start bid" };
                    return Json(faliurereturnVal);

                }

            }
            else
            {
                bidToUpdate.ProjectEndDate = DateTime.Today;
                var successreturnVal = new { success = true, msg = $"Bid sucessfully Ended" };

                try
                {
                    _context.Update(bidToUpdate);
                    await _context.SaveChangesAsync();
                    return Json(successreturnVal);

                }
                catch
                {
                    var faliurereturnVal = new { success = false, msg = $"Failed to start bid" };
                    return Json(faliurereturnVal);
                }
            }

          

        }

    }




}
