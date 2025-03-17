using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoFetchGrooming.Data;
using SoFetchGrooming.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SoFetchGrooming.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AppointmentsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            // var applicationDbContext = _context.Appointment.Include(a => a.User);
            // return View(await applicationDbContext.ToListAsync());
            return View();
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        [Authorize] // Only allow authenticated users to create appointments
        public async Task<IActionResult> Create()
        {
            var userId = _userManager.GetUserId(User);

            var userPets = await _context.Pets
                .Where(p => p.UserId == userId)
                .Select(p => new { p.PetId, p.PetName })
                .ToListAsync();

            if (!userPets.Any())
            {
                TempData["ErrorMessage"] = "You must have a pet to create an appointment.";
                return RedirectToAction("Create", "Pets");
            }

            var serviceTypes = await _context.ServiceTypes
                .Select(st => new { st.ServiceTypeId, st.ServiceName })
                .ToListAsync();

            var tomorrow = DateTime.Today.AddDays(1); // Default to tomorrow for the appointment date
            
            if (tomorrow.DayOfWeek == DayOfWeek.Sunday) // If it's Sunday, set to Monday
            {
                tomorrow = tomorrow.AddDays(1);
        }

            var appointmentVM = new AppointmentViewModel
            {
                PetId = 0, // Default to the first pet
                ServiceTypeId = 0, // Default to the first service type
                AppointmentDate = tomorrow, // Default to today
                AppointmentTime = TimeSpan.FromHours(9), // Default to 9 AM
            };

            // Populate the dropdowns for pets and service types
            ViewData["PetId"] = new SelectList(_context.Pets, "PetId", "PetName", appointmentVM.PetId);
            ViewData["ServiceTypeId"] = new SelectList(serviceTypes, "ServiceTypeId", "ServiceName", appointmentVM.ServiceTypeId);

            return View(appointmentVM);
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize] 
        public async Task<IActionResult> Create([Bind("AppointmentId,UserId,PetId,ServiceTypeId,AppointmentDate,AppointmentTime")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "UserId", "UserEmail", appointment.UserId);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "UserId", "UserEmail", appointment.UserId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId, UserId, PetId, ServiceTypeId, AppointmentDate, AppointmentTime")] Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.AppointmentId))
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
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "UserId", "UserEmail", appointment.UserId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointment.Remove(appointment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.AppointmentId == id);
        }
    }
}
