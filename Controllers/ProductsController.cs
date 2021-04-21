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
    public class ProductsController : Controller
    {
        private readonly OasisContext _context;

        public ProductsController(OasisContext context)
        {
            _context = context;
        }

        // GET: Products
        [Authorize(Policy = "ProductViewPolicy")]

        public async Task<IActionResult> Index(string QuickSearchName, string SearchProdCode, string SearchProdSize ,int? ProductTypeID,
            int? page, int? pageSizeID, string actionButton, string sortDirection = "asc", string sortField = "Price")
        {
            //Start with Includes
            var products = from b in _context.Products
                 .Include(b => b.ProductType)
                              select b;



            // PopulateDropDownLists1(); //Data for ProductType filter DDL
            ViewData["ProductTypeID"] = new SelectList(_context
               .ProductTypes
               .OrderBy(c => c.Name), "ID", "Name");

            ViewData["Filtering"] = ""; //Assume not filtering

            //Clear the sort/filter/paging URL Cookie
            CookieHelper.CookieSet(HttpContext, "CustomersURL", "", -1);

            if (!String.IsNullOrEmpty(SearchProdCode))
            {
                products = products.Where(p => p.Code.ToUpper().Contains(SearchProdCode.ToUpper()));
                ViewData["Filtering"] = "show";
            }

            if (String.IsNullOrEmpty(SearchProdCode))
            {
                if (!String.IsNullOrEmpty(QuickSearchName))
                {
                    products = products.Where(p => p.Code.ToUpper().Contains(QuickSearchName.ToUpper()));
                }
            }

            if (!String.IsNullOrEmpty(SearchProdSize))
            {
                products = products.Where(p => p.size.Contains(SearchProdSize));
                ViewData["Filtering"] = "show";
            }

            if (ProductTypeID.HasValue)
            {
                products = products.Where(p => p.ProductTypeID == ProductTypeID);
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

            else if (sortField == "Description")
            {
                if (sortDirection == "asc")
                {
                    products = products
                        .OrderBy(p => p.Description);
                }
                else
                {
                    products = products
                       .OrderByDescending(p => p.Description);
                }
            }
            else if (sortField == "Price")
            {
                if (sortDirection == "asc")
                {
                    products = products
                        .OrderBy(p => p.Price);
                }
                else
                {
                    products = products
                       .OrderByDescending(p => p.Price);
                }
            }

            else //Sort By product type:Name
            {
                if (sortDirection == "asc")
                {
                    products = products
                    .OrderBy(p => p.ProductType.Name);
                }
                else
                {
                    products = products
                    .OrderByDescending(p => p.ProductType.Name);
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
            var pagedData = await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);

        }

        // GET: Products/Details/5
        [Authorize(Policy = "ProductViewPolicy")]
        public async Task<IActionResult> Details(int? id ,string returnURL)
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

            var product = await _context.Products
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Authorize(Policy = "ProductCreatePolicy")]
        public IActionResult Create(string returnURL, int? productTypeID)
        {
            Product product = new Product();
            if (productTypeID != null)
            {
                product.ProductTypeID = (int)productTypeID;
                //save the customer ID
                TempData["ProductTypeID"] = productTypeID;
            }
            else
            {
                TempData["ProductTypeID"] = 0;

            }

            //Get the URL of the page that send us here
            if (String.IsNullOrEmpty(returnURL))
            {
                returnURL = Request.Headers["Referer"].ToString();
            }

            ViewData["returnURL"] = returnURL;

            PopulateDropDownLists1(product);
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "ProductCreatePolicy")]
        public async Task<IActionResult> Create([Bind("ID,Code,Description,size,Price,ProductTypeID")] Product product ,string returnURL, int fromProductTypeID)
        {
            ViewData["returnURL"] = returnURL;

            if (fromProductTypeID != 0)
            {
                //set the tempdata again for post back after error
                TempData["ProductTypeID"] = fromProductTypeID;

                product.ProductTypeID = fromProductTypeID;
            }
            else
            {
                //set the tempdata again for post back after error
                TempData["ProductTypeID"] = 0;
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();

                    //If no referrer then go back to index
                    if (String.IsNullOrEmpty(returnURL))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return RedirectToAction("Details", new { product.ID, returnURL });
                    }
                }
            }
            catch (DbUpdateException dex)
            {

                if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed: Products.Code"))
                {
                    ModelState.AddModelError("Code", "Unable to save changes.You cannot have duplicate Product Code.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes.Try again,and if the problem persists see your system administrator.");
                }
            }
            PopulateDropDownLists1(product);
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Policy = "ProductEditPolicy")]

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

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            PopulateDropDownLists1(product);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "ProductEditPolicy")]
        public async Task<IActionResult> Edit(int id, string returnURL ,Byte[] RowVersion)
        {
            ViewData["returnURL"] = returnURL;

            //Role to update
            var productToUpdate = await _context.Products.SingleOrDefaultAsync(p => p.ID == id);

            if (productToUpdate == null)
            {
                return NotFound();
            }

            //Put the original RowVersion value in the OriginalValues collection for the entity
            _context.Entry(productToUpdate).Property("RowVersion").OriginalValue = RowVersion;

            if (await TryUpdateModelAsync<Product>(productToUpdate, "",
                p => p.size, p => p.Price, p => p.Code, p => p.Description ,p => p.ProductTypeID ))
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
                        return RedirectToAction("Details", new { productToUpdate.ID, returnURL });
                    }      
                }
                catch (DbUpdateConcurrencyException ex)// Added for concurrency
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Product)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError("",
                            "Unable to save changes. The Product was deleted by another user.");
                    }
                    else
                    {
                        var databaseValues = (Product)databaseEntry.ToObject();

                        if (databaseValues.Code != clientValues.Code)
                            ModelState.AddModelError("Code", "Current value: "
                                + databaseValues.Code);
                        if (databaseValues.Description != clientValues.Description)
                            ModelState.AddModelError("Description", "Current value: "
                                + databaseValues.Description);
                        if (databaseValues.size != clientValues.size)
                            ModelState.AddModelError("size", "Current value: "
                                + databaseValues.size);
                        if (databaseValues.Price != clientValues.Price)
                            ModelState.AddModelError("Price", "Current value: "
                                + databaseValues.Price);
                        if (databaseValues.ProductTypeID!= clientValues.ProductTypeID)
                        {
                            ProductType databaseProductType = await _context.ProductTypes.SingleOrDefaultAsync(i => i.ID == databaseValues.ProductTypeID);
                            ModelState.AddModelError("ProductTypeID", $"Current value: {databaseProductType?.Name}");
                        }
                            
                        ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                                + "was modified by another user after you received your values. The "
                                + "edit operation was canceled and the current values in the database "
                                + "have been displayed. If you still want to save your version of this record, click "
                                + "the Save button again. Otherwise click the 'Back to List' hyperlink.");
                        productToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
                 catch (DbUpdateException dex)
                {

                    if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed: Products.Code"))
                    {
                        ModelState.AddModelError("Code", "Unable to save changes.You cannot have duplicate Product Code.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes.Try again,and if the problem persists see your system administrator.");
                    }
                }

         
            }
            PopulateDropDownLists1(productToUpdate);
            return View(productToUpdate);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id , string returnURL)
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


            var product = await _context.Products
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id , string returnURL)
        {
            ViewData["returnURL"] = returnURL;

            var product = await _context.Products.FindAsync(id);

            _context.Products.Remove(product);
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

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }

        // drop down lists for Bids and Products 
        private void PopulateDropDownLists1(Product product = null)
        {
            var dQuery = from d in _context.ProductTypes
                         orderby d.Name
                         select d;
            ViewData["ProductTypeID"] = new SelectList(dQuery, "ID", "Name", product?.ProductTypeID);

        }
    }

}
