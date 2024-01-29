using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using JobApplication_software_design.Models;
using JobApplication_software_design.Data;

namespace JobApplication_software_design.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;
        public UserController(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        public IActionResult Upload()
        {
            return Redirect("https://localhost:7072/Identity/Account/Manage/Picture");
        }

        public IActionResult Add()
        {
            return Redirect("https://localhost:7072/Identity/Account/Register");
        }
    }
}
