using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetPickupSolution.Data;
using PetPickupSolution.Models;

namespace PetPickupSolution.Controllers
{
    public class PetPickupModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PetPickupModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PetPickupModels
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.PetPickupModel.ToListAsync());
        }

        // GET: PetPickupModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petPickupModel = await _context.PetPickupModel
                .FirstOrDefaultAsync(m => m.PetID == id);
            if (petPickupModel == null)
            {
                return NotFound();
            }

            return View(petPickupModel);
        }

        // GET: PetPickupModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PetPickupModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PetID,PetMicroChipID,PetName,OwnerPhoneNumber")] PetPickupModel petPickupModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petPickupModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(petPickupModel);
        }

        // GET: PetPickupModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petPickupModel = await _context.PetPickupModel.FindAsync(id);
            if (petPickupModel == null)
            {
                return NotFound();
            }
            return View(petPickupModel);
        }

        // POST: PetPickupModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PetID,PetMicroChipID,PetName,OwnerPhoneNumber")] PetPickupModel petPickupModel)
        {
            if (id != petPickupModel.PetID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petPickupModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetPickupModelExists(petPickupModel.PetID))
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
            return View(petPickupModel);
        }

        // GET: PetPickupModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petPickupModel = await _context.PetPickupModel
                .FirstOrDefaultAsync(m => m.PetID == id);
            if (petPickupModel == null)
            {
                return NotFound();
            }

            return View(petPickupModel);
        }

        // POST: PetPickupModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petPickupModel = await _context.PetPickupModel.FindAsync(id);
            _context.PetPickupModel.Remove(petPickupModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetPickupModelExists(int id)
        {
            return _context.PetPickupModel.Any(e => e.PetID == id);
        }
    }
}
