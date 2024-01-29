using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using JobApplication_software_design.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace JobApplication_software_design.Controllers
{
    [Authorize]
    public class ProfileController : Controller, IProfileSubject
    {
        private readonly UserManager<User> _userManager;

        public ProfileController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        // Implementation of the Observer pattern
        private readonly List<IProfileUpdatedObserver> _observers = new List<IProfileUpdatedObserver>();

        public void Attach(IProfileUpdatedObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IProfileUpdatedObserver observer)
        {
            _observers.Remove(observer);
        }

        public async Task NotifyProfileUpdated(User updatedUser)
        {
            foreach (var observer in _observers)
            {
                observer.OnProfileUpdated(updatedUser);
            }
        }

        // Action method to display the user profile
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // Action method to update the user profile
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(User updatedUser)
        {
            // Update the user profile
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            // Update other profile properties as needed

            await _userManager.UpdateAsync(user);

            // Notify observers about the profile update
            await NotifyProfileUpdated(user);

            return RedirectToAction(nameof(Profile));
        }
    }

    // Observer pattern interfaces
    public interface IProfileUpdatedObserver
    {
        void OnProfileUpdated(User updatedUser);
    }

    public interface IProfileSubject
    {
        void Attach(IProfileUpdatedObserver observer);
        void Detach(IProfileUpdatedObserver observer);
        Task NotifyProfileUpdated(User updatedUser);
    }
}
