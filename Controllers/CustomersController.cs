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
    public class CustomersController : Controller
    {
        private readonly OasisContext _context;

        public CustomersController(OasisContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index(string SearchName, string SearchProject, string SearchOrg, string SearchEmail,
            int? page, int? pageSizeID, string actionButton, string sortDirection = "asc", string sortField = "project")
        {
            var customers = from p in _context.Customers
                .Include(p => p.Projects)
                           select p;

            ViewData["Filtering"] = "";

            if (!String.IsNullOrEmpty(SearchName))
            {
                customers = customers.Where(p => p.LastName.ToUpper().Contains(SearchName.ToUpper())
                                       || p.FirstName.ToUpper().Contains(SearchName.ToUpper()));
                ViewData["Filtering"] = "show";
            }

            if (!String.IsNullOrEmpty(SearchOrg))
            {
                customers = customers.Where(p => p.OrgName.ToUpper().Contains(SearchOrg.ToUpper()));
                ViewData["Filtering"] = "show";
            }

            if (!String.IsNullOrEmpty(SearchEmail))
            {
                customers = customers.Where(p => p.Email.ToUpper().Contains(SearchEmail.ToUpper()));
                ViewData["Filtering"] = "show";
            }

            if (!String.IsNullOrEmpty(SearchProject))
            {
                customers = customers.Where(p => p.Projects.Any( m => m.Name.ToLower().Contains(SearchProject.ToLower())));
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

            if (sortField == "Projects")
            {
                if (sortDirection == "asc")
                {
                    customers = customers
                        .OrderByDescending(p => p.Projects.FirstOrDefault(m=> m.CustomerID == p.ID));
                }
                else
                {
                    customers = customers
                        .OrderBy(p => p.Projects.FirstOrDefault(m => m.CustomerID == p.ID));
                }
            }
            else if (sortField == "Customer")
            {
                if (sortDirection == "asc")
                {
                    customers = customers
                        .OrderBy(p => p.LastName)
                        .ThenBy(p => p.FirstName);
                }
                else
                {
                    customers = customers
                        .OrderByDescending(p => p.LastName)
                        .ThenByDescending(p => p.FirstName);
                }
            }
            else 
            {
                if (sortDirection == "asc")
                {
                    customers = customers
                        .OrderBy(p => p.OrgName);
                }
                else
                {
                    customers = customers
                        .OrderByDescending(p => p.OrgName);
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
            pageSize = (pageSize == 0) ?5 : pageSize;
            ViewData["pageSizeID"] =
                new SelectList(new[] { "3", "5", "10", "20", "30", "40", "50", "100", "500" }, pageSize.ToString());
            var pagedData = await PaginatedList<Customer>.CreateAsync(customers.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);

        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
           
            var customer = await _context.Customers
                        .Include(p => p.Projects)
                        .FirstOrDefaultAsync(m => m.ID == id);

            if (id == null)
            {
                return NotFound();
            }

           
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OrgName,FirstName,LastName,MiddleName,Position,AddressLineOne,AddressLineTwo,ApartmentNumber,City,Province,Country,Phone,Email")] Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(customer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException dex)
            {
                if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed: Customers.Email"))
                {
                    ModelState.AddModelError("Email", "Unable to save changes.You cannot have same email address as another employee .");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Byte[] RowVersion)
        {
            var customerToUpdate = _context.Customers.SingleOrDefault(p => p.ID == id);

            if (customerToUpdate == null)
            {
                return NotFound();
            }

            _context.Entry(customerToUpdate).Property("RowVersion").OriginalValue = RowVersion;


            if (await TryUpdateModelAsync<Customer>(customerToUpdate, "", p => p.FirstName, p => p.LastName, p => p.MiddleName, p => p.OrgName, p => p.Position, p => p.AddressLineOne, p => p.AddressLineTwo
            , p => p.City, p => p.Province, p => p.Country, p => p.Phone, p => p.Email))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateConcurrencyException ex)// Added for concurrency
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Customer)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError("",
                            "Unable to save changes. The Customer was deleted by another user.");
                    }
                    else
                    {
                        var databaseValues = (Customer)databaseEntry.ToObject();

                        if (databaseValues.OrgName != clientValues.OrgName)
                            ModelState.AddModelError("OrgName", "Current value: "
                                + databaseValues.OrgName);
                        if (databaseValues.FirstName != clientValues.FirstName)
                            ModelState.AddModelError("FirstName", "Current value: "
                                + databaseValues.FirstName);
                        if (databaseValues.LastName != clientValues.LastName)
                            ModelState.AddModelError("LastName", "Current value: "
                                + databaseValues.LastName);
                        if (databaseValues.MiddleName != clientValues.MiddleName)
                            ModelState.AddModelError("MiddleName", "Current value: "
                                + databaseValues.MiddleName);
                        if (databaseValues.AddressLineOne != clientValues.AddressLineOne)
                            ModelState.AddModelError("AddressLineOne", "Current value: "
                                + databaseValues.AddressLineOne);
                        if (databaseValues.AddressLineTwo != clientValues.AddressLineTwo)
                            ModelState.AddModelError("AddressLineTwo", "Current value: "
                                + databaseValues.AddressLineTwo);
                        if (databaseValues.City != clientValues.City)
                            ModelState.AddModelError("City", "Current value: "
                                + databaseValues.City);
                        if (databaseValues.Province != clientValues.Province)
                            ModelState.AddModelError("Province", "Current value: "
                                + databaseValues.Province);
                        if (databaseValues.Country != clientValues.Country)
                            ModelState.AddModelError("Country", "Current value: "
                                + databaseValues.Country);
                        if (databaseValues.Phone != clientValues.Phone)
                            ModelState.AddModelError("Phone", "Current value: "
                                + databaseValues.Phone);
                        if (databaseValues.Email != clientValues.Email)
                            ModelState.AddModelError("Email", "Current value: "
                                + databaseValues.Email);



                        ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                                + "was modified by another user after you received your values. The "
                                + "edit operation was canceled and the current values in the database "
                                + "have been displayed. If you still want to save your version of this record, click "
                                + "the Save button again. Otherwise click the 'Back to List' hyperlink.");
                        customerToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
                catch (DbUpdateException dex)
                {
                    if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed: Customers.Email"))
                    {
                        ModelState.AddModelError("Email", "Unable to save changes.You cannot have same email address as another employee .");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                    }
                }
            }
            return View(customerToUpdate);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            try
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException dex)
            {
                if (dex.GetBaseException().Message.Contains("FOREIGN KEY constraint failed"))
                {
                    ModelState.AddModelError("", "Unable to Delete Customer. You cannot delete a Customer that has ongoing projects.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            return View(customer);
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.ID == id);
        }
    }
}
