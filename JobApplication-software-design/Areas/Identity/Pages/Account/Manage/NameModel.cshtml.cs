using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using JobApplication_software_design.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace JobApplication_software_design.Areas.Identity.Pages.Account.Manage
{
    public interface INameUpdatedObserver
    {
        void OnNameUpdated(string firstName, string lastName);
    }

    public class NameUpdatedObserver : INameUpdatedObserver
    {
        private readonly UserManager<User> _userManager;

        public NameUpdatedObserver(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public void OnNameUpdated(string firstName, string lastName)
        {
            var user = _userManager.GetUserAsync(null).Result;
            if (user != null)
            {
                user.FirstName = firstName ?? "";
                user.LastName = lastName ?? "";
                _userManager.UpdateAsync(user).Wait();
            }
        }
    }

    public interface INameModelSubject
    {
        void Attach(INameUpdatedObserver observer);
        void Detach(INameUpdatedObserver observer);
        Task NotifyNameUpdated();
    }

    public class NameModel : PageModel, INameModelSubject
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

        private readonly List<INameUpdatedObserver> _observers = new List<INameUpdatedObserver>();

        public void Attach(INameUpdatedObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(INameUpdatedObserver observer)
        {
            _observers.Remove(observer);
        }

        public async Task NotifyNameUpdated()
        {
            foreach (var observer in _observers)
            {
                observer.OnNameUpdated(FirstName, LastName);
            }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            FirstName = user.FirstName ?? "";
            LastName = user.LastName ?? "";

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

            user.FirstName = FirstName ?? "";
            user.LastName = LastName ?? "";
            await _userManager.UpdateAsync(user);

            await NotifyNameUpdated();

            StatusMessage = "Name updated successfully.";
            return RedirectToPage();
        }
    }
}
