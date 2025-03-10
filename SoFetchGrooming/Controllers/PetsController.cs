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
    [Authorize(Roles = "CustomerUser")] // Ensure that only authenticated users can access the PetsController
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
        public async Task<IActionResult> Create(PetViewModel petVM)
        {
            if (ModelState.IsValid)
            {
                var pet = new Pet
                {
                    UserId = _userManager.GetUserId(User),
                    PetName = petVM.PetName,
                    PetTypeId = petVM.PetTypeId,
                    PetBreed = petVM.PetBreed,
                    PetColor = petVM.PetColor,
                    PetWeight = petVM.PetWeight,
                    PetAge = petVM.PetAge,
                    PetGender = petVM.PetGender,
                    PetVaccination = petVM.PetVaccination,
                    PetAllergies = petVM.PetAllergies,
                    PetSpecialNeeds = petVM.PetSpecialNeeds,
                    PetMedications = petVM.PetMedications
                };

                _context.Add(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(petVM);
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

            var petVM = new PetViewModel
            {
                PetId = pet.PetId,
                PetName = pet.PetName,
                PetTypeId = pet.PetTypeId,
                PetBreed = pet.PetBreed,
                PetColor = pet.PetColor,
                PetWeight = pet.PetWeight,
                PetAge = pet.PetAge,
                PetGender = pet.PetGender,
                PetVaccination = pet.PetVaccination,
                PetAllergies = pet.PetAllergies,
                PetSpecialNeeds = pet.PetSpecialNeeds,
                PetMedications = pet.PetMedications
            };

            ViewData["PetTypeId"] = new SelectList(_context.PetTypes, "PetTypeId", "PetTypeName", pet.PetTypeId);
            return View(petVM);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PetViewModel petVM)
        {
            if (id != petVM.PetId)
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
                    existingPet.PetName = petVM.PetName;
                    existingPet.PetTypeId = petVM.PetTypeId;
                    existingPet.PetBreed = petVM.PetBreed;
                    existingPet.PetColor = petVM.PetColor;
                    existingPet.PetWeight = petVM.PetWeight;
                    existingPet.PetAge = petVM.PetAge;
                    existingPet.PetGender = petVM.PetGender;
                    existingPet.PetVaccination = petVM.PetVaccination;
                    existingPet.PetAllergies = petVM.PetAllergies;
                    existingPet.PetSpecialNeeds = petVM.PetSpecialNeeds;
                    existingPet.PetMedications = petVM.PetMedications;

                    _context.Update(existingPet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetExists(id))
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
            ViewData["PetTypeId"] = new SelectList(_context.PetTypes, "PetTypeId", "PetTypeName", petVM.PetTypeId);
            return View(petVM);
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
