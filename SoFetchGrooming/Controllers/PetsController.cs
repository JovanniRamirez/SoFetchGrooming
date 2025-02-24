using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoFetchGrooming.Data;
using SoFetchGrooming.Models;


namespace SoFetchGrooming.Controllers
{
    [Authorize] // Ensure that only authenticated users can access the PetsController
    public class PetsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public PetsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Pets
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var userPets = await _context.Pets
                .Where(p => p.UserId == userId)
                .Include(p => p.PetType)
                .ToListAsync();

            return View(userPets);
        }

        // GET: Pets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            var pet = await _context.Pets
                .Include(p => p.PetType)
                .FirstOrDefaultAsync(m => m.PetId == id && m.UserId == userId); // Ensure that the pet belongs to the current user

            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // GET: Pets/Create
        public IActionResult Create()
        {
            ViewData["PetTypeId"] = new SelectList(_context.PetTypes, "PetTypeId", "PetTypeName");
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PetName,PetTypeId,PetBreed,PetColor,PetWeight,PetAge,PetGender,PetVaccination,PetAllergies,PetSpecialNeeds,PetMedications")] Pet pet)
        {
            // Set the UserId of the pet to the current user's Id
            pet.UserId = _userManager.GetUserId(User);

            pet.PetType = await _context.PetTypes.FirstOrDefaultAsync(pt => pt.PetTypeId == pet.PetTypeId);

            if (ModelState.IsValid)
            {
                _context.Add(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PetTypeId"] = new SelectList(_context.PetTypes, "PetTypeId", "PetTypeName", pet.PetTypeId);
            return View(pet);
        }

        // GET: Pets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            var pet = await _context.Pets.FirstOrDefaultAsync(p => p.PetId == id && p.UserId == userId);
            if (pet == null)
            {
                return NotFound();
            }
            ViewData["PetTypeId"] = new SelectList(_context.PetTypes, "PetTypeId", "PetTypeName", pet.PetTypeId);
            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PetId,PetName,PetTypeId,PetBreed,PetColor,PetWeight,PetAge,PetGender,PetVaccination,PetAllergies,PetSpecialNeeds,PetMedications")] Pet pet)
        {
            if (id != pet.PetId)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            var existingPet = await _context.Pets.FirstOrDefaultAsync(p => p.PetId == id && p.UserId == userId);

            if (existingPet == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    existingPet.PetName = pet.PetName;
                    existingPet.PetTypeId = pet.PetTypeId;
                    existingPet.PetBreed = pet.PetBreed;
                    existingPet.PetColor = pet.PetColor;
                    existingPet.PetWeight = pet.PetWeight;
                    existingPet.PetAge = pet.PetAge;
                    existingPet.PetGender = pet.PetGender;
                    existingPet.PetVaccination = pet.PetVaccination;
                    existingPet.PetAllergies = pet.PetAllergies;
                    existingPet.PetSpecialNeeds = pet.PetSpecialNeeds;
                    existingPet.PetMedications = pet.PetMedications;

                    _context.Update(existingPet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetExists(pet.PetId))
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
            ViewData["PetTypeId"] = new SelectList(_context.PetTypes, "PetTypeId", "PetTypeName", pet.PetTypeId);
            return View(pet);
        }

        // GET: Pets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            var pet = await _context.Pets
                .Include(p => p.PetType)
                .FirstOrDefaultAsync(m => m.PetId == id && m.UserId == userId);

            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = _userManager.GetUserId(User);
            var pet = await _context.Pets.FirstOrDefaultAsync(p => p.PetId == id && p.UserId == userId);

            if (pet != null)
            {
                _context.Pets.Remove(pet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetExists(int id)
        {
            return _context.Pets.Any(e => e.PetId == id);
        }
    }
}
