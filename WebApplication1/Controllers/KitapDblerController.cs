using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class KitapDblerController : Controller
    {
        private readonly MyDbContext _context;

        public KitapDblerController(MyDbContext context)
        {
            _context = context;
        }

        // GET: KitapDbler
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kitaplar.ToListAsync());
        }

        // GET: KitapDbler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitapDb = await _context.Kitaplar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kitapDb == null)
            {
                return NotFound();
            }

            return View(kitapDb);
        }

        // GET: KitapDbler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KitapDbler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Yazar,YayınEvi")] KitapDb kitapDb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitapDb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kitapDb);
        }

        // GET: KitapDbler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitapDb = await _context.Kitaplar.FindAsync(id);
            if (kitapDb == null)
            {
                return NotFound();
            }
            return View(kitapDb);
        }

        // POST: KitapDbler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Yazar,YayınEvi")] KitapDb kitapDb)
        {
            if (id != kitapDb.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitapDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitapDbExists(kitapDb.Id))
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
            return View(kitapDb);
        }

        // GET: KitapDbler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitapDb = await _context.Kitaplar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kitapDb == null)
            {
                return NotFound();
            }

            return View(kitapDb);
        }

        // POST: KitapDbler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kitapDb = await _context.Kitaplar.FindAsync(id);
            if (kitapDb != null)
            {
                _context.Kitaplar.Remove(kitapDb);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitapDbExists(int id)
        {
            return _context.Kitaplar.Any(e => e.Id == id);
        }
    }
}
