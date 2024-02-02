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
    public class InPersonInterviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InPersonInterviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InPersonInterviews
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.InPersonInterview.Include(i => i.JobApplication).Include(i => i.Interview);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: InPersonInterviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inPersonInterview = await _context.InPersonInterview
                .Include(i => i.JobApplication)
                .Include(i => i.Interview)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inPersonInterview == null)
            {
                return NotFound();
            }

            return View(inPersonInterview);
        }

        // GET: InPersonInterviews/Create
        public IActionResult Create()
        {
            ViewData["JobApplicationId"] = new SelectList(_context.JobApplications, "Id", "Id");
            ViewData["InterviewId"] = new SelectList(_context.Interviews, "Id", "Id");
            return View();
        }

        // POST: InPersonInterviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Location,InterviewId,Id,JobApplicationId,Notes,PhoneInterviewId,InPersonInterviewId")] InPersonInterview inPersonInterview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inPersonInterview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobApplicationId"] = new SelectList(_context.JobApplications, "Id", "Id", inPersonInterview.JobApplicationId);
            ViewData["InterviewId"] = new SelectList(_context.Interviews, "Id", "Id", inPersonInterview.InterviewId);
            return View(inPersonInterview);
        }

        // GET: InPersonInterviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inPersonInterview = await _context.InPersonInterview.FindAsync(id);
            if (inPersonInterview == null)
            {
                return NotFound();
            }
            ViewData["JobApplicationId"] = new SelectList(_context.JobApplications, "Id", "Id", inPersonInterview.JobApplicationId);
            ViewData["InterviewId"] = new SelectList(_context.Interviews, "Id", "Id", inPersonInterview.InterviewId);
            return View(inPersonInterview);
        }

        // POST: InPersonInterviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Location,InterviewId,Id,JobApplicationId,Notes,PhoneInterviewId,InPersonInterviewId")] InPersonInterview inPersonInterview)
        {
            if (id != inPersonInterview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inPersonInterview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InPersonInterviewExists(inPersonInterview.Id))
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
            ViewData["JobApplicationId"] = new SelectList(_context.JobApplications, "Id", "Id", inPersonInterview.JobApplicationId);
            ViewData["InterviewId"] = new SelectList(_context.Interviews, "Id", "Id", inPersonInterview.InterviewId);
            return View(inPersonInterview);
        }

        // GET: InPersonInterviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inPersonInterview = await _context.InPersonInterview
                .Include(i => i.JobApplication)
                .Include(i => i.Interview)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inPersonInterview == null)
            {
                return NotFound();
            }

            return View(inPersonInterview);
        }

        // POST: InPersonInterviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inPersonInterview = await _context.InPersonInterview.FindAsync(id);
            if (inPersonInterview != null)
            {
                _context.InPersonInterview.Remove(inPersonInterview);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InPersonInterviewExists(int id)
        {
            return _context.InPersonInterview.Any(e => e.Id == id);
        }
    }
}
