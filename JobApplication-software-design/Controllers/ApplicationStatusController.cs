using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobApplication_software_design.Data;
using JobApplication_software_design.Models;

namespace JobApplication_software_design.Controllers
{
    public class ApplicationStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationStatus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ApplicationStatuses.Include(a => a.JobApplication);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ApplicationStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationStatus = await _context.ApplicationStatuses
                .Include(a => a.JobApplication)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationStatus == null)
            {
                return NotFound();
            }

            return View(applicationStatus);
        }

        // GET: ApplicationStatus/Create
        public IActionResult Create()
        {
            ViewData["JobApplicationId"] = new SelectList(_context.JobApplications, "Id", "Id");
            return View();
        }

        // POST: ApplicationStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,JobApplicationId")] ApplicationStatus applicationStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobApplicationId"] = new SelectList(_context.JobApplications, "Id", "Id", applicationStatus.JobApplicationId);
            return View(applicationStatus);
        }

        // GET: ApplicationStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationStatus = await _context.ApplicationStatuses.FindAsync(id);
            if (applicationStatus == null)
            {
                return NotFound();
            }
            ViewData["JobApplicationId"] = new SelectList(_context.JobApplications, "Id", "Id", applicationStatus.JobApplicationId);
            return View(applicationStatus);
        }

        // POST: ApplicationStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,JobApplicationId")] ApplicationStatus applicationStatus)
        {
            if (id != applicationStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationStatusExists(applicationStatus.Id))
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
            ViewData["JobApplicationId"] = new SelectList(_context.JobApplications, "Id", "Id", applicationStatus.JobApplicationId);
            return View(applicationStatus);
        }

        // GET: ApplicationStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationStatus = await _context.ApplicationStatuses
                .Include(a => a.JobApplication)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationStatus == null)
            {
                return NotFound();
            }

            return View(applicationStatus);
        }

        // POST: ApplicationStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationStatus = await _context.ApplicationStatuses.FindAsync(id);
            if (applicationStatus != null)
            {
                _context.ApplicationStatuses.Remove(applicationStatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationStatusExists(int id)
        {
            return _context.ApplicationStatuses.Any(e => e.Id == id);
        }
    }
}
