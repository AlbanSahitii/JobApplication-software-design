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
    public class CoverLettersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoverLettersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CoverLetters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CoverLetters.Include(c => c.JobApplication);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CoverLetters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coverLetter = await _context.CoverLetters
                .Include(c => c.JobApplication)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coverLetter == null)
            {
                return NotFound();
            }

            return View(coverLetter);
        }

        // GET: CoverLetters/Create
        public IActionResult Create()
        {
            ViewData["JobApplicationId"] = new SelectList(_context.JobApplications, "Id", "Id");
            return View();
        }

        // POST: CoverLetters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JobApplicationId,Content,LastUpdated,Title")] CoverLetter coverLetter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coverLetter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobApplicationId"] = new SelectList(_context.JobApplications, "Id", "Id", coverLetter.JobApplicationId);
            return View(coverLetter);
        }

        // GET: CoverLetters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coverLetter = await _context.CoverLetters.FindAsync(id);
            if (coverLetter == null)
            {
                return NotFound();
            }
            ViewData["JobApplicationId"] = new SelectList(_context.JobApplications, "Id", "Id", coverLetter.JobApplicationId);
            return View(coverLetter);
        }

        // POST: CoverLetters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JobApplicationId,Content,LastUpdated,Title")] CoverLetter coverLetter)
        {
            if (id != coverLetter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coverLetter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoverLetterExists(coverLetter.Id))
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
            ViewData["JobApplicationId"] = new SelectList(_context.JobApplications, "Id", "Id", coverLetter.JobApplicationId);
            return View(coverLetter);
        }

        // GET: CoverLetters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coverLetter = await _context.CoverLetters
                .Include(c => c.JobApplication)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coverLetter == null)
            {
                return NotFound();
            }

            return View(coverLetter);
        }

        // POST: CoverLetters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coverLetter = await _context.CoverLetters.FindAsync(id);
            if (coverLetter != null)
            {
                _context.CoverLetters.Remove(coverLetter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoverLetterExists(int id)
        {
            return _context.CoverLetters.Any(e => e.Id == id);
        }
    }
}
