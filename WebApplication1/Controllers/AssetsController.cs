using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using X.PagedList;
using PagedList;

namespace WebApplication1.Controllers
{
    public class AssetsController : Controller
    {
        private readonly thewhitecouchContext _context;

        public AssetsController(thewhitecouchContext context)
        {
            _context = context;
        }

        // GET: Assets
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page, int perPage)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var thewhitecouchContext = _context.Assets.Include(a => a.Category).Include(a => a.Color).Include(a => a.Image).Include(a => a.Location).Include(a => a.Related);

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var asset = from a in thewhitecouchContext select a;
            //Search Bar logic
            if (!String.IsNullOrEmpty(searchString))
            {
                asset = asset.Where(a => a.Comments.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    asset = asset.OrderByDescending(a => a.Category);
                    break;
                case "Date":
                    asset = asset.OrderBy(a => a.AquiredDate);
                    break;
                case "date_desc":
                    asset = asset.OrderByDescending(a => a.AquiredDate);
                    break;
                default:
                    asset = asset.OrderBy(a => a.Category);
                    break;
            }

            return View(await asset.ToListAsync());
        }

        // GET: Assets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assets = await _context.Assets
                .Include(a => a.Category)
                .Include(a => a.Color)
                .Include(a => a.Image)
                .Include(a => a.Location)
                .Include(a => a.Related)
                .SingleOrDefaultAsync(m => m.Assetid == id);
            if (assets == null)
            {
                return NotFound();
            }

            return View(assets);
        }

        // GET: Assets/Create
        public IActionResult Create()
        {
            ViewData["Categoryid"] = new SelectList(_context.Categories, "Categoryid", "Categoryid");
            ViewData["Colorid"] = new SelectList(_context.Colors, "Colorid", "Colorid");
            ViewData["Imageid"] = new SelectList(_context.Images, "Imageid", "Imageid");
            ViewData["Locationid"] = new SelectList(_context.Locations, "AddressId", "AddressId");
            ViewData["Relatedid"] = new SelectList(_context.Assets, "Assetid", "Assetid");
            return View();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Assetid,AquiredDate,Imageid,Checkedout,Comments,Description,Height,Width,Length,Weight,Purchaseprice,Relatedid,Categoryid,Colorid,Locationid")] Assets assets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Categoryid"] = new SelectList(_context.Categories, "Categoryid", "Categoryid", assets.Categoryid);
            ViewData["Colorid"] = new SelectList(_context.Colors, "Colorid", "Colorid", assets.Colorid);
            ViewData["Imageid"] = new SelectList(_context.Images, "Imageid", "Imageid", assets.Imageid);
            ViewData["Locationid"] = new SelectList(_context.Locations, "AddressId", "AddressId", assets.Locationid);
            ViewData["Relatedid"] = new SelectList(_context.Assets, "Assetid", "Assetid", assets.Relatedid);
            return View(assets);
        }

        // GET: Assets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assets = await _context.Assets.SingleOrDefaultAsync(m => m.Assetid == id);
            if (assets == null)
            {
                return NotFound();
            }
            ViewData["Categoryid"] = new SelectList(_context.Categories, "Categoryid", "Categoryid", assets.Categoryid);
            ViewData["Colorid"] = new SelectList(_context.Colors, "Colorid", "Colorid", assets.Colorid);
            ViewData["Imageid"] = new SelectList(_context.Images, "Imageid", "Imageid", assets.Imageid);
            ViewData["Locationid"] = new SelectList(_context.Locations, "AddressId", "AddressId", assets.Locationid);
            ViewData["Relatedid"] = new SelectList(_context.Assets, "Assetid", "Assetid", assets.Relatedid);
            return View(assets);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Assetid,AquiredDate,Imageid,Checkedout,Comments,Description,Height,Width,Length,Weight,Purchaseprice,Relatedid,Categoryid,Colorid,Locationid")] Assets assets)
        {
            if (id != assets.Assetid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetsExists(assets.Assetid))
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
            ViewData["Categoryid"] = new SelectList(_context.Categories, "Categoryid", "Categoryid", assets.Categoryid);
            ViewData["Colorid"] = new SelectList(_context.Colors, "Colorid", "Colorid", assets.Colorid);
            ViewData["Imageid"] = new SelectList(_context.Images, "Imageid", "Imageid", assets.Imageid);
            ViewData["Locationid"] = new SelectList(_context.Locations, "AddressId", "AddressId", assets.Locationid);
            ViewData["Relatedid"] = new SelectList(_context.Assets, "Assetid", "Assetid", assets.Relatedid);
            return View(assets);
        }

        // GET: Assets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assets = await _context.Assets
                .Include(a => a.Category)
                .Include(a => a.Color)
                .Include(a => a.Image)
                .Include(a => a.Location)
                .Include(a => a.Related)
                .SingleOrDefaultAsync(m => m.Assetid == id);
            if (assets == null)
            {
                return NotFound();
            }

            return View(assets);
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assets = await _context.Assets.SingleOrDefaultAsync(m => m.Assetid == id);
            _context.Assets.Remove(assets);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetsExists(int id)
        {
            return _context.Assets.Any(e => e.Assetid == id);
        }
    }
}
