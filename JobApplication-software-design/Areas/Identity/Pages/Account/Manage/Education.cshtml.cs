using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using JobApplication_software_design.Models;
using System.Threading.Tasks;

namespace JobApplication_software_design.Areas.Identity.Pages.Account.Manage
{
    public interface IEducationObserver
    {
        Task EducationUpdated(string newEducation);
    }

    public class EducationObserver : IEducationObserver
    {
        private readonly UserManager<User> _userManager;

        public EducationObserver(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task EducationUpdated(string newEducation)
        {
            var user = await _userManager.GetUserAsync(null);
            if (user != null)
            {
                user.Education = newEducation;
                await _userManager.UpdateAsync(user);
            }
        }
    }

    public interface IEducationModelSubject
    {
        void Attach(IEducationObserver observer);
        void Detach(IEducationObserver observer);
        Task NotifyEducationUpdated();
    }

    public class EducationModel : PageModel, IEducationModelSubject
    {
        private readonly UserManager<User> _userManager;

        public EducationModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public string Education { get; set; }

        private readonly List<IEducationObserver> _observers = new List<IEducationObserver>();

        public void Attach(IEducationObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IEducationObserver observer)
        {
            _observers.Remove(observer);
        }

        public async Task NotifyEducationUpdated()
        {
            foreach (var observer in _observers)
            {
                await observer.EducationUpdated(Education);
            }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Education = user.Education;

            return Page();
        }

        public async Task<IActionResult> OnPostUpdateEducationAsync()
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

            user.Education = Education;
            await _userManager.UpdateAsync(user);

            await NotifyEducationUpdated();

            StatusMessage = "Education updated successfully.";
            return RedirectToPage();
        }
    }
}
