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
    public class LeconsController : Controller
    {
        private readonly ECF_AELContext _context;

        public LeconsController(ECF_AELContext context)
        {
            _context = context;
        }

        // GET: Lecons
        public async Task<IActionResult> Index()
        {
            var eCF_AELContext = _context.Lecons.Include(l => l.DateHeureNavigation).Include(l => l.IdMoniteurNavigation).Include(l => l.IdÉlèveNavigation).Include(l => l.ModèleVéhiculeNavigation);
            return View(await eCF_AELContext.ToListAsync());
        }

        // GET: Lecons/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Lecons == null)
            {
                return NotFound();
            }

            var lecon = await _context.Lecons
                .Include(l => l.DateHeureNavigation)
                .Include(l => l.IdMoniteurNavigation)
                .Include(l => l.IdÉlèveNavigation)
                .Include(l => l.ModèleVéhiculeNavigation)
                .FirstOrDefaultAsync(m => m.ModèleVéhicule == id);
            if (lecon == null)
            {
                return NotFound();
            }

            return View(lecon);
        }

        // GET: Lecons/Create
        public IActionResult Create()
        {
            ViewData["DateHeure"] = new SelectList(_context.Calendriers, "DateHeure", "DateHeure");
            ViewData["IdMoniteur"] = new SelectList(_context.Moniteurs, "IdMoniteur", "IdMoniteur");
            ViewData["IdÉlève"] = new SelectList(_context.Eleves, "IdÉlève", "IdÉlève");
            ViewData["ModèleVéhicule"] = new SelectList(_context.Modeles, "ModèleVéhicule", "ModèleVéhicule");
            return View();
        }

        // POST: Lecons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModèleVéhicule,DateHeure,IdÉlève,IdMoniteur,Durée")] Lecon lecon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lecon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DateHeure"] = new SelectList(_context.Calendriers, "DateHeure", "DateHeure", lecon.DateHeure);
            ViewData["IdMoniteur"] = new SelectList(_context.Moniteurs, "IdMoniteur", "IdMoniteur", lecon.IdMoniteur);
            ViewData["IdÉlève"] = new SelectList(_context.Eleves, "IdÉlève", "IdÉlève", lecon.IdÉlève);
            ViewData["ModèleVéhicule"] = new SelectList(_context.Modeles, "ModèleVéhicule", "ModèleVéhicule", lecon.ModèleVéhicule);
            return View(lecon);
        }

        // GET: Lecons/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Lecons == null)
            {
                return NotFound();
            }

            var lecon = await _context.Lecons.FindAsync(id);
            if (lecon == null)
            {
                return NotFound();
            }
            ViewData["DateHeure"] = new SelectList(_context.Calendriers, "DateHeure", "DateHeure", lecon.DateHeure);
            ViewData["IdMoniteur"] = new SelectList(_context.Moniteurs, "IdMoniteur", "IdMoniteur", lecon.IdMoniteur);
            ViewData["IdÉlève"] = new SelectList(_context.Eleves, "IdÉlève", "IdÉlève", lecon.IdÉlève);
            ViewData["ModèleVéhicule"] = new SelectList(_context.Modeles, "ModèleVéhicule", "ModèleVéhicule", lecon.ModèleVéhicule);
            return View(lecon);
        }

        // POST: Lecons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ModèleVéhicule,DateHeure,IdÉlève,IdMoniteur,Durée")] Lecon lecon)
        {
            if (id != lecon.ModèleVéhicule)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lecon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeconExists(lecon.ModèleVéhicule))
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
            ViewData["DateHeure"] = new SelectList(_context.Calendriers, "DateHeure", "DateHeure", lecon.DateHeure);
            ViewData["IdMoniteur"] = new SelectList(_context.Moniteurs, "IdMoniteur", "IdMoniteur", lecon.IdMoniteur);
            ViewData["IdÉlève"] = new SelectList(_context.Eleves, "IdÉlève", "IdÉlève", lecon.IdÉlève);
            ViewData["ModèleVéhicule"] = new SelectList(_context.Modeles, "ModèleVéhicule", "ModèleVéhicule", lecon.ModèleVéhicule);
            return View(lecon);
        }

        // GET: Lecons/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Lecons == null)
            {
                return NotFound();
            }

            var lecon = await _context.Lecons
                .Include(l => l.DateHeureNavigation)
                .Include(l => l.IdMoniteurNavigation)
                .Include(l => l.IdÉlèveNavigation)
                .Include(l => l.ModèleVéhiculeNavigation)
                .FirstOrDefaultAsync(m => m.ModèleVéhicule == id);
            if (lecon == null)
            {
                return NotFound();
            }

            return View(lecon);
        }

        // POST: Lecons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Lecons == null)
            {
                return Problem("Entity set 'ECF_AELContext.Lecons'  is null.");
            }
            var lecon = await _context.Lecons.FindAsync(id);
            if (lecon != null)
            {
                _context.Lecons.Remove(lecon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeconExists(string id)
        {
          return _context.Lecons.Any(e => e.ModèleVéhicule == id);
        }
    }
}
