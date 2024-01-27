using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobApplication_software_design.Data; // Adjust the namespace as per your project structure
using System.Threading.Tasks;
using JobApplication_software_design.Models;
using Microsoft.AspNetCore.Identity;

namespace JobApplication_software_design.Areas.Identity.Pages.Account.Manage
{
    public class SkillsModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public SkillsModel(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public string Skills { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Skills = user.Skills; // Assuming you have a Skills property in your User model

            return Page();
        }

        public async Task<IActionResult> OnPostUpdateSkillsAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Update Skills in the database
            user.Skills = Skills;
            await _userManager.UpdateAsync(user);

            // You can also update the Skills directly in the database if necessary
            // var userFromDb = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            // userFromDb.Skills = Skills;
            // await _context.SaveChangesAsync();

            StatusMessage = "Skills updated successfully.";
            return RedirectToPage();
        }
    }
}
