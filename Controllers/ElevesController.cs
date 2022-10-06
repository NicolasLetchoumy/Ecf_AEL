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
    public class ElevesController : Controller
    {
        private readonly ECF_AELContext _context;

        public ElevesController(ECF_AELContext context)
        {
            _context = context;
        }

        // GET: Eleves
        public async Task<IActionResult> Index()
        {
              return _context.Eleves != null ?
                View(await _context.Eleves.ToListAsync()) :
                Problem("Entity set 'NicolatorContext.Genies'  is null.");
        }

        // GET: Eleves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Eleves == null)
            {
                return NotFound();
            }

            var eleve = await _context.Eleves
                .FirstOrDefaultAsync(m => m.IdÉlève == id);
            if (eleve == null)
            {
                return NotFound();
            }

            return View(eleve);
        }

        // GET: Eleves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Eleves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdÉlève,NomÉlève,PrénomÉlève,Code,Conduite,DateNaissance")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eleve);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eleve);
        }

        // GET: Eleves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Eleves == null)
            {
                return NotFound();
            }

            var eleve = await _context.Eleves.FindAsync(id);
            if (eleve == null)
            {
                return NotFound();
            }
            return View(eleve);
        }

        // POST: Eleves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdÉlève,NomÉlève,PrénomÉlève,Code,Conduite,DateNaissance")] Eleve eleve)
        {
            if (id != eleve.IdÉlève)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eleve);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EleveExists(eleve.IdÉlève))
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
            return View(eleve);
        }

        // GET: Eleves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Eleves == null)
            {
                return NotFound();
            }

            var eleve = await _context.Eleves
                .FirstOrDefaultAsync(m => m.IdÉlève == id);
            if (eleve == null)
            {
                return NotFound();
            }

            return View(eleve);
        }

        // POST: Eleves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Eleves == null)
            {
                return Problem("Entity set 'ECF_AELContext.Eleves'  is null.");
            }
            var eleve = await _context.Eleves.FindAsync(id);
            if (eleve != null)
            {
                _context.Eleves.Remove(eleve);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EleveExists(int id)
        {
          return _context.Eleves.Any(e => e.IdÉlève == id);
        }
    }
}
