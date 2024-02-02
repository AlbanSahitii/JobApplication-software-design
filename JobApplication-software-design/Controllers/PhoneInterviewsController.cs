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
    public class PhoneInterviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhoneInterviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PhoneInterviews
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PhoneInterview.Include(p => p.JobApplication).Include(p => p.Interview);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PhoneInterviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneInterview = await _context.PhoneInterview
                .Include(p => p.JobApplication)
                .Include(p => p.Interview)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phoneInterview == null)
            {
                return NotFound();
            }

            return View(phoneInterview);
        }

        // GET: PhoneInterviews/Create
        public IActionResult Create()
        {
            ViewData["JobApplicationId"] = new SelectList(_context.JobApplications, "Id", "Id");
            ViewData["InterviewId"] = new SelectList(_context.Interviews, "Id", "Id");
            return View();
        }

        // POST: PhoneInterviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DialInNumber,InterviewId,Id,JobApplicationId,Location,Notes,PhoneInterviewId,InPersonInterviewId")] PhoneInterview phoneInterview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phoneInterview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobApplicationId"] = new SelectList(_context.JobApplications, "Id", "Id", phoneInterview.JobApplicationId);
            ViewData["InterviewId"] = new SelectList(_context.Interviews, "Id", "Id", phoneInterview.InterviewId);
            return View(phoneInterview);
        }

        // GET: PhoneInterviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneInterview = await _context.PhoneInterview.FindAsync(id);
            if (phoneInterview == null)
            {
                return NotFound();
            }
            ViewData["JobApplicationId"] = new SelectList(_context.JobApplications, "Id", "Id", phoneInterview.JobApplicationId);
            ViewData["InterviewId"] = new SelectList(_context.Interviews, "Id", "Id", phoneInterview.InterviewId);
            return View(phoneInterview);
        }

        // POST: PhoneInterviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DialInNumber,InterviewId,Id,JobApplicationId,Location,Notes,PhoneInterviewId,InPersonInterviewId")] PhoneInterview phoneInterview)
        {
            if (id != phoneInterview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phoneInterview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneInterviewExists(phoneInterview.Id))
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
            ViewData["JobApplicationId"] = new SelectList(_context.JobApplications, "Id", "Id", phoneInterview.JobApplicationId);
            ViewData["InterviewId"] = new SelectList(_context.Interviews, "Id", "Id", phoneInterview.InterviewId);
            return View(phoneInterview);
        }

        // GET: PhoneInterviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneInterview = await _context.PhoneInterview
                .Include(p => p.JobApplication)
                .Include(p => p.Interview)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phoneInterview == null)
            {
                return NotFound();
            }

            return View(phoneInterview);
        }

        // POST: PhoneInterviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phoneInterview = await _context.PhoneInterview.FindAsync(id);
            if (phoneInterview != null)
            {
                _context.PhoneInterview.Remove(phoneInterview);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneInterviewExists(int id)
        {
            return _context.PhoneInterview.Any(e => e.Id == id);
        }
    }
}
