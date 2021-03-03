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
    public class BidProductsController : Controller
    {
        private readonly OasisContext _context;

        public BidProductsController(OasisContext context)
        {
            _context = context;
        }

        // GET: BidProducts
        public async Task<IActionResult> Index(int? SearchProdQuantity, int? BidID, int? ProductID,
            int? page, int? pageSizeID, string actionButton, string sortDirection = "asc", string sortField = "Code")
        {

            //Prepare SelectLists for filters
            var bidProducts = from b in _context.BidProducts
                 .Include(b => b.Bid).
                 Include(b => b.Product)
                              select b;


            ViewData["Filtering"] = ""; //Assume not filtering

            //Clear the sort/filter/paging URL Cookie
            CookieHelper.CookieSet(HttpContext, "CustomersURL", "", -1);


          /*   if (SearchProdQuantity != null)
             {
                 bidProducts = bidProducts.Where(p => p.Quantity = SearchProdQuantity);   
                 ViewData["Filtering"] = "show";
             } /*
           <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Filter by Product Quantity:</label>
                        @Html.TextBox("SearchProdQuantity", null, new { @class = "form-control" })
                    </div>
                </div> 
          */
         
            if (BidID.HasValue)
            {
                bidProducts = bidProducts.Where(p => p.BidID == BidID);
                ViewData["Filtering"] = " show";
            }
            if (ProductID.HasValue)
            {
                bidProducts = bidProducts.Where(p => p.ProductID == ProductID);
                ViewData["Filtering"] = " show";
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

            if (sortField == "Code")
            {
                if (sortDirection == "asc")
                {
                    bidProducts = bidProducts
                        .OrderBy(p => p.Product.Code);
                }
                else
                {
                    bidProducts = bidProducts
                       .OrderByDescending(p => p.Product.Code);
                }
            }
            else if (sortField == "BidProduct")
            {
                if (sortDirection == "asc")
                {
                    bidProducts = bidProducts
                        .OrderBy(p => p.Quantity);
                        
                }
                else
                {
                    bidProducts = bidProducts
                         .OrderByDescending(p => p.Quantity);
                }
            }
            else //Sort by Bid :DateCreated
            {
                if (sortDirection == "asc")
                {
                    bidProducts = bidProducts
                     .OrderBy(p => p.Bid.DateCreated);
                }
                else
                {
                    bidProducts = bidProducts
                     .OrderByDescending(p => p.Bid.DateCreated);
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
            var pagedData = await PaginatedList<BidProduct>.CreateAsync(bidProducts.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);

        }

        // GET: BidProducts/Details/5
        public async Task<IActionResult> Details(int? id , string returnURL)
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

            var bidProduct = await _context.BidProducts
                .Include(b => b.Bid)
                .Include(b => b.Product)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bidProduct == null)
            {
                return NotFound();
            }

            return View(bidProduct);
        }

        // GET: BidProducts/Create
        public IActionResult Create(string returnURL)
        {
           // BidProduct bidProduct= new BidProduct();

            //Get the URL of the page that send us here
            if (String.IsNullOrEmpty(returnURL))
            {
                returnURL = Request.Headers["Referer"].ToString();
            }
            ViewData["returnURL"] = returnURL;

            PopulateDropDownListsProduct();
            PopulateDropDownListsBid();


            return View();
        }

        // POST: BidProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Quantity,BidID,ProductID")] BidProduct bidProduct ,string returnURL)
        {

            ViewData["returnURL"] = returnURL;

            if (ModelState.IsValid)
            {
                _context.Add(bidProduct);
                await _context.SaveChangesAsync();

                //If no referrer then go back to index
                if (String.IsNullOrEmpty(returnURL))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("Details", new { bidProduct.ID, returnURL });
                }
            }
            PopulateDropDownListsProduct();
            PopulateDropDownListsBid();

           // ViewData["ProductID"] = new SelectList(_context.Products, "ID", "Code", bidProduct.ProductID);
            return View(bidProduct);
        }

        // GET: BidProducts/Edit/5
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

            var bidProduct = await _context.BidProducts.FindAsync(id);
            if (bidProduct == null)
            {
                return NotFound();
            }

            PopulateDropDownListsProduct(bidProduct);
            PopulateDropDownListsBid(bidProduct);
            return View(bidProduct);
        }

        // POST: BidProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Quantity,BidID,ProductID")] BidProduct bidProduct, string returnURL)
        {

            ViewData["returnURL"] = returnURL;

            if (id != bidProduct.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bidProduct);
                    await _context.SaveChangesAsync();
                    //If no referrer then go back to index
                    if (String.IsNullOrEmpty(returnURL))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return RedirectToAction("Details", new { bidProduct.ID, returnURL });
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidProductExists(bidProduct.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            PopulateDropDownListsProduct(bidProduct);
            PopulateDropDownListsBid(bidProduct);
            return View(bidProduct);
        }

        // GET: BidProducts/Delete/5
        public async Task<IActionResult> Delete(int? id,string returnURL)
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

            var bidProduct = await _context.BidProducts
                .Include(b => b.Bid)
                .Include(b => b.Product)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bidProduct == null)
            {
                return NotFound();
            }

            return View(bidProduct);
        }

        // POST: BidProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id ,string returnURL)
        {
            ViewData["returnURL"] = returnURL;

            var bidProduct = await _context.BidProducts.FindAsync(id);
            _context.BidProducts.Remove(bidProduct);
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

        private bool BidProductExists(int id)
        {
            return _context.BidProducts.Any(e => e.ID == id);
        }


        // DDL & Lists for Bid and Products
        private void PopulateDropDownListsBid(BidProduct bidProduct = null)
        {
            ViewData["BidID"] = SelectListBid(bidProduct?.BidID);
        }
        private void PopulateDropDownListsProduct(BidProduct bidProduct = null)
        {
            ViewData["ProductID"] = SelectListProduct(bidProduct?.ProductID);
        }

        
        private SelectList SelectListBid(int? id)
        {
            var dQuery = from d in _context.Bids
                         orderby d.DateCreated
                         select d;
            return new SelectList(dQuery, "ID", "DateCreated", id);
        }

        private SelectList SelectListProduct(int? id)
        {
            var dQuery = from d in _context.Products
                         orderby d.Code
                         select d;
            return new SelectList(dQuery, "ID", "Code", id);
        }
        


    }
}
