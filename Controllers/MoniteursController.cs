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
    public class MoniteursController : Controller
    {
        private readonly ECF_AELContext _context;

        public MoniteursController(ECF_AELContext context)
        {
            _context = context;
        }

        // GET: Moniteurs
        public async Task<IActionResult> Index()
        {
              return View(await _context.Moniteurs.ToListAsync());
        }

        // GET: Moniteurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Moniteurs == null)
            {
                return NotFound();
            }

            var moniteur = await _context.Moniteurs
                .FirstOrDefaultAsync(m => m.IdMoniteur == id);
            if (moniteur == null)
            {
                return NotFound();
            }

            return View(moniteur);
        }

        // GET: Moniteurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moniteurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMoniteur,NomMoniteur,PrénomMoniteur,DateNaissance,DateEmbauche,Activité")] Moniteur moniteur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moniteur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moniteur);
        }

        // GET: Moniteurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Moniteurs == null)
            {
                return NotFound();
            }

            var moniteur = await _context.Moniteurs.FindAsync(id);
            if (moniteur == null)
            {
                return NotFound();
            }
            return View(moniteur);
        }

        // POST: Moniteurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMoniteur,NomMoniteur,PrénomMoniteur,DateNaissance,DateEmbauche,Activité")] Moniteur moniteur)
        {
            if (id != moniteur.IdMoniteur)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moniteur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoniteurExists(moniteur.IdMoniteur))
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
            return View(moniteur);
        }

        // GET: Moniteurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Moniteurs == null)
            {
                return NotFound();
            }

            var moniteur = await _context.Moniteurs
                .FirstOrDefaultAsync(m => m.IdMoniteur == id);
            if (moniteur == null)
            {
                return NotFound();
            }

            return View(moniteur);
        }

        // POST: Moniteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Moniteurs == null)
            {
                return Problem("Entity set 'ECF_AELContext.Moniteurs'  is null.");
            }
            var moniteur = await _context.Moniteurs.FindAsync(id);
            if (moniteur != null)
            {
                _context.Moniteurs.Remove(moniteur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoniteurExists(int id)
        {
          return _context.Moniteurs.Any(e => e.IdMoniteur == id);
        }
    }
}
