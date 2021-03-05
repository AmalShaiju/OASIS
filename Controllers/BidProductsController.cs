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
    public class BidProductsController : Controller
    {
        private readonly OasisContext _context;

        public BidProductsController(OasisContext context)
        {
            _context = context;
        }

        // GET: BidProducts
        public async Task<IActionResult> Index()
        {
            var oasisContext = _context.BidProducts.Include(b => b.Bid).Include(b => b.Product);
            return View(await oasisContext.ToListAsync());
        }

        // GET: BidProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidProduct = await _context.BidProducts
                .Include(b => b.Bid)
                .Include(b => b.Product)
                .FirstOrDefaultAsync(m => m.BidID == id);
            if (bidProduct == null)
            {
                return NotFound();
            }

            return View(bidProduct);
        }

        // GET: BidProducts/Create
        public IActionResult Create()
        {
            ViewData["BidID"] = new SelectList(_context.Bids, "ID", "ID");
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "Code");
            return View();
        }

        // POST: BidProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BidID,Quantity,ProductID")] BidProduct bidProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bidProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BidID"] = new SelectList(_context.Bids, "ID", "ID", bidProduct.BidID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "Code", bidProduct.ProductID);
            return View(bidProduct);
        }

        // GET: BidProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidProduct = await _context.BidProducts.FindAsync(id);
            if (bidProduct == null)
            {
                return NotFound();
            }
            ViewData["BidID"] = new SelectList(_context.Bids, "ID", "ID", bidProduct.BidID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "Code", bidProduct.ProductID);
            return View(bidProduct);
        }

        // POST: BidProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BidID,Quantity,ProductID")] BidProduct bidProduct)
        {
            if (id != bidProduct.BidID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bidProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidProductExists(bidProduct.BidID))
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
            ViewData["BidID"] = new SelectList(_context.Bids, "ID", "ID", bidProduct.BidID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "Code", bidProduct.ProductID);
            return View(bidProduct);
        }

        // GET: BidProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidProduct = await _context.BidProducts
                .Include(b => b.Bid)
                .Include(b => b.Product)
                .FirstOrDefaultAsync(m => m.BidID == id);
            if (bidProduct == null)
            {
                return NotFound();
            }

            return View(bidProduct);
        }

        // POST: BidProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bidProduct = await _context.BidProducts.FindAsync(id);
            _context.BidProducts.Remove(bidProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BidProductExists(int id)
        {
            return _context.BidProducts.Any(e => e.BidID == id);
        }
    }
}
