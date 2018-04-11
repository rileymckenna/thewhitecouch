using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class CheckoutsController : Controller
    {
        private readonly thewhitecouchContext _context;

        public CheckoutsController(thewhitecouchContext context)
        {
            _context = context;
        }

        // GET: Checkouts
        public async Task<IActionResult> Index()
        {
            var thewhitecouchContext = _context.Checkout.Include(c => c.Asset).Include(c => c.Contact).Include(c => c.Location);
            return View(await thewhitecouchContext.ToListAsync());
        }

        // GET: Checkouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkout = await _context.Checkout
                .Include(c => c.Asset)
                .Include(c => c.Contact)
                .Include(c => c.Location)
                .SingleOrDefaultAsync(m => m.Checkoutid == id);
            if (checkout == null)
            {
                return NotFound();
            }

            return View(checkout);
        }

        // GET: Checkouts/Create
        public IActionResult Create()
        {
            ViewData["Assetid"] = new SelectList(_context.Assets, "Assetid", "Assetid");
            ViewData["Contactid"] = new SelectList(_context.Customers, "Customerid", "Customerid");
            ViewData["Locationid"] = new SelectList(_context.Locations, "AddressId", "AddressId");
            return View();
        }

        // POST: Checkouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Checkoutid,Startdate,Enddate,Contactid,Locationid,Assetid")] Checkout checkout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Assetid"] = new SelectList(_context.Assets, "Assetid", "Assetid", checkout.Assetid);
            ViewData["Contactid"] = new SelectList(_context.Customers, "Customerid", "Customerid", checkout.Contactid);
            ViewData["Locationid"] = new SelectList(_context.Locations, "AddressId", "AddressId", checkout.Locationid);
            return View(checkout);
        }

        // GET: Checkouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkout = await _context.Checkout.SingleOrDefaultAsync(m => m.Checkoutid == id);
            if (checkout == null)
            {
                return NotFound();
            }
            ViewData["Assetid"] = new SelectList(_context.Assets, "Assetid", "Assetid", checkout.Assetid);
            ViewData["Contactid"] = new SelectList(_context.Customers, "Customerid", "Customerid", checkout.Contactid);
            ViewData["Locationid"] = new SelectList(_context.Locations, "AddressId", "AddressId", checkout.Locationid);
            return View(checkout);
        }

        // POST: Checkouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Checkoutid,Startdate,Enddate,Contactid,Locationid,Assetid")] Checkout checkout)
        {
            if (id != checkout.Checkoutid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckoutExists(checkout.Checkoutid))
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
            ViewData["Assetid"] = new SelectList(_context.Assets, "Assetid", "Assetid", checkout.Assetid);
            ViewData["Contactid"] = new SelectList(_context.Customers, "Customerid", "Customerid", checkout.Contactid);
            ViewData["Locationid"] = new SelectList(_context.Locations, "AddressId", "AddressId", checkout.Locationid);
            return View(checkout);
        }

        // GET: Checkouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkout = await _context.Checkout
                .Include(c => c.Asset)
                .Include(c => c.Contact)
                .Include(c => c.Location)
                .SingleOrDefaultAsync(m => m.Checkoutid == id);
            if (checkout == null)
            {
                return NotFound();
            }

            return View(checkout);
        }

        // POST: Checkouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkout = await _context.Checkout.SingleOrDefaultAsync(m => m.Checkoutid == id);
            _context.Checkout.Remove(checkout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckoutExists(int id)
        {
            return _context.Checkout.Any(e => e.Checkoutid == id);
        }
    }
}
