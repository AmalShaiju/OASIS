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
    public class ProjectsController : Controller
    {
        private readonly OasisContext _context;

        public ProjectsController(OasisContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var oasisContext = _context.Projects.Include(p => p.Customer);
            return View(await oasisContext.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Customer)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            Project project = new Project();
            PopulateDropDownLists(project);
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,SiteAddressLineOne,SiteAddressLineTwo,City,Province,Country,CustomerID")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDropDownLists(project);
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

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
        public async Task<IActionResult> Edit(int id, Byte[] RowVersion)
        {
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
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)// Added for concurrency
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Project)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError("",
                            "Unable to save changes. The Patient was deleted by another user.");
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
            var project = await _context.Projects.FindAsync(id);

            try
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
