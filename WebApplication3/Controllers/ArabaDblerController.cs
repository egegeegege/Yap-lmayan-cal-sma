using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ArabaDblerController : Controller
    {
        private readonly MyDbContext _context;

        public ArabaDblerController(MyDbContext context)
        {
            _context = context;
        }

        // GET: ArabaDbler
        public async Task<IActionResult> Index()
        {
            return View(await _context.Arabalar.ToListAsync());
        }

        // GET: ArabaDbler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arabaDb = await _context.Arabalar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arabaDb == null)
            {
                return NotFound();
            }

            return View(arabaDb);
        }

        // GET: ArabaDbler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArabaDbler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,Marka")] ArabaDb arabaDb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arabaDb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arabaDb);
        }

        // GET: ArabaDbler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arabaDb = await _context.Arabalar.FindAsync(id);
            if (arabaDb == null)
            {
                return NotFound();
            }
            return View(arabaDb);
        }

        // POST: ArabaDbler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,Marka")] ArabaDb arabaDb)
        {
            if (id != arabaDb.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arabaDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArabaDbExists(arabaDb.Id))
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
            return View(arabaDb);
        }

        // GET: ArabaDbler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arabaDb = await _context.Arabalar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arabaDb == null)
            {
                return NotFound();
            }

            return View(arabaDb);
        }

        // POST: ArabaDbler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arabaDb = await _context.Arabalar.FindAsync(id);
            if (arabaDb != null)
            {
                _context.Arabalar.Remove(arabaDb);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArabaDbExists(int id)
        {
            return _context.Arabalar.Any(e => e.Id == id);
        }
    }
}
