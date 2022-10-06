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
    public class ModelesController : Controller
    {
        private readonly ECF_AELContext _context;

        public ModelesController(ECF_AELContext context)
        {
            _context = context;
        }

        // GET: Modeles
        public async Task<IActionResult> Index()
        {
              return View(await _context.Modeles.ToListAsync());
        }

        // GET: Modeles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Modeles == null)
            {
                return NotFound();
            }

            var modele = await _context.Modeles
                .FirstOrDefaultAsync(m => m.ModèleVéhicule == id);
            if (modele == null)
            {
                return NotFound();
            }

            return View(modele);
        }

        // GET: Modeles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modeles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModèleVéhicule,Marque,Année,DateAchat")] Modele modele)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modele);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modele);
        }

        // GET: Modeles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Modeles == null)
            {
                return NotFound();
            }

            var modele = await _context.Modeles.FindAsync(id);
            if (modele == null)
            {
                return NotFound();
            }
            return View(modele);
        }

        // POST: Modeles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ModèleVéhicule,Marque,Année,DateAchat")] Modele modele)
        {
            if (id != modele.ModèleVéhicule)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modele);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeleExists(modele.ModèleVéhicule))
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
            return View(modele);
        }

        // GET: Modeles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Modeles == null)
            {
                return NotFound();
            }

            var modele = await _context.Modeles
                .FirstOrDefaultAsync(m => m.ModèleVéhicule == id);
            if (modele == null)
            {
                return NotFound();
            }

            return View(modele);
        }

        // POST: Modeles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Modeles == null)
            {
                return Problem("Entity set 'ECF_AELContext.Modeles'  is null.");
            }
            var modele = await _context.Modeles.FindAsync(id);
            if (modele != null)
            {
                _context.Modeles.Remove(modele);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeleExists(string id)
        {
          return _context.Modeles.Any(e => e.ModèleVéhicule == id);
        }
    }
}
