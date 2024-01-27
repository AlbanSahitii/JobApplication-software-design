using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using JobApplication_software_design.Models;
using System.Threading.Tasks;

namespace JobApplication_software_design.Areas.Identity.Pages.Account.Manage
{
    public interface IAddressObserver
    {
        Task AddressUpdated(string newAddress);
    }

    public class AddressObserver : IAddressObserver
    {
        private readonly UserManager<User> _userManager;

        public AddressObserver(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task AddressUpdated(string newAddress)
        {
            var user = await _userManager.GetUserAsync(null);
            if (user != null)
            {
                user.Address = newAddress;
                await _userManager.UpdateAsync(user);
            }
        }
    }

    public interface IAddressModelSubject
    {
        void Attach(IAddressObserver observer);
        void Detach(IAddressObserver observer);
        Task NotifyAddressUpdated();
    }

    public class AddressModel : PageModel, IAddressModelSubject
    {
        private readonly UserManager<User> _userManager;

        public AddressModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public string Address { get; set; }

        private readonly List<IAddressObserver> _observers = new List<IAddressObserver>();

        public void Attach(IAddressObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IAddressObserver observer)
        {
            _observers.Remove(observer);
        }

        public async Task NotifyAddressUpdated()
        {
            foreach (var observer in _observers)
            {
                await observer.AddressUpdated(Address);
            }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Address = user.Address;

            return Page();
        }

        public async Task<IActionResult> OnPostUpdateAddressAsync()
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

            user.Address = Address;
            await _userManager.UpdateAsync(user);

            await NotifyAddressUpdated();

            StatusMessage = "Address updated successfully.";
            return RedirectToPage();
        }
    }
}
