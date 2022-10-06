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
    public class VehiculesController : Controller
    {
        private readonly ECF_AELContext _context;

        public VehiculesController(ECF_AELContext context)
        {
            _context = context;
        }

        // GET: Vehicules
        public async Task<IActionResult> Index()
        {
            var eCF_AELContext = _context.Vehicules.Include(v => v.ModèleVéhiculeNavigation);
            return View(await eCF_AELContext.ToListAsync());
        }

        // GET: Vehicules/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Vehicules == null)
            {
                return NotFound();
            }

            var vehicule = await _context.Vehicules
                .Include(v => v.ModèleVéhiculeNavigation)
                .FirstOrDefaultAsync(m => m.NImmatriculation == id);
            if (vehicule == null)
            {
                return NotFound();
            }

            return View(vehicule);
        }

        // GET: Vehicules/Create
        public IActionResult Create()
        {
            ViewData["ModèleVéhicule"] = new SelectList(_context.Modeles, "ModèleVéhicule", "ModèleVéhicule");
            return View();
        }

        // POST: Vehicules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NImmatriculation,ModèleVéhicule,État")] Vehicule vehicule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModèleVéhicule"] = new SelectList(_context.Modeles, "ModèleVéhicule", "ModèleVéhicule", vehicule.ModèleVéhicule);
            return View(vehicule);
        }

        // GET: Vehicules/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Vehicules == null)
            {
                return NotFound();
            }

            var vehicule = await _context.Vehicules.FindAsync(id);
            if (vehicule == null)
            {
                return NotFound();
            }
            ViewData["ModèleVéhicule"] = new SelectList(_context.Modeles, "ModèleVéhicule", "ModèleVéhicule", vehicule.ModèleVéhicule);
            return View(vehicule);
        }

        // POST: Vehicules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NImmatriculation,ModèleVéhicule,État")] Vehicule vehicule)
        {
            if (id != vehicule.NImmatriculation)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculeExists(vehicule.NImmatriculation))
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
            ViewData["ModèleVéhicule"] = new SelectList(_context.Modeles, "ModèleVéhicule", "ModèleVéhicule", vehicule.ModèleVéhicule);
            return View(vehicule);
        }

        // GET: Vehicules/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Vehicules == null)
            {
                return NotFound();
            }

            var vehicule = await _context.Vehicules
                .Include(v => v.ModèleVéhiculeNavigation)
                .FirstOrDefaultAsync(m => m.NImmatriculation == id);
            if (vehicule == null)
            {
                return NotFound();
            }

            return View(vehicule);
        }

        // POST: Vehicules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Vehicules == null)
            {
                return Problem("Entity set 'ECF_AELContext.Vehicules'  is null.");
            }
            var vehicule = await _context.Vehicules.FindAsync(id);
            if (vehicule != null)
            {
                _context.Vehicules.Remove(vehicule);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculeExists(string id)
        {
          return _context.Vehicules.Any(e => e.NImmatriculation == id);
        }
    }
}
