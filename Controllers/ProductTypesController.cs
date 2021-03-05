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
    public class ProductTypesController : Controller
    {
        private readonly OasisContext _context;

        public ProductTypesController(OasisContext context)
        {
            _context = context;
        }

        // GET: ProductTypes
        public async Task<IActionResult> Index(string SearchByName,
            int? page, int? pageSizeID, string actionButton, string sortDirection = "asc", string sortField = "Name")
        {  
            var productTypes = from b in _context.ProductTypes select b;
            ViewData["Filtering"] = ""; //Assume not filtering

            //Clear the sort/filter/paging URL Cookie
            CookieHelper.CookieSet(HttpContext, "CustomersURL", "", -1);


            if (!String.IsNullOrEmpty(SearchByName))
            {
                productTypes = productTypes.Where(p => p.Name.ToUpper().Contains(SearchByName.ToUpper()));
                ViewData["Filtering"] = "show";
            }

            //Before we sort, see if we have called for a change of filtering or sorting
            if (!String.IsNullOrEmpty(actionButton))
            {
                page = 1;//Reset page to start
                if (actionButton != "Filter")
                {
                    if (actionButton == sortField)
                    {
                        sortDirection = sortDirection == "asc" ? "desc" : "asc";
                    }
                    sortField = actionButton;
                }
            }

            if (sortField == "Name")
            {
                if (sortDirection == "asc")
                {
                    productTypes = productTypes
                        .OrderBy(p => p.Name);
                }
                else
                {
                    productTypes = productTypes
                       .OrderByDescending( p => p.Name);
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
            var pagedData = await PaginatedList<ProductType>.CreateAsync(productTypes.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);

        }

        // GET: ProductTypes/Details/5
        public async Task<IActionResult> Details(int? id , string returnURL)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Get the URL of the page that send us here
            if(String.IsNullOrEmpty(returnURL))
            {
                returnURL = Request.Headers["Referer"].ToString();
            }
            ViewData["returnURL"] = returnURL;

            var productType = await _context.ProductTypes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        // GET: ProductTypes/Create
        public IActionResult Create(string returnURL)
        {
            //Get the URL of the page that send us here
            if (String.IsNullOrEmpty(returnURL))
            {
                returnURL = Request.Headers["Referer"].ToString();
            }
            ViewData["returnURL"] = returnURL;

            return View();
        }

        // POST: ProductTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] ProductType productType ,string returnURL ,Byte[] RowVersion)
        {
            ViewData["returnURL"] = returnURL;
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(productType);
                    await _context.SaveChangesAsync();

                    //If no referrer then go back to index
                    if(String.IsNullOrEmpty(returnURL))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return RedirectToAction("Details", new { productType.ID , returnURL});
                    }
                   
                }
            }
            catch (DbUpdateException dex)
            {

                if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed: ProductTypes.Name"))
                {
                    ModelState.AddModelError("Name", "Unable to save changes.You cannot have duplicate Product Type Name.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes.Try again,and if the problem persists see your system administrator.");
                }
            }
            return View(productType);
        }

        // GET: ProductTypes/Edit/5
        public async Task<IActionResult> Edit(int? id ,string returnURL)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Get the URL of the page that send us here
            if (String.IsNullOrEmpty(returnURL))
            {
                returnURL = Request.Headers["Referer"].ToString();
            }
            ViewData["returnURL"] = returnURL;

            var productType = await _context.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }

        // POST: ProductTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id ,Byte[] RowVersion, string returnURL)
        {
            ViewData["returnURL"] = returnURL;

            //get the productType to update
            var productTypeToUpdate = await _context.ProductTypes.SingleOrDefaultAsync(p => p.ID == id);

            if (productTypeToUpdate == null)
            {
                return NotFound();
            }

            //Put the original RowVersion value in the OriginalValues collection for the entity
            _context.Entry(productTypeToUpdate).Property("RowVersion").OriginalValue = RowVersion;

            if (await TryUpdateModelAsync<ProductType>(productTypeToUpdate, "",
                p => p.Name))
            {
                try
                {
                      await _context.SaveChangesAsync();
                     //If no referrer then go back to index
                     if (String.IsNullOrEmpty(returnURL))
                         {
                                return RedirectToAction(nameof(Index));
                         }
                     else
                         {
                    return RedirectToAction("Details", new { productTypeToUpdate.ID, returnURL });
                    
                         }
                }  
                catch (DbUpdateConcurrencyException ex)// Added for concurrency
                {
                    
                      var exceptionEntry = ex.Entries.Single();
                     var clientValues = (ProductType)exceptionEntry.Entity;
                     var databaseEntry = exceptionEntry.GetDatabaseValues();
                     if (databaseEntry == null)
                     {
                         ModelState.AddModelError("",
                             "Unable to save changes. The Product was deleted by another user.");
                     }
                     else
                     {
                         var databaseValues = (ProductType)databaseEntry.ToObject();
                         if (databaseValues.Name != clientValues.Name)
                             ModelState.AddModelError("Name", "Current value: "
                                 + databaseValues.Name);

                         ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                                 + "was modified by another user after you received your values. The "
                                 + "edit operation was canceled and the current values in the database "
                                 + "have been displayed. If you still want to save your version of this record, click "
                                 + "the Save button again. Otherwise click the 'Back to List' hyperlink.");
                         productTypeToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                         ModelState.Remove("RowVersion");
                     } 
                }
                catch (DbUpdateException dex)
                {

                    if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed: ProductTypes.Name"))
                    {
                        ModelState.AddModelError("Name", "Unable to save changes.You cannot have duplicate Product Type Name.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes.Try again,and if the problem persists see your system administrator.");
                    }
                }

            }

            return View(productTypeToUpdate);
        }

        // GET: ProductTypes/Delete/5
        public async Task<IActionResult> Delete(int? id ,string returnURL)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Get the URL of the page that send us here
            if (String.IsNullOrEmpty(returnURL))
            {
                returnURL = Request.Headers["Referer"].ToString();
            }
            ViewData["returnURL"] = returnURL;


            var productType = await _context.ProductTypes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        // POST: ProductTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id ,string returnURL)
        {
            ViewData["returnURL"] = returnURL;

            var productType = await _context.ProductTypes
                          .Include(p => p.Products)
                         .FirstOrDefaultAsync(m => m.ID == id);
            try
            {
                _context.ProductTypes.Remove(productType);
                await _context.SaveChangesAsync();
                if (String.IsNullOrEmpty(returnURL))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return Redirect(ViewData["returnURL"].ToString());
                }
                
            }
            catch (InvalidOperationException dex)
            {
                if (dex.GetBaseException().Message.Contains("foreign key"))
                {
                    ModelState.AddModelError("", "Unable to Delete Product Type. You cannot delete a Product Type that has Products assigned.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            catch (DbUpdateException dex)
            {
                if (dex.GetBaseException().Message.Contains("FOREIGN KEY constraint failed"))
                {
                    ModelState.AddModelError("", "Unable to Delete Product Type. You cannot delete a Product Type that has Ptoducts assigned.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }


            return View(productType);
        }

        private bool ProductTypeExists(int id)
        {
            return _context.ProductTypes.Any(e => e.ID == id);
        }
    }
}
