using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MeyveDbsController : Controller
    {
        private readonly MeyveDbContext _context;

        public MeyveDbsController(MeyveDbContext context)
        {
            _context = context;
        }

        // GET: MeyveDbs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyProperty.ToListAsync());
        }

        // GET: MeyveDbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meyveDb = await _context.MyProperty
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meyveDb == null)
            {
                return NotFound();
            }

            return View(meyveDb);
        }

        // GET: MeyveDbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MeyveDbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,LastName")] MeyveDb meyveDb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meyveDb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meyveDb);
        }

        // GET: MeyveDbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meyveDb = await _context.MyProperty.FindAsync(id);
            if (meyveDb == null)
            {
                return NotFound();
            }
            return View(meyveDb);
        }

        // POST: MeyveDbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,LastName")] MeyveDb meyveDb)
        {
            if (id != meyveDb.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meyveDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeyveDbExists(meyveDb.Id))
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
            return View(meyveDb);
        }

        // GET: MeyveDbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meyveDb = await _context.MyProperty
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meyveDb == null)
            {
                return NotFound();
            }

            return View(meyveDb);
        }

        // POST: MeyveDbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meyveDb = await _context.MyProperty.FindAsync(id);
            if (meyveDb != null)
            {
                _context.MyProperty.Remove(meyveDb);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeyveDbExists(int id)
        {
            return _context.MyProperty.Any(e => e.Id == id);
        }
    }
}
