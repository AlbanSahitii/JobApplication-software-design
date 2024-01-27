using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using JobApplication_software_design.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplication_software_design.Areas.Identity.Pages.Account.Manage
{
    public interface ISkillsObserver
    {
        Task SkillsUpdated(string newSkills);
    }

    public class SkillsObserver : ISkillsObserver
    {
        private readonly UserManager<User> _userManager;

        public SkillsObserver(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task SkillsUpdated(string newSkills)
        {
            var user = await _userManager.GetUserAsync(null);
            if (user != null)
            {
                user.Skills = newSkills;
                await _userManager.UpdateAsync(user);
            }
        }
    }
    public interface ISkillsModelSubject
    {
        void Attach(ISkillsObserver observer);
        void Detach(ISkillsObserver observer);
        Task NotifySkillsUpdated();
    }

    public class SkillsModel : PageModel, ISkillsModelSubject
    {
        private readonly UserManager<User> _userManager;

        public SkillsModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public string Skills { get; set; }

        private readonly List<ISkillsObserver> _observers = new List<ISkillsObserver>();

        public void Attach(ISkillsObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(ISkillsObserver observer)
        {
            _observers.Remove(observer);
        }

        public async Task NotifySkillsUpdated()
        {
            foreach (var observer in _observers)
            {
                await observer.SkillsUpdated(Skills);
            }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Skills = user.Skills;

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
            user.Skills = Skills;
            await _userManager.UpdateAsync(user);

            await NotifySkillsUpdated();

            StatusMessage = "Skills updated successfully.";
            return RedirectToPage();
        }
    }
}
