using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OASIS.Data;
using OASIS.Models;
using OASIS.Utilities;

namespace OASIS.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly OasisContext _context;

        public ProjectsController(OasisContext context)
        {
            _context = context; 
        }

        // GET: Projects
        [Authorize(Policy = "ProjectViewPolicy")]

        public async Task<IActionResult> Index(string SearchProjectName, string SearchCustomerName, string SearchOrg, string SearchCity,
            string actionButton, int? page, int? pageSizeID,  string sortDirection = "asc", string sortField = "Project")
        {
            var project = from p in _context.Projects
              .Include(p => p.Customer)
              .Include(p => p.Bids)
                            select p;

            ViewData["Filtering"] = "";

            CookieHelper.CookieSet(HttpContext, "ProjectsURL", "", -1);

            if (!String.IsNullOrEmpty(SearchProjectName))
            {
                project = project.Where(p => p.Name.ToUpper().Contains(SearchProjectName.ToUpper()));
                ViewData["Filtering"] = " show";
            }

            if (!String.IsNullOrEmpty(SearchCity))
            {
                project = project.Where(p => p.City.ToUpper().Contains(SearchCity.ToUpper()));
                ViewData["Filtering"] = "show";
            }

            if (!String.IsNullOrEmpty(SearchOrg))
            {
                project = project.Where(p=>p.Customer.OrgName.ToUpper().Contains(SearchOrg.ToUpper()));
                ViewData["Filtering"] = "show";
            }

            if (!String.IsNullOrEmpty(SearchCustomerName))
            {
                project = project.Where(p => p.Customer.LastName.ToUpper().Contains(SearchCustomerName.ToUpper())
                                        || p.Customer.FirstName.ToUpper().Contains(SearchCustomerName.ToUpper()));
                ViewData["Filtering"] = "show";
            }

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

            if (sortField == "Project")
            {
                if (sortDirection == "asc")
                {
                    project = project
                        .OrderByDescending(p => p.Name);
                }
                else
                {
                    project = project
                         .OrderBy(p => p.Name);
                }
            }
            else if (sortField == "Organization")
            {
                if (sortDirection == "asc")
                {
                    project = project
                        .OrderBy(p => p.Customer.OrgName);
                }
                else
                {
                    project = project
                        .OrderByDescending(p => p.Customer.OrgName);
                }
            }
            else //Sorting by Patient Name
            {
                if (sortDirection == "asc")
                {
                    project = project
                        .OrderBy(p => p.City);
                }
                else
                {
                    project = project
                        .OrderByDescending(p => p.City);
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
            var pagedData = await PaginatedList<Project>.CreateAsync(project.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);

        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Projects");

            var project = await _context.Projects
                .Include(p => p.Customer)
                .Include(p => p.Bids)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        [Authorize(Policy = "ProjectCreatePolicy")]

        public IActionResult Create(int? customerID)
        {
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Projects");
            Project project = new Project();

            if (!TempData.ContainsKey("fromCustomer"))
                TempData["fromCustomer"] = "False";


            if (customerID != null)
            {
                project.CustomerID = (int)customerID;

            }
                PopulateDropDownLists(project);

            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "ProjectCreatePolicy")]
        public async Task<IActionResult> Create([Bind("ID,Name,SiteAddressLineOne,SiteAddressLineTwo,City,Province,Country,CustomerID")] Project project, int bidTrue)
        {
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Projects");
            //if (!TempData.ContainsKey("fromCustomer"))
            //    TempData["fromCustomer"] = "False";

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(project);
                    await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                  
                    if (bidTrue == 1)
                    {
                        TempData["fromProject"] = "True";

                        return RedirectToAction(actionName: "Create", controllerName: "Bids", new {projectID = project.ID });
                    }

                    TempData["fromProject"] = "False";


                    return RedirectToAction("Details", new { project.ID });
                }
            }
            catch (DbUpdateException dex)
            {
                if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed: Projects.Name"))
                {
                    ModelState.AddModelError("Name", "Unable to save changes.You cannot have duplicate Project Names.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
          
            PopulateDropDownLists(project);
            return View(project);
        }

        // GET: Projects/Edit/5
        [Authorize(Policy = "ProjectEditPolicy")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Projects");

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            PopulateDropDownLists(project);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "ProjectEditPolicy")]
        public async Task<IActionResult> Edit(int id, Byte[] RowVersion)
        {
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Projects");

            var  projectToUpdate = await _context.Projects.SingleOrDefaultAsync(p => p.ID == id);

            if (projectToUpdate == null)
            {
                return NotFound();
            }

            _context.Entry(projectToUpdate).Property("RowVersion").OriginalValue = RowVersion;

            if (await TryUpdateModelAsync<Project>(projectToUpdate,"", p=> p.Name, p => p.SiteAddressLineOne, p => p.SiteAddressLineTwo, p => p.City, p => p.Province, p => p.Country, p => p.CustomerID))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                    return RedirectToAction("Details", new { projectToUpdate.ID });
                }

                catch (DbUpdateConcurrencyException ex)// Added for concurrency
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Project)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError("",
                            "Unable to save changes. The Project was deleted by another user.");
                    }
                    else
                    {
                        var databaseValues = (Project)databaseEntry.ToObject();
                        if (databaseValues.Name != clientValues.Name)
                            ModelState.AddModelError("Name", "Current value: "
                                + databaseValues.Name);
                        if (databaseValues.SiteAddressLineOne != clientValues.SiteAddressLineOne)
                            ModelState.AddModelError("SiteAddressLineOne", "Current value: "
                                + databaseValues.SiteAddressLineOne);
                        if (databaseValues.SiteAddressLineTwo != clientValues.SiteAddressLineTwo)
                            ModelState.AddModelError("SiteAddressLineTwo", "Current value: "
                                + databaseValues.SiteAddressLineTwo);
                        if (databaseValues.City != clientValues.City)
                            ModelState.AddModelError("City", "Current value: "
                                + databaseValues.City);
                        if (databaseValues.Province != clientValues.Province)
                            ModelState.AddModelError("Province", "Current value: "
                                + databaseValues.Province);
                        if (databaseValues.Country != clientValues.Country)
                            ModelState.AddModelError("Country", "Current value: "
                                + databaseValues.Country);

                        //For the foreign key, we need to go to the database to get the information to show
                        if (databaseValues.CustomerID != clientValues.CustomerID)
                        {
                            Customer databaseCustomer = await _context.Customers.SingleOrDefaultAsync(i => i.ID == databaseValues.CustomerID);
                            ModelState.AddModelError("CustomerID", $"Current value: {databaseCustomer?.FormalName}");
                        }
                       
                        ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                                + "was modified by another user after you received your values. The "
                                + "edit operation was canceled and the current values in the database "
                                + "have been displayed. If you still want to save your version of this record, click "
                                + "the Save button again. Otherwise click the 'Back to List' hyperlink.");
                        projectToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
                catch (DbUpdateException dex)
                {
                    if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed: Projects.Name"))
                    {
                        ModelState.AddModelError("Name", "Unable to save changes.You cannot have duplicate Project Names.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                    }
                }

            }
            PopulateDropDownLists(projectToUpdate);
            return View(projectToUpdate);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Projects");

            var project = await _context.Projects
                .Include(p => p.Customer)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Projects");

            var project = await _context.Projects
                            .Include(p => p.Bids)
                         .FirstOrDefaultAsync(m => m.ID == id);

            try
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return Redirect(ViewData["returnURL"].ToString());
            }
            catch (DbUpdateException dex)
            {
                if (dex.GetBaseException().Message.Contains("FOREIGN KEY constraint failed"))
                {
                    ModelState.AddModelError("", "Unable to Delete Project. You cannot delete a Project that has Bids Designed.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            return View(project);
           
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ID == id);
        }

        private void PopulateDropDownLists(Project project = null)
        {
            var dQuery = from d in _context.Customers
                         orderby d.LastName, d.FirstName
                         select d;
            ViewData["CustomerID"] = new SelectList(dQuery, "ID", "FormalName", project?.CustomerID);
        }
    }
}
