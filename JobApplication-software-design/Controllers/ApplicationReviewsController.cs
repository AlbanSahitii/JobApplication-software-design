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
    public class ApplicationReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationReviews
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ApplicationReviews.Include(a => a.JobApplication).Include(a => a.Reviewer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ApplicationReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationReview = await _context.ApplicationReviews
                .Include(a => a.JobApplication)
                .Include(a => a.Reviewer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationReview == null)
            {
                return NotFound();
            }

            return View(applicationReview);
        }

        // GET: ApplicationReviews/Create
        public IActionResult Create()
        {
            ViewData["JobApplicationId"] = new SelectList(_context.JobApplications, "Id", "Id");
            ViewData["ReviewerId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: ApplicationReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JobApplicationId,ReviewerId,Feedback,Date")] ApplicationReview applicationReview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobApplicationId"] = new SelectList(_context.JobApplications, "Id", "Id", applicationReview.JobApplicationId);
            ViewData["ReviewerId"] = new SelectList(_context.Users, "Id", "Id", applicationReview.ReviewerId);
            return View(applicationReview);
        }

        // GET: ApplicationReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationReview = await _context.ApplicationReviews.FindAsync(id);
            if (applicationReview == null)
            {
                return NotFound();
            }
            ViewData["JobApplicationId"] = new SelectList(_context.JobApplications, "Id", "Id", applicationReview.JobApplicationId);
            ViewData["ReviewerId"] = new SelectList(_context.Users, "Id", "Id", applicationReview.ReviewerId);
            return View(applicationReview);
        }

        // POST: ApplicationReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JobApplicationId,ReviewerId,Feedback,Date")] ApplicationReview applicationReview)
        {
            if (id != applicationReview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationReviewExists(applicationReview.Id))
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
            ViewData["JobApplicationId"] = new SelectList(_context.JobApplications, "Id", "Id", applicationReview.JobApplicationId);
            ViewData["ReviewerId"] = new SelectList(_context.Users, "Id", "Id", applicationReview.ReviewerId);
            return View(applicationReview);
        }

        // GET: ApplicationReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationReview = await _context.ApplicationReviews
                .Include(a => a.JobApplication)
                .Include(a => a.Reviewer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationReview == null)
            {
                return NotFound();
            }

            return View(applicationReview);
        }

        // POST: ApplicationReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationReview = await _context.ApplicationReviews.FindAsync(id);
            if (applicationReview != null)
            {
                _context.ApplicationReviews.Remove(applicationReview);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationReviewExists(int id)
        {
            return _context.ApplicationReviews.Any(e => e.Id == id);
        }
    }
}
