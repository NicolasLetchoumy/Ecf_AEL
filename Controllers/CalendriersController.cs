using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECF_auto_ecole.Models;

namespace ECF_auto_ecole.Controllers
{
    public class CalendriersController : Controller
    {
        private readonly ECF_AELContext _context;

        public CalendriersController(ECF_AELContext context)
        {
            _context = context;
        }

        // GET: Calendriers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Calendriers.ToListAsync());
        }

        // GET: Calendriers/Details/5
        public async Task<IActionResult> Details(DateTime? id)
        {
            if (id == null || _context.Calendriers == null)
            {
                return NotFound();
            }

            var calendrier = await _context.Calendriers
                .FirstOrDefaultAsync(m => m.DateHeure == id);
            if (calendrier == null)
            {
                return NotFound();
            }

            return View(calendrier);
        }

        // GET: Calendriers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Calendriers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DateHeure")] Calendrier calendrier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calendrier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calendrier);
        }

        // GET: Calendriers/Edit/5
        public async Task<IActionResult> Edit(DateTime? id)
        {
            if (id == null || _context.Calendriers == null)
            {
                return NotFound();
            }

            var calendrier = await _context.Calendriers.FindAsync(id);
            if (calendrier == null)
            {
                return NotFound();
            }
            return View(calendrier);
        }

        // POST: Calendriers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DateTime id, [Bind("DateHeure")] Calendrier calendrier)
        {
            if (id != calendrier.DateHeure)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calendrier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalendrierExists(calendrier.DateHeure))
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
            return View(calendrier);
        }

        // GET: Calendriers/Delete/5
        public async Task<IActionResult> Delete(DateTime? id)
        {
            if (id == null || _context.Calendriers == null)
            {
                return NotFound();
            }

            var calendrier = await _context.Calendriers
                .FirstOrDefaultAsync(m => m.DateHeure == id);
            if (calendrier == null)
            {
                return NotFound();
            }

            return View(calendrier);
        }

        // POST: Calendriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateTime id)
        {
            if (_context.Calendriers == null)
            {
                return Problem("Entity set 'ECF_AELContext.Calendriers'  is null.");
            }
            var calendrier = await _context.Calendriers.FindAsync(id);
            if (calendrier != null)
            {
                _context.Calendriers.Remove(calendrier);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalendrierExists(DateTime id)
        {
          return _context.Calendriers.Any(e => e.DateHeure == id);
        }
    }
}
