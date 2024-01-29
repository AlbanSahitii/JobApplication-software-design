using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using JobApplication_software_design.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace JobApplication_software_design.Areas.Identity.Pages.Account.Manage
{
    public interface IPictureObserver
    {
        Task PictureUpdated(string newPicture);
    }

    public class PictureObserver : IPictureObserver
    {
        private readonly UserManager<User> _userManager;
        public readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        public PictureObserver(UserManager<User> userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _userManager = userManager;
            _environment = environment;
        }

        public async Task PictureUpdated(string newPicture)
        {
            var user = await _userManager.GetUserAsync(null);
            if (user != null)
            {
                user.Picture = newPicture;
                await _userManager.UpdateAsync(user);
            }
        }
    }

    public interface IPictureModelSubject
    {
        void Attach(IPictureObserver observer);
        void Detach(IPictureObserver observer);
        Task NotifyPictureUpdated();
    }

    public class PictureModel : PageModel, IPictureModelSubject
    {
        private readonly UserManager<User> _userManager;
        public readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

        public PictureModel(UserManager<User> userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _userManager = userManager;
            _environment = environment;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public string Picture { get; set; }
        public IFormFile PicturePath { get; set; }

        private readonly List<IPictureObserver> _observers = new List<IPictureObserver>();

        public void Attach(IPictureObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IPictureObserver observer)
        {
            _observers.Remove(observer);
        }

        public async Task NotifyPictureUpdated()
        {
            foreach (var observer in _observers)
            {
                await observer.PictureUpdated(Picture);
            }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Picture = user.Picture;

            return Page();
        }

        public async Task<IActionResult> OnPostUpdatePictureAsync()
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
            var path = _environment.WebRootPath;
            var filePath = "img/" + PicturePath.FileName;
            var fullPath = Path.Combine(path, filePath);
            FileStream stream = new FileStream(fullPath, FileMode.Create);
            PicturePath.CopyTo(stream);

            user.Picture = filePath;
            await _userManager.UpdateAsync(user);

            await NotifyPictureUpdated();

            StatusMessage = "Picture updated successfully.";
            return RedirectToPage();
        }
    }
}
