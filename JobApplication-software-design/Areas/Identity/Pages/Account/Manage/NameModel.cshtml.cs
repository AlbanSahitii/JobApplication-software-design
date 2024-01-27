using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using JobApplication_software_design.Models;
using System.Threading.Tasks;

namespace JobApplication_software_design.Areas.Identity.Pages.Account.Manage
{
    public class NameModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public NameModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            FirstName = user.FirstName ?? ""; // Handle NULL by providing a default value
            LastName = user.LastName ?? "";   // Handle NULL by providing a default value

            return Page();
        }
        public async Task<IActionResult> OnPostUpdateNameAsync()
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

            // Update FirstName and LastName in the database, handle NULL values
            user.FirstName = FirstName ?? ""; // Provide a default value
            user.LastName = LastName ?? "";   // Provide a default value
            await _userManager.UpdateAsync(user);

            StatusMessage = "Name updated successfully.";
            return RedirectToPage();
        }
    }
}
